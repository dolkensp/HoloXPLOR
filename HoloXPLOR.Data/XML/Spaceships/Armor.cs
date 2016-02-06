using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    public partial class Item
    {
        [XmlElement(ElementName = "armor")]
        public Armor Armor { get; set; }
    }

    [XmlRoot(ElementName = "armor")]
    public partial class Armor
    {
        [XmlArray(ElementName = "signalMultipliers")]
        [XmlArrayItem(ElementName = "multipliers")]
        public Param[] Multipliers { get; set; }

        [XmlArray(ElementName = "damageMultipliers")]
        [XmlArrayItem(ElementName = "damageMultiplier")]
        public DamageMultiplier[] DamageMultipliers { get; set; }
    }
}
