using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_Params")]
    public partial class InnerThought_Params
    {
        [XmlAttribute(AttributeName = "FontSize")]
        public Single FontSize { get; set; }

        [XmlArray(ElementName = "States")]
        [XmlArrayItem(Type = typeof(InnerThought_LayoutStates))]
        public InnerThought_LayoutStates[] States { get; set; }

        [XmlAttribute(AttributeName = "Anim")]
        public Guid Anim { get; set; }

    }
}
