using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CollectibleType")]
    public partial class CollectibleType
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "collectionMessage")]
        public String CollectionMessage { get; set; }

    }
}
