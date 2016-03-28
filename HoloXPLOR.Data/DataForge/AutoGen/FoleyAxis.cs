using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyAxis")]
    public partial class FoleyAxis
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
