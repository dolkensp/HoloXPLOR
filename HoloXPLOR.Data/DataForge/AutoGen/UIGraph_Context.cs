using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_Context")]
    public partial class UIGraph_Context : CtxGraph_Context
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "BackBehavior")]
        public UIGraph_BackBehavior BackBehavior { get; set; }

        [XmlArray(ElementName = "UIController")]
        [XmlArrayItem(Type = typeof(UIGraph_ControllerComponent))]
        public UIGraph_ControllerComponent[] UIController { get; set; }

    }
}
