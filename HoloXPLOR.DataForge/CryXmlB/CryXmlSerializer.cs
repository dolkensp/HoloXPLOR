using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HoloXPLOR.DataForge
{
    public enum ByteOrderEnum
    {
        AutoDetect,
        BigEndian,
        LittleEndian,
    }

    public static class CryXmlSerializer
    {
        public static Int64 ReadInt64(this BinaryReader br, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian)
        {
            var bytes = new Byte[] {
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
            };

            if (byteOrder == ByteOrderEnum.LittleEndian)
                bytes = bytes.Reverse().ToArray();

            return BitConverter.ToInt64(bytes, 0);
        }

        public static Int32 ReadInt32(this BinaryReader br, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian)
        {
            var bytes = new Byte[] {
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
            };

            if (byteOrder == ByteOrderEnum.LittleEndian)
                bytes = bytes.Reverse().ToArray();

            return BitConverter.ToInt32(bytes, 0);
        }

        public static Int16 ReadInt16(this BinaryReader br, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian)
        {
            var bytes = new Byte[] {
                br.ReadByte(),
                br.ReadByte(),
            };

            if (byteOrder == ByteOrderEnum.LittleEndian)
                bytes = bytes.Reverse().ToArray();

            return BitConverter.ToInt16(bytes, 0);
        }

        public static UInt64 ReadUInt64(this BinaryReader br, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian)
        {
            var bytes = new Byte[] {
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
            };

            if (byteOrder == ByteOrderEnum.LittleEndian)
                bytes = bytes.Reverse().ToArray();

            return BitConverter.ToUInt64(bytes, 0);
        }

        public static UInt32 ReadUInt32(this BinaryReader br, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian)
        {
            var bytes = new Byte[] {
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
                br.ReadByte(),
            };

            if (byteOrder == ByteOrderEnum.LittleEndian)
                bytes = bytes.Reverse().ToArray();

            return BitConverter.ToUInt32(bytes, 0);
        }

        public static UInt16 ReadUInt16(this BinaryReader br, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian)
        {
            var bytes = new Byte[] {
                br.ReadByte(),
                br.ReadByte(),
            };

            if (byteOrder == ByteOrderEnum.LittleEndian)
                bytes = bytes.Reverse().ToArray();

            return BitConverter.ToUInt16(bytes, 0);
        }

        public static XmlDocument ReadFile(String inFile, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian, Boolean writeLog = false)
        {
            return CryXmlSerializer.ReadStream(File.OpenRead(inFile), byteOrder, writeLog);
        }

        public static XmlDocument ReadStream(Stream inStream, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian, Boolean writeLog = false)
        {
            using (BinaryReader br = new BinaryReader(inStream))
            {
                var peek = br.PeekChar();

                if (peek == '<')
                {
                    return null; // File is already XML
                }
                else if (peek != 'C')
                {
                    throw new Exception("Unknown File Format"); // Unknown file format
                }

                String header = br.ReadCString();

                if (header != "CryXmlB")
                {
                    throw new Exception("Unknown File Format");
                }

                var headerLength = br.BaseStream.Position;

                byteOrder = ByteOrderEnum.BigEndian;

                var fileLength = br.ReadInt32(byteOrder);

                if (fileLength != br.BaseStream.Length)
                {
                    br.BaseStream.Seek(headerLength, SeekOrigin.Begin);
                    byteOrder = ByteOrderEnum.LittleEndian;
                    fileLength = br.ReadInt32(byteOrder);
                }

                var nodeTableOffset = br.ReadInt32(byteOrder);
                var nodeTableCount = br.ReadInt32(byteOrder);
                var nodeTableSize = 28;

                var referenceTableOffset = br.ReadInt32(byteOrder);
                var referenceTableCount = br.ReadInt32(byteOrder);
                var referenceTableSize = 8;

                var offset3 = br.ReadInt32(byteOrder);
                var count3 = br.ReadInt32(byteOrder);
                var length3 = 4;

                var contentOffset = br.ReadInt32(byteOrder);
                var contentLength = br.ReadInt32(byteOrder);

                if (writeLog)
                {
                    // Regex byteFormatter = new Regex("([0-9A-F]{8})");
                    Console.WriteLine("Header");
                    Console.WriteLine("0x{0:X6}: {1}", 0x00, header);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x00, fileLength);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x04, nodeTableOffset);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x08, nodeTableCount);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x12, referenceTableOffset);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x16, referenceTableCount);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x20, offset3);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x24, count3);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x28, contentOffset);
                    Console.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x32, contentLength);
                    Console.WriteLine("");
                    Console.WriteLine("Node Table");
                }

                List<CryXmlNode> nodeTable = new List<CryXmlNode> { };
                br.BaseStream.Seek(nodeTableOffset, SeekOrigin.Begin);
                Int32 nodeID = 0;
                while (br.BaseStream.Position < nodeTableOffset + nodeTableCount * nodeTableSize)
                {
                    var position = br.BaseStream.Position;
                    var value = new CryXmlNode
                    {
                        NodeID = nodeID++,
                        NodeNameOffset = br.ReadInt32(byteOrder),
                        ItemType = br.ReadInt32(byteOrder),
                        AttributeCount = br.ReadInt16(byteOrder),
                        ChildCount = br.ReadInt16(byteOrder),
                        ParentNodeID = br.ReadInt32(byteOrder),
                        FirstAttributeIndex = br.ReadInt32(byteOrder),
                        FirstChildIndex = br.ReadInt32(byteOrder),
                        Reserved = br.ReadInt32(byteOrder),
                    };

                    nodeTable.Add(value);
                    if (writeLog)
                    {
                        Console.WriteLine(
                            "0x{0:X6}: {1:X8} {2:X8} {3:X4} {4:X4} {5:X8} {6:X8} {7:X8} {8:X8}",
                            position,
                            value.NodeNameOffset,
                            value.ItemType,
                            value.AttributeCount,
                            value.ChildCount,
                            value.ParentNodeID,
                            value.FirstAttributeIndex,
                            value.FirstChildIndex,
                            value.Reserved);
                    }
                }

                if (writeLog)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Reference Table");
                }

                List<CryXmlReference> attributeTable = new List<CryXmlReference> { };
                br.BaseStream.Seek(referenceTableOffset, SeekOrigin.Begin);
                while (br.BaseStream.Position < referenceTableOffset + referenceTableCount * referenceTableSize)
                {
                    var position = br.BaseStream.Position;
                    var value = new CryXmlReference
                    {
                        NameOffset = br.ReadInt32(byteOrder),
                        ValueOffset = br.ReadInt32(byteOrder)
                    };

                    attributeTable.Add(value);
                    if (writeLog)
                    {
                        Console.WriteLine("0x{0:X6}: {1:X8} {2:X8}", position, value.NameOffset, value.ValueOffset);
                    }
                }
                if (writeLog)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Order Table");
                }

                List<Int32> table3 = new List<Int32> { };
                br.BaseStream.Seek(offset3, SeekOrigin.Begin);
                while (br.BaseStream.Position < offset3 + count3 * length3)
                {
                    var position = br.BaseStream.Position;
                    var value = br.ReadInt32(byteOrder);

                    table3.Add(value);
                    if (writeLog)
                    {
                        Console.WriteLine("0x{0:X6}: {1:X8}", position, value);
                    }
                }

                if (writeLog)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Dynamic Dictionary");
                }

                List<CryXmlValue> dataTable = new List<CryXmlValue> { };
                br.BaseStream.Seek(contentOffset, SeekOrigin.Begin);
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    var position = br.BaseStream.Position;
                    var value = new CryXmlValue
                    {
                        Offset = (Int32)position - contentOffset,
                        Value = br.ReadCString(),
                    };
                    dataTable.Add(value);
                    if (writeLog)
                    {
                        Console.WriteLine("0x{0:X6}: {1:X8} {2}", position, value.Offset, value.Value);
                    }
                }

                var dataMap = dataTable.ToDictionary(k => k.Offset, v => v.Value);

                var attributeIndex = 0;

                var xmlDoc = new XmlDocument();

                var bugged = false;

                Dictionary<Int32, XmlElement> xmlMap = new Dictionary<Int32, XmlElement> { };
                foreach (var node in nodeTable)
                {
                    XmlElement element = xmlDoc.CreateElement(dataMap[node.NodeNameOffset]);

                    for (Int32 i = 0, j = node.AttributeCount; i < j; i++)
                    {
                        if (dataMap.ContainsKey(attributeTable[attributeIndex].ValueOffset))
                        {
                            element.SetAttribute(dataMap[attributeTable[attributeIndex].NameOffset], dataMap[attributeTable[attributeIndex].ValueOffset]);
                        }
                        else
                        {
                            bugged = true;
                            element.SetAttribute(dataMap[attributeTable[attributeIndex].NameOffset], "BUGGED");
                        }
                        attributeIndex++;
                    }

                    xmlMap[node.NodeID] = element;
                    if (xmlMap.ContainsKey(node.ParentNodeID))
                        xmlMap[node.ParentNodeID].AppendChild(element);
                    else
                        xmlDoc.AppendChild(element);
                }

                return xmlDoc;
            }
        }

        public static TObject Deserialize<TObject>(String inFile, ByteOrderEnum byteOrder = ByteOrderEnum.BigEndian, Boolean writeLog = false) where TObject : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var xmlDoc = CryXmlSerializer.ReadFile(inFile, byteOrder, writeLog);

                xmlDoc.Save(ms);

                ms.Seek(0, SeekOrigin.Begin);

                XmlSerializer xs = new XmlSerializer(typeof(TObject));

                return xs.Deserialize(ms) as TObject;
            }
        }
    }
}