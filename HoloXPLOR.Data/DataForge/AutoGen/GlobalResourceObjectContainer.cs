using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GlobalResourceObjectContainer")]
    public partial class GlobalResourceObjectContainer : GlobalResourceBase
    {
        [XmlAttribute(AttributeName = "path")]
        public String Path { get; set; }

    }
}
