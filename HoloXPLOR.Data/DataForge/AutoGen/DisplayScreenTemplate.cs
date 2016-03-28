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
        [XmlArrayItem(Type = typeof(ScreenView))]
        public Guid[] Default_views { get; set; }

        [XmlAttribute(AttributeName = "background_view")]
        public Guid Background_view { get; set; }

    }
}
