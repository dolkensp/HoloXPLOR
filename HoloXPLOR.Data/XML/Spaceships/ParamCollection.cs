using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    [XmlRoot(ElementName = "params")]
    public partial class ParamCollection
    {
        [XmlElement(ElementName = "param")]
        public Param[] Items { get; set; }

        // TODO: Add itemStats
    }
}
