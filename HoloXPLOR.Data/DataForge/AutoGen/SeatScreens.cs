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
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public Int32[] Views { get; set; }

        [XmlAttribute(AttributeName = "seatType")]
        public SeatScreensType SeatType { get; set; }

        [XmlAttribute(AttributeName = "reticleArchetype")]
        public Guid ReticleArchetype { get; set; }

    }
}
