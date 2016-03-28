using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SPipePriority")]
    public partial class SPipePriority
    {
        [XmlAttribute(AttributeName = "PriorityGroup")]
        public EPipePriorityGroup PriorityGroup { get; set; }

        [XmlAttribute(AttributeName = "PriorityType")]
        public EPipePriorityType PriorityType { get; set; }

    }
}
