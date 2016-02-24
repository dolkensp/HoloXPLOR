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
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: HoloXPLOR.DataForge.exe [infile]");
                Console.WriteLine();
                Console.WriteLine("Converts an SC binary `xml` file into an actual XML file, and saves it as a .raw file in the original location");
                return;
            }

            var xml = DataForgeSerializer.ReadFile(args[0]);
            xml.Save(Path.ChangeExtension(args[0], "raw"));
        }
    }
}
