using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Inventory
{
    [XmlRoot(ElementName = "ship")]
    public class Ship : Item
    {
        [XmlAttribute(AttributeName = "name")]
        [DefaultValue("")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "isTrainer")]
        [DefaultValue(0)]
        public Int32 __IsTrainer
        {
            get { return this.IsTrainer ? 1 : 0; }
            set { this.IsTrainer = value == 1; }
        }
        [XmlIgnore]
        public Boolean IsTrainer { get; set; }

        public override String ToString()
        {
            return String.Format("{0} [{1}]", this.Name, this.ID);
        }
    }
}