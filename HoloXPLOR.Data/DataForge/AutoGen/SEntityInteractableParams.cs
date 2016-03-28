using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEntityInteractableParams")]
    public partial class SEntityInteractableParams
    {
        [XmlArray(ElementName = "InteractionPoints")]
        [XmlArrayItem(Type = typeof(SInteractionPointParams))]
        public SInteractionPointParams[] InteractionPoints { get; set; }

    }
}
