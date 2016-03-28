using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GOSTState")]
    public partial class GOSTState
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

    }
}
