using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    [XmlRoot(ElementName = "Pipe")]
    public partial class Pipe
    {
        [XmlAttribute(AttributeName = "class")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "allowThrottle")]
        [DefaultValue(0)]
        public Int32 __AllowThrottle
        {
            get { return this.AllowThrottle ? 1 : 0; }
            set { this.AllowThrottle = value == 1; }
        }
        [XmlIgnore]
        public Boolean AllowThrottle { get; set; }

        // TODO: Signature
        // TODO: States>State>Value
        // TODO: States>State>Pipe*
    }
}
