using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BulletVisualParams")]
    public partial class BulletVisualParams
    {
        [XmlAttribute(AttributeName = "gapSize")]
        public Single GapSize { get; set; }

        [XmlAttribute(AttributeName = "maxLength")]
        public Single MaxLength { get; set; }

        [XmlAttribute(AttributeName = "meshOffset")]
        public Single MeshOffset { get; set; }

        [XmlAttribute(AttributeName = "meshLength")]
        public Single MeshLength { get; set; }

        [XmlAttribute(AttributeName = "geometryRadius")]
        public Single GeometryRadius { get; set; }

    }
}
