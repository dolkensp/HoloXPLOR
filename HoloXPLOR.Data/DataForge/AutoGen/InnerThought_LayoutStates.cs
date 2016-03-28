using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_LayoutStates")]
    public partial class InnerThought_LayoutStates
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "Layout")]
        [XmlArrayItem(Type = typeof(InnerThought_LayoutBase))]
        [XmlArrayItem(Type = typeof(InnerThought_LayoutCurve))]
        public InnerThought_LayoutBase[] Layout { get; set; }

    }
}
