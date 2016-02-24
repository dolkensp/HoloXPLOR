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
    public static class DataForgeSerializer
    {
        public static TObject Deserialize<TObject>(String inFile) where TObject : class
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(inFile)))
            {
                String header = br.ReadCString();
                var headerLength = br.BaseStream.Position;
                var fileLength = br.ReadInt32();

                var nodeTableOffset = br.ReadInt32();
                var nodeTableCount = br.ReadInt32();
                var nodeTableSize = 28;

                var referenceTableOffset = br.ReadInt32();
                var referenceTableCount = br.ReadInt32();
                var referenceTableSize = 8;

                var offset3 = br.ReadInt32();
                var count3 = br.ReadInt32();
                var length3 = 4;

                var contentOffset = br.ReadInt32();
                var contentLength = br.ReadInt32();

                // Regex byteFormatter = new Regex("([0-9A-F]{8})");

                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x00, fileLength);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x04, nodeTableOffset);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x08, nodeTableCount);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x12, referenceTableOffset);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x16, referenceTableCount);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x20, offset3);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x24, count3);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x28, contentOffset);
                // Debug.WriteLine("0x{0:X6}: {1:X8} (Dec: {1:D8})", headerLength + 0x32, contentLength);

                List<BinaryNode> nodeTable = new List<BinaryNode> { };
                br.BaseStream.Seek(nodeTableOffset, SeekOrigin.Begin);
                Int32 nodeID = 0;
                while (br.BaseStream.Position < nodeTableOffset + nodeTableCount * nodeTableSize)
                {
                    var position = br.BaseStream.Position;
                    var value = new BinaryNode
                    {
                        NodeID = nodeID++,
                        NodeNameOffset = br.ReadInt32(),
                        Item2 = br.ReadInt32(),
                        AttributeCount = br.ReadInt16(),
                        ChildCount = br.ReadInt16(),
                        ParentNodeID = br.ReadInt32(),
                        Item6 = br.ReadInt32(),
                        Item7 = br.ReadInt32(),
                        Item8 = br.ReadInt32(),
                    };

                    nodeTable.Add(value);
                    // Debug.WriteLine(
                    //     "0x{0:X6}: {1:X8} {2:X8} {3:X4} {4:X4} {5:X8} {6:X8} {7:X8} {8:X8}",
                    //     position,
                    //     value.NodeNameOffset,
                    //     value.Item2,
                    //     value.AttributeCount,
                    //     value.ChildCount,
                    //     value.ParentNodeID,
                    //     value.Item6,
                    //     value.Item7,
                    //     value.Item8);
                }

                List<BinaryReference> attributeTable = new List<BinaryReference> { };
                br.BaseStream.Seek(referenceTableOffset, SeekOrigin.Begin);
                while (br.BaseStream.Position < referenceTableOffset + referenceTableCount * referenceTableSize)
                {
                    var position = br.BaseStream.Position;
                    var value = new BinaryReference
                    {
                        NameOffset = br.ReadInt32(),
                        ValueOffset = br.ReadInt32()
                    };

                    attributeTable.Add(value);
                    // Debug.WriteLine("0x{0:X6}: {1:X8} {2:X8}", position, value.NameOffset, value.ValueOffset);
                }

                List<Int32> table3 = new List<Int32> { };
                br.BaseStream.Seek(offset3, SeekOrigin.Begin);
                while (br.BaseStream.Position < offset3 + count3 * length3)
                {
                    var position = br.BaseStream.Position;
                    var value = br.ReadInt32();

                    table3.Add(value);
                    // Debug.WriteLine("0x{0:X6}: {1:X8}", position, value);
                }

                List<BinaryValue> dataTable = new List<BinaryValue> { };
                br.BaseStream.Seek(contentOffset, SeekOrigin.Begin);
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    var position = br.BaseStream.Position;
                    var value = new BinaryValue
                    {
                        Offset = (Int32)position - contentOffset,
                        Value = br.ReadCString(),
                    };
                    dataTable.Add(value);
                    // Debug.WriteLine("0x{0:X6}: {1:X8} {2}", position, value.Offset, value.Value);
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

                using (MemoryStream ms = new MemoryStream())
                {
                    // if (bugged)
                    // {
                    //     xmlDoc.Save(Path.ChangeExtension(inFile, "bug"));
                    // }
                    // else
                    // {
                    //     xmlDoc.Save(Path.ChangeExtension(inFile, "raw"));
                    // }

                    xmlDoc.Save(ms);

                    ms.Seek(0, SeekOrigin.Begin);

                    XmlSerializer xs = new XmlSerializer(typeof(TObject));

                    return xs.Deserialize(ms) as TObject;
                }
            }
        }
    }
}