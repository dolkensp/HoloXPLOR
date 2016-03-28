using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortAttachmentDef")]
    public partial class SItemPortAttachmentDef
    {
        [XmlAttribute(AttributeName = "Type")]
        public EItemType Type { get; set; }

        [XmlAttribute(AttributeName = "SubType")]
        public EItemSubType SubType { get; set; }

        [XmlAttribute(AttributeName = "Size")]
        public Int32 Size { get; set; }

        [XmlAttribute(AttributeName = "Grade")]
        public Int32 Grade { get; set; }

        [XmlAttribute(AttributeName = "Tags")]
        public String Tags { get; set; }

        [XmlAttribute(AttributeName = "RequiredTags")]
        public String RequiredTags { get; set; }

        [XmlAttribute(AttributeName = "DisplayType")]
        public String DisplayType { get; set; }

    }
}
