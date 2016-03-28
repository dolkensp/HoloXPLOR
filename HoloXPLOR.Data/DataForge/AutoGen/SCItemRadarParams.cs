using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemRadarParams")]
    public partial class SCItemRadarParams : SCItemComponentParams
    {
        [XmlAttribute(AttributeName = "Filter")]
        public UInt32 Filter { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public UInt32 Type { get; set; }

        [XmlAttribute(AttributeName = "Signature")]
        public UInt32 Signature { get; set; }

        [XmlAttribute(AttributeName = "Radius")]
        public Single Radius { get; set; }

        [XmlAttribute(AttributeName = "Refreshrate")]
        public Single Refreshrate { get; set; }

        [XmlAttribute(AttributeName = "ObjectLifetime")]
        public Single ObjectLifetime { get; set; }

    }
}
