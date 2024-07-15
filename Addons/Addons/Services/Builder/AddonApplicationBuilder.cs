using Addons.Model.Manifest;
using Addons.Model.Manifest.Modules;

namespace Addons
{
    public partial class Addon
    {
        public partial class Builder
        {
            private const int VersionMaxLength = 3;

            /// <summary>
            /// Sets the name of the addon.
            /// </summary>
            /// <param name="name">The name to set.</param>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the name is null or empty.</exception>
            public Builder SetName(string name)
            {
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

                addon.Name = name;
                return this;
            }

            /// <summary>
            /// Sets the description of the addon.
            /// </summary>
            /// <param name="description">The description to set.</param>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the description is null or empty.</exception>
            public Builder SetDescription(string description)
            {
                if (String.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));

                addon.Description = description;
                return this;
            }

            /// <summary>
            /// Sets the version of the addon from a string.
            /// </summary>
            /// <param name="version">The version string to set.</param>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
            public Builder SetVersion(string version)
            {

                var versionAddon = ParseVersion(version);
                ValidateVersion(versionAddon);
                addon.Version = versionAddon;
                return this;
            }

            /// <summary>
            /// Sets the version of the addon from a list of integers.
            /// </summary>
            /// <param name="version">The version list to set.</param>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the version list is invalid.</exception>
            public Builder SetVersion(List<int> version)
            {
                ValidateVersion(version);
                addon.Version = version;
                return this;
            }

            /// <summary>
            /// Sets the minimum version of the addon from a string.
            /// </summary>
            /// <param name="version">The minimum version string to set.</param>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
            public Builder SetMinVersion(string version)
            {
                var versionAddon = ParseVersion(version);
                ValidateVersion(versionAddon);

                addon.Minversion = versionAddon;
                return this;
            }

            /// <summary>
            /// Parses a version string into a list of integers.
            /// </summary>
            /// <param name="version">The version string to parse.</param>
            /// <returns>A list of integers representing the version.</returns>
            /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
            public Builder SetMinVersion(List<int> version)
            {
                ValidateVersion(version);
                addon.Minversion = version;
                return this;
            }

            /// <summary>
            /// Parses a version string into a list of integers.
            /// </summary>
            /// <param name="version">The version string to parse.</param>
            /// <returns>A list of integers representing the version.</returns>
            /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
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

            /// <summary>
            /// Validates a version list.
            /// </summary>
            /// <param name="version">The version list to validate.</param>
            /// <exception cref="ArgumentException">Thrown when the version list is invalid.</exception>
            private void ValidateVersion(List<int> version)
            {
                if (version.Count > VersionMaxLength || version.Count == 0)
                    throw new ArgumentException($"Version invalid {string.Join('.', version)}");
            }

            /// <summary>
            /// Adds a behavior pack to the addon.
            /// </summary>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the behavior pack is already defined or when the addon name/description is null or empty.</exception>
            public Builder AddBehavior()
            {
                if (addon.Behavior != null) throw new ArgumentException("Behavior has already been defined");

                if(String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifesB = new AddonManifest(addon.Name, addon.Description);
                manifesB.AddModules(new AddonModules(AddonType.Data, addon.Description));

                addon.Behavior = new BehaviorPack(manifesB);
                return this;
            }

            /// <summary>
            /// Adds a resource pack to the addon.
            /// </summary>
            /// <returns>The current instance of the <see cref="Builder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the resource pack is already defined or when the addon name/description is null or empty.</exception>
            public Builder AddResource()
            {
                if (addon.Resource != null) throw new ArgumentException("Resource has already been defined");

                if (String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifesR = new AddonManifest(addon.Name, addon.Description);
                manifesR.AddModules(new AddonModules(AddonType.Resources, addon.Description));

                addon.Resource = new ResourcePack(manifesR);

                return this;
            }
        }
    }
}
