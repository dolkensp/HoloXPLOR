using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HoloXPLOR.DataForge
{
    public class DataForgeRecord : DataForgeSerializable
    {
        public UInt32 NameOffset { get; set; }
        public String Name { get { return this.DocumentRoot.ValueMap[this.NameOffset]; } }

        [JsonProperty("StructIndex")]
        public String __structIndex { get { return String.Format("{0:X4}", this.StructIndex); } }
        [JsonIgnore]
        public UInt32 StructIndex { get; set; }

        public Guid? Hash { get; set; }

        [JsonProperty("VariantIndex")]
        public String __variantIndex { get { return String.Format("{0:X4}", this.VariantIndex); } }
        [JsonIgnore]
        public UInt16 VariantIndex { get; set; }

        [JsonProperty("Item1")]
        public String __item1 { get { return String.Format("{0:X4}", this.Item1); } }
        [JsonIgnore]
        public UInt16 Item1 { get; set; }

        public DataForgeRecord(DataForge documentRoot)
            : base(documentRoot)
        {
            this.NameOffset = this._br.ReadUInt32();
            this.StructIndex = this._br.ReadUInt32();
            this.Hash = this.ReadGuid(false);

            this.VariantIndex = this._br.ReadUInt16();
            this.Item1 = this._br.ReadUInt16();
        }

        public override String ToString()
        {
            return String.Format("<{0} {1:X4} />", this.Name, this.StructIndex);
        }
    }
}
