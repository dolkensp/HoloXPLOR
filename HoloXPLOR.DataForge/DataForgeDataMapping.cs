using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeDataMapping : DataForgeSerializable
    {
        public UInt16 StructIndex { get; set; }
        public UInt16 StructCount { get; set; }
        public String Name { get; set; }

        public DataForgeDataMapping(DataForge documentRoot)
            : base(documentRoot)
        {
            this.StructCount = this._br.ReadUInt16();
            this.StructIndex = this._br.ReadUInt16();
            this.Name = documentRoot.StructDefinitionTable[this.StructIndex].Name;
        }

        public override String ToString()
        {
            return String.Format("0x{1:X4} {2}[0x{0:X4}]", this.StructCount, this.StructIndex, this.Name);
        }
    }
}
