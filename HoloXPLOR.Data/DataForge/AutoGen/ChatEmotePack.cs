using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatEmotePack")]
    public partial class ChatEmotePack
    {
        [XmlAttribute(AttributeName = "PackType")]
        public String PackType { get; set; }

        [XmlArray(ElementName = "Emotes")]
        [XmlArrayItem(Type = typeof(ChatEmoteData))]
        public ChatEmoteData[] Emotes { get; set; }

    }
}
