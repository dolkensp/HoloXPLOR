using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSQueryCollection")]
    public partial class TPSQueryCollection
    {
        [XmlArray(ElementName = "Queries")]
        [XmlArrayItem(ElementName = "Reference", Type=typeof(_Reference))]
        public _Reference[] Queries { get; set; }

    }
}
