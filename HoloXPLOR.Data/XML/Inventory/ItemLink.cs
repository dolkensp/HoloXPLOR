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
    [XmlRoot(ElementName = "item")]
    public class ItemLink
    {
        [XmlAttribute(AttributeName = "__EID__itemId")]
        [DefaultValue(0)]
        public Guid ItemID { get; set; }

        [XmlAttribute(AttributeName = "type")]
        [DefaultValue(0)]
        public Int32 Type { get; set; }

        [XmlAttribute(AttributeName = "subType")]
        [DefaultValue(0)]
        public Int32 SubType { get; set; }

        [XmlAttribute(AttributeName = "portId")]
        [DefaultValue(0)]
        public Int32 PortID { get; set; }
    }
}