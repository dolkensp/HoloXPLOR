using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatFilter")]
    public partial class ChatFilter
    {
        [XmlAttribute(AttributeName = "tagId")]
        public Int32 TagId { get; set; }

        [XmlAttribute(AttributeName = "localizedString")]
        public String LocalizedString { get; set; }

    }
}
