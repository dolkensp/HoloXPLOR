using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Character_Goto_Speed_Float")]
    public partial class BTInput_Character_Goto_Speed_Float : BTInput_Character_Goto_Speed
    {
        [XmlAttribute(AttributeName = "value")]
        public Single Value { get; set; }

    }
}
