using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnSuccess_BB")]
    public partial class BTInput_HandleRequestSignal_ResponseOnSuccess_BB : BTInput_HandleRequestSignal_ResponseOnSuccess
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
