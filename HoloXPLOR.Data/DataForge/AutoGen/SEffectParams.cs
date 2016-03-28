using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEffectParams")]
    public partial class SEffectParams
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "Tag")]
        public String Tag { get; set; }

        [XmlAttribute(AttributeName = "Helper")]
        public String Helper { get; set; }

        [XmlElement(ElementName = "Offset")]
        public QuatT Offset { get; set; }

        [XmlAttribute(AttributeName = "IsArchetype")]
        public Boolean IsArchetype { get; set; }

        [XmlAttribute(AttributeName = "IsLooped")]
        public Boolean IsLooped { get; set; }

        [XmlAttribute(AttributeName = "Enabled")]
        public Boolean Enabled { get; set; }

        [XmlAttribute(AttributeName = "Prime")]
        public Boolean Prime { get; set; }

        [XmlAttribute(AttributeName = "Kill")]
        public Boolean Kill { get; set; }

        [XmlAttribute(AttributeName = "Timer")]
        public Single Timer { get; set; }

        [XmlAttribute(AttributeName = "RenderSlot")]
        public Int32 RenderSlot { get; set; }

        [XmlAttribute(AttributeName = "SubMaterialID")]
        public Int32 SubMaterialID { get; set; }

        [XmlAttribute(AttributeName = "ContextFlags")]
        public UInt32 ContextFlags { get; set; }

        [XmlElement(ElementName = "Axis")]
        public Vec3 Axis { get; set; }

    }
}
