using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEntityPhysicsControllerParams")]
    public partial class SEntityPhysicsControllerParams
    {
        [XmlAttribute(AttributeName = "Mass")]
        public Single Mass { get; set; }

        [XmlAttribute(AttributeName = "Density")]
        public Single Density { get; set; }

    }
}
