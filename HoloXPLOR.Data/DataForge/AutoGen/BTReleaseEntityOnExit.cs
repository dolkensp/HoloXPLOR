using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTReleaseEntityOnExit")]
    public partial class BTReleaseEntityOnExit : BTDecorator
    {
        [XmlArray(ElementName = "ObjectSlot")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] ObjectSlot { get; set; }

    }
}
