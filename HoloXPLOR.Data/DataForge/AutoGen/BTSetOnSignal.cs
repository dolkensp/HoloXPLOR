using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSetOnSignal")]
    public partial class BTSetOnSignal
    {
        [XmlAttribute(AttributeName = "onSignal")]
        public String OnSignal { get; set; }

        [XmlArray(ElementName = "putValue")]
        [XmlArrayItem(Type = typeof(BTInputValueOnly))]
        [XmlArrayItem(Type = typeof(BTInputValueOnlyBool))]
        [XmlArrayItem(Type = typeof(BTInputValueOnlyInt))]
        [XmlArrayItem(Type = typeof(BTInputValueOnlyFloat))]
        [XmlArrayItem(Type = typeof(BTInputValueOnlyString))]
        [XmlArrayItem(Type = typeof(BTInputValueOnlyTag))]
        public BTInputValueOnly[] PutValue { get; set; }

        [XmlArray(ElementName = "in")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] In { get; set; }

    }
}
