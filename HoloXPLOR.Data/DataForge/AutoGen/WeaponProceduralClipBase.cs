using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "WeaponProceduralClipBase")]
    public partial class WeaponProceduralClipBase
    {
        [XmlAttribute(AttributeName = "blendTime")]
        public Single BlendTime { get; set; }

    }
}
