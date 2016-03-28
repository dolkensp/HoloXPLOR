using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTMonitorNotHasEntityStateValue")]
    public partial class BTMonitorNotHasEntityStateValue : BTDecorator
    {
        [XmlArray(ElementName = "Path")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Path { get; set; }

    }
}
