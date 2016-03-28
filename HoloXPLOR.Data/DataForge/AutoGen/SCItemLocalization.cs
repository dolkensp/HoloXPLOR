using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemLocalization")]
    public partial class SCItemLocalization
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Description")]
        public String Description { get; set; }

    }
}
