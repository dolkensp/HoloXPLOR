using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SeatScreens")]
    public partial class SeatScreens
    {
        [XmlArray(ElementName = "screens")]
        [XmlArrayItem(Type = typeof(SeatScreen))]
        public SeatScreen[] Screens { get; set; }

        [XmlAttribute(AttributeName = "element")]
        public String Element { get; set; }

        [XmlArray(ElementName = "display_screens")]
        [XmlArrayItem(Type = typeof(DisplayScreen))]
        public DisplayScreen[] Display_screens { get; set; }

        [XmlElement(ElementName = "focusViews")]
        public FocusViews FocusViews { get; set; }

        [XmlArray(ElementName = "views")]
        [XmlArrayItem(ElementName = "Int32", Type=typeof(_Int32))]
        public _Int32[] Views { get; set; }

        [XmlAttribute(AttributeName = "seatType")]
        public SeatScreensType SeatType { get; set; }

        [XmlAttribute(AttributeName = "reticleArchetype")]
        public Guid ReticleArchetype { get; set; }

    }
}
