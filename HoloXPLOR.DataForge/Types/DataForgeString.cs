using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForgeString : _DataForgeSerializable
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
}
