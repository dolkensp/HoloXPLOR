using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public abstract class DataForgeSerializable
    {
        [JsonIgnore]
        public DataForge DocumentRoot { get; private set; }
        [JsonIgnore]
        internal BinaryReader _br;
        [JsonIgnore]
        internal Int64 _offset;

        [JsonIgnore]
        internal Int64 _index;

        [JsonProperty("Offset")]
        public String __offset { get { return String.Format("{0:X8}", this._offset); } }

        [JsonProperty("Index")]
        public String __index { get { return String.Format("{0:X8}", this._index); } }

        public DataForgeSerializable(DataForge documentRoot)
        {
            this.DocumentRoot = documentRoot;
            this._br = documentRoot._br;
            this._offset = this._br.BaseStream.Position;
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
                // TODO: Check if this logic is correct - do we need to preprocess ALL arrays and pass an array size?
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
                    let data = (U)Activator.CreateInstance(typeof(U), this.DocumentRoot)
                    let hack = data._index = i
                    select data).ToArray();
        }
    }
}
