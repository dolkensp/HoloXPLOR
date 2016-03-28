using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_HandleRequestSignal_ResponseOnEnter_BB")]
    public partial class BTInput_HandleRequestSignal_ResponseOnEnter_BB : BTInput_HandleRequestSignal_ResponseOnEnter
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
