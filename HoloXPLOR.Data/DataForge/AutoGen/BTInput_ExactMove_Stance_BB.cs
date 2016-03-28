using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_ExactMove_Stance_BB")]
    public partial class BTInput_ExactMove_Stance_BB : BTInput_ExactMove_Stance
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
