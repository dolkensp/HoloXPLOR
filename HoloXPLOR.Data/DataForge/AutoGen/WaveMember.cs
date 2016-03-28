using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WaveMember")]
    public partial class WaveMember
    {
        [XmlAttribute(AttributeName = "archetype")]
        public String Archetype { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "baseProfile")]
        public String BaseProfile { get; set; }

        [XmlAttribute(AttributeName = "combatProfile")]
        public String CombatProfile { get; set; }

        [XmlAttribute(AttributeName = "flightProfile")]
        public String FlightProfile { get; set; }

        [XmlAttribute(AttributeName = "targetingProfile")]
        public String TargetingProfile { get; set; }

        [XmlAttribute(AttributeName = "raceProfile")]
        public String RaceProfile { get; set; }

        [XmlAttribute(AttributeName = "amount")]
        public Int32 Amount { get; set; }

        [XmlAttribute(AttributeName = "minAmount")]
        public Int32 MinAmount { get; set; }

        [XmlAttribute(AttributeName = "midAmount")]
        public Int32 MidAmount { get; set; }

        [XmlAttribute(AttributeName = "maxAmount")]
        public Int32 MaxAmount { get; set; }

    }
}
