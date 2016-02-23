using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class BinaryNode
    {
        public Int32 NodeID { get; set; }
        public Int32 NodeNameOffset { get; set; }
        public Int32 Item2 { get; set; }
        public Int16 AttributeCount { get; set; }
        public Int16 ChildCount { get; set; }
        public Int32 ParentNodeID { get; set; }
        public Int32 Item6 { get; set; }
        public Int32 Item7 { get; set; }
        public Int32 Item8 { get; set; }
    }
}
