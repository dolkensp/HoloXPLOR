using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_MoveToCover_Speed_BB")]
    public partial class BTInput_MoveToCover_Speed_BB : BTInput_MoveToCover_Speed
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
