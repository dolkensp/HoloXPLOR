using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "MusicLogicParameter")]
    public partial class MusicLogicParameter
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "min")]
        public Single Min { get; set; }

        [XmlAttribute(AttributeName = "max")]
        public Single Max { get; set; }

        [XmlAttribute(AttributeName = "defaultValue")]
        public Single DefaultValue { get; set; }

        [XmlAttribute(AttributeName = "decayRate")]
        public Single DecayRate { get; set; }

        [XmlAttribute(AttributeName = "decayIsPercentage")]
        public Boolean DecayIsPercentage { get; set; }

        [XmlAttribute(AttributeName = "scaleModifier")]
        public Single ScaleModifier { get; set; }

        [XmlAttribute(AttributeName = "shiftModifier")]
        public Single ShiftModifier { get; set; }

        [XmlAttribute(AttributeName = "inverted")]
        public Boolean Inverted { get; set; }

        [XmlAttribute(AttributeName = "rtpc")]
        public String Rtpc { get; set; }

        [XmlArray(ElementName = "contributors")]
        [XmlArrayItem(ElementName = "Reference", Type=typeof(_Reference))]
        public _Reference[] Contributors { get; set; }

    }
}
