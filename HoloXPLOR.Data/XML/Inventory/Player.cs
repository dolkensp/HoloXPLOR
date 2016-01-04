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
    [Serializable]
    [XmlRoot(ElementName = "player")]
    public class Player : Item
    {
        [XmlAttribute(AttributeName = "loadout")]
        [DefaultValue("")]
        public String Loadout { get; set; }
        
        [XmlAttribute(AttributeName = "hangarVehicleId")]
        [DefaultValue(0)]
        public Int32 HangarVehicleID { get; set; }

        [XmlAttribute(AttributeName = "currVehicleOwner")]
        [DefaultValue(0)]
        public Int32 VehicleOwner { get; set; }

        [XmlAttribute(AttributeName = "Version")]
        [DefaultValue(0)]
        public Int32 Version { get; set; }

        [XmlAttribute(AttributeName = "__DSID__currVehicleDID")]
        public Guid VehicleID { get; set; }

        [XmlElement(ElementName = "ship")]
        public Ship[] Ships { get; set; }

        [XmlElement(ElementName = "item")]
        public Item[] Items { get; set; }

        [XmlElement(ElementName = "hangar")]
        public Hangar Hangar { get; set; }
    }
}