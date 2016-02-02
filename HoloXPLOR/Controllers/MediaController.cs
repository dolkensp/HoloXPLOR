using BitMiracle.LibJpeg;
using ImageProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HoloXPLOR.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Cache(String slug, String format, String filename)
        {
            String cacheFilename = Server.MapPath(String.Format("~/App_Data/media/{0}/{1}/{2}", slug, format, filename));
            String remoteFilename = String.Format("https://robertsspaceindustries.com/media/{0}/{1}/{2}", slug, "source", filename);

            if (!System.IO.File.Exists(cacheFilename))
            {
                if (!System.IO.Directory.Exists(Path.GetDirectoryName(cacheFilename)))
                    System.IO.Directory.CreateDirectory(Path.GetDirectoryName(cacheFilename));

                using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenRead(remoteFilename))
                    {
                        using (MemoryStream inStream = new MemoryStream())
                        {
                            stream.CopyTo(inStream);

                            using (ImageFactory factory = new ImageFactory())
                            {
                                factory.Load(inStream);

                                String[] parts = format.Split('x');

                                if (parts.Length != 2)
                                {
                                    parts = new String[] { "800", "600" };
                                }

                                factory.Constrain(new System.Drawing.Size
                                {
                                    Height = parts[1].ToInt32(600),
                                    Width = parts[0].ToInt32(800)
                                });

                                // , new System.Drawing.Point
                                // {
                                //     X = factory.Image.Width / 2,
                                //     Y = factory.Image.Height / 2
                                // });

                                if (Path.GetExtension(cacheFilename) == "jpg")
                                {
                                    using (FileStream outStream = new FileStream(cacheFilename, FileMode.Create))
                                    {
                                        factory.Optimize(outStream);
                                    }
                                }
                                else
                                {
                                    factory.Save(cacheFilename);
                                }
                            }
                        }
                    }
                }
            }

            String contentType = MimeMapping.GetMimeMapping(cacheFilename);

            return File(cacheFilename, contentType);
        }
    }
}