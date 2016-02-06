using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    public partial class Missile : ParamCollection
    {
        public String GuidanceType { get { return this["guidanceType"]; } }

        public Double? TrackingSignalMin{ get { return this["trackingSignalMin"].ToDouble(); } }

        public Double? TrackingSignalAmplifier { get { return this["trackingSignalAmplifier"].ToDouble(); } }

        public Double? TrackingSignalAmplifierSeeking { get { return this["trackingSignalAmplifierSeeking"].ToDouble(); } }

        public String TrackingSignalType { get { return this["trackingSignalType"]; } }

        public Double? TrackerNoiseAmplifier { get { return this["trackerNoiseAmplifier"].ToDouble(); } }

        public Double? TrackingDistanceMax { get { return this["trackingDistanceMax"].ToDouble(); } }

        public Double? TrackingAngle { get { return this["trackingAngle"].ToDouble(); } }

        public Double? LockTime { get { return this["lockTime"].ToDouble(); } }

        public Double? Lifetime { get { return this["lifetime"].ToDouble(); } }

        public Double? Ignitiontime { get { return this["ignitiontime"].ToDouble(); } }

        public Double? MaxSpeed { get { return this["maxSpeed"].ToDouble(); } }

        public Double? ForwardAcceleration { get { return this["forwardAcceleration"].ToDouble(); } }

        public Double? ReverseAcceleration { get { return this["reverseAcceleration"].ToDouble(); } }

        public Double? ManeuverAcceleration { get { return this["maneuverAcceleration"].ToDouble(); } }

        public Double? RotationAcceleration { get { return this["rotationAcceleration"].ToDouble(); } }

        public Double? RotationThrottleAngle { get { return this["rotationThrottleAngle"].ToDouble(); } }

        public Double? ExplodeProximity { get { return this["explodeProximity"].ToDouble(); } }

        public Double? FuelRateAngular { get { return this["fuelRateAngular"].ToDouble(); } }

        public Double? FuelRateLinear { get { return this["fuelRateLinear"].ToDouble(); } }

        public Double? FuelCapacity { get { return this["fuelCapacity"].ToDouble(); } }
    }

    public partial class Explosion : ParamCollection
    {
        public Double? Pressure { get { return this["pressure"].ToDouble(); } }

        public Double? MaxRadius { get { return this["max_radius"].ToDouble(); } }

        public Double? Damage_Physical { get { return this["damage"].ToDouble(); } }

        public Double? Damage_Energy { get { return this["damage_energy"].ToDouble(); } }

        public Double? Damage_Distortion { get { return this["damage_distortion"].ToDouble(); } }
    }

    public partial class Item
    {
        [XmlElement(ElementName = "missile")]
        public Missile Missile { get; set; }

        [XmlElement(ElementName = "explosion")]
        public Explosion Explosion { get; set; }
    }
}
