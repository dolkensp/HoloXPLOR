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
    [XmlRoot(ElementName = "ship")]
    public class ShipLink
    {
        [XmlAttribute(AttributeName = "__EID__shipId")]
        public Guid ShipID { get; set; }
    }
}