using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeArrayLocale : DataForgeSerializable
    {
        public String Value { get; set; }

        public DataForgeArrayLocale(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this.ReadString();
        }

        public override String ToString()
        {
            return this.Value;
        }
    }
}
