using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatEmoteAnimData")]
    public partial class ChatEmoteAnimData
    {
        [XmlAttribute(AttributeName = "FragmentID")]
        public String FragmentID { get; set; }

        [XmlAttribute(AttributeName = "TagID")]
        public String TagID { get; set; }

        [XmlAttribute(AttributeName = "TextToDisplay")]
        public String TextToDisplay { get; set; }

    }
}
