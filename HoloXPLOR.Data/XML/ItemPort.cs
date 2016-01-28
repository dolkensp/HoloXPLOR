using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML
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

        [XmlAttribute(AttributeName = "portTags")]
        public String PortTags { get; set; }

        [XmlAttribute(AttributeName = "requiredTags")]
        public String RequiredTags { get; set; }

        [XmlAttribute(AttributeName = "requiredItemTags")]
        public String RequiredItemTags { get; set; }
        
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

        [XmlIgnore]
        public String HTML_Attributes
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!String.IsNullOrWhiteSpace(this.Name))
                    sb.AppendFormat(@" data-port-name=""{0}""", this.Name);
                if (this.MinSize != 0)
                    sb.AppendFormat(@" data-port-min-size=""{0}""", this.MinSize);
                if (this.MaxSize != 0)
                    sb.AppendFormat(@" data-port-max-size=""{0}""", this.MaxSize);
                if (!String.IsNullOrWhiteSpace(this.PortTags))
                    sb.AppendFormat(@" data-port-tags=""{0}""", this.PortTags);
                if (!String.IsNullOrWhiteSpace(this.RequiredTags))
                    sb.AppendFormat(@" data-port-required-tags=""{0}""", this.RequiredTags);
                if (!String.IsNullOrWhiteSpace(this.RequiredItemTags))
                    sb.AppendFormat(@" data-port-required-item-tags=""{0}""", this.RequiredItemTags);
                if (this.Types.Count() > 0)
                    sb.AppendFormat(@" data-port-types=""{0}""", String.Join(",", this.Types.Select(t => String.Format("{0}:{1}", t.Type, t.SubType).Trim(':'))));

                return sb.ToString();
            }
        }
    }
}
