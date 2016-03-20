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
        public static void Main(params String[] args)
        {
            // args = new String[] { "game.dcb" };

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
                            var df = new DataForge(br);

                            df.Save(Path.ChangeExtension(args[0], "xml"));
                        }
                    } else {
                        var xml = CryXmlSerializer.ReadFile(args[0], args.Length == 2);
                        xml.Save(Path.ChangeExtension(args[0], "raw"));
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