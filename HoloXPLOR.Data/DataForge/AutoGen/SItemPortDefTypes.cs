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
        [XmlArrayItem(Type = typeof(BTInputVelocity))]
        [XmlArrayItem(Type = typeof(BTInputVelocityVar))]
        [XmlArrayItem(Type = typeof(BTInputVelocityBB))]
        public EItemSubType[] SubTypes { get; set; }

    }
}
