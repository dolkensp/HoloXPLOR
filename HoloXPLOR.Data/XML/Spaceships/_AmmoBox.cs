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
        [XmlElement(ElementName = "ammoBox")]
        public AmmoCollection AmmoBox { get; set; }
    }

    public partial class AmmoCollection : ParamCollection
    {
        [XmlIgnore]
        [JsonProperty("AmmoType")]
        public String AmmoName { get { return this["ammo_name"]; } }

        [XmlIgnore]
        public Int32? MaxAmmo { get { return this["max_ammo_count"].ToInt16(); } }
    }
}
