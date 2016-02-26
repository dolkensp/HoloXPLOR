using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public abstract class DataForgeSerializable
    {
        private BinaryReader _br;
        private Int64 _offset;
        private Int64[] _signature;

        public DataForgeSerializable(BinaryReader br)
        {
            this._br = br;
            this._offset = this._br.BaseStream.Position;
            this._signature = this._signature ?? new Int64[] { this._br.BaseStream.Length, 0x04 };
        }

        public void Deserialize()
        {
            var i = 1;
            while (this._br.BaseStream.Position < this._signature[0] && this._br.BaseStream.Position < this._br.BaseStream.Length)
            {
                if (i >= this._signature.Length) i = 1;

                var width = this._signature[i];
                var isNull = false;
                var format = "";
                Object data = null;

                if ((width & 0x20) == 0x20)
                {
                    isNull = _br.ReadInt32() == -1;
                }

                switch (width)
                {
                    case 0x00:
                        format = "| ";
                        data = "";
                        break;
                    case 0x80:
                        format = @"""{0}"" ";
                        data = (_br.ReadCString() ?? String.Empty).Replace("\r", "\\r").Replace("\n", "\\n");
                        break;
                    case 0x81:
                    case 0x01:
                        format = "0x{0:X2} ";
                        data = _br.ReadByte();
                        break;
                    case 0x82:
                    case 0x02:
                        format = "0x{0:X4} ";
                        data = _br.ReadInt16();
                        break;
                    case 0x03:
                        format = "#{0} ";
                        data = String.Format("{0:X2}{1:X2}{2:X2}", _br.ReadByte(), _br.ReadByte(), _br.ReadByte());
                        break;
                    case 0x84:
                    case 0x04:
                        format = "0x{0:X8} ";
                        data = _br.ReadInt32();
                        break;
                    case 0x44:
                        format = "{0} ";
                        data = _br.ReadSingle();
                        break;
                    case 0x88:
                    case 0x08:
                        format = "0x{0:X16} ";
                        data = _br.ReadInt64();
                        break;
                    case 0x48:
                        format = "{0} ";
                        data = _br.ReadDouble();
                        break;
                    case 0x26:
                    case 0x16:
                        format = "{0} ";
                        var p3 = _br.ReadInt16();
                        var p2 = _br.ReadInt16();
                        var p1 = _br.ReadInt32();
                        var p4 = _br.ReadByte();
                        var p5 = _br.ReadByte();
                        var p6 = _br.ReadByte();
                        var p7 = _br.ReadByte();
                        var p8 = _br.ReadByte();
                        var p9 = _br.ReadByte();
                        var p10 = _br.ReadByte();
                        var p11 = _br.ReadByte();
                        data = new Guid(p1, p2, p3, p11, p10, p9, p8, p7, p6, p5, p4);
                        break;
                }

                if (isNull)
                {
                    data = null;
                }

                if ((width & 0x80) == 0x80 && (width != 0x80))
                {
                    var stringOffset = (data as Int64? ?? data as Int32? ?? data as Int16? ?? -1);

                    if (stringOffset <= 0x00066E19 &&
                        stringOffset >= 0x00000000)
                    {
                        var oldPos = _br.BaseStream.Position;
                        _br.BaseStream.Seek(stringOffset + 0x0002F1DC, SeekOrigin.Begin);
                        Console.Write(@"[{0}] ", (_br.ReadCString() ?? String.Empty).Replace("\r", "\\r").Replace("\n", "\\n"));
                        _br.BaseStream.Seek(oldPos, SeekOrigin.Begin);
                    }
                    else if (stringOffset == -1)
                    {
                        Console.Write("[__NULL__] ");
                    }
                    else
                    {
                        Console.Write("[__{0:X8}__] ", data);
                    }
                }
                else
                {
                    Console.Write(format, data ?? "NULL");
                }
            }
        }

        public String ReadString()
        {
            var stringOffset = this._br.ReadUInt32();

            var oldPos = this._br.BaseStream.Position;

            this._br.BaseStream.Seek(0x0002F1DC + stringOffset, SeekOrigin.Begin);

            String buffer = this._br.ReadCString();

            this._br.BaseStream.Seek(oldPos, SeekOrigin.Begin);

            return buffer;
        }

        public Guid? ReadGuid(Boolean nullable = true)
        {
            var isNull = nullable && this._br.ReadInt32() == -1;

            var c = this._br.ReadInt16();
            var b = this._br.ReadInt16();
            var a = this._br.ReadInt32();
            var k = this._br.ReadByte();
            var j = this._br.ReadByte();
            var i = this._br.ReadByte();
            var h = this._br.ReadByte();
            var g = this._br.ReadByte();
            var f = this._br.ReadByte();
            var e = this._br.ReadByte();
            var d = this._br.ReadByte();

            if (isNull) return null;

            return new Guid(a, b, c, d, e, f, g, h, i, j, k);
        }

        public U[] ReadArray<U>(UInt32? arraySize = null) where U : DataForgeSerializable
        {
            if (!arraySize.HasValue)
            {
                arraySize = this._br.ReadUInt32();
            
                if (arraySize == 0xFFFFFFFF)
                {
                    return null;
                } 
            }
            
            if (arraySize == 0xFFFFFFFF)
            {
                return null;
            }

            return (from i in Enumerable.Range(0, (Int32)arraySize.Value)
                    select (U)Activator.CreateInstance(typeof(U), this._br)).ToArray();
        }
    }
}
