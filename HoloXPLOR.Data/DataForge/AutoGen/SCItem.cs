using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItem")]
    public partial class SCItem
    {
        [XmlElement(ElementName = "Localization")]
        public SCItemLocalization Localization { get; set; }

        [XmlElement(ElementName = "AttachmentDef")]
        public SItemPortAttachmentDef AttachmentDef { get; set; }

        [XmlAttribute(AttributeName = "Manufacturer")]
        public Guid Manufacturer { get; set; }

        [XmlArray(ElementName = "Components")]
        [XmlArrayItem(Type = typeof(SCItemComponentParams))]
        [XmlArrayItem(Type = typeof(SCItemRadarParams))]
        [XmlArrayItem(Type = typeof(SCItemSeatParams))]
        [XmlArrayItem(Type = typeof(SCItemShieldEmitterParams))]
        [XmlArrayItem(Type = typeof(SCItemShieldGeneratorParams))]
        [XmlArrayItem(Type = typeof(SCItemRoomParams))]
        [XmlArrayItem(Type = typeof(SCItemPurchasableParams))]
        [XmlArrayItem(Type = typeof(SCItemSuitThrusterPackParams))]
        [XmlArrayItem(Type = typeof(SCAirlockParams))]
        [XmlArrayItem(Type = typeof(SCItemFlashlightParams))]
        [XmlArrayItem(Type = typeof(SCItemShopRackParams))]
        [XmlArrayItem(Type = typeof(SCItemPowerPlantParams))]
        public SCItemComponentParams[] Components { get; set; }

        [XmlArray(ElementName = "GeometryResource")]
        [XmlArrayItem(Type = typeof(SGeometryResourceParams))]
        public SGeometryResourceParams[] GeometryResource { get; set; }

        [XmlArray(ElementName = "ItemPorts")]
        [XmlArrayItem(Type = typeof(SItemPortCoreParams))]
        public SItemPortCoreParams[] ItemPorts { get; set; }

        [XmlArray(ElementName = "Energy")]
        [XmlArrayItem(Type = typeof(SEntityEnergyParams))]
        public SEntityEnergyParams[] Energy { get; set; }

        [XmlArray(ElementName = "AnimationController")]
        [XmlArrayItem(Type = typeof(SAnimationControllerParams))]
        public SAnimationControllerParams[] AnimationController { get; set; }

        [XmlArray(ElementName = "PhysicsController")]
        [XmlArrayItem(Type = typeof(SEntityPhysicsControllerParams))]
        [XmlArrayItem(Type = typeof(SEntityRigidPhysicsControllerParams))]
        [XmlArrayItem(Type = typeof(SEntityParticlePhysicsControllerParams))]
        public SEntityPhysicsControllerParams[] PhysicsController { get; set; }

        [XmlArray(ElementName = "EffectParams")]
        [XmlArrayItem(Type = typeof(SEntityEffectCoreParams))]
        public SEntityEffectCoreParams[] EffectParams { get; set; }

        [XmlArray(ElementName = "InteractableParams")]
        [XmlArrayItem(Type = typeof(SEntityInteractableParams))]
        public SEntityInteractableParams[] InteractableParams { get; set; }

    }
}
