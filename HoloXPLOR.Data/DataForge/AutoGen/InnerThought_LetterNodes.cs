using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "InnerThought_LetterNodes")]
    public partial class InnerThought_LetterNodes
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Code")]
        public UInt16 Code { get; set; }

    }
}
