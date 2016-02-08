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
    public partial class FireMode
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public String Type { get; set; }

        [XmlElement(ElementName = "fire")]
        public FireCollection Fire { get; set; }

        [XmlElement(ElementName = "burst")]
        public BurstCollection Burst { get; set; }

        [XmlElement(ElementName = "rapid")]
        public RapidCollection Rapid { get; set; }

        [XmlElement(ElementName = "spread")]
        public ParamCollection Spread { get; set; }

        [XmlArray(ElementName = "pools")]
        [XmlArrayItem(ElementName = "pool")]
        public Pool[] Pools { get; set; }
    }

    public partial class FireCollection : ParamCollection
    {
        [XmlIgnore]
        public String AmmoType { get { return this["ammo_type"]; } }

        [XmlIgnore]
        public Double? Rate { get { return this["rate"].ToDouble(); } }

        [XmlIgnore]
        public Double? ClipSize { get { return this["clip_size"].ToDouble(); } }

        [XmlIgnore]
        public Double? MaxClips { get { return this["max_clips"].ToDouble(); } }
    }

    public partial class BurstCollection : ParamCollection
    {
        [XmlIgnore]
        public Double? Rate { get { return this["rate"].ToDouble(); } }

        [XmlIgnore]
        public Double? BurstSize { get { return this["nshots"].ToDouble(); } }
    }

    public partial class RapidCollection : ParamCollection
    {
        [XmlIgnore]
        public Double? MinRate { get { return this["min_rate"].ToDouble(); } }

        [XmlIgnore]
        public Double? MinSpeed { get { return this["min_speed"].ToDouble(); } }

        [XmlIgnore]
        public Double? MaxSpeed { get { return this["max_speed"].ToDouble(); } }

        [XmlIgnore]
        public Double? Acceleration { get { return this["acceleration"].ToDouble(); } }

        [XmlIgnore]
        public Double? Decelaration { get { return this["deceleration"].ToDouble(); } }
    }

    public partial class SpreadCollection : ParamCollection
    {
        [XmlIgnore]
        public Double? Min { get { return this["min"].ToDouble(); } }

        [XmlIgnore]
        public Double? Max { get { return this["max"].ToDouble(); } }

        [XmlIgnore]
        public Double? Attack { get { return this["attack"].ToDouble(); } }

        [XmlIgnore]
        public Double? DecayRate { get { return this["decayRate"].ToDouble(); } }

        [XmlIgnore]
        public Double? Decay { get { return this["decay"].ToDouble(); } }

        [XmlIgnore]
        public Double? Instability { get { return this["instability"].ToDouble(); } }
    }

    public partial class Pool
    {
        [XmlAttribute(AttributeName = "class")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public String Value { get; set; }
    }

    public partial class Item
    {
        [XmlAttribute(AttributeName = "weaponParams")]
        [JsonIgnore]
        [DefaultValue(0)]
        public Int32 __WeaponParams
        {
            get { return this.WeaponParams ? 1 : 0; }
            set { this.WeaponParams = value == 1; }
        }
        [XmlIgnore]
        public Boolean WeaponParams { get; set; }

        // TODO: Consider if we want to preserve this to allow filling ammo boxes easily
        [XmlElement(ElementName = "defaultLoadout")]
        [JsonIgnore]
        public Loadout DefaultLoadout { get; set; }

        [XmlArray(ElementName = "firemodes")]
        [XmlArrayItem(ElementName = "firemode")]
        public FireMode[] FireModes { get; set; }

    }
}
