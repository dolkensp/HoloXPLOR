using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeArrayUInt32 : DataForgeSerializable
    {
        public UInt32 Value { get; set; }

        public DataForgeArrayUInt32(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this._br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("{0}", this.Value);
        }

        public XmlElement Read()
        {
            var element = this.DocumentRoot.CreateElement("UInt32");
            var attribute = this.DocumentRoot.CreateAttribute("value");
            attribute.Value = this.Value.ToString();
            element.Attributes.Append(attribute);
            return element;
        }
    }
}
