using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyBone")]
    public partial class FoleyBone
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
