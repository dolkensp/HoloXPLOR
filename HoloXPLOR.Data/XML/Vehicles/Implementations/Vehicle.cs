using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.XML.Vehicles.Implementations
{
    [XmlRoot(ElementName = "Vehicle")]
    public partial class Vehicle
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "category")]
        public String Category { get; set; }

        [XmlAttribute(AttributeName = "displayname")]
        public String DisplayName { get; set; }

        //private String _displayName;

        //[XmlIgnore]
        //public String DisplayName
        //{
        //    get { return this._displayName = this._displayName ?? this._shipKey.ToLocalized(); }
        //    set { this._displayName = value; }
        //}

        //private String _shipKey
        //{
        //    get
        //    {
        //        String key = this.Name;

        //        switch (key)
        //        {
        //            case "AEGS_Avenger_Warlock": return "AEGS_Avenger_Stalker_Warlock";
        //            case "AEGS_Avenger_Titan": return "AEGS_Avenger_Stalker_Titan";
        //        }

        //        return key;
        //    }
        //}

        [XmlAttribute(AttributeName = "classname")]
        public String ClassName { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public String ID { get; set; }

        [XmlAttribute(AttributeName = "dockingclass")]
        [DefaultValue(0)]
        public Int32 DockingClass { get; set; }

        [XmlAttribute(AttributeName = "HudPaletteScheme")]
        public String HUDPaletteScheme { get; set; }

        [XmlAttribute(AttributeName = "requiredItemTags")]
        public String RequiredItemTags { get; set; }

        [XmlAttribute(AttributeName = "itemPortTags")]
        public String ItemPortTags { get; set; }

        [XmlAttribute(AttributeName = "crossSectionMultiplier")]
        public String CrossSectionMultiplier { get; set; }

        [XmlArray(ElementName = "Parts")]
        [XmlArrayItem(ElementName = "Part")]
        public Part[] Parts { get; set; }

        [XmlArray(ElementName = "Modifications")]
        [XmlArrayItem(ElementName = "Modification")]
        public Modification[] Modifications { get; set; }
        
        public override String ToString()
        {
            return String.Format("{0}", this.DisplayName);
        }
    }
}