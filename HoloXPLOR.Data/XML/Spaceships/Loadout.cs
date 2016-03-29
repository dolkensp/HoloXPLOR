using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.Xml.Spaceships
{
    [XmlRoot(ElementName = "Loadout")]
    public partial class Loadout
    {
        [XmlArray(ElementName = "Items")]
        [XmlArrayItem(ElementName = "Item")]
        public ItemLink[] Ports { get; set; }
    }
}