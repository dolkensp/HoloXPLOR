using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    [XmlRoot(ElementName = "Item")]
    public partial class ItemLink
    {
        [XmlAttribute(AttributeName = "portName")]
        public String PortName { get; set; }

        [XmlAttribute(AttributeName = "itemName")]
        public String ItemName { get; set; }

        [XmlArray(ElementName = "Items")]
        [XmlArrayItem(ElementName = "Item")]
        public ItemLink[] Items { get; set; }

        public override String ToString()
        {
            return String.Format("{0}: {1}", this.PortName, this.ItemName);
        }
    }
}