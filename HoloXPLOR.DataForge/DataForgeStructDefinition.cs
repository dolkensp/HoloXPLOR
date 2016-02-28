using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeStructDefinition : DataForgeSerializable
    {
        public String Name { get; set; }

        [JsonProperty("ParentTypeIndex")]
        public String __parentTypeIndex { get { return String.Format("{0:X4}", this.ParentTypeIndex); } }
        [JsonIgnore]
        public UInt32 ParentTypeIndex { get; set; }
        [JsonProperty("AttributeCount")]
        public String __attributeCount { get { return String.Format("{0:X4}", this.AttributeCount); } }
        [JsonIgnore]
        public UInt16 AttributeCount { get; set; }
        [JsonProperty("FirstAttributeIndex")]
        public String __firstAttributeIndex { get { return String.Format("{0:X4}", this.FirstAttributeIndex); } }
        [JsonIgnore]
        public UInt16 FirstAttributeIndex { get; set; }
        [JsonProperty("NodeType")]
        public String __nodeType { get { return String.Format("{0:X4}", this.NodeType); } }
        [JsonIgnore]
        public UInt32 NodeType { get; set; }

        public DataForgeStructDefinition(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Name = this.ReadString();
            this.ParentTypeIndex = this._br.ReadUInt32();
            this.AttributeCount = this._br.ReadUInt16();
            this.FirstAttributeIndex = this._br.ReadUInt16();
            this.NodeType = this._br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("<{0} />", this.Name);
        }

        public XmlNode Serialize(XmlDocument xmlDocument, String name = null)
        {
            var baseStruct = this;
            var properties = new List<DataForgePropertyDefinition> { };

            var element = xmlDocument.CreateElement(name ?? this.Name);

            while (baseStruct.ParentTypeIndex != 0xFFFFFFFF)
            {
                baseStruct = this.DocumentRoot.StructDefinitionTable[baseStruct.ParentTypeIndex];

                properties.AddRange(from index in Enumerable.Range(this.FirstAttributeIndex, this.AttributeCount)
                                    select this.DocumentRoot.PropertyDefinitionTable[index]);
            }

            var attribute = xmlDocument.CreateAttribute("__type");
            attribute.Value = baseStruct.Name;
            element.Attributes.Append(attribute);

            if (this.ParentTypeIndex != 0xFFFFFFFF)
            {
                attribute = xmlDocument.CreateAttribute("__polymorphicType");
                attribute.Value = this.Name;
                element.Attributes.Append(attribute);
            }

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

        public XmlElement Read()
        {
            var element = this.DocumentRoot.CreateElement(this.Name);

            var baseStruct = this;
            var properties = new List<DataForgePropertyDefinition> { };

            properties.AddRange(
                 from index in Enumerable.Range(this.FirstAttributeIndex, this.AttributeCount)
                 select this.DocumentRoot.PropertyDefinitionTable[index]);

            while (baseStruct.ParentTypeIndex != 0xFFFFFFFF)
            {
                baseStruct = this.DocumentRoot.StructDefinitionTable[baseStruct.ParentTypeIndex];

                properties.AddRange(from index in Enumerable.Range(baseStruct.FirstAttributeIndex, baseStruct.AttributeCount)
                                    let property = this.DocumentRoot.PropertyDefinitionTable[index]
                                    where !properties.Contains(property)
                                    select property);
            }

            
            var attribute = this.DocumentRoot.CreateAttribute("__type");
            attribute.Value = baseStruct.Name;
            element.Attributes.Append(attribute);

            attribute = this.DocumentRoot.CreateAttribute("__globalOffset");
            attribute.Value = String.Format("{0:X8}", this._br.BaseStream.Position);
            element.Attributes.Append(attribute);

            attribute = this.DocumentRoot.CreateAttribute("__offset");
            attribute.Value = String.Format("{0:X8}", this._br.BaseStream.Position - 0x00096027);
            element.Attributes.Append(attribute);

            if (this.ParentTypeIndex != 0xFFFFFFFF)
            {
                attribute = this.DocumentRoot.CreateAttribute("__polymorphicType");
                attribute.Value = this.Name;
                element.Attributes.Append(attribute);
            }

            foreach (var node in properties)
            {
                if (node.ConversionType == EConversionType.varAttribute)
                {
                    element.Attributes.Append(node.Read());
                }
                else
                {
                    attribute = this.DocumentRoot.CreateAttribute(String.Format("{0}Count", node.Name));
                    attribute.Value = String.Format("{0:X4}", this._br.ReadUInt64());
                    element.Attributes.Append(attribute);
                }
            }

            return element;
        }
    }
}
