using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DFMCriticalInfo_Config")]
    public partial class DFMCriticalInfo_Config
    {
        [XmlAttribute(AttributeName = "StackSize")]
        public Byte StackSize { get; set; }

        [XmlArray(ElementName = "Notify")]
        [XmlArrayItem(Type = typeof(DFMCriticalInfo_Notify))]
        public DFMCriticalInfo_Notify[] Notify { get; set; }

    }
}
