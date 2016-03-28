using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RECAward")]
    public partial class RECAward
    {
        [XmlAttribute(AttributeName = "id")]
        public String Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public String Description { get; set; }

        [XmlAttribute(AttributeName = "amount")]
        public Int32 Amount { get; set; }

    }
}
