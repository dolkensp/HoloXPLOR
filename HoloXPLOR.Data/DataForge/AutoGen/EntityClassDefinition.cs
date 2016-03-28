using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "EntityClassDefinition")]
    public partial class EntityClassDefinition
    {
        [XmlAttribute(AttributeName = "Category")]
        public String Category { get; set; }

        [XmlAttribute(AttributeName = "Icon")]
        public String Icon { get; set; }

        [XmlArray(ElementName = "Components")]
        [XmlArrayItem(Type = typeof(DataForgeComponentParams))]
        public DataForgeComponentParams[] Components { get; set; }

    }
}
