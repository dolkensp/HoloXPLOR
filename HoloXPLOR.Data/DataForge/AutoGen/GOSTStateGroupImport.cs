using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTStateGroupImport")]
    public partial class GOSTStateGroupImport
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "impl")]
        public Guid Impl { get; set; }

    }
}
