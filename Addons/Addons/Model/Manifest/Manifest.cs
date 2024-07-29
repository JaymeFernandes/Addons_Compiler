using Newtonsoft.Json;

namespace Addons.Model
{
    public class AddonManifest
    {
        BaseJson _json = new BaseJson();

        private const int Formet_Version = 1;

        public AddonHeader Header { get; set; }

        public List<AddonModules> Modules { get; private set; } = new List<AddonModules>();

        public List<AddonDependencies> Dependencies { get; private set; } = new List<AddonDependencies>();

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

        public override string ToString()
        {
            if (this.Header == null) throw new ArgumentNullException("header is null");
            if (this.Modules == null) throw new ArgumentNullException("modeles is null");

            _json.Propety(x =>
            {
                x.data.Add("format_version", Formet_Version);
                x.data.Add("header", Header);
                x.data.Add("modules", Modules);
                if (Dependencies.Count != 0) x.data.Add("dependencies", Dependencies);
            });
            return _json.ToString();
        }
    }

    public class AddonDependencies
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; } = "";

        [JsonProperty("version")]
        public List<int>? Versions { get; set; }
    }
}
