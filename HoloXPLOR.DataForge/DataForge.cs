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
        public static Regex NEWLINE = new Regex("\r\n\t", RegexOptions.Multiline);

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
        public List<XmlElement> DataTable { get; set; }

        public DataForge(BinaryReader br, Boolean loadData = true)
        {
            this._br = br;
            this.FileVersion = this._br.ReadInt64();

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

            Console.WriteLine("0x{0:X8}: Text", this._br.BaseStream.Position);
            var buffer = new List<DataForgeString> { };
            var maxPosition = this._br.BaseStream.Position + totalLength25;
            while (this._br.BaseStream.Position < maxPosition)
            {
                buffer.Add(new DataForgeString(this));
            }
            this.ValueTable = buffer.ToArray();

            if (loadData)
            {
                this.DataTable = new List<XmlElement> { };
                foreach (var dataMapping in this.DataMappingTable)
                {
                    var dataStruct = this.StructDefinitionTable[dataMapping.StructIndex];

                    for (Int32 i = 0; i < dataMapping.StructCount; i++)
                    {
                        var node = dataStruct.Read();
                        Console.WriteLine(node.OuterXml);
                        this.DataTable.Add(node);
                    }
                }
            }
        }

        private XmlDocument _xmlDocument = new XmlDocument();
        public XmlElement CreateElement(String name) { return this._xmlDocument.CreateElement(name); }
        public XmlAttribute CreateAttribute(String name) { return this._xmlDocument.CreateAttribute(name); }

        public String ReadString()
        {
            var stringOffset = this._br.ReadUInt32();

            var oldPos = this._br.BaseStream.Position;

            this._br.BaseStream.Seek(0x0002F1DC + stringOffset, SeekOrigin.Begin);

            String buffer = this._br.ReadCString();

            this._br.BaseStream.Seek(oldPos, SeekOrigin.Begin);

            return buffer;
        }

        public Guid? ReadGuid(Boolean nullable = true)
        {
            var isNull = nullable && this._br.ReadInt32() == -1;

            var c = this._br.ReadInt16();
            var b = this._br.ReadInt16();
            var a = this._br.ReadInt32();
            var k = this._br.ReadByte();
            var j = this._br.ReadByte();
            var i = this._br.ReadByte();
            var h = this._br.ReadByte();
            var g = this._br.ReadByte();
            var f = this._br.ReadByte();
            var e = this._br.ReadByte();
            var d = this._br.ReadByte();

            if (isNull) return null;

            return new Guid(a, b, c, d, e, f, g, h, i, j, k);
        }

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

            Console.WriteLine("0x{0:X8}: {2} 0x{1:X4}", this._br.BaseStream.Position, arraySize.Value, typeof(U).Name);

            return (from i in Enumerable.Range(0, (Int32)arraySize.Value)
                    let data = (U)Activator.CreateInstance(typeof(U), this)
                    let hack = data._index = i
                    select data).ToArray();
        }
     
        public void DumpFile()
        {
            return;

            String outFile = "definitionDump.txt";

            Int32 i;

            File.WriteAllLines(outFile, new String[] { });

            File.AppendAllLines(outFile, new String[] { "", "FileDefinitionTable:" });

            i = 0;
            File.AppendAllLines(outFile,
                from node in this.RecordDefinitionTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));

            File.AppendAllLines(outFile, new String[] { "", "SchemaDefinitionTable:" });

            i = 0;
            File.AppendAllLines(outFile,
                from node in this.StructDefinitionTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));

            File.AppendAllLines(outFile, new String[] { "", "PropertyDefinitionTable:" });

            i = 0;
            File.AppendAllLines(outFile,
                from node in this.PropertyDefinitionTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));

            File.AppendAllLines(outFile, new String[] { "", "EnumDefinitionTable:" });

            i = 0;
            File.AppendAllLines(outFile, 
                from node in this.EnumDefinitionTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));

            File.AppendAllLines(outFile, new String[] { "", "EnumValueTable:" });

            i = 0;
            File.AppendAllLines(outFile,
                from node in this.EnumOptionTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));

            File.AppendAllLines(outFile, new String[] { "", "SchemaCountTable:" });

            i = 0;
            File.AppendAllLines(outFile,
                from node in this.DataMappingTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));

            File.AppendAllLines(outFile, new String[] { "", "ValueTable:" });

            i = 0;
            File.AppendAllLines(outFile,
                from node in this.ValueTable
                select String.Format("0x{0:X8} 0x{1:X8}: {2}", i++, node._offset, node));
        }

        public XmlDocument Serialize()
        {
            var xmlDocument = new XmlDocument();

            var element = xmlDocument.CreateElement("DataForge");
            
            xmlDocument.AppendChild(element);

            List<Int64[]> signature = new List<Int64[]>
            {
                //            Offset      Index   IsFile
                new Int64[] { 0xFFFFFFFF, 0x0000, 0x0000 },
                new Int64[] { 0xFFFFFFFF, 0x0000, 0x0001 },
                new Int64[] { 0xFFFFFFFF, 0x0002, 0x0001 },
                // new Int64[] { 0x00097418, 0x0003, 0x0001 }
            };

            foreach (var dataSpec in signature)
            {
                if (dataSpec[0] != 0xFFFFFFFF)
                {
                    this._br.BaseStream.Seek(dataSpec[0], SeekOrigin.Begin);
                }

                Console.WriteLine();

                XmlNode node;

                if (dataSpec[2] == 0x0001)
                {
                    var file = this.RecordDefinitionTable[dataSpec[1]];

                    node = file.Serialize(xmlDocument);
                } else {
                    var schema = this.StructDefinitionTable[dataSpec[1]];

                    node = schema.Serialize(xmlDocument);
                }

                Console.WriteLine(node.OuterXml);
                element.AppendChild(node);
            }

            // var oldposition = this._br.BaseStream.Position;
            // 
            // foreach (var dataForgeStruct in this.StructDefinitionTable)
            // {
            //     try
            //     {
            //         this._br.BaseStream.Seek(oldposition, SeekOrigin.Begin);
            //         var node = dataForgeStruct.Serialize(xmlDocument);
            // 
            //         Console.WriteLine("Success Schema {0}", dataForgeStruct.Name);
            //         Console.WriteLine(node.OuterXml);
            //     }
            //     catch (Exception) { }
            // }

            return xmlDocument;
        }
    }
}
