using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "UIGraph_MovieClipTransformationInterpolatorComponent")]
    public partial class UIGraph_MovieClipTransformationInterpolatorComponent : CtxGraph_Component
    {
        [XmlAttribute(AttributeName = "movieClipTransformationInterpolator")]
        public Guid MovieClipTransformationInterpolator { get; set; }

    }
}
