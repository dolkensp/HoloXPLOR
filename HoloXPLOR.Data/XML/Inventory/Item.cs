using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Inventory
{
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        /// <summary>
        /// The ID of the manufacturer of the Item
        /// </summary>
        [XmlAttribute(AttributeName = "oemId")]
        public Guid ManufacturerID { get; set; }

        /// <summary>
        /// The item's unique identifier
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public Guid ID { get; set; }

        /// <summary>
        /// Flag that indicates if the equipment is a rental
        /// </summary>
        [XmlAttribute(AttributeName = "acRentalEquipment")]
        [DefaultValue(0)]
        public Int32 __IsRental
        {
            get { return this.IsRental ? 1 : 0; }
            set { this.IsRental = value == 1; }
        }
        [XmlIgnore]
        public Boolean IsRental { get; set; }

        /// <summary>
        /// NOTE: NOT UNIQUE
        /// </summary>
        [XmlAttribute(AttributeName = "acMembershipId")]
        [DefaultValue(0)]
        public Int32 ArenaCommanderID { get; set; }

        /// <summary>
        /// The type of the Item
        /// </summary>
        [XmlAttribute(AttributeName = "class")]
        [DefaultValue("")]
        public String Class { get; set; }

        [XmlElement(ElementName = "inventory")]
        public Inventory Inventory { get; set; }
        [XmlElement(ElementName = "ports")]
        public PortCollection Ports { get; set; }
        [XmlElement(ElementName = "pipes")]
        public PipeCollection Pipes { get; set; }

        public override String ToString()
        {
            return String.Format("{0} [{1}]", this.Class, this.ID);
        }

        [XmlIgnore]
        public String HTML_Attributes
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@" data-draggable=""true""");
                
                sb.AppendFormat(@" data-item-id=""{0}""", this.ID);
                
                if (this.IsRental)
                    sb.AppendFormat(@" data-item-rental=""{0}""", this.IsRental);
                
                if (this.ManufacturerID != Guid.Empty)
                    sb.AppendFormat(@" data-item-manufacturer=""{0}""", this.ManufacturerID);

                return sb.ToString();
            }
        }
    }
}