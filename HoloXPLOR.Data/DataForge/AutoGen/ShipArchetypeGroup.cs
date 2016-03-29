using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "ShipArchetypeGroup")]
    public partial class ShipArchetypeGroup
    {
        [XmlArray(ElementName = "shipArchetypes")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] ShipArchetypes { get; set; }

    }
}
