using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Spaceships
{
    [XmlRoot(ElementName = "item")]
    public partial class Item
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "class")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "category")]
        public String Category { get; set; }

        [XmlAttribute(AttributeName = "interface")]
        public String Interface { get; set; }

        [XmlAttribute(AttributeName = "invisible")]
        [DefaultValue(0)]
        public Int32 __Invisible
        {
            get { return this.Invisible ? 1 : 0; }
            set { this.Invisible = value == 1; }
        }
        [XmlIgnore]
        public Boolean Invisible { get; set; }

        [XmlElement(ElementName = "params")]
        public ParamCollection Params { get; set; }

        [XmlElement(ElementName = "portParams")]
        public PortCollection PortParams { get; set; }

        [XmlArray(ElementName = "Pipes")]
        [XmlArrayItem(ElementName = "Pipe")]
        public Pipe[] Pipes { get; set; }

        // TODO: DamageLevels
        // TODO: Geometry
        // TODO: Add <Pipes><Pipe class/prioType><StateLevels><Warning value><Critical value><Fail value> <States><Pipe name/value><State state/ignorepool/transition><Value value> <Signature name/multiplier>
    }
}