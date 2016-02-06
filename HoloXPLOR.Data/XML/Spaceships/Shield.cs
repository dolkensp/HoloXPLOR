using Newtonsoft.Json;
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
        [XmlElement("shield")]
        public Shield Shields { get; set; }
    }

    [XmlRoot(ElementName = "shield")]
    public partial class Shield
    {
        [XmlElement(ElementName = "data")]
        [JsonIgnore]
        public ParamCollection Data { get; set; }

        public String FaceType { get { return this.Data["shieldFaceType", String.Empty]; } }

        public Double? MaxHitPoints { get { return this.Data["shieldMaxHitpoints"].ToDouble(); } }

        public Double? MaxRegenRate { get { return this.Data["shieldMaxRegenRate"].ToDouble(); } }

        public Double? RegenDelay { get { return this.Data["shieldRegenDelay"].ToDouble(); } }

        public Double? MaxHitPointShift { get { return this.Data["shieldMaxHPShift"].ToDouble(); } }

        public Double? MaxRegenShift { get { return this.Data["shieldMaxRegenShift"].ToDouble(); } }

        public Double? HitPointAllocationRate { get { return this.Data["shieldHpAllocRate"].ToDouble(); } }

        public Double? Physical_DamageAbsorbDirect { get { return this.Data["shieldDamageAbsorbFactor"].ToDouble(); } }

        public Double? Energy_DamageAbsorbDirect { get { return this.Data["shieldDamageAbsorbFactor_Energy"].ToDouble(); } }

        public Double? Distortion_DamageAbsorbDirect { get { return this.Data["shieldDamageAbsorbFactor_Distortion"].ToDouble(); } }

        public Double? Physical_DamageAbsorbSplash { get { return this.Data["shieldDamageAbsorbSplashFactor"].ToDouble(); } }

        public Double? Energy_DamageAbsorbSplash { get { return this.Data["shieldDamageAbsorbSplashFactor_Energy"].ToDouble(); } }

        public Double? Distortion_DamageAbsorbSplash { get { return this.Data["shieldDamageAbsorbSplashFactor_Distortion"].ToDouble(); } }
    }
}
