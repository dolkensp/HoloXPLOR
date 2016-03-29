using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefTypes")]
    public partial class SItemPortDefTypes
    {
        [XmlAttribute(AttributeName = "Type")]
        public EItemType Type { get; set; }

        [XmlArray(ElementName = "SubTypes")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_EItemSubType))]
        public _EItemSubType[] SubTypes { get; set; }

    }
}
