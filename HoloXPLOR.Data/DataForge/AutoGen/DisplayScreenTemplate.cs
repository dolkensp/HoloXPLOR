using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DisplayScreenTemplate")]
    public partial class DisplayScreenTemplate
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public String Description { get; set; }

        [XmlArray(ElementName = "default_views")]
        [XmlArrayItem(ElementName = "Reference", Type=typeof(_Reference))]
        public _Reference[] Default_views { get; set; }

        [XmlAttribute(AttributeName = "background_view")]
        public Guid Background_view { get; set; }

    }
}
