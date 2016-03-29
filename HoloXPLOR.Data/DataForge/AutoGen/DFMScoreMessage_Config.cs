using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "DFMScoreMessage_Config")]
    public partial class DFMScoreMessage_Config
    {
        [XmlArray(ElementName = "PrimaryMessage")]
        [XmlArrayItem(ElementName = "Locale", Type=typeof(_Locale))]
        public _Locale[] PrimaryMessage { get; set; }

        [XmlArray(ElementName = "SecondaryMessage")]
        [XmlArrayItem(ElementName = "Locale", Type=typeof(_Locale))]
        public _Locale[] SecondaryMessage { get; set; }

    }
}
