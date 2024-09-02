using Newtonsoft.Json;

namespace Addons.Model
{
    public class AddonManifest : BaseJson
    {

        public class AddonDependencies
        {
            [JsonProperty("uuid")]
            public string Uuid { get; set; } = "";

            [JsonProperty("version")]
            public List<int>? Versions { get; set; }
        }


        internal AddonManifest() => Header = new AddonHeader();

        public AddonManifest(string name, string description) : this()
            => Header.Property(x => {
                x.Name = name;
                x.Description = description;
            });

        public AddonManifest(string name, string description, List<int> version, List<int> minVersion) : this(name, description)
            => Header.Property(x => {
                x.Versions = version;
                x.MinVersion = minVersion;
            });

        public override string ToString()
        {
            if (this.Header == null) throw new ArgumentNullException(nameof(this.Header));
            if (this.Modules == null) throw new ArgumentNullException(nameof(this.Modules));

            data.Add("format_version", Format_Version);
            data.Add("header", Header);
            data.Add("modules", Modules);
            if (Dependencies.Count != 0) data.Add("dependencies", Dependencies);

            return base.ToString();
        }


        private const int Format_Version = 1;

        public AddonHeader Header { get; set; }

        public List<AddonModules> Modules { get; private set; } = new List<AddonModules>();

        public List<AddonDependencies> Dependencies { get; private set; } = new List<AddonDependencies>();
    }

    
}
