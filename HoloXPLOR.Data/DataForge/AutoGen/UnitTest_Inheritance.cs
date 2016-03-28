using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UnitTest_Inheritance")]
    public partial class UnitTest_Inheritance
    {
        [XmlArray(ElementName = "baseArray")]
        [XmlArrayItem(Type = typeof(UnitTest_BaseTest))]
        [XmlArrayItem(Type = typeof(UnitTest_ClassA))]
        [XmlArrayItem(Type = typeof(UnitTest_ClassB))]
        public UnitTest_BaseTest[] BaseArray { get; set; }

        [XmlAttribute(AttributeName = "weakPtrBase")]
        public String WeakPtrBase { get; set; }

    }
}
