using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputBoolBB")]
    public partial class BTInputBoolBB : BTInputBool
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
