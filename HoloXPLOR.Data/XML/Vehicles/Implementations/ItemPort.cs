using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Vehicles.Implementations
{
    [XmlRoot(ElementName = "ItemPort")]
    public partial class ItemPort
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }
        
        [XmlAttribute(AttributeName = "display_name")]
        public String DisplayName { get; set; }
        
        [XmlAttribute(AttributeName = "flags")]
        public String Flags { get; set; }
        
        [XmlAttribute(AttributeName = "minsize")]
        [DefaultValue(0)]
        public Int32 MinSize { get; set; }
        
        [XmlAttribute(AttributeName = "maxsize")]
        [DefaultValue(0)]
        public Int32 MaxSize { get; set; }

        [XmlArray(ElementName = "Types")]
        [XmlArrayItem(ElementName = "Type")]
        public ItemType[] Types { get; set; }

        public override String ToString()
        {
            return String.Format("{0}: {1}-{2}", this.DisplayName, this.MinSize, this.MaxSize);
        }
    }
}
