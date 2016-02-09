using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    [XmlRoot(ElementName = "ammo")]
    public partial class Ammo
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "class")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "interface")]
        public String Interface { get; set; }

        [XmlElement(ElementName = "flags")]
        public ParamCollection Flags { get; set; }

        [XmlElement(ElementName = "physics")]
        public PhysicsCollection Physics { get; set; }

        [XmlElement(ElementName = "params")]
        public ParamCollection Params { get; set; }

        [XmlElement(ElementName = "explosion")]
        public Explosion Explosion { get; set; }

        [XmlIgnore]
        public Double? Lifetime { get { return this.Params["lifetime"].ToDouble(); } }

        [XmlIgnore]
        public Double? Damage_Physical { get { return this.Params["damage"].ToDouble(); } }

        [XmlIgnore]
        public Double? Damage_Energy { get { return this.Params["damage_energy"].ToDouble(); } }

        [XmlIgnore]
        public Double? Damage_Distortion { get { return this.Params["damage_distortion"].ToDouble(); } }

        [XmlIgnore]
        public Double? DamageRadius { get { return this.Params["damage_radius"].ToDouble(); } }
    }

    public partial class PhysicsCollection : ParamCollection
    {
        [XmlAttribute(AttributeName = "type")]
        public String Type { get; set; }

        [XmlIgnore]
        public Double? Mass { get { return this["mass"].ToDouble(); } }

        [XmlIgnore]
        public Double? Speed { get { return this["speed"].ToDouble(); } }

        [XmlIgnore]
        public Double? Radius { get { return this["radius"].ToDouble(); } }

        //    <physics type="particle">
        //        <param name="mass" value="1.2" />
        //        <param name="speed" value="1340" />
        //        <param name="radius" value="0.1" />
        //        <param name="air_resistance" value="0" />
        //        <param name="water_resistance" value="0" />
        //        <param name="gravity" value="0, 0, 0" />
        //        <param name="water_gravity" value="0, 0, 0" />
        //        <param name="material" value="metal_dense" />
        //        <param name="pierceability" value="14" />
        //        <param name="no_spin" value="1"/>
        //        <param name="single_contact" value="1" />
        //        <param name="no_path_alignment" value="1"/>
        //        <param name="constant_orientation" value="1"/>
        //        <param name="no_self_collisions" value="1"/>
        //    </physics>
    }
}
