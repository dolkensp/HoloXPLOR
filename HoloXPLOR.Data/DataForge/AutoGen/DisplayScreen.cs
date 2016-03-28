using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DisplayScreen")]
    public partial class DisplayScreen
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public String Description { get; set; }

        [XmlAttribute(AttributeName = "display_screen_template")]
        public Guid Display_screen_template { get; set; }

        [XmlAttribute(AttributeName = "starting_view")]
        public Guid Starting_view { get; set; }

        [XmlAttribute(AttributeName = "helper")]
        public String Helper { get; set; }

        [XmlAttribute(AttributeName = "port")]
        public String Port { get; set; }

        [XmlAttribute(AttributeName = "screenSpace")]
        public Boolean ScreenSpace { get; set; }

        [XmlAttribute(AttributeName = "useParentPort")]
        public Boolean UseParentPort { get; set; }

        [XmlAttribute(AttributeName = "scale")]
        public Single Scale { get; set; }

        [XmlElement(ElementName = "offset")]
        public Vec3 Offset { get; set; }

        [XmlElement(ElementName = "rotation")]
        public Deg3 Rotation { get; set; }

    }
}
