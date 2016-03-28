using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "Conversation")]
    public partial class Conversation
    {
        [XmlAttribute(AttributeName = "disableReactions")]
        public Boolean DisableReactions { get; set; }

        [XmlArray(ElementName = "fragments")]
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
        public ConversationNode_Base[] Fragments { get; set; }

    }
}
