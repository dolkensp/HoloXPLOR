using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTConstant")]
    public partial class GOSTConstant
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public EGOSTVariableType Type { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }

    }
}
