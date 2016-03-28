using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SLoadingScreenInformationDef")]
    public partial class SLoadingScreenInformationDef
    {
        [XmlAttribute(AttributeName = "loadingScreenType")]
        public ELoadingScreenType LoadingScreenType { get; set; }

        [XmlAttribute(AttributeName = "imagePath")]
        public String ImagePath { get; set; }

        [XmlAttribute(AttributeName = "primaryTitle")]
        public String PrimaryTitle { get; set; }

        [XmlAttribute(AttributeName = "secondaryTitle")]
        public String SecondaryTitle { get; set; }

        [XmlAttribute(AttributeName = "subtitle")]
        public String Subtitle { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public String Description { get; set; }

    }
}
