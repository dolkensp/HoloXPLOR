using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCAirlockParams")]
    public partial class SCAirlockParams : SCItemComponentParams
    {
        [XmlAttribute(AttributeName = "InteriorIPName")]
        public String InteriorIPName { get; set; }

        [XmlAttribute(AttributeName = "ExteriorIPName")]
        public String ExteriorIPName { get; set; }

        [XmlAttribute(AttributeName = "InnerIPName")]
        public String InnerIPName { get; set; }

        [XmlAttribute(AttributeName = "CycleTime")]
        public Single CycleTime { get; set; }

        [XmlAttribute(AttributeName = "HoldTime")]
        public Single HoldTime { get; set; }

    }
}
