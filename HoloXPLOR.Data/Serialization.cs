using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data
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
    }

    [XmlRoot(ElementName = "item")]
    public class InventoryItem
    {
        /// <summary>
        /// The ID of the item in the inventory
        /// </summary>
        [XmlAttribute(AttributeName = "__EID__id")]
        public Guid ID { get; set; }
    }

    [XmlRoot(ElementName = "inventory")]
    public class Inventory : XmlCollection<InventoryItem>
    {
        [XmlElement(ElementName = "item")]
        public override InventoryItem[] __Collection { get; set; }
    }

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
    }

    [XmlRoot(ElementName = "connection")]
    public class Connection
    {
        [XmlAttribute(AttributeName = "pipeClass")]
        [DefaultValue("")]
        public String PipeClass { get; set; }

        [XmlAttribute(AttributeName = "pipe")]
        [DefaultValue("")]
        public String Pipe { get; set; }

        [XmlElement(ElementName = "PrioGroup")]
        public PrioCollection PrioGroup { get; set; }
    }

    public class PrioCollection : XmlCollection<Prio>
    {
        [XmlElement(ElementName = "Prio")]
        public override Prio[] __Collection { get; set; }
    }

    public class Prio
    {
        [XmlAttribute(AttributeName = "Value")]
        [DefaultValue("")]
        public String Value { get; set; }
    }

    [XmlRoot(ElementName = "pipes")]
    public class ConnectionCollection : XmlCollection<Connection>
    {
        [XmlElement(ElementName = "connection")]
        public override Connection[] __Collection { get; set; }
    }

    [XmlRoot(ElementName = "ports")]
    public class PortCollection : XmlCollection<Port>
    {
        [XmlElement(ElementName = "port")]
        public override Port[] __Collection { get; set; }
    }

    [XmlRoot(ElementName = "pipes")]
    public class PipeCollection : XmlCollection<Pipe>
    {
        [XmlElement(ElementName = "pipe")]
        public override Pipe[] __Collection { get; set; }
    }

    [XmlRoot(ElementName = "pipe")]
    public class Pipe
    {
        [XmlAttribute(AttributeName = "name")]
        [DefaultValue("")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "class")]
        [DefaultValue("")]
        public String Class { get; set; }

        [XmlAttribute(AttributeName = "priority")]
        [DefaultValue(0)]
        public Int32 Priority { get; set; }

        [XmlAttribute(AttributeName = "type")]
        [DefaultValue(0)]
        public Int32 Type { get; set; }
    }

    [XmlRoot(ElementName = "hangar")]
    public class Hangar : Item
    {
        [XmlAttribute(AttributeName = "owner")]
        [DefaultValue("")]
        public String Owner { get; set; }

        [XmlElement(ElementName = "rooms")]
        public RoomCollection Rooms { get; set; }
    }

    public abstract class XmlCollection<T>
    {
        [XmlAttribute(AttributeName = "count")]
        [DefaultValue(0)]
        public Int32 Count
        {
            get { return this.__Collection == null ? 0 : this.__Collection.Length; }
            set { /* required for xml serialization */ }
        }

        [XmlIgnore]
        public abstract T[] __Collection { get; set; }
        [XmlIgnore]
        public T this[Int32 index]
        {
            get { return this.__Collection[index]; }
            set { this.__Collection[index] = value; }
        }
    }

    [XmlRoot(ElementName = "rooms")]
    public class RoomCollection : XmlCollection<Room>
    {
        [XmlElement(ElementName = "room")]
        public override Room[] __Collection { get; set; }
    }

    [XmlRoot(ElementName = "room")]
    public class Room
    {
        [XmlAttribute(AttributeName = "library")]
        [DefaultValue("")]
        public String Library { get; set; }

        [XmlAttribute(AttributeName = "category")]
        [DefaultValue("")]
        public String Category { get; set; }

        [XmlElement(ElementName = "features")]
        public FeatureCollection Features { get; set; }
    }

    [XmlRoot(ElementName = "features")]
    public class FeatureCollection : XmlCollection<Feature>
    {
        [XmlElement(ElementName = "feature")]
        public override Feature[] __Collection { get; set; }
    }

    [XmlRoot(ElementName = "feature")]
    public class Feature
    {
        [XmlAttribute(AttributeName = "category")]
        [DefaultValue("")]
        public String Category { get; set; }

        [XmlAttribute(AttributeName = "count")]
        public Int32 Count
        {
            get { return this.__Collection == null ? 0 : this.__Collection.Count; }
            set { /* required for xml serialization */ }
        }
        public Boolean ShouldSerializeCount()
        {
            // Generally expect a single item, but if it's a VehicleSpawnPoint - always serialize
            return this.Count > 1 || this.Category == "VehicleSpawnFeature";
        }

        [XmlElement(Type = typeof(ItemLink), ElementName = "item")]
        [XmlElement(Type = typeof(DoorLink), ElementName = "door")]
        [XmlElement(Type = typeof(ShipLink), ElementName = "ship")]
        public ArrayList __Collection { get; set; }

        [XmlIgnore]
        public Object this[Int32 index]
        {
            get { return this.__Collection[index]; }
            set { this.__Collection[index] = value; }
        }
    }

    [XmlRoot(ElementName = "item")]
    public class ItemLink
    {
        [XmlAttribute(AttributeName = "__EID__itemId")]
        [DefaultValue(0)]
        public Guid ItemID { get; set; }

        [XmlAttribute(AttributeName = "type")]
        [DefaultValue(0)]
        public Int32 Type { get; set; }

        [XmlAttribute(AttributeName = "subType")]
        [DefaultValue(0)]
        public Int32 SubType { get; set; }

        [XmlAttribute(AttributeName = "portId")]
        [DefaultValue(0)]
        public Int32 PortID { get; set; }
    }

    [XmlRoot(ElementName = "ship")]
    public class ShipLink
    {
        [XmlAttribute(AttributeName = "__EID__shipId")]
        public Guid ShipID { get; set; }
    }

    [XmlRoot(ElementName = "door")]
    public class DoorLink
    {
        [XmlAttribute(AttributeName = "linkId")]
        [DefaultValue(0)]
        public Int32 LinkID { get; set; }

        [XmlAttribute(AttributeName = "label")]
        [DefaultValue("")]
        public String Label { get; set; }

        [XmlAttribute(AttributeName = "state")]
        [DefaultValue(0)]
        public Int32 State { get; set; }
    }

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
    }

    [Serializable]
    [XmlRoot(ElementName = "player")]
    public class Player : Item
    {
        [XmlAttribute(AttributeName = "loadout")]
        [DefaultValue("")]
        public String Loadout { get; set; }

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