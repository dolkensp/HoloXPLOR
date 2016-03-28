using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UnitTest")]
    public partial class UnitTest
    {
        [XmlElement(ElementName = "atomics")]
        public TestAtomics Atomics { get; set; }

        [XmlElement(ElementName = "arrays")]
        public TestArrays Arrays { get; set; }

        [XmlAttribute(AttributeName = "reference")]
        public Guid Reference { get; set; }

        [XmlAttribute(AttributeName = "weakptr")]
        public String Weakptr { get; set; }

        [XmlAttribute(AttributeName = "weakptrnull")]
        public String Weakptrnull { get; set; }

        [XmlArray(ElementName = "strongptr")]
        [XmlArrayItem(Type = typeof(TestAtomics))]
        public TestAtomics[] Strongptr { get; set; }

        [XmlArray(ElementName = "strongptrnull")]
        [XmlArrayItem(Type = typeof(TestAtomics))]
        public TestAtomics[] Strongptrnull { get; set; }

        [XmlElement(ElementName = "inheritance")]
        public UnitTest_Inheritance Inheritance { get; set; }

        [XmlAttribute(AttributeName = "guid")]
        public Guid Guid { get; set; }

        [XmlAttribute(AttributeName = "locale")]
        public String Locale { get; set; }

    }
}
