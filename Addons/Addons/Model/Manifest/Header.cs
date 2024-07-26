using Addons.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Model.Manifest
{
    public class AddonHeader
    {
        [JsonProperty("description")]
        public string Description { get; set; } = "Undefined";

        [JsonProperty("name")]
        public string Name { get; set; } = "Undefined";

        [JsonProperty("uuid")]
        public string _UUID { get; set; } = UUID.Generate();

        [JsonProperty("version")]
        public List<int> Versions { get; set; } = new List<int>() { 3, 0, 0 };

        [JsonProperty("min_engine_version")]
        public List<int> MinVersion { get; set; } = new List<int> { 1, 8, 0 };

    }
}
