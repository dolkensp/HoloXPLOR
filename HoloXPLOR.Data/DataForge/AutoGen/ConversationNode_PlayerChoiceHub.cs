using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ConversationNode_PlayerChoiceHub")]
    public partial class ConversationNode_PlayerChoiceHub : ConversationNode_Base
    {
        [XmlAttribute(AttributeName = "targetNPC")]
        public Guid TargetNPC { get; set; }

        [XmlArray(ElementName = "innerVoice")]
        [XmlArrayItem(Type = typeof(ProjectileParams))]
        [XmlArrayItem(Type = typeof(RocketProjectileParams))]
        [XmlArrayItem(Type = typeof(CounterMeasureProjectileParams))]
        [XmlArrayItem(Type = typeof(ShatterRocketProjectileParams))]
        [XmlArrayItem(Type = typeof(GrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(SmokeGrenadeProjectileParams))]
        [XmlArrayItem(Type = typeof(C4ProjectileParams))]
        [XmlArrayItem(Type = typeof(BulletProjectileParams))]
        public String[] InnerVoice { get; set; }

        [XmlAttribute(AttributeName = "timeOut")]
        public Single TimeOut { get; set; }

        [XmlAttribute(AttributeName = "timeOutLink")]
        public String TimeOutLink { get; set; }

        [XmlArray(ElementName = "outputLinks")]
        [XmlArrayItem(Type = typeof(ConversationNode_Base))]
        [XmlArrayItem(Type = typeof(ConversationNode_BaseNext))]
        [XmlArrayItem(Type = typeof(ConversationNode_Start))]
        [XmlArrayItem(Type = typeof(ConversationNode_Dialogue))]
        [XmlArrayItem(Type = typeof(ConversationNode_ConditionalGameToken))]
        [XmlArrayItem(Type = typeof(ConversationNode_ConditionalNPCReputation))]
        [XmlArrayItem(Type = typeof(ConversationNode_ConditionalPlayerReputation))]
        [XmlArrayItem(Type = typeof(ConversationNode_VariableGameToken))]
        [XmlArrayItem(Type = typeof(ConversationNode_VariableNPCReputation))]
        [XmlArrayItem(Type = typeof(ConversationNode_VariablePlayerReputation))]
        [XmlArrayItem(Type = typeof(ConversationNode_ReactionsToggle))]
        [XmlArrayItem(Type = typeof(ConversationNode_ReactionOverride))]
        [XmlArrayItem(Type = typeof(ConversationNode_PlayerChoiceHub))]
        [XmlArrayItem(Type = typeof(ConversationNode_Hub))]
        [XmlArrayItem(Type = typeof(ConversationNode_FlowGraphEvent))]
        [XmlArrayItem(Type = typeof(ConversationNode_Wait))]
        [XmlArrayItem(Type = typeof(ConversationNode_PlayFacialAnim))]
        [XmlArrayItem(Type = typeof(ConversationNode_PlayGestureAnim))]
        [XmlArrayItem(Type = typeof(ConversationNode_PlayMannequinFragment))]
        [XmlArrayItem(Type = typeof(ConversationNode_OverrideDOFandFOV))]
        [XmlArrayItem(Type = typeof(ConversationNode_SetCharacterLookIKSpeed))]
        [XmlArrayItem(Type = typeof(ConversationNode_SetCharacterLookAtCharacter))]
        [XmlArrayItem(Type = typeof(ConversationNode_SetCharacterLookAtEntity))]
        public String[] OutputLinks { get; set; }

    }
}
