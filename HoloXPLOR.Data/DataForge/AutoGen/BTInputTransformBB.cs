using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTInputTransformBB")]
    public partial class BTInputTransformBB : BTInputTransform
    {
        [XmlAttribute(AttributeName = "bbPath")]
        public String BbPath { get; set; }

    }
}
