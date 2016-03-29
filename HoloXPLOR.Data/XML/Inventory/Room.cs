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
    [XmlRoot(ElementName = "room")]
    public class Room
    {
        [XmlAttribute(AttributeName = "library")]
        [DefaultValue("")]
        public String Library { get; set; }

        [XmlAttribute(AttributeName = "category")]
        [DefaultValue("")]
        public String Category { get; set; }

        [XmlElement(ElementName = "features")]
        public FeatureCollection Features { get; set; }
    }
}