using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    [XmlRoot(ElementName = "Pool")]
    public partial class PipePool
    {
        [XmlAttribute(AttributeName = "capacity")]
        public String _capacity { get; set; }
        [XmlIgnore]
        public Double Capacity { get { return this._capacity.ToDouble(0); } }

        [XmlAttribute(AttributeName = "rate")]
        public String _rate { get; set; }
        [XmlIgnore]
        public Double Rate { get { return this._rate.ToDouble(0); } }
        
        [XmlAttribute(AttributeName = "critical")]
        public String _critical { get; set; }
        [XmlIgnore]
        public Double Critical { get { return this._critical.ToDouble(0); } }
    }

    [XmlRoot(ElementName = "Pipe")]
    public partial class Pipe
    {
        [XmlAttribute(AttributeName = "class")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "allowThrottle")]
        [DefaultValue(0)]
        public Int32 __AllowThrottle
        {
            get { return this.AllowThrottle ? 1 : 0; }
            set { this.AllowThrottle = value == 1; }
        }
        [XmlIgnore]
        public Boolean AllowThrottle { get; set; }

        [XmlElement(ElementName = "Pool")]
        public PipePool Pool { get; set; }

        // TODO: Signature
        // TODO: States>State>Value
        // TODO: States>State>Pipe*

        // <Pipes>
        //    <Pipe class="Power" prioType="manageable" prioGroup="shield">
        //            <Signature name="Electromagnetic" multiplier="0.25" />
        //            <Pool capacity="-800" rate="-120" critical="1"/>
        //      <StateLevels>
        //        <Warning  value = "0.50" />
        //        <Critical value = "0.25" />
        //        <Fail     value = "0.01" />
        //      </StateLevels>

        //      <States>
        //        <State state="Default">
        //          <Value value="-10"	/><!-- Base consumption -->
        //          <!-- <Variable name="allocated_hitpoints" value="-1" critical="0"/> --><!-- 1 unit of shield hitpoints allocated = 1 units of power -->
        //          <Variable name="total_regen" value="-15" critical="0"/><!-- 1 unit of shield regen allocated = 0.1 units of power -->
        //        </State>
        //          <State state="Off">
        //              <Value value="0" />
        //          </State>
        //      </States>
        //    </Pipe>
        //      <Pipe class="Heat" prioType="manageable" prioGroup="shield">
        //      <Signature name="Infrared" poolMultiplier="0.1" />
        //      <Pool capacity="100" rate="5.5" critical="1"/>
        //      <States>
        //        <State state="Default"><Value value="5.5" /></State>
        //      </States>
        //    </Pipe>
        //</Pipes>

    }
}
