using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "HUDSilhouette")]
    public partial class HUDSilhouette
    {
        [XmlArray(ElementName = "hudSilhouetteDataList")]
        [XmlArrayItem(Type = typeof(HUDSilhouetteData))]
        public HUDSilhouetteData[] HudSilhouetteDataList { get; set; }

    }
}
