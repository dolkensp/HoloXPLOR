using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationSystem_InnerThoughtConfig")]
    public partial class ConversationSystem_InnerThoughtConfig
    {
        [XmlAttribute(AttributeName = "MinDistance")]
        public Single MinDistance { get; set; }

        [XmlAttribute(AttributeName = "MaxDistance")]
        public Single MaxDistance { get; set; }

        [XmlElement(ElementName = "Rotation")]
        public Deg3 Rotation { get; set; }

        [XmlAttribute(AttributeName = "Bone")]
        public ActorBone Bone { get; set; }

        [XmlElement(ElementName = "BoneOffset")]
        public Vec3 BoneOffset { get; set; }

        [XmlAttribute(AttributeName = "RotationRate")]
        public Single RotationRate { get; set; }

        [XmlAttribute(AttributeName = "TranslationRate")]
        public Single TranslationRate { get; set; }

        [XmlAttribute(AttributeName = "InnerThought")]
        public Guid InnerThought { get; set; }

    }
}
