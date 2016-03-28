using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UnitTest_BaseTest")]
    public partial class UnitTest_BaseTest
    {
        [XmlAttribute(AttributeName = "myBaseString")]
        public String MyBaseString { get; set; }

    }
}
