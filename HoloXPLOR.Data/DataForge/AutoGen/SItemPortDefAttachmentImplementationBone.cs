using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDefAttachmentImplementationBone")]
    public partial class SItemPortDefAttachmentImplementationBone : SItemPortDefAttachmentImplementationBase
    {
        [XmlElement(ElementName = "Helper")]
        public SItemPortDefHelperNode Helper { get; set; }

    }
}
