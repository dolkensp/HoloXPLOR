using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ChatEmoteRecord")]
    public partial class ChatEmoteRecord
    {
        [XmlArray(ElementName = "Packs")]
        [XmlArrayItem(Type = typeof(ChatEmotePack))]
        public ChatEmotePack[] Packs { get; set; }

    }
}
