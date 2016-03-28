using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTTransition")]
    public partial class BTTransition
    {
        [XmlAttribute(AttributeName = "signal")]
        public String Signal { get; set; }

        [XmlAttribute(AttributeName = "targetState")]
        public String TargetState { get; set; }

    }
}
