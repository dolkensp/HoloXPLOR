using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputAnyBB")]
    public partial class BTInputAnyBB : BTInputAny
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
