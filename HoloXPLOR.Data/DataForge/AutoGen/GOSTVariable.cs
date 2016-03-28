using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTVariable")]
    public partial class GOSTVariable
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public EGOSTVariableType Type { get; set; }

        [XmlAttribute(AttributeName = "default")]
        public String Default { get; set; }

    }
}
