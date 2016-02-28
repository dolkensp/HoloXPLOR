using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeArrayGuid : DataForgeSerializable
    {
        public Guid Value { get; set; }

        public DataForgeArrayGuid(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this.ReadGuid(false).Value;
        }

        public override String ToString()
        {
            return this.Value.ToString();
        }
    }
}
