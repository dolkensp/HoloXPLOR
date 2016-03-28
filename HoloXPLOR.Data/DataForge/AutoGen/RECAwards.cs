using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "RECAwards")]
    public partial class RECAwards
    {
        [XmlArray(ElementName = "awards")]
        [XmlArrayItem(Type = typeof(RECAward))]
        public RECAward[] Awards { get; set; }

    }
}
