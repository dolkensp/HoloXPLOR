using NClone;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;
using Xml = HoloXPLOR.Data.XML;

namespace System
{
    public static class __Proxy
    {
        public static String ToLocalized(this String input) { return HoloXPLOR.Data.Scripts.Localization.GetValue(input ?? String.Empty, input); }
    }
}

namespace HoloXPLOR.Data
{
    public static class Scripts
    {
        #region Item XML

        private static Dictionary<String, XML.Spaceships.Item> _items;
        public static Dictionary<String, XML.Spaceships.Item> Items
        {
            get
            {
                if (Scripts._items == null)
                {
                    Scripts._items = new Dictionary<String, XML.Spaceships.Item>(StringComparer.InvariantCultureIgnoreCase);

                    DirectoryInfo weaponsDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Items/XML/Spaceships"));

                    foreach (FileInfo file in weaponsDir.GetFiles("*.xml", SearchOption.AllDirectories))
                    {
                        if (file.FullName.Contains(@"_Interface\") ||
                            file.FullName.Contains(@"\Interface_") ||
                            file.FullName.Contains(@"\Ammo\Ballistic_Ammo\") ||
                            file.FullName.Contains(@"\Ammo\Countermeasures\") ||
                            file.FullName.Contains(@"\Ammo\Laser_Bolts\") ||
                            file.FullName.Contains(@"\Ammo\Rocket_Ammo\"))
                            continue;

#if !DEBUG || DEBUG
                        try
                        {
#endif
                            var item = File.ReadAllText(file.FullName).FromXML<XML.Spaceships.Item>();

                            if (item == null)
                                continue;

                            item = Scripts._CleanEdgeCases(item);
                            
                            Scripts._items[item.Name] = Scripts._CleanEdgeCases(item);
#if !DEBUG || DEBUG
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Unable to parse {0} - {1}", file.FullName, ex.Message);
                        }
#endif
                    }
                }

                return Scripts._items;
            }
        }

        #endregion

        #region Vehicle XML

        private static Dictionary<String, Ships.Vehicle> _vehicles;
        public static Dictionary<String, Ships.Vehicle> Vehicles
        {
            get
            {
                if (Scripts._vehicles == null)
                {
                    Scripts._vehicles = new Dictionary<String, Ships.Vehicle>(StringComparer.InvariantCultureIgnoreCase);

                    DirectoryInfo vehicleDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml"));

                    #region Load all vehicle files

                    foreach (FileInfo file in vehicleDir.GetFiles("*.xml", SearchOption.TopDirectoryOnly))
                    {
#if !DEBUG
                        try
                        {
#endif
                        var vehicle = File.ReadAllText(file.FullName).FromXML<Ships.Vehicle>();

                        if (vehicle == null)
                            continue;

                        vehicle = Scripts._CleanEdgeCases(vehicle);

                        Scripts._vehicles[vehicle.Name] = vehicle;

                        if (vehicle.Name == "CNOU_Mustang")
                            Scripts._vehicles["CNOU_Mustang_Alpha"] = vehicle;
                        // if (vehicle.Name == "AEGS_Avenger_Stalker_Warlock")
                        //     Scripts._vehicles["AEGS_Avenger_Warlock"] = vehicle;
                        // if (vehicle.Name == "AEGS_Avenger_Stalker_Titan")
                        //     Scripts._vehicles["AEGS_Avenger_Titan"] = vehicle;


                        #region Variant Support

                        if (vehicle.Modifications != null && vehicle.Modifications.Length > 0)
                        {
                            foreach (var modification in vehicle.Modifications)
                            {
                                var variantXML = new XmlDocument();
                                variantXML.LoadXml(vehicle.ToXML().Remove(0, 39));

                                var replacementParts = modification.Parts;

                                #region Patch Support

                                if (!String.IsNullOrWhiteSpace(modification.PatchFile))
                                {
                                    var patch = File.ReadAllText(HttpContext.Current.Server.MapPath(String.Format(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml/{0}.xml", modification.PatchFile))).FromXML<Ships.Modification>();

                                    if (patch.Parts != null && patch.Parts.Length > 0)
                                    {
                                        replacementParts = patch.Parts;
                                    }

                                    patch.Elements = patch.Elements ?? new Ships.Element[] { };

                                    foreach (var difference in patch.Elements)
                                    {
                                        var element = variantXML.SelectSingleNode(String.Format("//*[@id='{0}']", difference.IDRef));

                                        if (element != null)
                                        {
                                            var attribute = element.Attributes[difference.Name];
                                            if (attribute == null)
                                            {
                                                attribute = variantXML.CreateAttribute(difference.Name);
                                                element.Attributes.Append(attribute);
                                            }
                                            attribute.Value = difference.Value;
                                        }
                                    }
                                }

                                #endregion

                                modification.Elements = modification.Elements ?? new Ships.Element[] { };

                                foreach (var difference in modification.Elements)
                                {
                                    var element = variantXML.SelectSingleNode(String.Format("//*[@id='{0}']", difference.IDRef));

                                    if (element != null)
                                    {
                                        var attribute = element.Attributes[difference.Name];
                                        if (attribute == null)
                                        {
                                            attribute = variantXML.CreateAttribute(difference.Name);
                                            element.Attributes.Append(attribute);
                                        }
                                        attribute.Value = difference.Value;
                                    }
                                }

                                var variant = variantXML.InnerXml.FromXML<XML.Vehicles.Implementations.Vehicle>();

                                if (replacementParts != null && replacementParts.Length > 0)
                                    variant.Parts = replacementParts;

                                if (vehicle.Name.Split('_')[0] == modification.Name.Split('_')[0])
                                    variant.Name = modification.Name;
                                else
                                    variant.Name = String.Format("{0}_{1}", variant.Name, modification.Name);

                                variant = Scripts._CleanEdgeCases(variant);

                                variant.Modifications = null;

                                Scripts._vehicles[variant.Name] = variant;
                            }
                        }

                        #endregion
#if !DEBUG
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Unable to parse {0} - {1}", file.FullName, ex.Message);
                        }
#endif
                    }

                    #endregion
                }

                return Scripts._vehicles;
            }
        }


        private static Items.Item _CleanEdgeCases(Items.Item item)
        {
            #region Edge Case Support

            if (item.AmmoBox != null && item.AmmoBox.Items != null)
            {
                switch (item.AmmoBox["ammo_name"])
                {
                    case "BEHR_Flare":
                        item.DisplayName = String.Format("{0} Flares", item.AmmoBox["max_ammo_count"]);
                        item.Params["itemSubType"] = "Ammo_CounterMeasure";
                        break;
                    case "TALN_Chaff":
                        item.DisplayName = String.Format("{0} Chaff", item.AmmoBox["max_ammo_count"]);
                        item.Params["itemSubType"] = "Ammo_CounterMeasure";
                        break;
                    case "20mm_AMMO":         item.DisplayName = String.Format("{0} 20mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "24mm_AMMO":         item.DisplayName = String.Format("{0} 24mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "25mm_AMMO":         item.DisplayName = String.Format("{0} 25mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "30mm_AMMO":         item.DisplayName = String.Format("{0} 30mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "35mm_AMMO":         item.DisplayName = String.Format("{0} 35mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "40mm_AMMO":         item.DisplayName = String.Format("{0} 40mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "40mm_5km_AMMO":     item.DisplayName = String.Format("{0} 40mm Explosive Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "40mm_5km_exp_AMMO": item.DisplayName = String.Format("{0} 40mm Explosive Shells (5km)", item.AmmoBox["max_ammo_count"]); break;
                    case "50mm_AMMO":         item.DisplayName = String.Format("{0} 50mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "60mm_AMMO":         item.DisplayName = String.Format("{0} 60mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "60mm_Rail_AMMO":    item.DisplayName = String.Format("{0} 60mm Slugs", item.AmmoBox["max_ammo_count"]); break;
                    case "80mm_AMMO":         item.DisplayName = String.Format("{0} 80mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "80mm_Rail_AMMO":    item.DisplayName = String.Format("{0} 60mm Slugs", item.AmmoBox["max_ammo_count"]); break;
                    case "106mm_exp_AMMO":    item.DisplayName = String.Format("{0} 106mm Explosive Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "Rocket_AMMO":       item.DisplayName = String.Format("{0} Delta Rockets", item.AmmoBox["max_ammo_count"]); break;
                    default: item.DisplayName = String.Format("{0} {1}", item.AmmoBox["max_ammo_count"], item.AmmoBox["ammo_name"].Replace("_", " ")); break;
                }
            }

            if (item.PortParams != null && item.PortParams.Items != null)
            {
                var cmp = item.PortParams.Items.Where(p => p.Types != null).SelectMany(p => p.Types.Where(t => t.Type == "AmmoBox").Where(t => String.IsNullOrWhiteSpace(t.SubType)));

                foreach (var port in cmp)
                {
                    port.SubType = "Ammo_CounterMeasure";
                }
            }

            switch (item.Name)
            {
                case "Class_2_KRIG_BG_S3_Q3_Mount": item.DisplayName = "Kruger S3 Gattling Nose Mount"; break;
                case "Class_2_GATS_BG_S2_Mount": item.DisplayName = "Gallenson Tactical S2 Gattling Mount"; break;
                case "BEHR_PC2_Dual_S3": item.DisplayName = "Behring Dual Side Turret"; break;
                case "ANVL_Gladiator_Turret_Ball_S2_Q2": item.DisplayName = "Gladiator S4 Ball Turret"; break;
                case "DRAK_Cutlass_Turret": item.DisplayName = "Cutlass Manned Turret"; break;
                case "drak_cutlass_s1_q2": item.DisplayName = "Cutlass Manned Turret"; break;
                case "BRRA_HornetCanard_S2_Q1": item.DisplayName = "Hornet S3 Canard Mount"; break;
                case "BRRA_HornetBall_S2_Q1": item.DisplayName = "Hornet S5 Ball Turret"; break;
                case "CNOU_Mustang_S1_Q2": item.DisplayName = "Consolidated Outland Ball Turret"; break;
                // case "BRRA_HornetBall_160f_S1_Q2": item.DisplayName = "Hornet S5 Ball Turret"; break;
                case "ANVL_Fixed_Mount_Hornet_Ball_S4": item.DisplayName = "Hornet S5 Fixed Mount"; break;
                case "BEHR_PC2_Dual_S4_Fixed": item.DisplayName = "Behring S4 Twin Rack"; break;
                case "AEGS_S2_Rack_x4": item.DisplayName = "Aegis S2 Quad Rack"; break;
                case "ANVL_S5_Rack_x2": item.DisplayName = "Anvil S5 Twin Rack"; break;
                case "Talon_Stalker_Twin": item.DisplayName = "Talon Stalker S2 Twin Rack"; break;
                case "Talon_Stalker_Quad": item.DisplayName = "Talon Stalker S1 Quad Rack"; break;
                case "Talon_Stalker_Platform_x2": item.DisplayName = "Talon Stalker S2 Twin Rack"; break;
                case "Talon_Stalker_Platform_x4": item.DisplayName = "Talon Stalker S1 Quad Rack"; break;
                case "VNCL_Mark_Platform_x4": item.DisplayName = "Vanduul S1 Quad Rack"; break;
                
                case "Mount_Gimbal_S1": item.DisplayName = "S1 Gimbal Mount"; break;
                case "Mount_Gimbal_S2": item.DisplayName = "S2 Gimbal Mount"; break;
                case "Mount_Gimbal_S3": item.DisplayName = "S3 Gimbal Mount"; break;
                case "Mount_Gimbal_S4": item.DisplayName = "S4 Gimbal Mount"; break;
                case "Mount_Gimbal_S5": item.DisplayName = "S5 Gimbal Mount"; break;

                case "JOKR_DistortionCannon_S1": item.DisplayName = "\"Suckerpunch\" Distortion Cannon"; break;
                case "VNCL_Weak_LC_S1": item.DisplayName = "'Weak' Laser Cannon"; break;
                case "KBAR_BallisticCannon_S3": item.DisplayName = "11-Series Broadsword"; break;
                case "GATS_BallisticGatling_S2": item.DisplayName = "Scorpion GT-215"; break;
                case "GATS_BallisticGatling_S3": item.DisplayName = "Mantis GT-220"; break;
                case "GATS_BallisticCannon_S2": item.DisplayName = "Tarantula GT-870"; break;
                case "GATS_BallisticCannon_S3": item.DisplayName = "Tarantula GT-870 Mark 3"; break;
                case "KLWE_LaserRepeater_S3": item.DisplayName = "CF-227 Panther Repeater"; break;
                case "KLWE_LaserRepeater_S2": item.DisplayName = "CF-117 Badger Repeater"; break;
                case "KLWE_LaserRepeater_S1": item.DisplayName = "CF-007 Bulldog Repeater"; break;
                case "KLWE_MassDriverCannon_S1": item.DisplayName = "Sledge II Mass Driver Cannon"; break;
                case "KRIG_BallisticGatling_S3": item.DisplayName = "Kruger Tigerstreik T-21"; break;
                case "KRIG_BallisticGatling_S2_Parasite": item.DisplayName = "Kruger Tigerstreik T-19P"; break;
                case "APAR_MassDriver_S2": item.DisplayName = "Strife Mass Driver"; break;
                case "APAR_BallisticGatling_S4": item.DisplayName = "Death Ballistic Gattling"; break;
                case "AEGS_EMP_Device": item.DisplayName = "REP-8 EMP Generator"; break;
                case "BEHR_LaserCannon_S1": item.DisplayName = "M3A Laser Cannon"; break;
                case "BEHR_LaserCannon_S2": item.DisplayName = "M4A Laser Cannon"; break;
                case "BEHR_LaserCannon_Vanguard_S2": item.DisplayName = "M4A Laser Cannon - Vanguard"; break;
                case "BEHR_LaserCannon_S3": item.DisplayName = "M5A Laser Cannon"; break;
                case "BEHR_LaserCannon_S4": item.DisplayName = "M6A Laser Cannon"; break;
                case "BEHR_BallisticCannon_S4": item.DisplayName = "C-788 \"Combine\" Ballistic Cannon"; break;
                case "BEHR_BallisticRepeater_S2": item.DisplayName = "SW16BR2 \"Sawbuck\""; break;
                case "MXOX_NeutronCannon_S1": item.DisplayName = "Maxox NN-13 Neutron Cannon"; break;
                case "MXOX_NeutronCannon_S2": item.DisplayName = "Maxox NN-14 Neutron Cannon"; break;
                case "AMRS_LaserCannon_S1": item.DisplayName = "Omnisky III Laser Cannon"; break;
                case "AMRS_LaserCannon_S2": item.DisplayName = "Omnisky VI Laser Cannon"; break;
                case "CNOU_Delta_RocketPod_x18": item.DisplayName = "R-18 rocket pod"; break;
            }

            #endregion

            return item;
        }

        private static Ships.Vehicle _CleanEdgeCases(XML.Vehicles.Implementations.Vehicle vehicle)
        {
            #region Edge Case Support

            switch (vehicle.Name)
            {
                case "GRIN_PTV":
                    vehicle.DisplayName = "Greycat Industries PTV";
                    break;
                case "RSI_Constellation":
                    vehicle.Name = "RSI_Constellation_Andromeda";
                    vehicle.DisplayName = "RSI Constellation Andromeda";
                    break;
                case "ORIG_300i":
                    vehicle.Name = "ORIG";
                    break;
                case "VNCL_Scythe":
                    vehicle.DisplayName = "Vanduul Scythe";
                    break;
                case "VNCL_Glaive_Glaive_Swarm":
                    vehicle.DisplayName = "Vanduul Glaive";
                    vehicle.Name = "VNCL_Glaive";
                    break;
                case "VNCL_Glaive_Glaive_Tutorial":
                    vehicle.DisplayName = "Vanduul Glaive";
                    vehicle.Name = "VNCL_Glaive_Tutorial";
                    break;
                case "AEGS_Avenger_Titan":
                case "AEGS_Avenger_Stalker_Titan":
                    vehicle.Name = "AEGS_Avenger_Titan";
                    vehicle.DisplayName = "Aegis Avenger Titan";
                    break;
                case "AEGS_Avenger_Warlock":
                case "AEGS_Avenger_Stalker_Warlock":
                    vehicle.Name = "AEGS_Avenger_Warlock";
                    vehicle.DisplayName = "Aegis Avenger Warlock";
                    break;
                case "AEGS_Avenger_Stalker":
                    vehicle.DisplayName = "Aegis Avenger Stalker";
                    break;
                case "AEGS_Retaliator":
                    vehicle.DisplayName = "Aegis Retaliator";
                    break;
                case "AEGS_Gladius":
                    vehicle.DisplayName = "Aegis Gladius";
                    break;
                case "AEGS_Gladiator":
                    vehicle.DisplayName = "Aegis Gladiator";
                    break;
                case "AEGS_Redeemer":
                    vehicle.DisplayName = "Aegis Redeemer";
                    break;
                default:
                    if (String.IsNullOrWhiteSpace(vehicle.DisplayName))
                        vehicle.DisplayName = vehicle.Name;
                    break;
            }

            #endregion

            return vehicle;
        }

        private static Ships.Part _GetPartByID(XML.Vehicles.Implementations.Part[] parts, String id)
        {
            if (parts != null && parts.Length > 0)
            {
                foreach (var part in parts)
                {
                    if (part.ID == id)
                        return part;

                    var buffer = Scripts._GetPartByID(part.Parts, id);

                    if (buffer != null)
                        return buffer;
                }
            }

            return null;
        }

        #endregion

        private static Dictionary<String, String> _localization;
        public static Dictionary<String, String> Localization
        {
            get
            {
                if (Scripts._localization == null)
                {
                    Scripts._localization = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase)
                    {
                        #region Turret Port Names

                        { "turrethelper", "Manned Turret" },

                        { "turret_left", "Left Turret Slot"},
                        { "turret_right", "Right Turret Slot"},

                        { "hardpoint_class_1_left", "Left Turret Slot"},
                        { "hardpoint_class_1_right", "Right Turret Slot"},

                        { "hardpoint_turret_backtop", "Back Top Turret" },
                        { "hardpoint_turret_backtopleft", "Back Top Left Turret" },
                        { "hardpoint_turret_backtopright", "Back Top Right Turret" },
                        { "hardpoint_turret_backbottom", "Back Bottom Turret" },
                        { "hardpoint_turret_fronttop", "Front Top Turret" },
                        { "hardpoint_turret_fronttopleft", "Front Top Left Turret" },
                        { "hardpoint_turret_fronttopright", "Front Top Right Turret" },
                        { "hardpoint_turret_frontbottom", "Front Bottom Turret" },
                        
                        { "right wing Class 1 Slot", "Right Wing Class 1 Slot" },
                        
                        #endregion

                        #region Shield Port Names

                        { "hardpoint_shieldgenerator_left", "Left Shield" },
                        { "hardpoint_shieldgenerator_right", "Right Shield" },

                        #endregion

                        #region Power Plant Port Names

                        { "hardpoint_powerplant", "Power Plant" },

                        #endregion

                        #region Thruster Port Names

                        { "hardpoint_engine_left_attach", "Main Thruster Left" },
                        { "hardpoint_engine_right_attach", "Main Thruster Right" },
                        { "hardpoint_engine_mid_attach", "Main Thruster" },

                        { "hardpoint_thruster_front_left_bottom", "Lower Front Left Thruster" },
                        { "hardpoint_thruster_front_right_bottom", "Lower Front Right Thruster" },
                        { "hardpoint_thruster_rear_left_bottom", "Lower Rear Left Thruster" },
                        { "hardpoint_thruster_rear_right_bottom", "Lower Rear Right Thruster" },
                        { "hardpoint_thruster_front_left_top", "Upper Front Left Thruster" },
                        { "hardpoint_thruster_front_right_top", "Upper Front Right Thruster" },
                        { "hardpoint_thruster_rear_left_top", "Upper Rear Left Thruster" },
                        { "hardpoint_thruster_rear_right_top", "Upper Rear Right Thruster" },
                        { "hardpoint_thruster_front_left_mid", "Front Left Thruster" },
                        { "hardpoint_thruster_front_right_mid", "Front Right Thruster" },
                        { "hardpoint_thruster_rear_left_mid", "Rear Left Thruster" },
                        { "hardpoint_thruster_rear_right_mid", "Rear Right Thruster" },

                        { "hardpoint_thruster_mid_front_bottom", "Lower Front Thruster" },
                        { "hardpoint_thruster_mid_back_bottom", "Lower Rear Thruster" },
                        { "hardpoint_thruster_mid_front_top", "Upper Front Thruster" },
                        { "hardpoint_thruster_mid_back_top", "Upper Rear Thruster" },
                        { "hardpoint_thruster_mid_front_mid", "Front Thruster" },
                        { "hardpoint_thruster_mid_back_mid", "Rear Thruster" },
                        { "hardpoint_thruster_left_front_bottom", "Lower Front Left Thruster" },
                        { "hardpoint_thruster_left_back_bottom", "Lower Rear Left Thruster" },
                        { "hardpoint_thruster_left_front_top", "Upper Front Left Thruster" },
                        { "hardpoint_thruster_left_back_top", "Upper Rear Left Thruster" },
                        { "hardpoint_thruster_left_front_mid", "Front Left Thruster" },
                        { "hardpoint_thruster_left_back_mid", "Rear Left Thruster" },
                        { "hardpoint_thruster_right_front_bottom", "Lower Front Right Thruster" },
                        { "hardpoint_thruster_right_back_bottom", "Lower Rear Right Thruster" },
                        { "hardpoint_thruster_right_front_top", "Upper Front Right Thruster" },
                        { "hardpoint_thruster_right_back_top", "Upper Rear Right Thruster" },
                        { "hardpoint_thruster_right_front_mid", "Front Right Thruster" },
                        { "hardpoint_thruster_right_back_mid", "Rear Right Thruster" },
                        
                        { "hardpoint_thruster_front_left_lower", "Lower Front Left Thruster" },
                        { "hardpoint_thruster_front_right_lower", "Lower Front Right Thruster" },
                        { "hardpoint_thruster_rear_left_lower", "Lower Rear Left Thruster" },
                        { "hardpoint_thruster_rear_right_lower", "Lower Rear Right Thruster" },
                        { "hardpoint_thruster_front_left_upper", "Upper Front Left Thruster" },
                        { "hardpoint_thruster_front_right_upper", "Upper Front Right Thruster" },
                        { "hardpoint_thruster_rear_left_upper", "Upper Rear Left Thruster" },
                        { "hardpoint_thruster_rear_right_upper", "Upper Rear Right Thruster" },

                        { "hardpoint_engine_left", "Main Thruster Left" },
                        { "hardpoint_engine_right", "Main Thruster Right" },
                        { "hardpoint_thruster_retro_left", "Left Retro Thruster" },
                        { "hardpoint_thruster_retro_right", "Right Retro Thruster" },
                        { "hardpoint_thruster_bottomFL", "Lower Front Left Thruster" },
                        { "hardpoint_thruster_bottomFR", "Lower Front Right Thruster" },
                        { "hardpoint_thruster_bottomRL", "Lower Rear Left Thruster" },
                        { "hardpoint_thruster_bottomRR", "Lower Rear Right Thruster" },
                        { "hardpoint_thruster_topFL", "Upper Front Left Thruster" },
                        { "hardpoint_thruster_topFR", "Upper Front Right Thruster" },
                        { "hardpoint_thruster_topRL", "Upper Rear Left Thruster" },
                        { "hardpoint_thruster_topRR", "Upper Rear Right Thruster" },
                        
                        { "hardpoint_thruster_intake_left_retro", "Left Intake Retro Thruster" },
                        { "hardpoint_thruster_intake_right_retro", "Right Intake Retro Thruster" },

                        { "hardpoint_thruster_front_left_side", "Front Left Side Thruster" },
                        { "hardpoint_thruster_front_right_side", "Front Right Side Thruster" },
                        { "hardpoint_thruster_rear_left_side", "Rear Left Side Thruster" },
                        { "hardpoint_thruster_rear_right_side", "Rear Right Side Thruster" },
                        { "hardpoint_thruster_wing_left_bottom", "Lower Wing Left Thruster" },
                        { "hardpoint_thruster_wing_right_bottom", "Lower Wing Right Thruster" },
                        { "hardpoint_thruster_wing_left_top", "Upper Wing Left Thruster" },
                        { "hardpoint_thruster_wing_right_top", "Upper Wing Right Thruster" },

                        { "hardpoint_thruster_left_retro", "Left Retro Thruster" },
                        { "hardpoint_thruster_right_retro", "Right Retro Thruster" },

                        { "hardpoint_thruster_engine", "Main Thruster" },
                        { "hardpoint_thruster_retro_bottom_left", "Lower Left Retro Thruster" },
                        { "hardpoint_thruster_retro_bottom_right", "Lower Right Retro Thruster" },
                        { "hardpoint_thruster_retro_top_left", "Upper Left Retro Thruster" },
                        { "hardpoint_thruster_retro_top_right", "Upper Right Retro Thruster" },

                        { "hardpoint_engine_attach", "Main Thruster" },
                        { "hardpoint_thruster_left_lower_front", "Lower Front Left Thruster" },
                        { "hardpoint_thruster_right_lower_front", "Lower Front Right Thruster" },
                        { "hardpoint_thruster_left_lower_rear", "Lower Rear Left Thruster" },
                        { "hardpoint_thruster_right_lower_rear", "Lower Rear Right Thruster" },
                        { "hardpoint_thruster_left_upper_front", "Upper Front Left Thruster" },
                        { "hardpoint_thruster_right_upper_front", "Upper Front Right Thruster" },
                        { "hardpoint_thruster_left_upper_rear", "Upper Rear Left Thruster" },
                        { "hardpoint_thruster_right_upper_rear", "Upper Rear Right Thruster" },

                        #endregion
                    };
                }

                return Scripts._localization;
            }
        }

        // https://robertsspaceindustries.com/media/kksqne0o8pi8tr/heap_infobox/BroadSword.jpg
        // https://robertsspaceindustries.com/media/kksqne0o8pi8tr/store_small/BroadSword.jpg
        // https://robertsspaceindustries.com/media/kksqne0o8pi8tr/store_slideshow_small/BroadSword.jpg
    }
}