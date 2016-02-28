using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeRecord : DataForgeSerializable
    {
        public String Name { get; set; }

        [JsonProperty("StructIndex")]
        public String __structIndex { get { return String.Format("{0:X4}", this.StructIndex); } }
        [JsonIgnore]
        public UInt32 StructIndex { get; set; }

        public Guid? Hash { get; set; }

        [JsonProperty("VariantIndex")]
        public String __variantIndex { get { return String.Format("{0:X4}", this.VariantIndex); } }
        [JsonIgnore]
        public UInt16 VariantIndex { get; set; }

        [JsonProperty("Item1")]
        public String __item1 { get { return String.Format("{0:X4}", this.Item1); } }
        [JsonIgnore]
        public UInt16 Item1 { get; set; }

        public DataForgeRecord(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Name = this.ReadString();
            this.StructIndex = this._br.ReadUInt32();
            this.Hash = this.ReadGuid(false);

            this.VariantIndex = this._br.ReadUInt16();
            this.Item1 = this._br.ReadUInt16();
        }

        public XmlNode Serialize(XmlDocument xmlDocument, String name = null)
        {
            var element = xmlDocument.CreateElement(name ?? this.Name);

            var schema = this.DocumentRoot.StructDefinitionTable[this.StructIndex];

            var attribute = xmlDocument.CreateAttribute("__hash");
            attribute.Value = this.Hash.ToString();
            element.Attributes.Append(attribute);

            var properties = (from index in Enumerable.Range(schema.FirstAttributeIndex, schema.AttributeCount)
                              select this.DocumentRoot.PropertyDefinitionTable[index]);

            foreach (var node in properties)
            {
                if (node.ConversionType == EConversionType.varAttribute)
                {
                    element.Attributes.Append(node.Serialize(xmlDocument) as XmlAttribute);
                }
                else
                {
                    element.AppendChild(node.Serialize(xmlDocument));
                }
            }

            return element;
        }

        public override String ToString()
        {
            return String.Format("<{0} {1:X4} />", this.Name, this.StructIndex);
        }
    }
}
