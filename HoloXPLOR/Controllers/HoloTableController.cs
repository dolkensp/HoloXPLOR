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

namespace HoloXPLOR.Controllers
{
    public class HoloTableController : Controller
    {
        // GET: HoloTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Hangar(String id)
        {
            try
            {
                var model = new DetailModel(id);

                ViewBag.ID = id;

                return View(model);
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
                var model = new DetailModel(id, shipID);

                ViewBag.ID = id;

                return View(model);
            }
            catch (FileNotFoundException)
            {
                return RedirectToAction("NotFound");
            }
        }

        [HttpPost]
        public ActionResult Ship(String id, Guid shipID, Guid targetID, Guid? parentID, String portName)
        {
            try
            {
                var model = new DetailModel(id, shipID);

                // Parents being equipped
                var parentItems = model.Player.Items.Where(i => i.ID == parentID).ToArray();
                var parentShipPorts = model.Player.Ships.Where(s => s.ID == shipID).Where(s => s.Ports != null).Where(s => s.Ports.Items != null).SelectMany(s => s.Ports.Items).Where(p => p.PortName == portName).ToArray();
                var parentItemPorts = model.Player.Items.Where(i => i.ID == parentID).Where(i => i.Ports != null).Where(i => i.Ports.Items != null).SelectMany(i => i.Ports.Items).Where(p => p.PortName == portName).ToArray();
                var parentPorts = parentShipPorts.Concat(parentItemPorts).ToArray();

                // Item IDs being replaced
                var childItemIDs = new HashSet<Guid>(parentPorts.Select(p => p.ItemID));

                var childShipInventory = model.Player.Ships.Where(s => s.Inventory != null).Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items.Where(i => childItemIDs.Contains(i.ID))).ToArray();
                var childHangarInventory = model.Player.Hangar.Inventory.Items.Where(i => childItemIDs.Contains(i.ID)).ToArray();

                var targetShipInventory = model.Player.Ships.Where(s => s.Inventory != null).Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items.Where(i => i.ID == targetID)).ToArray();
                var targetHangarInventory = model.Player.Hangar.Inventory.Items.Where(i => i.ID == targetID).ToArray();
                var targetItems = model.Player.Items.Where(i => i.ID == targetID).ToArray();

                var targetShipPorts = model.Player.Ships.Where(s => s.Ports != null).Where(s => s.Ports.Items != null).SelectMany(s => s.Ports.Items).Where(p => p.ItemID == targetID).ToArray();
                var targetItemPorts = model.Player.Items.Where(i => i.Ports != null).Where(i => i.Ports.Items != null).SelectMany(i => i.Ports.Items).Where(p => p.ItemID == targetID).ToArray();

                var ship = model.Player.Ships.Where(s => s.ID == shipID).SingleOrDefault();

                

                var newItem = model.Player.Items.Where(i => i.ID == targetID).SingleOrDefault();

                var port = model.Player.Items.Where(i => i.ID == parentID).SelectMany(i => i.Ports.Items).Where(p => p.PortName == portName).SingleOrDefault() ??
                    ship.Ports.Items.Where(p => p.PortName == portName).SingleOrDefault();

                var oldPartID = port.ItemID;

                // TODO: Validate parts

                #region Move Old Child Items To Hangar

                var hosts = model.Player.Items.Where(i => i.ID == oldPartID).ToList();

                var nextHost = hosts.FirstOrDefault();

                List<Inventory.InventoryItem> removed = new List<Inventory.InventoryItem> { };

                removed.AddRange(ship.Inventory.Items.Where(i => i.ID == oldPartID));
                removed.AddRange(model.Player.Ships.Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items).Where(i => i.ID == oldPartID));

                if (!removed.Where(i => i.ID == oldPartID).Any())
                    removed.Add(new Inventory.InventoryItem { ID = oldPartID });

                model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != oldPartID).ToArray();
                ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != oldPartID).ToArray();

                while (nextHost != null)
                {
                    hosts.RemoveAt(0);

                    if (nextHost.Ports.Items != null)
                    {
                        foreach (var childPort in nextHost.Ports.Items)
                        {
                            hosts.AddRange(model.Player.Items.Where(i => i.ID == childPort.ItemID));
                            removed.AddRange(ship.Inventory.Items.Where(i => i.ID == childPort.ItemID));
                            removed.AddRange(model.Player.Ships.Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items).Where(i => i.ID == childPort.ItemID));
                            model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                            ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                        }
                    }

                    model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Concat(removed).ToArray();

                    nextHost = hosts.FirstOrDefault();
                }

                #endregion

                #region Move New Child Items To Ship

                hosts = model.Player.Items.Where(i => i.ID == targetID).ToList();

                nextHost = hosts.FirstOrDefault();

                removed = new List<Inventory.InventoryItem> { };

                removed.AddRange(ship.Inventory.Items.Where(i => i.ID == targetID));
                removed.AddRange(model.Player.Ships.Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items).Where(i => i.ID == targetID));

                if (!removed.Where(i => i.ID == targetID).Any())
                    removed.Add(new Inventory.InventoryItem { ID = targetID });

                model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != targetID).ToArray();
                ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != targetID).ToArray();

                while (nextHost != null)
                {
                    hosts.RemoveAt(0);

                    if (nextHost.Ports.Items != null)
                    {
                        foreach (var childPort in nextHost.Ports.Items)
                        {
                            hosts.AddRange(model.Player.Items.Where(i => i.ID == childPort.ItemID));
                            removed.AddRange(ship.Inventory.Items.Where(i => i.ID == childPort.ItemID));
                            removed.AddRange(model.Player.Ships.Where(s => s.Inventory.Items != null).SelectMany(s => s.Inventory.Items).Where(i => i.ID == childPort.ItemID));
                            model.Player.Hangar.Inventory.Items = model.Player.Hangar.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                            ship.Inventory.Items = ship.Inventory.Items.Where(i => i.ID != childPort.ItemID).ToArray();
                        }
                    }

                    ship.Inventory.Items = ship.Inventory.Items.Concat(removed).ToArray();

                    nextHost = hosts.FirstOrDefault();
                }

                #endregion

                // Mount Item
                port.ItemID = targetID;

                // Set current ship (Optional)
                model.Player.VehicleID = shipID;

                model.Save();

                ViewBag.ID = id;

                return View(model);            
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
            String filename = Server.MapPath(String.Format(@"~/App_Data/{0}.xml", id));

            if (!System.IO.File.Exists(filename))
                return RedirectToAction("NotFound");

            return File(filename, "application/xml", String.Format("{0}.xml", id));
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
                        UrlPath = Url.Action("Hangar", new { id = Path.GetFileNameWithoutExtension(xmlFile) })
                    }
                };
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