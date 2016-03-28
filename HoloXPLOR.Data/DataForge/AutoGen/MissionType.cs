using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MissionType")]
    public partial class MissionType
    {
        [XmlAttribute(AttributeName = "IconName")]
        public String IconName { get; set; }

        [XmlAttribute(AttributeName = "LocalisedTypeName")]
        public String LocalisedTypeName { get; set; }

    }
}
