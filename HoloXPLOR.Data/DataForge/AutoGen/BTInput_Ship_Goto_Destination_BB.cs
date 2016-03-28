using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Ship_Goto_Destination_BB")]
    public partial class BTInput_Ship_Goto_Destination_BB : BTInput_Ship_Goto_Destination
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
