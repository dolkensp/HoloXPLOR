using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendSignalToGroup_Name_BB")]
    public partial class BTInput_SendSignalToGroup_Name_BB : BTInput_SendSignalToGroup_Name
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
