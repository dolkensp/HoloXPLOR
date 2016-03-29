using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Vehicles.Implementations
{
    [XmlRoot(ElementName = "Vehicle")]
    public partial class Vehicle
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "category")]
        public String Category { get; set; }

        [XmlAttribute(AttributeName = "displayname")]
        public String DisplayName { get; set; }

        [XmlAttribute(AttributeName = "classname")]
        public String ClassName { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public String ID { get; set; }

        [XmlAttribute(AttributeName = "dockingclass")]
        [DefaultValue(0)]
        public Int32 DockingClass { get; set; }

        [XmlAttribute(AttributeName = "HudPaletteScheme")]
        public String HUDPaletteScheme { get; set; }

        [XmlAttribute(AttributeName = "requiredItemTags")]
        public String RequiredItemTags { get; set; }

        [XmlAttribute(AttributeName = "itemPortTags")]
        public String ItemPortTags { get; set; }

        [XmlAttribute(AttributeName = "crossSectionMultiplier")]
        public String CrossSectionMultiplier { get; set; }

        [XmlArray(ElementName = "Parts")]
        [XmlArrayItem(ElementName = "Part")]
        public Part[] Parts { get; set; }

        [XmlArray(ElementName = "Modifications")]
        [XmlArrayItem(ElementName = "Modification")]
        public Modification[] Modifications { get; set; }
        
        public override String ToString()
        {
            return String.Format("{0}", this.DisplayName);
        }
    }
}