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
    [XmlRoot(ElementName = "hangar")]
    public class Hangar : Item
    {
        [XmlAttribute(AttributeName = "owner")]
        [DefaultValue("")]
        public String Owner { get; set; }

        [XmlElement(ElementName = "rooms")]
        public RoomCollection Rooms { get; set; }
    }
}