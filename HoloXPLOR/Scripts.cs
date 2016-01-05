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
                        catch (Exception) { }
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
                case "RSI_Constellation_Hangar_Aquila":
                    vehicle.Name = "RSI_Constellation_Aquila";
                    break;
                case "RSI_Constellation_Hangar_Taurus":
                    vehicle.Name = "RSI_Constellation_Taurus";
                    break;
                case "RSI_Constellation_Hangar_Phoenix":
                    vehicle.Name = "RSI_Constellation_Phoenix";
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

        #region HardPoint XML

        private static Dictionary<String, Dictionary<String, XML.Vehicles.Implementations.Part>> _hardpoints;
        public static Dictionary<String, Dictionary<String, XML.Vehicles.Implementations.Part>> Hardpoints
        {
            get
            {
                if (Scripts._hardpoints == null)
                {
                    Scripts._hardpoints = new Dictionary<String, Dictionary<String, XML.Vehicles.Implementations.Part>>(StringComparer.InvariantCultureIgnoreCase);

                    foreach (var vehicle in Scripts.Vehicles.Values)
                        Scripts._hardpoints[vehicle.Name] = Scripts._GetHardpoints(vehicle.Parts, null, "ItemPort");
                }

                return Scripts._hardpoints;
            }
        }

        private static Dictionary<String, XML.Vehicles.Implementations.Part> _GetHardpoints(XML.Vehicles.Implementations.Part[] parts, Dictionary<String, XML.Vehicles.Implementations.Part> buffer = null, params String[] filters)
        {
            if (buffer == null)
                buffer = new Dictionary<String, XML.Vehicles.Implementations.Part>(StringComparer.InvariantCultureIgnoreCase);

            if (parts == null)
                return buffer;

            foreach (var part in parts)
            {
                if (filters.Contains(part.Class))
                    buffer[part.Name] = part;

                Scripts._GetHardpoints(part.Parts, buffer, filters);
            }

            return buffer;
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