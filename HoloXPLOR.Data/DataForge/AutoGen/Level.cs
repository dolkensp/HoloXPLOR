using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Level")]
    public partial class Level
    {
        [XmlAttribute(AttributeName = "displayName")]
        public String DisplayName { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public EModuleType Type { get; set; }

        [XmlAttribute(AttributeName = "filename")]
        public String Filename { get; set; }

        [XmlAttribute(AttributeName = "loadout")]
        public String Loadout { get; set; }

        [XmlAttribute(AttributeName = "locationUniqueId")]
        public UInt64 LocationUniqueId { get; set; }

        [XmlAttribute(AttributeName = "defaultGameRules")]
        public Guid DefaultGameRules { get; set; }

        [XmlArray(ElementName = "validGameRules")]
        [XmlArrayItem(ElementName = "Reference", Type=typeof(_Reference))]
        public _Reference[] ValidGameRules { get; set; }

        [XmlElement(ElementName = "loadingScreenInfo")]
        public SLoadingScreenInformationDef LoadingScreenInfo { get; set; }

    }
}
