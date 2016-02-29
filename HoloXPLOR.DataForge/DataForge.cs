using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForge
    {
        internal BinaryReader _br;

        public Int64 FileVersion { get; set; }
        
        public DataForgeStructDefinition[] StructDefinitionTable { get; set; }
        public DataForgePropertyDefinition[] PropertyDefinitionTable { get; set; }
        public DataForgeEnumDefinition[] EnumDefinitionTable { get; set; }
        public DataForgeDataMapping[] DataMappingTable { get; set; }
        public DataForgeRecord[] RecordDefinitionTable { get; set; }
        public DataForgeArrayReference[] Array_ReferenceValues { get; set; }
        public DataForgeStringLookup[] EnumOptionTable { get; set; }
        public DataForgeString[] ValueTable { get; set; }
        public DataForgeArrayGuid[] Array_GuidValues { get; set; }
        public DataForgeArrayString[] Array_StringValues { get; set; }
        public DataForgeArrayLocale[] Array_LocaleValues { get; set; }
        public DataForgeArrayEnum[] Array_EnumValues { get; set; }
        public DataForgeArrayInt8[] Array_Int8Values { get; set; }
        public DataForgeArrayInt16[] Array_Int16Values { get; set; }
        public DataForgeArrayInt32[] Array_Int32Values { get; set; }
        public DataForgeArrayInt64[] Array_Int64Values { get; set; }
        public DataForgeArrayUInt8[] Array_UInt8Values { get; set; }
        public DataForgeArrayUInt16[] Array_UInt16Values { get; set; }
        public DataForgeArrayUInt32[] Array_UInt32Values { get; set; }
        public DataForgeArrayUInt64[] Array_UInt64Values { get; set; }
        public DataForgeArrayBoolean[] Array_BooleanValues { get; set; }
        public DataForgeArraySingle[] Array_SingleValues { get; set; }
        public DataForgeArrayDouble[] Array_DoubleValues { get; set; }

        public Dictionary<UInt32, List<XmlElement>> DataMap { get; set; }
        public List<Tuple<XmlElement, UInt16, Int32>> NeedsMapping { get; set; }
        public List<XmlElement> DataTable { get; set; }

        private Dictionary<UInt32, String> _valueMap;
        public Dictionary<UInt32, String> ValueMap { get { return this._valueMap = this._valueMap ?? this.ValueTable.ToDictionary(k => (UInt32)k._offset, v => v.Value); } }

        public DataForge(BinaryReader br, Boolean loadData = true)
        {
            this._br = br;
            this.FileVersion = this._br.ReadInt64();
            this.NeedsMapping = new List<Tuple<XmlElement, UInt16, Int32>> { };

            var structDefinitionCount   = this._br.ReadUInt16(); this._br.ReadUInt16();  // 0x02d3
            var propertyDefinitionCount = this._br.ReadUInt16(); this._br.ReadUInt16();  // 0x0602
            var enumDefinitionCount     = this._br.ReadUInt16(); this._br.ReadUInt16();  // 0x0041 : 0x0002 ???
            var dataMappingCount        = this._br.ReadUInt16(); this._br.ReadUInt16();  // 0x013c
            var recordDefinitionCount   = this._br.ReadUInt16(); this._br.ReadUInt16();  // 0x0b35
                                                                                         
            //  38 schemas                                                               
            // 20a structs                                                               
            //  41 enums                                                                 
            #region Unmapped Tables                                                      
                                                                                         
            var int8ValueCount    = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? int8
            var int16ValueCount   = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? int16
            var int64ValueCount   = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? int32
            var int32ValueCount   = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0024 - ??? int64
            var uint8ValueCount   = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? uint8
            var uint16ValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? uint16
            var uint64ValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? uint32
            var uint32ValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? uint64
            var booleanValueCount = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - 0x0001b910 - Boolean
            var singleValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x003c - ??? single
            var doubleValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - ??? double
            var guidValueCount    = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0014 - Guid Array Values
            var stringValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0076 - String Array Values
            var localeValueCount  = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x0034 - Locale Array Values
            var enumValueCount    = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x006e - Enum Array Values
            var numRecords21      = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x1cf3 - ??? Class Array Values
            var numRecords22      = this._br.ReadUInt16(); this._br.ReadUInt16();        // 0x079d - ??? Pointer Array Values

            #endregion

            var referenceValueCount = this._br.ReadUInt16(); this._br.ReadUInt16();     // 0x0026 - Reference Array Values
            var enumOptionCount = this._br.ReadUInt16(); this._br.ReadUInt16();         // 0x0284 - Enum Options
            var totalLength25  = this._br.ReadUInt32();                                 // 0x2e45 : 0x00066e4b

            this.StructDefinitionTable = this.ReadArray<DataForgeStructDefinition>(structDefinitionCount);
            this.PropertyDefinitionTable = this.ReadArray<DataForgePropertyDefinition>(propertyDefinitionCount);
            this.EnumDefinitionTable = this.ReadArray<DataForgeEnumDefinition>(enumDefinitionCount);
            this.DataMappingTable = this.ReadArray<DataForgeDataMapping>(dataMappingCount);
            this.RecordDefinitionTable = this.ReadArray<DataForgeRecord>(recordDefinitionCount);

            this.Array_Int8Values = this.ReadArray<DataForgeArrayInt8>(int8ValueCount);
            this.Array_Int16Values = this.ReadArray<DataForgeArrayInt16>(int16ValueCount);
            this.Array_Int32Values = this.ReadArray<DataForgeArrayInt32>(int32ValueCount);
            this.Array_Int64Values = this.ReadArray<DataForgeArrayInt64>(int64ValueCount);
            this.Array_UInt8Values = this.ReadArray<DataForgeArrayUInt8>(uint8ValueCount);
            this.Array_UInt16Values = this.ReadArray<DataForgeArrayUInt16>(uint16ValueCount);
            this.Array_UInt32Values = this.ReadArray<DataForgeArrayUInt32>(uint32ValueCount);
            this.Array_UInt64Values = this.ReadArray<DataForgeArrayUInt64>(uint64ValueCount);
            
            this.Array_BooleanValues = this.ReadArray<DataForgeArrayBoolean>(booleanValueCount);
            this.Array_SingleValues = this.ReadArray<DataForgeArraySingle>(singleValueCount);
            this.Array_DoubleValues = this.ReadArray<DataForgeArrayDouble>(doubleValueCount);
            this.Array_GuidValues = this.ReadArray<DataForgeArrayGuid>(guidValueCount);
            this.Array_StringValues = this.ReadArray<DataForgeArrayString>(stringValueCount);
            this.Array_LocaleValues = this.ReadArray<DataForgeArrayLocale>(localeValueCount);
            this.Array_EnumValues = this.ReadArray<DataForgeArrayEnum>(enumValueCount);

            // HACK: Skip unknown tables at this stage
            this._br.BaseStream.Seek(0x0002e4d4, SeekOrigin.Begin);

            this.Array_ReferenceValues = this.ReadArray<DataForgeArrayReference>(referenceValueCount);
            this.EnumOptionTable = this.ReadArray<DataForgeStringLookup>(enumOptionCount);

            // Console.WriteLine("0x{0:X8}: Text", this._br.BaseStream.Position);
            var buffer = new List<DataForgeString> { };
            var maxPosition = this._br.BaseStream.Position + totalLength25;
            var index = 0;
            var startPosition = this._br.BaseStream.Position;
            while (this._br.BaseStream.Position < maxPosition)
            {
                var offset = this._br.BaseStream.Position - startPosition;
                buffer.Add(new DataForgeString(this)
                {
                    _index = index++,
                    _offset = offset,
                });
            }
            this.ValueTable = buffer.ToArray();
            
            this.DataTable = new List<XmlElement> { };
            this.DataMap = new Dictionary<UInt32, List<XmlElement>> { };

            foreach (var dataMapping in this.DataMappingTable)
            {
                this.DataMap[dataMapping.StructIndex] = new List<XmlElement> { };

                var dataStruct = this.StructDefinitionTable[dataMapping.StructIndex];

                for (Int32 i = 0; i < dataMapping.StructCount; i++)
                {
                    var node = dataStruct.Read();

                    this.DataMap[dataMapping.StructIndex].Add(node);
                    this.DataTable.Add(node);
                }
            }

            foreach (var dataMapping in this.NeedsMapping)
            {
                dataMapping.Item1.ParentNode.ReplaceChild(
                    this.DataMap[dataMapping.Item2][dataMapping.Item3],
                    dataMapping.Item1);
            }

            var root = this._xmlDocument.CreateElement("DataForge");
            this._xmlDocument.AppendChild(root);
            foreach (var record in this.RecordDefinitionTable)
            {
                root.AppendChild(this.DataMap[record.StructIndex][record.VariantIndex]);
            }
        }

        private XmlDocument _xmlDocument = new XmlDocument();
        public XmlElement CreateElement(String name) { return this._xmlDocument.CreateElement(name); }
        public XmlAttribute CreateAttribute(String name) { return this._xmlDocument.CreateAttribute(name); }
        public void Save(String filename) { this._xmlDocument.Save(filename); }
        public String OuterXML { get { return this._xmlDocument.OuterXml; } }

        public U[] ReadArray<U>(UInt32? arraySize = null) where U : DataForgeSerializable
        {
            if (!arraySize.HasValue)
            {
                // TODO: Check if this logic is correct - do we need to preprocess ALL arrays and pass an array size?
                arraySize = this._br.ReadUInt32();
            
                if (arraySize == 0xFFFFFFFF)
                {
                    return null;
                } 
            }
            
            if (arraySize == 0xFFFFFFFF)
            {
                return null;
            }

            // Console.WriteLine("0x{0:X8}: {2} 0x{1:X4}", this._br.BaseStream.Position, arraySize.Value, typeof(U).Name);

            return (from i in Enumerable.Range(0, (Int32)arraySize.Value)
                    let data = (U)Activator.CreateInstance(typeof(U), this)
                    let hack = data._index = i
                    select data).ToArray();
        }
    }
}
