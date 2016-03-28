using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTDecorator")]
    public partial class BTDecorator : BTNode
    {
        [XmlAttribute(AttributeName = "child")]
        public String Child { get; set; }

    }
}
