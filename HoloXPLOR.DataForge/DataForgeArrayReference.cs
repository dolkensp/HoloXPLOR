using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeArrayReference : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public Guid Value { get; set; }

        public DataForgeArrayReference(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Item1 = this._br.ReadUInt32();
            this.Value = this.ReadGuid(false).Value;
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1}", this.Item1, this.Value);
        }
    }
}
