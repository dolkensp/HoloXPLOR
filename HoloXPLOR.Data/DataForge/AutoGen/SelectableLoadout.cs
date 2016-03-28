using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SelectableLoadout")]
    public partial class SelectableLoadout
    {
        [XmlAttribute(AttributeName = "assetName")]
        public String AssetName { get; set; }

        [XmlAttribute(AttributeName = "thumbnailName")]
        public String ThumbnailName { get; set; }

        [XmlAttribute(AttributeName = "displayName")]
        public String DisplayName { get; set; }

    }
}
