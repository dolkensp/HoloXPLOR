using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTMonitorInLandingArea")]
    public partial class BTMonitorInLandingArea : BTDecorator
    {
        [XmlArray(ElementName = "AreaId")]
        [XmlArrayItem(Type = typeof(BTInputEntityId))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdVar))]
        [XmlArrayItem(Type = typeof(BTInputEntityIdBB))]
        public BTInputEntityId[] AreaId { get; set; }

    }
}
