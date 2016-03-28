using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemSuitThrusterParams")]
    public partial class SCItemSuitThrusterParams
    {
        [XmlAttribute(AttributeName = "TagName")]
        public String TagName { get; set; }

        [XmlAttribute(AttributeName = "GroupId")]
        public UInt32 GroupId { get; set; }

    }
}
