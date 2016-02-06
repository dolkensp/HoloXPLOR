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

        
 //<firemodes>
 //   <firemode name="Weapon" type="Burst">
 //    <!-- 4 shots over 1 second, 1.5 seconds between button presses-->
 //     <fire>
 //       <param name="rate" value="240" />
 //       <param name="clip_size" value="0" /> <!-- Clip size needs to be 0 for CounterMeasures to work -->
 //       <param name="muzzleFromFiringLocator" value="1" /> <!-- turning off muzzle flashes form following the barrels -->.
 //       <param name="fireLocatorType" value = "default" />
 //     </fire>
	  
 //     <burst>
 //       <param name="rate" value="40" />
 //       <param name="nshots" value="4" />
 //       <param name="noSound" value="0" />
 //       <param name="retriggeronhold" value="0" />
 //       <param name="spreadAngle" value="120" />
 //     </burst>

 //     <muzzleflash>
 //       <!-- Muzzle Flash only needs to be applied on the first muzzle. Barrels will handle moving the muzzle flash over -->
 //       <!--         <firstperson effect="spaceships\counter_measures\counter_measures_generic.Chaff_A_Launch_ALL.Chaff_A_Launch_01"/>
 //       <thirdperson effect="spaceships\counter_measures\counter_measures_generic.Chaff_A_Launch_ALL.Chaff_A_Launch_01"/> -->
 //     </muzzleflash>
 //   </firemode>
 // </firemodes>



 
  //<firemodes>
  //  <firemode name="Auto" type="Automatic">
  //    <fire>
  //      <param name="ammo_type" value="BEHR_LaserCannon_S3_AMMO" />
  //      <param name="rate" value="160" />
  //      <param name="clip_size" value="-1" />
  //      <param name="max_clips" value="0" />
  //      <param name="nearmiss_signal" value="OnNearMiss" />
  //      <param name="helper_fp" value="muzzle_out" />
  //      <param name="helper_tp" value="muzzle_out" />
  //      <param name="fireLocatorType" value = "circle" />
  //      <param name="start_fire_audio_trigger" value="Play_WPHA_BEHR_LaserCannon_S2_Fire_Placeholder" />
  //      <param name="stop_fire_audio_trigger" value="" />
  //      <param name="audio_looped" value="0" />
  //    </fire>
  //    <spread>
  //      <param name="min" value="0" />
  //      <param name="max" value="0.25" />
  //      <param name="attack" value="0.075" />
  //      <param name="decayRate" value="0.06" />
  //      <param name="instability" value="0.15" />
  //    </spread>

  //    <pools>
  //      <!-- This is Pool manipulation per shot -->
  //      <pool class="Power" value="-50" />
  //      <pool class="Heat" value="26" />
  //    </pools>
  //  </firemode>
  //</firemodes>

    }
}
