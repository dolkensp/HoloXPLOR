using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemRoomParams")]
    public partial class SCItemRoomParams : SCItemComponentParams
    {
        [XmlElement(ElementName = "objectContainer")]
        public GlobalResourceObjectContainer ObjectContainer { get; set; }

    }
}
