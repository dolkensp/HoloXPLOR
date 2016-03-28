using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UnitTest_ClassA")]
    public partial class UnitTest_ClassA : UnitTest_BaseTest
    {
        [XmlAttribute(AttributeName = "myClassA")]
        public String MyClassA { get; set; }

    }
}
