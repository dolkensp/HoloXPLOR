using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    public partial class Item
    {
        [XmlArray(ElementName = "ammoBox")]
        [XmlArrayItem(ElementName = "param")]
        public Param[] AmmoBox { get; set; }
    }
}
