using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    public partial class Item
    {
        public Double Inefficiency
        {
            get { return this.Params["inefficiency", String.Empty].ToDouble(0); }
            set { this.Params["inefficiency"] = value.ToString(); }
        }
    }
}
