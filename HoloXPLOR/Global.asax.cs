using HoloXPLOR.DataForge;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Inventory = HoloXPLOR.Data.Xml.Inventory;
using Ships = HoloXPLOR.Data.Xml.Vehicles.Implementations;
using Items = HoloXPLOR.Data.Xml.Spaceships;
using Xml = HoloXPLOR.Data.Xml;
using Scripts = HoloXPLOR.Data.Scripts;

namespace HoloXPLOR
{
    public class HoloXPLOR_App : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HoloXPLOR_App.CheckForNewBuild();

            ThreadStart ts = new ThreadStart(HoloXPLOR_App.CheckForNewBuild);
            new Thread(ts).Start();
        }

        private static Boolean _stopping = false;
        private static String _launcherInfo = @"http://manifest.robertsspaceindustries.com/Launcher/_LauncherInfo";
        private static DateTime _lastRun;
        public static Random _random = new Random();

        public static Scripts Scripts { get; private set; }

        protected void Application_End()
        {
            _stopping = true;
        }

        public static void CheckForNewBuild()
        {
            String launcherInfo = String.Empty;
            String universe = ConfigurationManager.AppSettings["HoloXPLOR.Universe"] ?? "Public";
            Regex versionRegex = new Regex(@"^(.*?)_version = (\d+\.\d+\.\d+) - (\d+)");
            Regex manifestRegex = new Regex(@"^(.*?)_fileIndex = (.*\.json)");

            String publicUniverse = String.Empty;
            String publicVersion = String.Empty;
            Int64 publicBuild = 0;

            String currentUniverse = String.Empty;
            String currentVersion = String.Empty;
            Int64 currentBuild = 0;

            String latestUniverse = String.Empty;
            String latestVersion = String.Empty;
            Int64 latestBuild = 0;

            var manifests = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase) { };

            while (!_stopping)
            {
                if ((DateTime.Now - _lastRun).TotalMinutes > 10)
                {
                    try
                    {
                        _lastRun = DateTime.Now;

                        using (WebClient client = new WebClient())
                        {
                            launcherInfo = client.DownloadString(_launcherInfo);
                        }

                        var lines = launcherInfo.Split(new Char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var line in lines)
                        {
                            var match = versionRegex.Match(line);

                            if (match.Success)
                            {
                                if (String.Equals(match.Groups[1].Value, "Public", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    publicUniverse = match.Groups[1].Value;
                                    publicVersion = match.Groups[2].Value;
                                    publicBuild = match.Groups[3].Value.ToInt64(0);
                                }

                                if (String.Equals(match.Groups[1].Value, universe, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    currentUniverse = match.Groups[1].Value;
                                    currentVersion = match.Groups[2].Value;
                                    currentBuild = match.Groups[3].Value.ToInt64(0);
                                }

                                if (match.Groups[3].Value.ToInt64() > latestBuild)
                                {
                                    latestUniverse = match.Groups[1].Value;
                                    latestVersion = match.Groups[2].Value;
                                    latestBuild = match.Groups[3].Value.ToInt64(0);
                                }
                            }

                            match = manifestRegex.Match(line);

                            if (match.Success)
                            {
                                manifests[match.Groups[1].Value] = match.Groups[2].Value;
                            }
                        }

                        CheckScripts(currentBuild, manifests[currentUniverse]);

                        HoloXPLOR_App.HasPTU = publicBuild < latestBuild;
                    }
                    catch (Exception e)
                    {
                        Elmah.ErrorLog.GetDefault(System.Web.HttpContext.Current).Log(new Elmah.Error(e));
                    }
                }

                Thread.Sleep(500);
            }
        }

        public static void CheckScripts(Int64 build, String manifestFile)
        {
            var scripts = HoloXPLOR_App.Scripts;

            HoloXPLOR_App._scriptsPath = HostingEnvironment.MapPath(String.Format("~/App_Data/Scripts-{0}", build));

            if (!Directory.Exists(HoloXPLOR_App._scriptsPath))
            {
                Directory.CreateDirectory(HoloXPLOR_App._scriptsPath);
            }

            if (!File.Exists(Path.Combine(HoloXPLOR_App._scriptsPath, "game.xml")))
            {
                using (WebClient client = new WebClient())
                {
                    // client.DownloadFile(manifestFile, Path.Combine(scriptsPath, String.Format("{0}.json", build)));
                    var manifest = client.DownloadString(manifestFile).FromJSON<Manifest>();

                    #region Download DataXML.pak

                    using (Stream pakStream = client.OpenRead(String.Format("{0}/{1}/{2}", manifest.WebseedUrls[HoloXPLOR_App._random.Next(manifest.WebseedUrls.Length)], manifest.KeyPrefix, "Data/DataXML.pak")))
                    {
                        using (var zipStream = new ZipInputStream(pakStream))
                        {
                            ZipEntry zipEntry = zipStream.GetNextEntry();
                            while (zipEntry != null)
                            {
                                String entryFileName = zipEntry.Name;

                                if (entryFileName.StartsWith("Scripts"))
                                {
                                    String fullZipToPath = Path.Combine(HoloXPLOR_App._scriptsPath, entryFileName).Replace(@"\Scripts\", @"\");
                                    String directoryName = Path.GetDirectoryName(fullZipToPath);

                                    if (directoryName.Length > 0)
                                    {
                                        Directory.CreateDirectory(directoryName);
                                    }

                                    using (var ms = new MemoryStream())
                                    {
                                        zipStream.CopyTo(ms);

                                        ms.Seek(0, SeekOrigin.Begin);

                                        var xml = CryXmlSerializer.ReadStream(ms);
                                        xml.Save(fullZipToPath);
                                    }
                                }

                                zipEntry = zipStream.GetNextEntry();
                            }
                        }
                    }

                    #endregion

                    #region Download GameData.pak

                    using (Stream pakStream = client.OpenRead(String.Format("{0}/{1}/{2}", manifest.WebseedUrls[HoloXPLOR_App._random.Next(manifest.WebseedUrls.Length)], manifest.KeyPrefix, "Data/GameData.pak")))
                    {
                        using (var zipStream = new ZipInputStream(pakStream))
                        {
                            ZipEntry zipEntry = zipStream.GetNextEntry();
                            while (zipEntry != null)
                            {
                                String entryFileName = zipEntry.Name;

                                if (entryFileName.EndsWith(".dcb"))
                                {
                                    String fullZipToPath = Path.Combine(HoloXPLOR_App._scriptsPath, "game.xml");
                                    
                                    using (var ms = new MemoryStream())
                                    {
                                        zipStream.CopyTo(ms);
                                        ms.Seek(0, SeekOrigin.Begin);

                                        using (var br = new BinaryReader(ms))
                                        {
                                            var df = new DataForge.DataForge(br);
                                            // df.GenerateXML();
                                            df.Save(fullZipToPath);
                                        }
                                    }
                                }

                                zipEntry = zipStream.GetNextEntry();
                            }
                        }
                    }

                    #endregion
                }

                scripts = new Scripts(HoloXPLOR_App._scriptsPath);
            }

            scripts = scripts ?? new Scripts(HoloXPLOR_App._scriptsPath);

            if (scripts.Ammo.Count > 0 &
                scripts.Items.Count > 0 &&
                scripts.Loadout.Count > 0 &&
                scripts.Localization.Count > 0 &&
                scripts.Vehicles.Count > 0)
            {
                HoloXPLOR_App.Scripts = scripts;
            }
        }

        private static String _scriptsPath { get; set; }

        public static Boolean HasPTU { get; private set; }

        public static Boolean IsPTU
        {
            get { return String.Equals(System.Web.HttpContext.Current.Request.Url.Host, "ptu.holoxplor.space", StringComparison.InvariantCultureIgnoreCase); }
        }
    }

    public class Manifest
    {
        [JsonProperty(PropertyName = "byte_count_total")]
        public UInt64 ByteCountTotal { get; set; }

        [JsonProperty(PropertyName = "file_count_total")]
        public UInt32 FileCountTotal { get; set; }

        [JsonProperty(PropertyName = "file_list")]
        public String[] FileList { get; set; }

        [JsonProperty(PropertyName = "key_prefix")]
        public String KeyPrefix { get; set; }

        [JsonProperty(PropertyName = "webseed_urls")]
        public String[] WebseedUrls { get; set; }
    }
}
