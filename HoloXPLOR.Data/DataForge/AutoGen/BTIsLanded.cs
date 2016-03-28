using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTIsLanded")]
    public partial class BTIsLanded : BTNode
    {
        [XmlArray(ElementName = "AreaId")]
        [XmlArrayItem(Type = typeof(BTOutput))]
        public BTOutput[] AreaId { get; set; }

    }
}
