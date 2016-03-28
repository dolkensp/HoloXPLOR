using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "FoleyItem")]
    public partial class FoleyItem
    {
        [XmlAttribute(AttributeName = "bone")]
        public Guid Bone { get; set; }

        [XmlAttribute(AttributeName = "velocityRTPCName")]
        public String VelocityRTPCName { get; set; }

        [XmlAttribute(AttributeName = "velocityRTPCMinimum")]
        public Single VelocityRTPCMinimum { get; set; }

        [XmlAttribute(AttributeName = "velocityRTPCMaximum")]
        public Single VelocityRTPCMaximum { get; set; }

        [XmlArray(ElementName = "oneShots")]
        [XmlArrayItem(Type = typeof(FoleyOneShot))]
        public FoleyOneShot[] OneShots { get; set; }

        [XmlArray(ElementName = "loops")]
        [XmlArrayItem(Type = typeof(FoleyLoop))]
        public FoleyLoop[] Loops { get; set; }

    }
}
