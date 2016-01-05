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
    [XmlRoot(ElementName = "port")]
    public class Port
    {
        /// <summary>
        /// The name of the port/hardpoint
        /// </summary>
        [XmlAttribute(AttributeName = "portName")]
        [DefaultValue("")]
        public String PortName { get; set; }

        /// <summary>
        /// The ID of the Item that is currently in this Port
        /// </summary>
        [XmlAttribute(AttributeName = "__EID__itemId")]
        public Guid ItemID { get; set; }

        [XmlElement(ElementName = "pipes")]
        public ConnectionCollection Pipes { get; set; }

        public override String ToString()
        {
            return String.Format("{0} [{1}]", this.PortName, this.ItemID);
        }
    }
}