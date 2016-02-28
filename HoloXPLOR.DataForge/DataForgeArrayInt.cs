using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeArrayInt8 : DataForgeSerializable
    {
        public SByte Value { get; set; }

        public DataForgeArrayInt8(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadSByte();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayInt16 : DataForgeSerializable
    {
        public Int16 Value { get; set; }

        public DataForgeArrayInt16(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadInt16();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayInt32 : DataForgeSerializable
    {
        public Int32 Value { get; set; }

        public DataForgeArrayInt32(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadInt32();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayInt64 : DataForgeSerializable
    {
        public Int64 Value { get; set; }

        public DataForgeArrayInt64(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadInt64();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayBoolean : DataForgeSerializable
    {
        public Boolean Value { get; set; }

        public DataForgeArrayBoolean(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadBoolean();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value ? "1" : "0");
        }
    }

    public class DataForgeArrayUInt8 : DataForgeSerializable
    {
        public Byte Value { get; set; }

        public DataForgeArrayUInt8(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadByte();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayUInt16 : DataForgeSerializable
    {
        public UInt16 Value { get; set; }

        public DataForgeArrayUInt16(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadUInt16();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayUInt32 : DataForgeSerializable
    {
        public UInt32 Value { get; set; }

        public DataForgeArrayUInt32(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayUInt64 : DataForgeSerializable
    {
        public UInt64 Value { get; set; }

        public DataForgeArrayUInt64(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadUInt64();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArraySingle : DataForgeSerializable
    {
        public Single Value { get; set; }

        public DataForgeArraySingle(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadSingle();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }

    public class DataForgeArrayDouble : DataForgeSerializable
    {
        public Double Value { get; set; }

        public DataForgeArrayDouble(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadDouble();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }
    }
}
