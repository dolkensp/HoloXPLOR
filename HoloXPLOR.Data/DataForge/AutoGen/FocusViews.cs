using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FocusViews")]
    public partial class FocusViews
    {
        [XmlArray(ElementName = "views")]
        [XmlArrayItem(Type = typeof(FocusView))]
        public FocusView[] Views { get; set; }

        [XmlAttribute(AttributeName = "DefaultViewLeft")]
        public String DefaultViewLeft { get; set; }

        [XmlAttribute(AttributeName = "DefaultViewRight")]
        public String DefaultViewRight { get; set; }

        [XmlAttribute(AttributeName = "DefaultViewUp")]
        public String DefaultViewUp { get; set; }

        [XmlAttribute(AttributeName = "DefaultViewDown")]
        public String DefaultViewDown { get; set; }

    }
}
