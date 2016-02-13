using HoloXPLOR.Data.XML.Spaceships;
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
                    sb.AppendFormat(@" data-port-id=""{0}""", this.Name);
                // if (!String.IsNullOrWhiteSpace(this.DisplayName))
                //     sb.AppendFormat(@" data-port-name=""{0}""", this.DisplayName);
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
                if (this.Types != null && this.Types.Count() > 0)
                    sb.AppendFormat(@" data-port-types=""{0}""", String.Join(",", this.Types.Select(t => String.Format("{0}:{1}", t.Type, t.SubType).Trim(':'))));

                return sb.ToString();
            }
        }

        [XmlIgnore]
        public IEnumerable<CategoryEnum> ItemCategories
        {
            get
            {
                if (this.Types != null)
                {
                    foreach (var t in this.Types)
                    {
                        switch (t.Type)
                        {
                            case "Armor":
                                yield return CategoryEnum.Armor;
                                break;
                            case "Shield":
                                yield return CategoryEnum.Shield;
                                break;
                            case "MainThruster":
                                yield return CategoryEnum.Engine;
                                break;
                            case "ManneuverThruster":
                                yield return CategoryEnum.Thruster;
                                break;
                            case "Ordinance":
                                if (t.SubType == "Missile")
                                    yield return CategoryEnum.Missile;
                                else
                                    yield return CategoryEnum.__Unknown__;
                                break;
                            case "Avionics":
                                if (t.SubType == "Cockpit_Audio")
                                    yield return CategoryEnum.CockpitAudio;
                                else
                                    yield return CategoryEnum.__Unknown__;
                                break;
                            case "WeaponMissile":
                                yield return CategoryEnum.MissileRack;
                                break;
                            case "AmmoBox":
                                if (t.SubType == "Ammo_CounterMeasure")
                                    yield return CategoryEnum.CounterMeasure;
                                else
                                    yield return CategoryEnum.AmmoBox;
                                break;
                            case "Turret":
                                yield return CategoryEnum.Turret;
                                break;
                            case "WeaponGun":
                                yield return CategoryEnum.Weapon;
                                break;
                            case "Container":
                                yield return CategoryEnum.Storage;
                                break;
                            case "PowerPlant":
                                yield return CategoryEnum.PowerPlant;
                                break;
                            case "Paints":
                                yield return CategoryEnum.Paints;
                                break;
                            default:
                                yield return CategoryEnum.__Unknown__;
                                break;
                        }
                    }
                }
                else
                {
                    yield return CategoryEnum.__Unknown__;
                }
            }
        }
    }
}
