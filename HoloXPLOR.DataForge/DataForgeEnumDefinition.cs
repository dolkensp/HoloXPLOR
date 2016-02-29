using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeEnumDefinition : DataForgeSerializable
    {
        public UInt32 NameOffset { get; set; }
        public String Name { get { return this.DocumentRoot.ValueMap[this.NameOffset]; } }
        public UInt16 ValueCount { get; set; }
        public UInt16 FirstValueIndex { get; set; }

        public DataForgeEnumDefinition(DataForge documentRoot)
            : base(documentRoot)
        {
            this.NameOffset = this._br.ReadUInt32();
            this.ValueCount = this._br.ReadUInt16();
            this.FirstValueIndex = this._br.ReadUInt16();
        }

        public override String ToString()
        {
            return String.Format("<{0} />", this.Name);
        }
    }
}
