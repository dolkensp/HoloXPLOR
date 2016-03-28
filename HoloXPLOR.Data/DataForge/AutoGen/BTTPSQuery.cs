using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTTPSQuery")]
    public partial class BTTPSQuery : BTNode
    {
        [XmlArray(ElementName = "QueryName")]
        [XmlArrayItem(Type = typeof(BTInputString))]
        [XmlArrayItem(Type = typeof(BTInputStringValue))]
        [XmlArrayItem(Type = typeof(BTInputStringVar))]
        [XmlArrayItem(Type = typeof(BTInputStringBB))]
        public BTInputString[] QueryName { get; set; }

        [XmlArray(ElementName = "QueryResult")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] QueryResult { get; set; }

        [XmlArray(ElementName = "CoverID")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] CoverID { get; set; }

    }
}
