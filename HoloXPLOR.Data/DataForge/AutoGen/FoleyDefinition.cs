using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyDefinition")]
    public partial class FoleyDefinition
    {
        [XmlArray(ElementName = "items")]
        [XmlArrayItem(Type = typeof(FoleyItem))]
        public FoleyItem[] Items { get; set; }

    }
}
