using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ScreenView")]
    public partial class ScreenView
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "display_name")]
        public String Display_name { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public String Description { get; set; }

        [XmlArray(ElementName = "providers")]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        public DockProvider[] Providers { get; set; }

    }
}
