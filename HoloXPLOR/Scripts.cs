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

                            if (item != null)
                                Scripts._items[item.Name] = item;
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

        private static Dictionary<String, XML.Vehicles.Implementations.Vehicle> _vehicles;
        public static Dictionary<String, XML.Vehicles.Implementations.Vehicle> Vehicles
        {
            get
            {
                if (Scripts._vehicles == null)
                {
                    Scripts._vehicles = new Dictionary<String, XML.Vehicles.Implementations.Vehicle>(StringComparer.InvariantCultureIgnoreCase);

                    DirectoryInfo vehicleDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml"));

                    #region Load all vehicle files

                    foreach (FileInfo file in vehicleDir.GetFiles("*.xml", SearchOption.TopDirectoryOnly))
                    {
#if !DEBUG
                        try
                        {
#endif
                            var vehicle = File.ReadAllText(file.FullName).FromXML<XML.Vehicles.Implementations.Vehicle>();

                            vehicle = Scripts._CleanEdgeCases(vehicle);

                            if (vehicle != null)
                            {
                                Scripts._vehicles[vehicle.Name] = vehicle;

                                #region Variant Support

                                if (vehicle.Modifications != null && vehicle.Modifications.Length > 0)
                                {
                                    foreach (var modification in vehicle.Modifications)
                                    {
                                        var variantXML = new XmlDocument();
                                        variantXML.LoadXml(vehicle.ToXML().Remove(0, 39));

                                        if (modification.Parts != null && modification.Parts.Length > 0)
                                        {
                                            // TODO: Replace variant parts with modification parts
                                        }

                                        #region Patch Support

                                        if (!String.IsNullOrWhiteSpace(modification.PatchFile))
                                        {
                                            // TODO: Load patch from file
                                            var patch = new XML.Vehicles.Implementations.Modification();

                                            if (patch.Parts != null && patch.Parts.Length > 0)
                                            {
                                                // TODO: Replace variant parts with modification parts
                                            }

                                            patch.Elements = patch.Elements ?? new XML.Vehicles.Implementations.Element[] { };

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

                                        modification.Elements = modification.Elements ?? new XML.Vehicles.Implementations.Element[] { };

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
                            }
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

        private static XML.Vehicles.Implementations.Vehicle _CleanEdgeCases(XML.Vehicles.Implementations.Vehicle vehicle)
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
                    vehicle.DisplayName = "Aegis Avenger Titan";
                    break;
                case "AEGS_Avenger_Warlock":
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
            }

            #endregion

            return vehicle;
        }

        private static XML.Vehicles.Implementations.Part _GetPartByID(XML.Vehicles.Implementations.Part[] parts, String id)
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
                        { "KBAR_BallisticCannon_S3", "11-Series Broadsword" },
                        { "GATS_BallisticGatling_S3", "Mantis GT-220" },
                        { "GATS_BallisticCannon_S3", "Tarantula GT-870 Mark 3" },
                        { "KLWE_LaserRepeater_S3", "CF-227 Panther Repeater" },
                        { "KRIG_BallisticGatling_S3", "KRIG Tigerstreik T-21" },
                        { "BEHR_LaserCannon_S3", "M5A Laser Cannon" },
                        { "APAR_MassDriver_S2", "APAR Mass Driver" },
                        { "BEHR_BallisticRepeater_S2", "SW16BR2 \"Sawbuck\"" },
                        { "BEHR_LaserCannon_S2", "M4A Laser Cannon" },
                        { "KLWE_MassDriverCannon_S1", "Sledge II Mass Driver Cannon" },
                        { "MXOX_NeutronCannon_S2", "NN-14 Neutron Cannon" },
                        { "KLWE_LaserRepeater_S2", "CF-117 Badger Repeater" },
                        { "AMRS_LaserCannon_S2", "Omnisky VI Laser Cannon" },
                        { "GATS_BallisticCannon_S2", "Tarantula GT-870" },
                        { "KRIG_BallisticGatling_S2_Parasite", "Tigerstreik T-19P" },
                        { "GATS_BallisticGatling_S2", "Scorpion GT-215" },
                        { "CNOU_Delta_RocketPod_x18", "R-18 rocket pod" },

                        { "hardpoint_engine_left_attach", "Main Thruster Left" },
                        { "hardpoint_engine_right_attach", "Main Thruster Right" },
                        { "hardpoint_thruster_front_left_top", "Upper Front Left Thruster" },
                        { "hardpoint_thruster_front_right_top", "Upper Front Right Thruster" },
                        { "hardpoint_thruster_front_left_bottom", "Lower Front Left Thruster" },
                        { "hardpoint_thruster_front_right_bottom", "Lower Front Right Thruster" },

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

                        // hardpoint_thruster_center_front_right
                        
                        { "hardpoint_thruster_engine ", "Main Thruster" },
                        { "hardpoint_thruster_retro_bottom_left ", "Lower Left Retro Thruster" },
                        { "hardpoint_thruster_retro_bottom_right", "Lower Right Retro Thruster" },
                        { "hardpoint_thruster_retro_top_left ", "Upper Left Retro Thruster" },
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