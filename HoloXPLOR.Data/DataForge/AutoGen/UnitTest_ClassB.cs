using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UnitTest_ClassB")]
    public partial class UnitTest_ClassB : UnitTest_ClassA
    {
        [XmlAttribute(AttributeName = "myClassB")]
        public String MyClassB { get; set; }

    }
}
