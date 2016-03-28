using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_LayoutCurve")]
    public partial class InnerThought_LayoutCurve : InnerThought_LayoutBase
    {
        [XmlAttribute(AttributeName = "Radius")]
        public Single Radius { get; set; }

        [XmlAttribute(AttributeName = "Angle")]
        public Single Angle { get; set; }

        [XmlArray(ElementName = "Cycles")]
        [XmlArrayItem(Type = typeof(InnerThought_CycleAnimBase))]
        [XmlArrayItem(Type = typeof(InnerThought_CycleAnimRotateX))]
        [XmlArrayItem(Type = typeof(InnerThought_CycleAnimRotateY))]
        [XmlArrayItem(Type = typeof(InnerThought_CycleAnimRotateZ))]
        public InnerThought_CycleAnimBase[] Cycles { get; set; }

        [XmlElement(ElementName = "SelectedColor")]
        public RGBA SelectedColor { get; set; }

        [XmlElement(ElementName = "UnselectedColorStart")]
        public RGBA UnselectedColorStart { get; set; }

        [XmlElement(ElementName = "UnselectedColorEnd")]
        public RGBA UnselectedColorEnd { get; set; }

        [XmlElement(ElementName = "SelectedOffset")]
        public Vec3 SelectedOffset { get; set; }

        [XmlElement(ElementName = "UnselectedOffset")]
        public Vec3 UnselectedOffset { get; set; }

        [XmlElement(ElementName = "SelectedRotation")]
        public Deg3 SelectedRotation { get; set; }

        [XmlElement(ElementName = "UnselectedRotation")]
        public Deg3 UnselectedRotation { get; set; }

    }
}
