using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeStringLookup : DataForgeSerializable
    {
        private UInt32 _value;
        public String Value { get { return this.DocumentRoot.ValueMap[this._value]; } }

        public DataForgeStringLookup(DataForge documentRoot)
            : base(documentRoot)
        {
            this._value = this._br.ReadUInt32();
        }

        public override String ToString()
        {
            return this.Value;
        }
    }

    public class DataForgeString : DataForgeSerializable
    {
        public String Value { get; set; }

        public DataForgeString(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadCString();
        }

        public override String ToString()
        {
            return this.Value;
        }
    }

    public abstract class DataForgeByteRecord : DataForgeSerializable
    {
        public List<Byte> Items { get; set; }
        public abstract Int32 Width { get; }

        public DataForgeByteRecord(DataForge documentRoot, Int32? width = null)
            : base(documentRoot)
        {
            this.Items = this.Items ?? new List<Byte> { };

            for (Int32 i = 0; i < (width ?? this.Width); i++)
            {
                this.Items.Add(this._br.ReadByte());
            }
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            Int32 i = 0;
            foreach (Byte b in this.Items)
            {
                if ((i++ % 4) == 0)
                    sb.Append(" 0x");

                sb.AppendFormat("{0:X2}", b);
            }

            return sb.ToString();
        }
    }

    public class DataForgeRecord6 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 6; } } // Locked
        public DataForgeRecord6(DataForge documentRoot) : base(documentRoot) { }
    }

    #region Unknown Records

    public class DataForgeRecord7 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 40; } }
        public DataForgeRecord7(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord8 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 8; } }
        public DataForgeRecord8(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord9 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 8; } }
        public DataForgeRecord9(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord10 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 8; } }
        public DataForgeRecord10(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord11 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 8; } }
        public DataForgeRecord11(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord12 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 8; } }
        public DataForgeRecord12(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord13 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 8; } }
        public DataForgeRecord13(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord14 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord14(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord15 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord15(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord16 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord16(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord17 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord17(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord18 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord18(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord19 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord19(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord20 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord20(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeRecord21 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 4; } }
        public DataForgeRecord21(DataForge documentRoot) : base(documentRoot) { }
    }

    #endregion

    public class DataForgeRecord22 : DataForgeByteRecord
    {
        public override Int32 Width { get { return 16; } }
        public DataForgeRecord22(DataForge documentRoot) : base(documentRoot) { }
    }

    public class DataForgeFlexible : DataForgeByteRecord
    {
        public override Int32 Width { get { return 0; } }
        public DataForgeFlexible(DataForge documentRoot, Int32 width) : base(documentRoot, width) { }
    }
}
