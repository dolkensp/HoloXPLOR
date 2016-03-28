using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendResponseSignal_Result_BB")]
    public partial class BTInput_SendResponseSignal_Result_BB : BTInput_SendResponseSignal_Result
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
