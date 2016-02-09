using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    public partial class Item
    {
        [XmlElement(ElementName = "turretParams")]
        public TurretParams Turret { get; set; }
    }

    public partial class TurretParams
    {
        [XmlElement(ElementName = "yaw")]
        public PitchYawRoll Yaw { get; set; }

        [XmlElement(ElementName = "pitch")]
        public PitchYawRoll Pitch { get; set; }

        [XmlElement(ElementName = "roll")]
        public PitchYawRoll Roll { get; set; }
    }

    public partial class PitchYawRoll
    {
        [XmlAttribute(AttributeName = "limits")]
        [JsonIgnore]
        public String _Limit { get; set; }

        [XmlAttribute(AttributeName = "speed")]
        [JsonIgnore]
        public String _Speed { get; set; }

        [XmlIgnore]
        public Double? Min { get { return ((this._Limit ?? String.Empty).Split(',').FirstOrDefault() ?? String.Empty).ToDouble(); } }
        
        [XmlIgnore]
        public Double? Max { get { return ((this._Limit ?? String.Empty).Split(',').LastOrDefault() ?? String.Empty).ToDouble(); } }

        [XmlIgnore]
        public Double? Speed { get { return this._Speed.ToDouble(); } }
    }
}
