using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "PostureDatabase")]
    public partial class PostureDatabase
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlArray(ElementName = "Groups")]
        [XmlArrayItem(Type = typeof(PostureGroup))]
        public PostureGroup[] Groups { get; set; }

    }
}
