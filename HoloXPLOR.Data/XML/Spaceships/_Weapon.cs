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
        [XmlAttribute(AttributeName = "weaponParams")]
        [DefaultValue(0)]
        public Int32 __WeaponParams
        {
            get { return this.WeaponParams ? 1 : 0; }
            set { this.WeaponParams = value == 1; }
        }
        [XmlIgnore]
        public Boolean WeaponParams { get; set; }

        [XmlElement(ElementName = "defaultLoadout")]
        public Loadout DefaultLoadout { get; set; }
    }
}
