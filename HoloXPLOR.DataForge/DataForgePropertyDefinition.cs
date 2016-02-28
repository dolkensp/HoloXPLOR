using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    // TODO: Verify this
    public class DataForgePropertyDefinition : DataForgeSerializable
    {
        public String Name { get; set; }
        public UInt16 SchemaIndex { get; set; }
        public EDataType DataType { get; set; }
        public EConversionType ConversionType { get; set; }
        public UInt16 Padding { get; set; }

        public DataForgePropertyDefinition(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Name = this.ReadString();
            this.SchemaIndex = this._br.ReadUInt16();
            this.DataType = (EDataType)this._br.ReadUInt16();
            this.ConversionType = (EConversionType)this._br.ReadUInt16();
            this.Padding = this._br.ReadUInt16();
        }

        public XmlNode Serialize(XmlDocument xmlDocument, String name = null)
        {
            if (this.DataType == EDataType.varClass ||
                this.DataType == EDataType.varReference ||
                this.DataType == EDataType.varStrongPointer ||
                this.DataType == EDataType.varWeakPointer ||
                this.DataType == EDataType.varLocale ||
                this.ConversionType == EConversionType.varSimpleArray ||
                this.ConversionType == EConversionType.varComplexArray)
            {
                var elementType = this.DocumentRoot.StructDefinitionTable[this.SchemaIndex];

                XmlElement element = this.CreateElement(xmlDocument, name ?? this.Name);

                return element;
            }
            else
            {
                XmlAttribute attribute = xmlDocument.CreateAttribute(name ?? this.Name);

                switch (this.DataType)
                {
                    case EDataType.varString:
                        attribute.Value = this.ReadString();
                        break;
                    case EDataType.varBoolean:
                        attribute.Value = this._br.ReadBoolean() ? "1" : "0";
                        break;
                    case EDataType.varSingle:
                        attribute.Value = this._br.ReadSingle().ToString();
                        break;
                    case EDataType.varDouble:
                        attribute.Value = this._br.ReadDouble().ToString();
                        break;
                    case EDataType.varGuid:
                        attribute.Value = this.ReadGuid(false).ToString();
                        break;
                    case EDataType.varInt8:
                        attribute.Value = this._br.ReadByte().ToString();
                        break;
                    case EDataType.varInt16:
                        attribute.Value = this._br.ReadInt16().ToString();
                        break;
                    case EDataType.varInt32:
                        attribute.Value = this._br.ReadInt32().ToString();
                        break;
                    case EDataType.varInt64:
                        attribute.Value = this._br.ReadInt64().ToString();
                        break;
                    case EDataType.varUInt8:
                        attribute.Value = this._br.ReadByte().ToString();
                        break;
                    case EDataType.varUInt16:
                        attribute.Value = this._br.ReadUInt16().ToString();
                        break;
                    case EDataType.varUInt32:
                        attribute.Value = this._br.ReadUInt32().ToString();
                        break;
                    case EDataType.varUInt64:
                        attribute.Value = this._br.ReadUInt32().ToString();
                        break;
                    case EDataType.varEnum:
                        var enumDefinition = this.DocumentRoot.EnumDefinitionTable[this.SchemaIndex];
                        attribute.Value = this.DocumentRoot.EnumOptionTable[enumDefinition.FirstValueIndex + this._br.ReadByte()].Value;
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return attribute;
            }
        }

        public XmlElement CreateElement(XmlDocument xmlDocument, String name = null)
        {
            var element = xmlDocument.CreateElement(name ?? this.Name);

            XmlElement item;
            UInt64 arrayCount = 0x0001;

            var schema = this.DocumentRoot.StructDefinitionTable[this.SchemaIndex];

            switch (this.ConversionType)
            {
                #region Complex Array

                case EConversionType.varComplexArray:
                    {
                        var count = this.DocumentRoot.DataMappingTable.Where(sc => sc.StructIndex == this.SchemaIndex).FirstOrDefault();
                        if (count != null)
                        {
                            arrayCount = count.StructCount;
                        }

                        for (UInt64 i = 0; i < arrayCount; i++)
                        {
                            element.AppendChild(schema.Serialize(xmlDocument));

                            // item = xmlDocument.CreateElement(this.Name);
                            // element.AppendChild(item);
                        }
                    }
                    break;

                #endregion

                #region Simple Array

                case EConversionType.varSimpleArray:
                    {
                        // arrayCount = this.DocumentRoot.SchemaCountTable[this.TypeIndex];

                        arrayCount = this._br.ReadUInt64();

                        for (UInt64 i = 0; i < arrayCount; i++)
                        {
                            if (this.DataType == EDataType.varEnum)
                            {
                                // TODO: Read array here
                                item = xmlDocument.CreateElement(this.DataType.ToString());
                                var attribute = xmlDocument.CreateAttribute("__type");
                                attribute.Value = this.DocumentRoot.EnumDefinitionTable[this.SchemaIndex].Name;
                                item.Attributes.Append(attribute);
                            }
                            else
                            {
                                item = xmlDocument.CreateElement(this.DataType.ToString());
                            }

                            element.AppendChild(item);
                        }
                    }
                    break;

                #endregion

                #region Attribute

                case EConversionType.varAttribute:
                    {
                        var properties = (from index in Enumerable.Range(schema.FirstAttributeIndex, schema.AttributeCount)
                                          select this.DocumentRoot.PropertyDefinitionTable[index].Serialize(xmlDocument)).ToList();

                        foreach (var node in properties)
                        {
                            if (node is XmlAttribute)
                            {
                                element.Attributes.Append(node as XmlAttribute);
                            }
                            else
                            {
                                element.AppendChild(node);
                            }
                        }
                    }
                    break;

                #endregion
            }

            return element;
        }

        public override String ToString()
        {
            return String.Format("<{0} />", this.Name);
        }

        public XmlAttribute Read()
        {
            if (this.ConversionType == EConversionType.varSimpleArray ||
                this.ConversionType == EConversionType.varComplexArray)
            {
                throw new NotImplementedException();
            }
            else
            {
                XmlAttribute attribute = this.DocumentRoot.CreateAttribute(this.Name);

                switch (this.DataType)
                {
                    case EDataType.varClass:
                        attribute.Value = String.Format("{0}:{1:X8}", this.DataType, this._br.ReadInt32());
                        break;
                    case EDataType.varReference:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this.DocumentRoot.Array_ReferenceValues[this._br.ReadInt32()].Value);
                        break;
                    case EDataType.varLocale:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this.DocumentRoot.Array_LocaleValues[this._br.ReadInt32()].Value);
                        break;
                    case EDataType.varStrongPointer:
                        attribute.Value = String.Format("{0}:{1:X8}", this.DataType, this.ReadString()); // _br.ReadInt32());
                        break;
                    case EDataType.varWeakPointer:
                        attribute.Value = String.Format("{0}:{1:X8}", this.DataType, this._br.ReadInt32());
                        break;
                    case EDataType.varString:
                        attribute.Value = this.ReadString();
                        break;
                    case EDataType.varBoolean:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadBoolean() ? "1" : "0");
                        break;
                    case EDataType.varSingle:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadSingle());
                        break;
                    case EDataType.varDouble:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadDouble());
                        break;
                    case EDataType.varGuid:
                        attribute.Value = this.ReadGuid(false).ToString();
                        break;
                    case EDataType.varInt8:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadSByte());
                        break;
                    case EDataType.varInt16:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadInt16());
                        break;
                    case EDataType.varInt32:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadInt32());
                        break;
                    case EDataType.varInt64:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadInt64());
                        break;
                    case EDataType.varUInt8:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadByte());
                        break;
                    case EDataType.varUInt16:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadUInt16());
                        break;
                    case EDataType.varUInt32:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadUInt32());
                        break;
                    case EDataType.varUInt64:
                        attribute.Value = String.Format("{0}:{1}", this.DataType, this._br.ReadUInt32());
                        break;
                    case EDataType.varEnum:
                        var enumDefinition = this.DocumentRoot.EnumDefinitionTable[this.SchemaIndex];
                        attribute.Value = String.Format("{0}:{1}", enumDefinition.Name, this.DocumentRoot.EnumOptionTable[enumDefinition.FirstValueIndex + this._br.ReadByte()].Value);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                return attribute;
            }
        }
    }
}
