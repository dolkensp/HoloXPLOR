using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTHandleExceptionSuccess")]
    public partial class BTHandleExceptionSuccess : BTDecorator
    {
        [XmlArray(ElementName = "Type")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] Type { get; set; }

    }
}
