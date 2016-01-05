using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Vehicles.Implementations
{
    [XmlRoot(ElementName = "Part")]
    public partial class Part
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "class")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "mass")]
        [DefaultValue(0)]
        public Int32 Mass { get; set; }

        [XmlAttribute(AttributeName = "scopeContext")]
        public String ScopeContext { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public String ID { get; set; }
        
        [XmlAttribute(AttributeName = "disablePhysics")]
        [DefaultValue(1)]
        public Int32 __DisablePhysics
        {
            get { return this.DisablePhysics ? 1 : 0; }
            set { this.DisablePhysics = value == 1; }
        }
        [XmlIgnore]
        public Boolean DisablePhysics { get; set; }

        [XmlAttribute(AttributeName = "skipPart")]
        [DefaultValue(0)]
        public Int32 __SkipPart
        {
            get { return this.SkipPart ? 1 : 0; }
            set { this.SkipPart = value == 1; }
        }
        [XmlIgnore]
        public Boolean SkipPart { get; set; }

        [XmlAttribute(AttributeName = "damageMax")]
        [DefaultValue("")]
        public String __DamageMax
        {
            get { return this.DamageMax.ToString(); }
            set { this.DamageMax = value.ToDouble(0D); }
        }
        [XmlIgnore]
        public Double DamageMax { get; set; }

        [XmlArray(ElementName = "Parts")]
        [XmlArrayItem(ElementName = "Part")]
        public Part[] Parts { get; set; }

        [XmlElement(ElementName = "ItemPort")]
        public ItemPort[] ItemPorts { get; set; }

        public override String ToString()
        {
            return String.Format("{0}: {1}", this.Class, this.Name);
        }
    }
}
