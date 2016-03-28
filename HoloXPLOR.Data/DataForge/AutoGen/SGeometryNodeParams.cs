using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SGeometryNodeParams")]
    public partial class SGeometryNodeParams
    {
        [XmlAttribute(AttributeName = "Tags")]
        public String Tags { get; set; }

        [XmlElement(ElementName = "Geometry")]
        public SGeometryDataParams Geometry { get; set; }

        [XmlArray(ElementName = "SubGeometry")]
        [XmlArrayItem(Type = typeof(SGeometryNodeParams))]
        public SGeometryNodeParams[] SubGeometry { get; set; }

    }
}
