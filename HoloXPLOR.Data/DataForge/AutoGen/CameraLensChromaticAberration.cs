using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CameraLensChromaticAberration")]
    public partial class CameraLensChromaticAberration
    {
        [XmlAttribute(AttributeName = "Transverse")]
        public Single Transverse { get; set; }

        [XmlAttribute(AttributeName = "Axial")]
        public Single Axial { get; set; }

    }
}
