using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    [XmlRoot(ElementName = "params")]
    public partial class ParamCollection
    {
        [XmlIgnore]
        [JsonIgnore]
        public Param[] Items
        {
            get { return (this._Items1 ?? new Param[] { }).Concat(this._Items2 ?? new Param[] { }).ToArray(); }
            set { this._Items1 = value; this._Items2 = new Param[] { }; }
        }

        [XmlElement(ElementName = "param")]
        [JsonIgnore]
        public Param[] _Items1 { get; set; }

        [XmlElement(ElementName = "parm")]
        [JsonIgnore]
        public Param[] _Items2 { get; set; }

        // TODO: Add itemStats

        private Dictionary<String, String> _paramMap;
 
        public String this[String key, String @default = null]
        {
            get
            {
                this._paramMap = this._paramMap ?? this.Items.ToDictionary(k => k.Name, v => v.Value);

                return this._paramMap.GetValue(key, @default);
            }
            set
            {
                this._paramMap = this._paramMap ?? this.Items.ToDictionary(k => k.Name, v => v.Value);
                this._paramMap[key] = value;
            }
        }
    }
}
