using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Character_ExactGoto_Speed_BB")]
    public partial class BTInput_Character_ExactGoto_Speed_BB : BTInput_Character_ExactGoto_Speed
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
