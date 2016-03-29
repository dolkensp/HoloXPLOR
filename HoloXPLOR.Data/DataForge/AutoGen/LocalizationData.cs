using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LocalizationData")]
    public partial class LocalizationData
    {
        [XmlAttribute(AttributeName = "Tag")]
        public String Tag { get; set; }

        [XmlArray(ElementName = "Filenames")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] Filenames { get; set; }

    }
}
