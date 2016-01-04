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
    [XmlRoot(ElementName = "feature")]
    public class Feature
    {
        [XmlAttribute(AttributeName = "category")]
        [DefaultValue("")]
        public String Category { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public Int32 Count
        {
            get { return this.Items == null ? 0 : this.Items.Count; }
            set { /* required for xml serialization */ }
        }
        public Boolean ShouldSerializeCount()
        {
            // Generally expect a single item, but if it's a VehicleSpawnPoint - always serialize
            return this.Count > 1 || this.Category == "VehicleSpawnFeature";
        }

        [XmlElement(Type = typeof(ItemLink), ElementName = "item")]
        [XmlElement(Type = typeof(DoorLink), ElementName = "door")]
        [XmlElement(Type = typeof(ShipLink), ElementName = "ship")]
        public ArrayList Items { get; set; }

        [XmlIgnore]
        public Object this[Int32 index]
        {
            get { return this.Items[index]; }
            set { this.Items[index] = value; }
        }
    }
}