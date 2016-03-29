using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Inventory
{
    [XmlRoot(ElementName = "features")]
    public class FeatureCollection : XmlCollection<Feature>
    {
        [XmlElement(ElementName = "feature")]
        public override Feature[] Items { get; set; }
    }
}