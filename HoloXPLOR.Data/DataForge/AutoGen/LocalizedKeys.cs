using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LocalizedKeys")]
    public partial class LocalizedKeys
    {
        [XmlArray(ElementName = "Keys")]
        [XmlArrayItem(Type = typeof(Key))]
        public Key[] Keys { get; set; }

    }
}
