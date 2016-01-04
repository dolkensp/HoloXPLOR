using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HoloXPLOR.Data
{
    public static class Scripts
    {
        private static Dictionary<String, XML.Spaceships.Item> _items;
        public static Dictionary<String, XML.Spaceships.Item> Items
        {
            get
            {
                if (Scripts._items == null)
                {
                    Scripts._items = new Dictionary<String, XML.Spaceships.Item>();

                    DirectoryInfo weaponsDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Items/XML/Spaceships"));

                    foreach (FileInfo file in weaponsDir.GetFiles("*.xml", SearchOption.AllDirectories))
                    {
                        try
                        {
                            var item = File.ReadAllText(file.FullName).FromXML<XML.Spaceships.Item>();

                            if (item != null)
                                Scripts._items[item.Name] = item;
                        }
                        catch (Exception) { }
                    }
                }

                return Scripts._items;
            }
        }
        private static Dictionary<String, XML.Vehicles.Implementations.Vehicle> _vehicles;
        public static Dictionary<String, XML.Vehicles.Implementations.Vehicle> Vehicles
        {
            get
            {
                if (Scripts._vehicles == null)
                {
                    Scripts._vehicles = new Dictionary<String, XML.Vehicles.Implementations.Vehicle>();

                    DirectoryInfo weaponsDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/App_Data/Scripts/Entities/Vehicles/Implementations/Xml"));

                    foreach (FileInfo file in weaponsDir.GetFiles("*.xml", SearchOption.AllDirectories))
                    {
                        try
                        {
                            var item = File.ReadAllText(file.FullName).FromXML<XML.Vehicles.Implementations.Vehicle>();

                            if (item != null)
                                Scripts._vehicles[item.Name] = item;
                        }
                        catch (Exception) { }
                    }
                }

                return Scripts._vehicles;
            }
        }
    }
}