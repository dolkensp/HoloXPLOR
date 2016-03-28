using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TestAtomics")]
    public partial class TestAtomics
    {
        [XmlAttribute(AttributeName = "myString")]
        public String MyString { get; set; }

        [XmlAttribute(AttributeName = "myEnum")]
        public EMyEnum MyEnum { get; set; }

        [XmlAttribute(AttributeName = "myInt8")]
        public SByte MyInt8 { get; set; }

        [XmlAttribute(AttributeName = "myInt16")]
        public Int16 MyInt16 { get; set; }

        [XmlAttribute(AttributeName = "myInt32")]
        public Int32 MyInt32 { get; set; }

        [XmlAttribute(AttributeName = "myInt64")]
        public Int64 MyInt64 { get; set; }

        [XmlAttribute(AttributeName = "myUInt8")]
        public Byte MyUInt8 { get; set; }

        [XmlAttribute(AttributeName = "myUInt16")]
        public UInt16 MyUInt16 { get; set; }

        [XmlAttribute(AttributeName = "myUInt32")]
        public UInt32 MyUInt32 { get; set; }

        [XmlAttribute(AttributeName = "myUInt64")]
        public UInt64 MyUInt64 { get; set; }

        [XmlAttribute(AttributeName = "myBooleanTrue")]
        public Boolean MyBooleanTrue { get; set; }

        [XmlAttribute(AttributeName = "myFloat")]
        public Single MyFloat { get; set; }

        [XmlAttribute(AttributeName = "myDouble")]
        public Double MyDouble { get; set; }

    }
}
