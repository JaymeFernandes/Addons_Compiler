using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Addons.Model.Manifest
{
    public class AddonManifest
    {
        [JsonProperty("format_version")]
        private int Formet_Version = 1;

        [JsonProperty("header")]
        public AddonHeader Header { get; set; }

        [JsonProperty("modules")]
        public List<AddonModules> Modules { get; private set; } = new List<AddonModules>();


        public AddonManifest(string name, string description)
        {
            Header = new AddonHeader()
            {
                Name = name,
                Description = description,
            };
        }

        public AddonManifest(string name, string description, List<int> version, List<int> minVersion)
        {
            Header = new AddonHeader()
            {
                Name = name,
                Description = description,
                Versions = version,
                MinVersion = minVersion
            };
        }

        public void AddModules(AddonModules modules)
        {
            Modules.Add(modules);
        }
    }
}
