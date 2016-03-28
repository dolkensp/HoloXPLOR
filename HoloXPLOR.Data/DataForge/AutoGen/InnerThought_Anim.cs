using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_Anim")]
    public partial class InnerThought_Anim
    {
        [XmlArray(ElementName = "Type")]
        [XmlArrayItem(Type = typeof(InnerThought_AnimBase))]
        public InnerThought_AnimBase[] Type { get; set; }

    }
}
