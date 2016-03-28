using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_Group")]
    public partial class UIGraph_Group : CtxGraph_Group
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
