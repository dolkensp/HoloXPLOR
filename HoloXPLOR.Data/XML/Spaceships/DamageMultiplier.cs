using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    [XmlRoot(ElementName = "damageMultiplier")]
    public partial class DamageMultiplier
    {
        [XmlAttribute(AttributeName = "damageType")]
        public String DamageType { get; set; }
        
        [XmlAttribute(AttributeName = "multiplier_physical")]
        public Double Physical { get; set; }
        
        [XmlAttribute(AttributeName = "multiplier_energy")]
        public Double Energy { get; set; }
        
        [XmlAttribute(AttributeName = "multiplier_distortion")]
        public Double Distortion { get; set; }
    }
}
