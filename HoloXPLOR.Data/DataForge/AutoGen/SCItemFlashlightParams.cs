using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemFlashlightParams")]
    public partial class SCItemFlashlightParams : SCItemComponentParams
    {
        [XmlElement(ElementName = "lightCookie")]
        public GlobalResourceMaterial LightCookie { get; set; }

        [XmlElement(ElementName = "material")]
        public GlobalResourceMaterial Material { get; set; }

        [XmlElement(ElementName = "color")]
        public RGB8 Color { get; set; }

        [XmlAttribute(AttributeName = "diffuseMult")]
        public Single DiffuseMult { get; set; }

        [XmlAttribute(AttributeName = "specularMult")]
        public Single SpecularMult { get; set; }

        [XmlAttribute(AttributeName = "attenuationBulbSize")]
        public Single AttenuationBulbSize { get; set; }

        [XmlAttribute(AttributeName = "distance")]
        public Single Distance { get; set; }

        [XmlAttribute(AttributeName = "fov")]
        public Single Fov { get; set; }

        [XmlAttribute(AttributeName = "style")]
        public Int32 Style { get; set; }

        [XmlAttribute(AttributeName = "animspeed")]
        public Single Animspeed { get; set; }

        [XmlElement(ElementName = "Light_On_SFX")]
        public GlobalResourceAudio Light_On_SFX { get; set; }

        [XmlElement(ElementName = "Light_Off_SFX")]
        public GlobalResourceAudio Light_Off_SFX { get; set; }

        [XmlAttribute(AttributeName = "helperName")]
        public String HelperName { get; set; }

        [XmlElement(ElementName = "helperDirection")]
        public Vec3 HelperDirection { get; set; }

        [XmlElement(ElementName = "helperOffset")]
        public Vec3 HelperOffset { get; set; }

    }
}
