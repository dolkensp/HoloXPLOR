using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "PooledLightData")]
    public partial class PooledLightData
    {
        [XmlAttribute(AttributeName = "flareName")]
        public String FlareName { get; set; }

        [XmlAttribute(AttributeName = "flareScale")]
        public Single FlareScale { get; set; }

        [XmlAttribute(AttributeName = "radius")]
        public Single Radius { get; set; }

        [XmlElement(ElementName = "diffuseColor")]
        public RGB DiffuseColor { get; set; }

        [XmlAttribute(AttributeName = "diffuseMultiplier")]
        public Single DiffuseMultiplier { get; set; }

        [XmlAttribute(AttributeName = "specularMultiplier")]
        public Single SpecularMultiplier { get; set; }

        [XmlAttribute(AttributeName = "attenuationBulbSize")]
        public Single AttenuationBulbSize { get; set; }

        [XmlAttribute(AttributeName = "animSpeed")]
        public Single AnimSpeed { get; set; }

        [XmlAttribute(AttributeName = "rampTime")]
        public Single RampTime { get; set; }

        [XmlAttribute(AttributeName = "fake")]
        public Boolean Fake { get; set; }

        [XmlAttribute(AttributeName = "autoClip")]
        public Boolean AutoClip { get; set; }

        [XmlAttribute(AttributeName = "style")]
        public Byte Style { get; set; }

        [XmlAttribute(AttributeName = "animPhase")]
        public Byte AnimPhase { get; set; }

        [XmlAttribute(AttributeName = "flareLensOpticsFrustumAngle")]
        public Byte FlareLensOpticsFrustumAngle { get; set; }

    }
}
