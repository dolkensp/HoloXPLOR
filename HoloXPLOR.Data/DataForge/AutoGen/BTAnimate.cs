using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTAnimate")]
    public partial class BTAnimate : BTNode
    {
        [XmlArray(ElementName = "FragmentID")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] FragmentID { get; set; }

        [XmlArray(ElementName = "FragmentTag")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] FragmentTag { get; set; }

        [XmlArray(ElementName = "SlaveId")]
        [XmlArrayItem(Type = typeof(BTInputGenericId))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdBB))]
        public BTInputGenericId[] SlaveId { get; set; }

        [XmlArray(ElementName = "SlaveId2")]
        [XmlArrayItem(Type = typeof(BTInputGenericId))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdVar))]
        [XmlArrayItem(Type = typeof(BTInputGenericIdBB))]
        public BTInputGenericId[] SlaveId2 { get; set; }

    }
}
