using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public abstract class _DataForgeSerializable
    {
        public DataForge DocumentRoot { get; private set; }

        internal BinaryReader _br;
        
        public String __offset { get { return String.Format("{0:X8}", this._offset); } }
        public Int64 _offset;

        public String __index { get { return String.Format("{0:X8}", this._index); } }
        public Int32 _index;

        public _DataForgeSerializable(DataForge documentRoot)
        {
            this.DocumentRoot = documentRoot;
            this._br = documentRoot._br;
            this._offset = this._br.BaseStream.Position;
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
    }
}
