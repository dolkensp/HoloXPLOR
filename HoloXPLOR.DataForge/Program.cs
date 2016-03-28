using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public static class Program
    {
        private static Boolean _overwrite = false;

        public static void Main(params String[] args)
        {
            UInt32 test = 0xFFFFFFFF;
            Int32 test2 = (Int32)test;
            Boolean test3 = test2 == 0xFFFFFFFF;
            // args = new String[] { "Game-2.2.3.dcb" };
            // args = new String[] { @"O:\Mods\BuildXPLOR\_manifest\333246" };

            if ((args.Length > 0) && Directory.Exists(args[0]))
            {
                _overwrite = true;

                foreach (var file in Directory.GetFiles(args[0], "*.*", SearchOption.AllDirectories))
                {
                    if (new String[] { "ini", "txt" }.Contains(Path.GetExtension(file), StringComparer.InvariantCultureIgnoreCase)) continue;

                    try
                    {
                        Console.WriteLine("Converting {0}", file.Replace(args[0], ""));

                        Program.Process(file);
                    }
                    catch (Exception) { }
                }
            }
            else
            {
                Program.Process(args);
            }
        }

        public static void Process(params String[] args)
        {

            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("Usage: HoloXPLOR.DataForge.exe [infile]");
                Console.WriteLine();
                Console.WriteLine("Converts any Star Citizen binary file into an actual XML file.");
                Console.WriteLine("CryXml files (.xml) are saved as .raw in the original location.");
                Console.WriteLine("DataForge files (.dcb) are saved as .xml in the original location.");
                return;
            }

            try
            {
                if (File.Exists(args[0]))
                {
                    if (Path.GetExtension(args[0]) == ".dcb")
                    {
                        using (BinaryReader br = new BinaryReader(File.OpenRead(args[0])))
                        {
                            var legacy = new FileInfo(args[0]).Length < 0x0e2e00;
                            
                            var df = new DataForge(br, legacy);

                            df.Save(Path.ChangeExtension(args[0], "xml"));
                        }
                    }
                    else
                    {
                        var xml = CryXmlSerializer.ReadFile(args[0]);

                        if (xml != null)
                        {
                            if (_overwrite)
                            {
                                xml.Save(args[0]);
                            }
                            else
                            {
                                xml.Save(Path.ChangeExtension(args[0], "raw"));
                            }
                        }
                        else
                        {
                            Console.WriteLine("{0} already in XML format", args[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting {0}: {1}", args[0], ex.Message);
            }
        }
    }
}