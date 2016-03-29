using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GameTokens")]
    public partial class GameTokens
    {
        [XmlArray(ElementName = "GameTokenLibraries")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] GameTokenLibraries { get; set; }

        [XmlArray(ElementName = "FlowGraphs")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] FlowGraphs { get; set; }

    }
}
