using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Inventory
{
    [XmlRoot(ElementName = "door")]
    public class DoorLink
    {
        [XmlAttribute(AttributeName = "linkId")]
        [DefaultValue(0)]
        public Int32 LinkID { get; set; }

        [XmlAttribute(AttributeName = "label")]
        [DefaultValue("")]
        public String Label { get; set; }

        [XmlAttribute(AttributeName = "state")]
        [DefaultValue(0)]
        public Int32 State { get; set; }
    }
}