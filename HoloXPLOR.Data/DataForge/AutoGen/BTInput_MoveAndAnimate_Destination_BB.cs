using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_MoveAndAnimate_Destination_BB")]
    public partial class BTInput_MoveAndAnimate_Destination_BB : BTInput_MoveAndAnimate_Destination
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
