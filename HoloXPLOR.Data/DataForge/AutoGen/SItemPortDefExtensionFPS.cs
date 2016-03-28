using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefExtensionFPS")]
    public partial class SItemPortDefExtensionFPS : SItemPortDefExtensionBase
    {
        [XmlAttribute(AttributeName = "SelectTag")]
        public String SelectTag { get; set; }

    }
}
