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
        public UInt32 NameOffset { get; set; }
        public String Name { get { return this.DocumentRoot.ValueMap[this.NameOffset]; } }

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
            this.NameOffset = this._br.ReadUInt32();
            this.ParentTypeIndex = this._br.ReadUInt32();
            this.AttributeCount = this._br.ReadUInt16();
            this.FirstAttributeIndex = this._br.ReadUInt16();
            this.NodeType = this._br.ReadUInt32();
        }

        public XmlElement Read(String name = null)
        {
            XmlAttribute attribute;
            var element = this.DocumentRoot.CreateElement(name ?? this.Name);

            var baseStruct = this;
            var properties = new List<DataForgePropertyDefinition> { };

            // TODO: Do we need to handle property overrides

            properties.InsertRange(0,
                from index in Enumerable.Range(this.FirstAttributeIndex, this.AttributeCount)
                let property = this.DocumentRoot.PropertyDefinitionTable[index]
                // where !properties.Select(p => p.Name).Contains(property.Name)
                select property);

            while (baseStruct.ParentTypeIndex != 0xFFFFFFFF)
            {
                baseStruct = this.DocumentRoot.StructDefinitionTable[baseStruct.ParentTypeIndex];

                properties.InsertRange(0,
                    from index in Enumerable.Range(baseStruct.FirstAttributeIndex, baseStruct.AttributeCount)
                    let property = this.DocumentRoot.PropertyDefinitionTable[index]
                    // where !properties.Contains(property)
                    select property);
            }

            var globalOffset = this._br.BaseStream.Position;
            var localOffset = this._br.BaseStream.Position - 0x00096027;

            foreach (var node in properties)
            {
                if (node.ConversionType == EConversionType.varAttribute)
                {
                    if (node.DataType == EDataType.varClass)
                    {
                        var dataStruct = this.DocumentRoot.StructDefinitionTable[node.StructIndex];
                        
                        var child = dataStruct.Read(node.Name);

                        element.AppendChild(child);
                    }
                    else
                    {
                        element.Attributes.Append(node.Read());
                    }
                }
                else
                {
                    var arrayCount = this._br.ReadUInt32();
                    var firstIndex = this._br.ReadUInt32();

                    var child = this.DocumentRoot.CreateElement(node.Name);

                    for (var i = 0; i < arrayCount; i++)
                    {
                        switch (node.DataType)
                        {
                            case EDataType.varBoolean:
                                child.AppendChild(this.DocumentRoot.Array_BooleanValues[firstIndex + i].Read());
                                break;
                            case EDataType.varDouble:
                                child.AppendChild(this.DocumentRoot.Array_DoubleValues[firstIndex + i].Read());
                                break;
                            case EDataType.varEnum:
                                child.AppendChild(this.DocumentRoot.Array_EnumValues[firstIndex + i].Read());
                                break;
                            case EDataType.varGuid:
                                child.AppendChild(this.DocumentRoot.Array_GuidValues[firstIndex + i].Read());
                                break;
                            case EDataType.varInt16:
                                child.AppendChild(this.DocumentRoot.Array_Int16Values[firstIndex + i].Read());
                                break;
                            case EDataType.varInt32:
                                child.AppendChild(this.DocumentRoot.Array_Int32Values[firstIndex + i].Read());
                                break;
                            case EDataType.varInt64:
                                child.AppendChild(this.DocumentRoot.Array_Int64Values[firstIndex + i].Read());
                                break;
                            case EDataType.varInt8:
                                child.AppendChild(this.DocumentRoot.Array_Int8Values[firstIndex + i].Read());
                                break;
                            case EDataType.varLocale:
                                child.AppendChild(this.DocumentRoot.Array_LocaleValues[firstIndex + i].Read());
                                break;
                            case EDataType.varReference:
                                child.AppendChild(this.DocumentRoot.Array_ReferenceValues[firstIndex + i].Read());
                                break;
                            case EDataType.varSingle:
                                child.AppendChild(this.DocumentRoot.Array_SingleValues[firstIndex + i].Read());
                                break;
                            case EDataType.varString:
                                child.AppendChild(this.DocumentRoot.Array_StringValues[firstIndex + i].Read());
                                break;
                            case EDataType.varUInt16:
                                child.AppendChild(this.DocumentRoot.Array_UInt16Values[firstIndex + i].Read());
                                break;
                            case EDataType.varUInt32:
                                child.AppendChild(this.DocumentRoot.Array_UInt32Values[firstIndex + i].Read());
                                break;
                            case EDataType.varUInt64:
                                child.AppendChild(this.DocumentRoot.Array_UInt64Values[firstIndex + i].Read());
                                break;
                            case EDataType.varUInt8:
                                child.AppendChild(this.DocumentRoot.Array_UInt8Values[firstIndex + i].Read());
                                break;
                            default:
                                var tempe = this.DocumentRoot.CreateElement(String.Format("{0}", node.DataType));
                                var tempa = this.DocumentRoot.CreateAttribute("__index");
                                tempa.Value = (firstIndex + i).ToString();
                                tempe.Attributes.Append(tempa);
                                child.AppendChild(tempe);
                                break;
                        }
                    }

                    element.AppendChild(child);
                }
            }

            attribute = this.DocumentRoot.CreateAttribute("__type");
            attribute.Value = baseStruct.Name;
            element.Attributes.Append(attribute);

            if (this.ParentTypeIndex != 0xFFFFFFFF)
            {
                attribute = this.DocumentRoot.CreateAttribute("__polymorphicType");
                attribute.Value = this.Name;
                element.Attributes.Append(attribute);
            }

            // attribute = this.DocumentRoot.CreateAttribute("__globalOffset");
            // attribute.Value = String.Format("{0:X8}", globalOffset);
            // element.Attributes.Append(attribute);

            // attribute = this.DocumentRoot.CreateAttribute("__offset");
            // attribute.Value = String.Format("{0:X8}", localOffset);
            // element.Attributes.Append(attribute);

            return element;
        }

        public override String ToString()
        {
            return String.Format("<{0} />", this.Name);
        }
    }
}
