using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SAnimationControllerParams")]
    public partial class SAnimationControllerParams
    {
        [XmlAttribute(AttributeName = "AnimationDatabase")]
        public String AnimationDatabase { get; set; }

        [XmlAttribute(AttributeName = "AnimationController")]
        public String AnimationController { get; set; }

        [XmlArray(ElementName = "ScopeContexts")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] ScopeContexts { get; set; }

    }
}
