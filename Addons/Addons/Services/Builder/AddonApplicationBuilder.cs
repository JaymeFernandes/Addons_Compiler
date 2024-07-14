using Addons.Model.Manifest;
using Addons.Model.Manifest.Modules;

namespace Addons
{
    public partial class Addon
    {
        public partial class Builder
        {
            private const int VersionMaxLength = 3;

            public Builder SetName(string name)
            {
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

                addon.Name = name;

                return this;
            }


            public Builder SetDescription(string description)
            {
                if (String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));

                addon.Description = description;

                return this;
            }


            public Builder SetVersion(string version)
            {

                List<int> versionAddon = ParseVersion(version);

                ValidateVersion(versionAddon);

                addon.Version = versionAddon;

                return this;
            }


            public Builder SetVersion(List<int> version)
            {
                ValidateVersion(version);

                addon.Version = version;
                return this;
            }

            public Builder SetMinVersion(string version)
            {
                List<int> versionAddon = ParseVersion(version);

                ValidateVersion(versionAddon);

                addon.Minversion = versionAddon;
                return this;
            }

            public Builder SetMinVersion(List<int> version)
            {
                ValidateVersion(version);

                addon.Minversion = version;
                return this;
            }


            private List<int> ParseVersion(string version)
            {
                var values = version.Split('.');

                if (values.Length > VersionMaxLength)
                    throw new ArgumentException($"Version invalide {version}");

                var versionAddon = new List<int>();
                foreach (var value in values)
                {
                    if (!int.TryParse(value, out var intValue))
                        throw new ArgumentException($"Version invalid {version}");

                    versionAddon.Add(intValue);
                }

                return versionAddon;
            }

            private void ValidateVersion(List<int> version)
            {
                if (version.Count > VersionMaxLength || version.Count == 0)
                    throw new ArgumentException($"Version invalid {string.Join('.', version)}");
            }


            public Builder AddBehavior()
            {
                if (addon.ManifestBehavior != null) throw new ArgumentException("Behavior has already been defined");

                if(String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifesB = new AddonManifest(addon.Name, addon.Description);
                manifesB.AddModules(new AddonModules(AddonType.Data, addon.Description));

                addon.ManifestBehavior = manifesB;
                return this;
            }

            public Builder AddResource()
            {
                if (addon.ManifestResource != null) throw new ArgumentException("Resource has already been defined");

                if (String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifesR = new AddonManifest(addon.Name, addon.Description);
                manifesR.AddModules(new AddonModules(AddonType.Resources, addon.Description));

                addon.ManifestResource = manifesR;
                return this;
            }
        }
    }
}
