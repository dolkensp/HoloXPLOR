using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTEmbedBT")]
    public partial class BTEmbedBT : BTNode
    {
        [XmlAttribute(AttributeName = "tree")]
        public Guid Tree { get; set; }

    }
}
