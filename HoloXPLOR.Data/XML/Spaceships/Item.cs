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

        [XmlIgnore]
        public String HTML_Attributes
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!String.IsNullOrWhiteSpace(this.Params["requiredPortTags", null]))
                    sb.AppendFormat(@" data-item-required-port-tags=""{0}""", this.Params["requiredPortTags", null]);
                if (!String.IsNullOrWhiteSpace(this.Params["itemPortTags", null]))
                    sb.AppendFormat(@" data-item-port-tags=""{0}""", this.Params["itemPortTags", null]);
                if (!String.IsNullOrWhiteSpace(this.Params["itemTags", null]))
                    sb.AppendFormat(@" data-item-tags=""{0}""", this.Params["itemTags", null]);
                if (!String.IsNullOrWhiteSpace(this.Params["itemType", null]))
                    sb.AppendFormat(@" data-item-type=""{0}""", this.Params["itemType", null]);
                if (!String.IsNullOrWhiteSpace(this.Params["itemSubType", null]))
                    sb.AppendFormat(@" data-item-sub-type=""{0}""", this.Params["itemSubType", null]);
                if (!String.IsNullOrWhiteSpace(this.Params["itemSize", null]))
                    sb.AppendFormat(@" data-item-size=""{0}""", this.Params["itemSize", null]);
                
                return sb.ToString();
            }
        }

        // TODO: DamageLevels
        // TODO: Geometry
        // TODO: Add <Pipes><Pipe class/prioType><StateLevels><Warning value><Critical value><Fail value> <States><Pipe name/value><State state/ignorepool/transition><Value value> <Signature name/multiplier>
    }
}