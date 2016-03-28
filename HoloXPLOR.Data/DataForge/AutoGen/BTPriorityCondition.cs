using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTPriorityCondition")]
    public partial class BTPriorityCondition : BTPriorityChild
    {
        [XmlAttribute(AttributeName = "Expression")]
        public String Expression { get; set; }

    }
}
