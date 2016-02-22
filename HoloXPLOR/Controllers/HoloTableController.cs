using HoloXPLOR.Data;
using HoloXPLOR.Data.XML.Inventory;
using HoloXPLOR.Models.HoloTable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;
using Xml = HoloXPLOR.Data.XML;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace HoloXPLOR.Controllers
{
    public class HoloTableController : Controller
    {
        private static Dictionary<String, Object> _lockMap = new Dictionary<String, Object>(StringComparer.InvariantCultureIgnoreCase);

        // GET: HoloTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hangar(String id)
        {
            try
            {
                HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

                lock (HoloTableController._lockMap[id])
                {
                    var model = new DetailModel(id);

                    ViewBag.ID = id;

                    return View(model);
                }
            }
            catch (FileNotFoundException)
            {
                return RedirectToAction("NotFound");
            }
        }

        public ActionResult Ship(String id, Guid shipID)
        {
            try
            {
                HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

                lock (HoloTableController._lockMap[id])
                {
                    var model = new DetailModel(id, shipID);

                    ViewBag.ID = id;

                    return View(model);
                }
            }
            catch (FileNotFoundException)
            {
                return RedirectToAction("NotFound");
            }
        }

        public ActionResult Inventory(String id)
        {
            HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

            lock (HoloTableController._lockMap[id])
            {
                DetailModel model = new DetailModel(id);
                HashSet<String> currentItems = new HashSet<String>(model.GameData_ItemMap.Values.Where(i => i.ItemCategory != Items.CategoryEnum.__Unknown__).Select(k => k.Name).Distinct());

                return new ContentResult
                {

                    Content = new
                    {
                        Inventory = Scripts.Items.Values.Where(i => currentItems.Contains(i.Name)).ToDictionary(k => k.Name, v => v),
                        Ammo = Scripts.Ammo.Values.Where(i => i.Class != "Countermeasure").ToDictionary(k => k.Name, v => v),
                        Loadouts = Scripts.Loadout.ToDictionary(k => k.Key, v => Scripts.Vehicles.GetValue(v.Key, new Ships.Vehicle { }).DisplayName)
                        // Ship = Scripts.Vehicles.Values.GroupBy(g => g.Name).ToDictionary(k => k.Key, v => v.FirstOrDefault().DisplayName)
                    }.ToJSON(),
                    ContentType = "application/json"
                };
            }
        }

        // http://holoxplor.ddrit.com/HoloTable/Rating/sample/00fa8108-001c-bff0-0000-000000000000/ANVL_Hornet_F7CM
        public ActionResult Rating(String id, Guid shipID, String targetShip)
        {
            HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

            lock (HoloTableController._lockMap[id])
            {
                DetailModel model = new DetailModel(id, shipID);

                ShipLoadout selfLoadout = new ShipLoadout(model);
                ShipLoadout enemyLoadout = new ShipLoadout(targetShip);

                return new ContentResult
                {
                    Content = new
                    {
                        Self = selfLoadout,
                        Enemy = enemyLoadout,
                    }.ToJSON(),
                    ContentType = "application/json"
                };
            }
        }

        public ActionResult Delete(String id)
        {
            if (String.Equals("sample", id, StringComparison.InvariantCultureIgnoreCase))
            {
                return RedirectToAction("NotAllowed");
            }

            HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

            lock (HoloTableController._lockMap[id])
            {
                String filename = HttpContext.Server.MapPath(String.Format(@"~/App_Data/{0}.xml", id));

                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
            }

            return View();
        }

        private IEnumerable<Guid> FlattenIDs(DetailModel model, Item item)
        {
            if (item != null || item.ID != Guid.Empty)
            {
                yield return item.ID;

                if (item.Ports != null && item.Ports.Items != null)
                    foreach (var childID in item.Ports.Items.Where(i => i.ItemID != Guid.Empty).SelectMany(i => this.FlattenIDs(model, model.Inventory_ItemMap.GetValue(i.ItemID, null))))
                        yield return childID;
            }
        }

        [HttpPost]
        public ActionResult Ship(String id, Guid shipID, Guid newID, Guid? parentID, String portName)
        {
            try
            {
                HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

                lock (HoloTableController._lockMap[id])
                {
                    var model = new DetailModel(id, shipID);

                    // Parents being equipped
                    var parentItems = model.Player.Items.Where(i => i.ID == parentID).ToArray();

                    // Ports being equipped
                    var newShipPorts = model.Player.Ships.Where(s => s.ID == shipID).Where(s => s.Ports != null).Where(s => s.Ports.Items != null).SelectMany(s => s.Ports.Items).Where(p => p.PortName == portName).ToArray();
                    var newItemPorts = model.Player.Items.Where(i => i.ID == parentID).Where(i => i.Ports != null).Where(i => i.Ports.Items != null).SelectMany(i => i.Ports.Items).Where(p => p.PortName == portName).ToArray();
                    var newPorts = newShipPorts.Concat(newItemPorts).ToArray();

                    // Item IDs being replaced
                    var oldItemIDs = new HashSet<Guid>(newPorts.Select(p => p.ItemID));

                    // Items being replaced
                    var oldItems = model.Player.Items.Where(i => oldItemIDs.Contains(i.ID)).ToArray();
                    var oldIDs = new HashSet<Guid>(oldItems.SelectMany(i => this.FlattenIDs(model, i)));

                    // Inventory being moved
                    var oldHangarInventory = model.Player.Inventory.Items.Where(i => oldIDs.Contains(i.ID));
                    var oldShipInventory = model.Player.Ships.Where(s => s.Inventory != null).Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items.Where(i => oldIDs.Contains(i.ID)));
                    var oldInventory = oldShipInventory.Union(oldHangarInventory).ToArray();

                    // Items being equipped
                    var newItems = model.Player.Items.Where(i => i.ID == newID).ToArray();
                    var newIDs = new HashSet<Guid>(newItems.SelectMany(i => this.FlattenIDs(model, i)));

                    // Inventory being moved
                    var newHangarInventory = model.Player.Inventory.Items.Where(i => newIDs.Contains(i.ID));
                    var newShipInventory = model.Player.Ships.Where(s => s.Inventory != null).Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items.Where(i => newIDs.Contains(i.ID)));
                    var newInventory = newShipInventory.Union(newHangarInventory).ToArray();

                    // Old ports
                    var oldShipPorts = model.Player.Ships.Where(s => s.Ports != null).Where(s => s.Ports.Items != null).SelectMany(s => s.Ports.Items).Where(p => p.ItemID == newID).Where(p => p.ItemID != Guid.Empty).ToArray();
                    var oldItemPorts = model.Player.Items.Where(i => i.Ports != null).Where(i => i.Ports.Items != null).SelectMany(i => i.Ports.Items).Where(p => p.ItemID == newID).Where(p => p.ItemID != Guid.Empty).ToArray();
                    var oldPorts = oldItemPorts.Concat(oldShipPorts).ToArray();

                    // Configure Ship inventory
                    foreach (var ship in model.Player.Ships.Where(s => s.Inventory != null).Where(s => s.Inventory.Items != null))
                    {
                        ship.Inventory.Items = ship.Inventory.Items.Where(i => !oldIDs.Contains(i.ID)).Where(i => !newIDs.Contains(i.ID)).ToArray();

                        if (ship.ID == shipID)
                        {
                            ship.Inventory.Items = ship.Inventory.Items.Union(newInventory).ToArray();
                        }
                    }

                    // Configure Player inventory
                    var shipItemIDs = new HashSet<Guid>(model.Player.Ships.Where(s => s.Inventory != null).Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items).Select(i => i.ID));

                    model.Player.Inventory = new Inventory.Inventory
                    {
                        Items = model.Player.Items.Where(i => !shipItemIDs.Contains(i.ID)).Select(i => new Inventory.InventoryItem { ID = i.ID }).ToArray()
                    };

                    var oldPort = oldPorts.SingleOrDefault();

                    if (oldPort != null)
                    {
                        oldPort.ItemID = oldItemIDs.Distinct().SingleOrDefault();
                    }

                    var newPort = newPorts.SingleOrDefault();

                    if (newPort != null)
                    {
                        newPort.ItemID = newID;
                    }

                    // TODO: Validate parts

                    // Set current ship (Optional)
                    model.Player.VehicleID = shipID;

                    model.Save();

                    ViewBag.ID = id;

                    return View(model);
                }
            }
            catch (FileNotFoundException)
            {
                this.Response.StatusCode = 500;

                return new JsonResult
                {
                    Data = new
                    {
                        Reason = "Hangar Removed"
                    }
                };
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));

                this.Response.StatusCode = 500;

                return new JsonResult
                {
                    Data = new
                    {
                        Reason = "System Error"
                    }
                };
            }
        }

        public ActionResult Download(String id)
        {
            HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

            lock (HoloTableController._lockMap[id])
            {
                String filename = Server.MapPath(String.Format(@"~/App_Data/{0}.xml", id));

                if (!System.IO.File.Exists(filename))
                    return RedirectToAction("NotFound");

                return File(filename, "application/xml", String.Format("{0}.xml", id));
            }
        }

        public enum UploadResult
        {
            Success = 200,
            FileTooLarge = 413,
            InvalidFileFormat = 415,
            ServerError = 500
        }

        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            try
            {
                String xmlFile = Server.MapPath(String.Format(@"~/App_Data/{0}.xml", Path.GetFileNameWithoutExtension(file.FileName)));
                String bakFile = Server.MapPath(String.Format(@"~/App_Data/{0}.bak", Path.GetFileNameWithoutExtension(file.FileName)));
                String tmpFile = Server.MapPath(String.Format(@"~/App_Data/{0}.tmp", Path.GetFileNameWithoutExtension(file.FileName)));

                if (file.ContentLength > 0x500000)
                {
                    this.Response.StatusCode = (Int32)UploadResult.FileTooLarge;
                    return new JsonResult { Data = new { Result = UploadResult.FileTooLarge } };
                }

                if (System.IO.File.Exists(tmpFile))
                {
                    System.IO.File.Delete(tmpFile);
                }

                file.SaveAs(tmpFile);

                try
                {
                    var temp = System.IO.File.ReadAllText(tmpFile).FromXML<Inventory.Player>();
                    if (temp.Hangar == null || temp.Hangar.Inventory == null || temp.Hangar.Inventory.Count == 0)
                    {
                        this.Response.StatusCode = (Int32)UploadResult.InvalidFileFormat;
                        return new JsonResult { Data = new { Result = UploadResult.InvalidFileFormat } };
                    }
                }
                catch (Exception)
                {
                    System.IO.File.Delete(tmpFile);
                    this.Response.StatusCode = (Int32)UploadResult.InvalidFileFormat;
                    return new JsonResult { Data = new { Result = UploadResult.InvalidFileFormat } };
                }

                String id = Path.GetFileNameWithoutExtension(xmlFile);

                HoloTableController._lockMap[id] = HoloTableController._lockMap.GetValue(id, new Object());

                lock (HoloTableController._lockMap[id])
                {

                    if (System.IO.File.Exists(bakFile))
                    {
                        System.IO.File.Delete(bakFile);
                    }

                    if (System.IO.File.Exists(xmlFile))
                    {
                        System.IO.File.Delete(xmlFile);
                    }

                    System.IO.File.Move(tmpFile, xmlFile);

                    return new JsonResult
                    {
                        Data = new
                        {
                            Result = UploadResult.Success,
                            UrlPath = Url.Action("Hangar", new { id = id })
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(ex));

                this.Response.StatusCode = (Int32)UploadResult.ServerError;

                return new JsonResult { Data = new { Result = UploadResult.ServerError } };
            }
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}