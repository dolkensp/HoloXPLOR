using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    [XmlRoot(ElementName = "portParams")]
    public partial class PortCollection
    {
        [XmlArray(ElementName = "ports")]
        [XmlArrayItem(ElementName = "ItemPort")]
        public ItemPort[] Items { get; set; }
    }
}
