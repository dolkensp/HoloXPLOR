using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TPSQueryCollection")]
    public partial class TPSQueryCollection
    {
        [XmlArray(ElementName = "Queries")]
        [XmlArrayItem(Type = typeof(TPSQuery))]
        public Guid[] Queries { get; set; }

    }
}
