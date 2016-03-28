using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SItemPortDef")]
    public partial class SItemPortDef
    {
        [XmlAttribute(AttributeName = "Name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "DisplayName")]
        public String DisplayName { get; set; }

        [XmlAttribute(AttributeName = "PortTags")]
        public String PortTags { get; set; }

        [XmlAttribute(AttributeName = "RequiredPortTags")]
        public String RequiredPortTags { get; set; }

        [XmlAttribute(AttributeName = "Flags")]
        public String Flags { get; set; }

        [XmlAttribute(AttributeName = "MinSize")]
        public Int32 MinSize { get; set; }

        [XmlAttribute(AttributeName = "MaxSize")]
        public Int32 MaxSize { get; set; }

        [XmlArray(ElementName = "Connections")]
        [XmlArrayItem(Type = typeof(SItemPortConnectionParam))]
        public SItemPortConnectionParam[] Connections { get; set; }

        [XmlArray(ElementName = "Types")]
        [XmlArrayItem(Type = typeof(SItemPortDefTypes))]
        public SItemPortDefTypes[] Types { get; set; }

        [XmlArray(ElementName = "Extension")]
        [XmlArrayItem(Type = typeof(SItemPortDefExtensionBase))]
        [XmlArrayItem(Type = typeof(SItemPortDefExtensionFPS))]
        [XmlArrayItem(Type = typeof(SItemPortDefExtensionTurret))]
        [XmlArrayItem(Type = typeof(SItemPortDefExtensionThruster))]
        public SItemPortDefExtensionBase[] Extension { get; set; }

        [XmlArray(ElementName = "DamageTech")]
        [XmlArrayItem(Type = typeof(SItemPortDamageTech))]
        public SItemPortDamageTech[] DamageTech { get; set; }

        [XmlArray(ElementName = "AttachmentImplementation")]
        [XmlArrayItem(Type = typeof(SItemPortDefAttachmentImplementationBase))]
        [XmlArrayItem(Type = typeof(SItemPortDefAttachmentImplementationBone))]
        [XmlArrayItem(Type = typeof(SItemPortDefAttachmentImplementationFace))]
        [XmlArrayItem(Type = typeof(SItemPortDefAttachmentImplementationSkin))]
        public SItemPortDefAttachmentImplementationBase[] AttachmentImplementation { get; set; }

    }
}
