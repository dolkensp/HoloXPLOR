using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeArrayLocale : DataForgeSerializable
    {
        private UInt32 _value;
        public String Value { get { return this.DocumentRoot.ValueMap[this._value]; } }

        public DataForgeArrayLocale(DataForge documentRoot)
            : base(documentRoot)
        {
            this._value = this._br.ReadUInt32();
        }

        public override String ToString()
        {
            return this.Value;
        }

        public XmlElement Read()
        {
            var element = this.DocumentRoot.CreateElement("LocID");
            var attribute = this.DocumentRoot.CreateAttribute("value");
            attribute.Value = this.Value.ToString();
            element.Attributes.Append(attribute);
            return element;
        }
    }
}
