using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Move_Destination_BB")]
    public partial class BTInput_Move_Destination_BB : BTInput_Move_Destination
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
