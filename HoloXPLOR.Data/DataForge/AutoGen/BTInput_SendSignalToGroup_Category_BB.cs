using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInput_SendSignalToGroup_Category_BB")]
    public partial class BTInput_SendSignalToGroup_Category_BB : BTInput_SendSignalToGroup_Category
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
