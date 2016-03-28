using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_Ship_Drift_Look_BB")]
    public partial class BTInput_Ship_Drift_Look_BB : BTInput_Ship_Drift_Look
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
