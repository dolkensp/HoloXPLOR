using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "LoadoutAttachment")]
    public partial class LoadoutAttachment
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "portName")]
        public String PortName { get; set; }

    }
}
