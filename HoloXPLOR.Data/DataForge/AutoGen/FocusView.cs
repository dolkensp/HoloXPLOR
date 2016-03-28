using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FocusView")]
    public partial class FocusView
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "screenContainer")]
        public String ScreenContainer { get; set; }

        [XmlAttribute(AttributeName = "displayScreen")]
        public String DisplayScreen { get; set; }

        [XmlAttribute(AttributeName = "focusViewAngle")]
        public Single FocusViewAngle { get; set; }

        [XmlAttribute(AttributeName = "zoom")]
        public Single Zoom { get; set; }

        [XmlAttribute(AttributeName = "parallaxMoveScale")]
        public Single ParallaxMoveScale { get; set; }

        [XmlElement(ElementName = "offset")]
        public Vec3 Offset { get; set; }

        [XmlAttribute(AttributeName = "LeftLink")]
        public String LeftLink { get; set; }

        [XmlAttribute(AttributeName = "DownLink")]
        public String DownLink { get; set; }

        [XmlAttribute(AttributeName = "RightLink")]
        public String RightLink { get; set; }

        [XmlAttribute(AttributeName = "UpLink")]
        public String UpLink { get; set; }

    }
}
