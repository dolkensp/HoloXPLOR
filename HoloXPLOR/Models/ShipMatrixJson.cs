using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoloXPLOR.Models
{
    public class ShipMatrixJson
    {
        public Int32 ID { get; set; }
        public Int32? CargoCapacity { get; set; }
        public String Classification { get; set; }
        public String Name { get; set; }
        public String Focus { get; set; }
        public String Tagline { get; set; }
        public String Description { get; set; }
        public String PledgeURL { get; set; }
        public ShipMatrixManufacturerJson Manufacturer { get; set; }
        public ShipMatrixMediaJson[] Media { get; set; }
    }

    public class ShipMatrixManufacturerJson
    {
        public String Name { get; set; }
        [JsonProperty("known_for")]
        public String KnownFor { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public ShipMatrixMediaJson[] Media { get; set; }
    }

    public class ShipMatrixMediaJson
    {
        [JsonProperty("source_url")]
        public String SourceURL { get; set; }
    }
}