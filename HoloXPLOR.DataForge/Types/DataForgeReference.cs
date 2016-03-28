using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeReference : _DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public Guid Value { get; set; }

        public DataForgeReference(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Item1 = this._br.ReadUInt32();
            this.Value = this.ReadGuid(false).Value;
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1}", this.Item1, this.Value);
        }

        public XmlElement Read()
        {
            var element = this.DocumentRoot.CreateElement("Reference");
            var attribute = this.DocumentRoot.CreateAttribute("value");
            attribute.Value = this.Value.ToString();
            element.Attributes.Append(attribute);
            return element;
        }
    }
}
