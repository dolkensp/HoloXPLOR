using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SGeometryResourceParams")]
    public partial class SGeometryResourceParams
    {
        [XmlElement(ElementName = "Geometry")]
        public SGeometryNodeParams Geometry { get; set; }

    }
}
