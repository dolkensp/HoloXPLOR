using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeGuid : _DataForgeSerializable
    {
        public Guid Value { get; set; }

        public DataForgeGuid(DataForge documentRoot)
            : base(documentRoot)
        {
            this.Value = this.ReadGuid(false).Value;
        }

        public override String ToString()
        {
            return this.Value.ToString();
        }

        public XmlElement Read()
        {
            var element = this.DocumentRoot.CreateElement("Guid");
            var attribute = this.DocumentRoot.CreateAttribute("value");
            attribute.Value = this.Value.ToString();
            element.Attributes.Append(attribute);
            return element;
        }
    }
}
