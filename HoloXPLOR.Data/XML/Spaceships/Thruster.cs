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
        [XmlArray(ElementName = "thrusters")]
        [XmlArrayItem(ElementName = "thruster")]
        public Thruster[] Thrusters { get; set; }
    }

    [XmlRoot(ElementName = "thruster")]
    public partial class Thruster
    {
        [XmlAttribute(AttributeName = "flags")]
        public String Flags { get; set; }

        [XmlAttribute(AttributeName = "maxThrust")]
        public String _maxThrust { get; set; }
        [XmlIgnore]
        public Double MaxThrust { get { return _maxThrust.ToDouble(0); } }

        [XmlAttribute(AttributeName = "boostScale")]
        public String _boostScale { get; set; }
        [XmlIgnore]
        public Double BoostScale { get { return _boostScale.ToDouble(0); } }

        [XmlAttribute(AttributeName = "rotationScale")]
        public String _rotationScale { get; set; }
        [XmlIgnore]
        public Double RotationScale { get { return _rotationScale.ToDouble(0); } }

        //<thrusters>
        //    <thruster flags="maneuver orientation" maxThrust ="1000000" rotationScale="1" boostScale="1.3" >
        //        <exhausts>
        //            <exhaust name ="run" scale ="1" helper="nozzle_exhaust" effectStopThreshold="0.1">
        //                <effect name="Spaceships\Thrusters\AEGS_Thruster_Fixed_Hermes.Thruster_ALL.AEGS_Thruster_Fixed_Hermes" helper="nozzle_exhaust" enable = "0" tag ="run">
        //                    <strength var="thrust" />
        //                </effect>
        //                <sound name="Play_SSTM_AEGS_Thruster_Fixed_Hermes_Start_Run" enable ="0" tag = "run">
        //                    <param name="rpm" var="thrust" lerpTime="1.8" />
        //                    <param name="boost" var="boost" lerpTime="2" />
        //                    <param name="in_out" var="in_out" />
        //                </sound>
        //            </exhaust>
        //        </exhausts>
        //    </thruster>
        //</thrusters>

    }
}
