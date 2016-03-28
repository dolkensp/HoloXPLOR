using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SGeometryDataParams")]
    public partial class SGeometryDataParams
    {
        [XmlElement(ElementName = "Material")]
        public GlobalResourceMaterial Material { get; set; }

        [XmlElement(ElementName = "Geometry")]
        public GlobalResourceGeometry Geometry { get; set; }

        [XmlAttribute(AttributeName = "AttachFlags")]
        public UInt32 AttachFlags { get; set; }

    }
}
