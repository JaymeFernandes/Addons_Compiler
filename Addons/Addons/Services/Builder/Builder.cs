using Addons.Model;
using Addons.Texture;
using System.Reflection;

namespace Addons
{
    public partial class Addon
    {

        /// <summary>
        /// Builder class for constructing <see cref="Addon"/> instances.
        /// </summary>
        public partial class Builder : IAddonBuilder
        {
            private readonly Addon addon;
            private const int VersionMaxLength = 3;

            public Builder() => addon = new Addon();

            /// <summary>
            /// Builds and returns the constructed <see cref="Addon"/> instance.
            /// </summary>
            /// <returns>The constructed <see cref="Addon"/> instance.</returns>
            /// <exception cref="ArgumentException">Thrown when Behavior or Resource is null.</exception>
            public Addon Base()
            {
                AddBehavior();
                AddResource();

                if (addon.Behavior?.Manifest != null && addon.Resource?.Manifest != null)
                {
                    McAddonManager.SetName(addon.Name);

                    BehaviorPackManager.SerName(addon.Name);
                    BehaviorPackManager.Create(addon.Name, addon.Behavior.Manifest);

                    ResourcePackManager.SerName(addon.Name);
                    ResourcePackManager.Create(addon.Name, addon.Resource.Manifest);

                    addon.Resource.TextureCollection = ResourcePack.Textures.TextureLoader.Load(addon.Resource.TextureCollection);
                    addon.Resource.TextureCollection.CreateFiles();
                }
                else
                {
                    throw new ArgumentException("Behavior or Resource is null");
                }

                return addon;
            }


            /// <summary>
            /// Sets the name of the addon.
            /// </summary>
            /// <param name="name">The name to set.</param>
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the name is null or empty.</exception>
            public IAddonBuilder SetName(string name)
            {
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

                addon.Name = name;
                return this;
            }

            /// <summary>
            /// Sets the description of the addon.
            /// </summary>
            /// <param name="description">The description to set.</param>
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentNullException">Thrown when the description is null or empty.</exception>
            public IAddonBuilder SetDescription(string description)
            {
                if (String.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));

                addon.Description = description;
                return this;
            }

            /// <summary>
            /// Sets the version of the addon from a string.
            /// </summary>
            /// <param name="version">The version string to set.</param>
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
            public IAddonBuilder SetVersion(string version)
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
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the version list is invalid.</exception>
            public IAddonBuilder SetVersion(List<int> version)
            {
                ValidateVersion(version);
                addon.Version = version;
                return this;
            }

            /// <summary>
            /// Sets the minimum version of the addon from a string.
            /// </summary>
            /// <param name="version">The minimum version string to set.</param>
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the version string is invalid.</exception>
            public IAddonBuilder SetMinVersion(string version)
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
            public IAddonBuilder SetMinVersion(List<int> version)
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
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the behavior pack is already defined or when the addon name/description is null or empty.</exception>
            public IAddonBuilder AddBehavior()
            {
                if (addon.Behavior != null) throw new ArgumentException("Behavior has already been defined");

                if (String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifesB = new AddonManifest(addon.Name, addon.Description);
                manifesB.AddModules(new AddonModules(AddonType.Data, addon.Description));

                addon.Behavior = new BehaviorPackController(manifesB);
                return this;
            }

            /// <summary>
            /// Adds a resource pack to the addon.
            /// </summary>
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the resource pack is already defined or when the addon name/description is null or empty.</exception>
            public IAddonBuilder AddResource()
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
