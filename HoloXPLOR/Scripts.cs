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
using HoloXPLOR.Models;
using HoloXPLOR.DataForge;
using System.Text.RegularExpressions;

namespace HoloXPLOR.Data
{
    public static class Scripts
    {
        #region Item XML

        private static Object _itemsLock = new Object();
        private static Dictionary<String, XML.Spaceships.Item> _items;
        public static Dictionary<String, XML.Spaceships.Item> Items
        {
            get
            {
                if (Scripts._items == null)
                {
                    lock (Scripts._itemsLock)
                    {
                        if (Scripts._items == null)
                        {
                            var buffer = new Dictionary<String, XML.Spaceships.Item>(StringComparer.InvariantCultureIgnoreCase);

                            DirectoryInfo weaponsDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Items/XML/Spaceships"));

                            foreach (FileInfo file in weaponsDir.GetFiles("*.xml", SearchOption.AllDirectories))
                            {
                                if (file.FullName.Contains(@"Interface") ||
                                    file.FullName.Contains(@"\Ammo\Ballistic_Ammo\") ||
                                    file.FullName.Contains(@"\Ammo\Countermeasures\") ||
                                    file.FullName.Contains(@"\Ammo\Laser_Bolts\") ||
                                    file.FullName.Contains(@"\Ammo\Rocket_Ammo\"))
                                    continue;

#if !DEBUG || DEBUG
                                try
                                {
#endif
                                    var item = CryXmlSerializer.Deserialize<XML.Spaceships.Item>(file.FullName);
                                    // var item = File.ReadAllText(file.FullName).FromXML<XML.Spaceships.Item>();

                                    if (item == null)
                                        continue;

                                    item = Scripts._CleanEdgeCases(item);

                                    buffer[item.Name] = Scripts._CleanEdgeCases(item);
#if !DEBUG || DEBUG
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("Unable to parse {0} - {1}", file.FullName, ex.Message);
                                }
#endif
                            }

                            Scripts._items = buffer;
                        }
                    }
                }

                return Scripts._items;
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
                        // item.DisplayName = String.Format("{0} Flares", item.AmmoBox["max_ammo_count"]);
                        item.Params["itemSubType"] = "Ammo_CounterMeasure";
                        break;
                    case "TALN_Chaff":
                        // item.DisplayName = String.Format("{0} Chaff", item.AmmoBox["max_ammo_count"]);
                        item.Params["itemSubType"] = "Ammo_CounterMeasure";
                        break;
                    case "20mm_AMMO": item.DisplayName = String.Format("{0} 20mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "24mm_AMMO": item.DisplayName = String.Format("{0} 24mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "25mm_AMMO": item.DisplayName = String.Format("{0} 25mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "30mm_AMMO": item.DisplayName = String.Format("{0} 30mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "35mm_AMMO": item.DisplayName = String.Format("{0} 35mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "40mm_AMMO": item.DisplayName = String.Format("{0} 40mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "40mm_5km_AMMO": item.DisplayName = String.Format("{0} 40mm Explosive Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "40mm_5km_exp_AMMO": item.DisplayName = String.Format("{0} 40mm Explosive Shells (5km)", item.AmmoBox["max_ammo_count"]); break;
                    case "50mm_AMMO": item.DisplayName = String.Format("{0} 50mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "60mm_AMMO": item.DisplayName = String.Format("{0} 60mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "60mm_Rail_AMMO": item.DisplayName = String.Format("{0} 60mm Slugs", item.AmmoBox["max_ammo_count"]); break;
                    case "80mm_AMMO": item.DisplayName = String.Format("{0} 80mm Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "80mm_Rail_AMMO": item.DisplayName = String.Format("{0} 60mm Slugs", item.AmmoBox["max_ammo_count"]); break;
                    case "106mm_exp_AMMO": item.DisplayName = String.Format("{0} 106mm Explosive Shells", item.AmmoBox["max_ammo_count"]); break;
                    case "Rocket_AMMO": item.DisplayName = String.Format("{0} Delta Rockets", item.AmmoBox["max_ammo_count"]); break;
                    default: item.DisplayName = String.Format("{0} {1}", item.AmmoBox["max_ammo_count"], item.AmmoBox["ammo_name"].Replace("_", " ")); break;
                }
            }

            if (item.Ports != null && item.Ports.Items != null)
            {
                var cmp = item.Ports.Items.Where(p => p.Types != null).SelectMany(p => p.Types.Where(t => t.Type == "AmmoBox").Where(t => String.IsNullOrWhiteSpace(t.SubType)));

                foreach (var port in cmp)
                {
                    port.SubType = "Ammo_CounterMeasure";
                }
            }

            switch (item.Name)
            {
                case "GODI_Retaliator_Shield_S3": item.Params["requiredPortTags"] = "AEGS_Retaliator_Base"; break;
                // case "Class_2_KRIG_BG_S3_Q3_Mount": item.DisplayName = "Kruger S3 Gattling Nose Mount"; break;
                // case "Class_2_GATS_BG_S2_Mount": item.DisplayName = "Gallenson Tactical S2 Gattling Mount"; break;
                // case "BEHR_PC2_Dual_S3": item.DisplayName = "Behring Dual Side Turret"; break;
                // case "ANVL_Gladiator_Turret_Ball_S2_Q2": item.DisplayName = "Gladiator S4 Ball Turret"; break;
                // case "DRAK_Cutlass_Turret": item.DisplayName = "Cutlass Manned Turret"; break;
                // case "MISC_Freelancer_Turret": item.DisplayName = "Freelancer Manned Turret"; break;
                // case "AEGS_Vanguard_Turret": item.DisplayName = "Vanguard Manned Turret"; break;
                // case "AEGS_Retaliator_Turret": item.DisplayName = "Retaliator Manned Turret"; break;
                // case "BRRA_HornetCanard_S2_Q1": item.DisplayName = "Hornet S3 Canard Mount"; break;
                // case "BRRA_HornetBall_S2_Q1": item.DisplayName = "Hornet S5 Ball Turret"; break;
                // case "CNOU_Mustang_S1_Q2": item.DisplayName = "Consolidated Outland Ball Turret"; break;
                // case "BRRA_HornetBall_160f_S1_Q2": item.DisplayName = "Hornet S5 Ball Turret"; break;
                // case "ANVL_Fixed_Mount_Hornet_Ball_S4": item.DisplayName = "Hornet S4 Fixed Mount"; break;
                // case "DRAK_Fixed_Mount_S4": item.DisplayName = "Cutlass S4 Fixed Mount"; break;
                // case "BEHR_PC2_Dual_S4_Fixed": item.DisplayName = "Behring S4 Twin Rack"; break;
                // case "AEGS_S2_Rack_x4": item.DisplayName = "Aegis S2 Quad Rack"; break;
                // case "ANVL_S5_Rack_x2": item.DisplayName = "Anvil S5 Twin Rack"; break;
                // case "Talon_Stalker_Twin": item.DisplayName = "Talon Stalker S2 Twin Rack"; break;
                // case "Talon_Stalker_Quad": item.DisplayName = "Talon Stalker S1 Quad Rack"; break;
                // case "Talon_Stalker_Platform_x2": item.DisplayName = "Talon Stalker S2 Twin Rack"; break;
                // case "Talon_Stalker_Platform_x4": item.DisplayName = "Talon Stalker S1 Quad Rack"; break;
                // case "VNCL_Mark_Platform_x4": item.DisplayName = "Vanduul S1 Quad Rack"; break;

                // case "Mount_Gimbal_S1": item.DisplayName = "S1 Gimbal Mount"; break;
                // case "Mount_Gimbal_S2": item.DisplayName = "S2 Gimbal Mount"; break;
                // case "Mount_Gimbal_S3": item.DisplayName = "S3 Gimbal Mount"; break;
                // case "Mount_Gimbal_S4": item.DisplayName = "S4 Gimbal Mount"; break;
                // case "Mount_Gimbal_S5": item.DisplayName = "S5 Gimbal Mount"; break;

                // case "JOKR_DistortionCannon_S1": item.DisplayName = "\"Suckerpunch\" Distortion Cannon"; break;
                // case "VNCL_Weak_LC_S1": item.DisplayName = "'Weak' Laser Cannon"; break;
                // case "KBAR_BallisticCannon_S1": item.DisplayName = "9-Series Longsword"; break;
                // case "KBAR_BallisticCannon_S3": item.DisplayName = "11-Series Broadsword"; break;
                // case "GATS_BallisticGatling_S2": item.DisplayName = "Scorpion GT-215"; break;
                // case "GATS_BallisticGatling_S3": item.DisplayName = "Mantis GT-220"; break;
                // case "GATS_BallisticCannon_S2": item.DisplayName = "Tarantula GT-870"; break;
                // case "GATS_BallisticCannon_S3": item.DisplayName = "Tarantula GT-870 Mark 3"; break;
                // case "KLWE_LaserRepeater_S3": item.DisplayName = "CF-227 Panther Repeater"; break;
                // case "KLWE_LaserRepeater_S2": item.DisplayName = "CF-117 Badger Repeater"; break;
                // case "KLWE_LaserRepeater_S1": item.DisplayName = "CF-007 Bulldog Repeater"; break;
                // case "KLWE_MassDriverCannon_S1": item.DisplayName = "Sledge II Mass Driver Cannon"; break;
                // case "KRIG_BallisticGatling_S3": item.DisplayName = "Kruger Tigerstreik T-21"; break;
                // case "KRIG_BallisticGatling_S2_Parasite": item.DisplayName = "Kruger Tigerstreik T-19P"; break;
                // case "APAR_MassDriver_S2": item.DisplayName = "Strife Mass Driver"; break;
                // case "APAR_BallisticGatling_S4": item.DisplayName = "Death Ballistic Gattling"; break;
                // case "AEGS_EMP_Device": item.DisplayName = "REP-8 EMP Generator"; break;
                // case "BEHR_LaserCannon_S1": item.DisplayName = "M3A Laser Cannon"; break;
                // case "BEHR_LaserCannon_S2": item.DisplayName = "M4A Laser Cannon"; break;
                // case "BEHR_LaserCannon_Vanguard_S2": item.DisplayName = "M4A Laser Cannon - Vanguard"; break;
                // case "BEHR_LaserCannon_S3": item.DisplayName = "M5A Laser Cannon"; break;
                // case "BEHR_LaserCannon_S4": item.DisplayName = "M6A Laser Cannon"; break;
                // case "BEHR_BallisticCannon_S4": item.DisplayName = "C-788 \"Combine\" Ballistic Cannon"; break;
                // case "BEHR_BallisticRepeater_S2": item.DisplayName = "SW16BR2 \"Sawbuck\""; break;
                // case "MXOX_NeutronCannon_S1": item.DisplayName = "Maxox NN-13 Neutron Cannon"; break;
                // case "MXOX_NeutronCannon_S2": item.DisplayName = "Maxox NN-14 Neutron Cannon"; break;
                // case "AMRS_LaserCannon_S1": item.DisplayName = "Omnisky III Laser Cannon"; break;
                // case "AMRS_LaserCannon_S2": item.DisplayName = "Omnisky VI Laser Cannon"; break;
                // case "CNOU_Delta_RocketPod_x18": item.DisplayName = "R-18 rocket pod"; break;

                // case "VNCL_MissileRack_Blade": item.DisplayName = "Vanduul Blade"; break;
                // case "RSI_Constellation_Turret": item.DisplayName = "Constellation Turret"; break;
                // case "RSI_Constellation_MissilePod_S2_x3": item.DisplayName = "Constellation S2 Triple Rack"; break;
                // case "RSI_Constellation_MissilePod_S1_x7": item.DisplayName = "Constellation S1 Heavy Rack"; break;
            }

            #endregion

            return item;
        }

        #endregion

        #region Ammo XML

        private static Object _ammoLock = new Object();
        private static Dictionary<String, XML.Spaceships.Ammo> _ammo;
        public static Dictionary<String, XML.Spaceships.Ammo> Ammo
        {
            get
            {
                if (Scripts._ammo == null)
                {
                    lock (Scripts._ammoLock)
                    {
                        if (Scripts._ammo == null)
                        {
                            var buffer = new Dictionary<String, XML.Spaceships.Ammo>(StringComparer.InvariantCultureIgnoreCase);

                            DirectoryInfo ammoDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Items/XML/Spaceships/Ammo"));

                            foreach (FileInfo file in ammoDir.GetFiles("*.xml", SearchOption.AllDirectories))
                            {
                                if (file.FullName.Contains(@"AmmoBoxes") ||
                                    file.FullName.Contains(@"TEMP") ||
                                    file.FullName.Contains(@"Interface"))
                                    continue;

#if !DEBUG || DEBUG
                                try
                                {
#endif
                                    var ammo = CryXmlSerializer.Deserialize<XML.Spaceships.Ammo>(file.FullName);
                                    // var ammo = File.ReadAllText(file.FullName).FromXML<XML.Spaceships.Ammo>();

                                    if (ammo == null)
                                        continue;

                                    buffer[ammo.Name] = Scripts._CleanEdgeCases(ammo);
#if !DEBUG || DEBUG
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("Unable to parse {0} - {1}", file.FullName, ex.Message);
                                }
#endif
                            }

                            Scripts._ammo = buffer;
                        }
                    }
                }

                return Scripts._ammo;
            }
        }

        private static Items.Ammo _CleanEdgeCases(Items.Ammo ammo)
        {
            #region Edge Case Support

            #endregion

            return ammo;
        }

        #endregion

        #region Loadout XML

        private static Object _loadoutLock = new Object();
        private static Dictionary<String, XML.Spaceships.Loadout> _loadout;
        public static Dictionary<String, XML.Spaceships.Loadout> Loadout
        {
            get
            {
                if (Scripts._loadout == null)
                {
                    lock (Scripts._loadoutLock)
                    {
                        if (Scripts._loadout == null)
                        {
                            var buffer = new Dictionary<String, XML.Spaceships.Loadout>(StringComparer.InvariantCultureIgnoreCase);

                            DirectoryInfo loadoutDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Loadouts/Vehicles"));

                            foreach (FileInfo file in loadoutDir.GetFiles("*.xml", SearchOption.AllDirectories))
                            {
                                if (file.FullName.Contains(@"Interface"))
                                    continue;
#if !DEBUG || DEBUG
                                try
                                {
#endif
                                    var loadout = CryXmlSerializer.Deserialize<XML.Spaceships.Loadout>(file.FullName);
                                    // var loadout = File.ReadAllText(file.FullName).FromXML<XML.Spaceships.Loadout>();

                                    if (loadout == null)
                                        continue;

                                    String name = Path.GetFileNameWithoutExtension(file.Name).Replace("Default_Loadout_", "");

                                    buffer[name] = loadout;
#if !DEBUG || DEBUG
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("Unable to parse {0} - {1}", file.FullName, ex.Message);
                                }
#endif
                            }

                            Scripts._loadout = buffer;
                        }
                    }
                }

                return Scripts._loadout;
            }
        }

        #endregion

        #region Vehicle XML

        private static Object _vehicleLock = new Object();
        private static Dictionary<String, Ships.Vehicle> _vehicles;
        public static Dictionary<String, Ships.Vehicle> Vehicles
        {
            get
            {
                if (Scripts._vehicles == null)
                {
                    lock (Scripts._vehicleLock)
                    {
                        if (Scripts._vehicles == null)
                        {
                            var buffer = new Dictionary<String, Ships.Vehicle>(StringComparer.InvariantCultureIgnoreCase);

                            DirectoryInfo vehicleDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml"));

                            #region Load all vehicle files

                            foreach (FileInfo file in vehicleDir.GetFiles("*.xml", SearchOption.TopDirectoryOnly))
                            {
#if !DEBUG
                        try
                        {
#endif
                                var vehicle = CryXmlSerializer.Deserialize<Ships.Vehicle>(file.FullName);
                                // var vehicle = File.ReadAllText(file.FullName).FromXML<Ships.Vehicle>();

                                if (vehicle == null)
                                    continue;

                                vehicle = Scripts._CleanEdgeCases(vehicle);

                                buffer[vehicle.Name] = vehicle;

                                if (vehicle.Name == "CNOU_Mustang")
                                    buffer["CNOU_Mustang_Alpha"] = vehicle;

                                if (vehicle.Name == "RSI_Constellation")
                                    buffer["RSI_Constellation_Andromeda"] = vehicle;

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
                                            var patch = CryXmlSerializer.Deserialize<Ships.Modification>(HttpContext.Current.Server.MapPath(String.Format(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml/{0}.xml", modification.PatchFile)));
                                            // var patch = File.ReadAllText(HttpContext.Current.Server.MapPath(String.Format(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml/{0}.xml", modification.PatchFile))).FromXML<Ships.Modification>();

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
                                                else
                                                {
                                                    Debug.WriteLine("Missing node: {0}", difference.IDRef);
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
                                            else
                                            {
                                                Debug.WriteLine("Missing node: {0}", difference.IDRef);
                                            }
                                        }

                                        var variant = variantXML.InnerXml.FromXML<XML.Vehicles.Implementations.Vehicle>();

                                        if (replacementParts != null && replacementParts.Length > 0)
                                            variant.Parts = replacementParts;

                                        if (modification.Name.StartsWith(vehicle.Name))
                                        {
                                            variant.Name = modification.Name;
                                        }
                                        else if (!String.IsNullOrWhiteSpace(Path.GetFileNameWithoutExtension(modification.PatchFile)) && variant.Name != "ORIG_300i")
                                        {
                                            variant.Name = Path.GetFileNameWithoutExtension(modification.PatchFile);
                                        }
                                        else
                                        {
                                            variant.Name = String.Format("{0}_{1}", vehicle.Name.Replace("_300i", ""), modification.Name);
                                        }

                                        variant = Scripts._CleanEdgeCases(variant);

                                        variant.Modifications = null;

                                        buffer[variant.Name] = variant;
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

                            Scripts._vehicles = buffer;
                        }
                    }
                }

                return Scripts._vehicles;
            }
        }


        private static Ships.Vehicle _CleanEdgeCases(XML.Vehicles.Implementations.Vehicle vehicle)
        {
            if (vehicle.Name == "ANVL_F7CM") vehicle.Name = "ANVL_Hornet_F7CM";

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

        private static Dictionary<Int32, ShipMatrixJson> _shipJsonMap;
        public static Dictionary<Int32, ShipMatrixJson> ShipJsonMap
        {
            get { return _shipJsonMap = _shipJsonMap ?? File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/shipmatrix.json")).FromJSON<ShipMatrixJson[]>().ToDictionary(k => k.ID, v => v); }
        }

        public static Dictionary<String, Int32> ShipJsonLookup = new Dictionary<String, Int32>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "ANVL_Hornet_F7CR", 14 },
            { "ANVL_Hornet_F7CS", 13 },
            { "ANVL_Hornet_F7CM", 15 },
            { "ANVL_Hornet_F7C", 11 },
            { "ANVL_Hornet_F7A", 37 },
            { "RSI_Aurora_CL", 5 },
            { "RSI_Aurora_ES", 1 },
            { "RSI_Aurora_LN", 6 },
            { "RSI_Aurora_LX", 3 },
            { "RSI_Aurora_MR", 4 },
            { "AEGS_Avenger", 100 },
            { "AEGS_Avenger_Stalker", 100 },
            { "AEGS_Avenger_Titan", 102 },
            { "AEGS_Avenger_Warlock", 101 },
            { "ANVL_Gladiator", 64 },
            { "AEGS_Gladius", 60 },
            { "ORIG", 7 },
            { "ORIG_300i", 7 },
            { "ORIG_315p", 8 },
            { "ORIG_325a", 9 },
            { "ORIG_350R", 10 },
            { "MISC_Starfarer", 88 },
            { "MISC_Starfarer_Gemini", 89 },
            { "RSI_Constellation", 45 },
            { "RSI_Constellation_Andromeda", 45 },
            { "RSI_Constellation_Taurus", 46 },
            { "RSI_Constellation_Hangar_Taurus", 46 },
            { "RSI_Constellation_Phoenix", 49 },
            { "RSI_Constellation_Hangar_Phoenix", 49 },
            { "RSI_Constellation_Aquila", 47 },
            { "RSI_Constellation_Hangar_Aquila", 47 },
            { "DRAK_Cutlass", 56 },
            { "DRAK_Cutlass_Black", 56 },
            { "DRAK_Cutlass_Red", 57 },
            { "DRAK_Cutlass_Blue", 58 },
            { "DRAK_Caterpillar", 24 },
            { "VNCL_Glaive", 93 },
            { "VNCL_Scythe", 26 },
            { "AEGS_Vanguard", 75 },
            { "AEGS_Vanguard_Warden", 75 },
            { "AEGS_Vanguard_Harbringer", 95 },
            { "AEGS_Vanguard_Sentinel", 96 },
            { "AEGS_Idris", 27 },
            { "AEGS_Idris_M", 27 },
            { "AEGS_Idris_P", 28 },
            { "AEGS_Retaliator", 72 },
            { "AEGS_Retaliator_Bomber", 72 },
            { "AEGS_Retaliator_Base", 99 },
            { "MISC_Freelancer", 16 },
            { "MISC_Freelancer_Base", 16 },
            { "MISC_Freelancer_DUR", 31 },
            { "MISC_Freelancer_MAX", 32 },
            { "MISC_Freelancer_MIS", 33 },
            { "ORIG_m50", 22 },
            { "CNOU_Mustang", 65 },
            { "CNOU_Mustang_Alpha", 65 },
            { "CNOU_Mustang_Beta", 66 },
            { "CNOU_Mustang_Delta", 69 },
            { "CNOU_Mustang_Gamma", 67 },
            { "CNOU_Mustang_Omega", 70 },
            { "Xian_Khartu", 35 },
            { "Xian_Khartu_Al", 35 },
            { "Xian_Scout", 35 },
            { "Banu_Merchantman", 36 },
            { "ORIG_890_Jump", 55 },
            { "KRIG_P52_Merlin", 92 },
            { "KRIG_P72_Archimedes", 104 },
            { "AEGS_Redeemer", 59 },
            { "AEGS_Sabre", 98 },
        };

        // https://robertsspaceindustries.com/media/kksqne0o8pi8tr/heap_infobox/BroadSword.jpg
        // https://robertsspaceindustries.com/media/kksqne0o8pi8tr/store_small/BroadSword.jpg
        // https://robertsspaceindustries.com/media/kksqne0o8pi8tr/store_slideshow_small/BroadSword.jpg
    }
}