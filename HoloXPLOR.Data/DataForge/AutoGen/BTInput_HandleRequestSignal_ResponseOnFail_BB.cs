using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnFail_BB")]
    public partial class BTInput_HandleRequestSignal_ResponseOnFail_BB : BTInput_HandleRequestSignal_ResponseOnFail
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
