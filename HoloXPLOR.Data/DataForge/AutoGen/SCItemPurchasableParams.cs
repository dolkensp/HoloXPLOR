using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SCItemPurchasableParams")]
    public partial class SCItemPurchasableParams : SCItemComponentParams
    {
        [XmlAttribute(AttributeName = "BaseValue")]
        public Int32 BaseValue { get; set; }

        [XmlAttribute(AttributeName = "Grade")]
        public String Grade { get; set; }

        [XmlArray(ElementName = "Display")]
        [XmlArrayItem(Type = typeof(PurchasableDisplayBase))]
        [XmlArrayItem(Type = typeof(PurchasableDisplayClothing))]
        public PurchasableDisplayBase[] Display { get; set; }

    }
}
