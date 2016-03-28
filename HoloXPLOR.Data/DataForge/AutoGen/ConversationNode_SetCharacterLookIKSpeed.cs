using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_SetCharacterLookIKSpeed")]
    public partial class ConversationNode_SetCharacterLookIKSpeed : ConversationNode_BaseNext
    {
        [XmlAttribute(AttributeName = "character")]
        public Guid Character { get; set; }

        [XmlAttribute(AttributeName = "defaultLookIKSmoothingTime")]
        public Single DefaultLookIKSmoothingTime { get; set; }

        [XmlAttribute(AttributeName = "movingLookIKSmoothingTime")]
        public Single MovingLookIKSmoothingTime { get; set; }

        [XmlAttribute(AttributeName = "vehicleLookIKSmoothingTime")]
        public Single VehicleLookIKSmoothingTime { get; set; }

        [XmlAttribute(AttributeName = "zeroGLookIKSmoothingTime")]
        public Single ZeroGLookIKSmoothingTime { get; set; }

    }
}
