using Addons.Model;
namespace Addons
{
    public partial class Addon
    {
        internal Addon() { }

        public static IAddonBuilder CreateBuilder() => new Builder();
        public static IAddonBuilder CreateBuilder(string name) => new Builder(name);
        public static IAddonBuilder CreateBuilder(string name, string description) => new Builder(name, description);


        /// <summary>
        /// Builder class for constructing <see cref="Addon"/> instances.
        /// </summary>
        private partial class Builder : IAddonBuilder
        {
            internal Builder() => addon = new Addon();
            internal Builder(string name) : this() => addon.Name = name;
            internal Builder(string name, string description) : this(name) => addon.Description = description;


            /// <summary>
            /// Builds and returns the constructed <see cref="Addon"/> instance.
            /// </summary>
            /// <returns>The constructed <see cref="Addon"/> instance.</returns>
            /// <exception cref="ArgumentException">Thrown when Behavior or Resource is null.</exception>
            public Addon Build()
            {
                AddBehavior();
                AddResource();

                if(addon.Behavior is null || addon.Resource is null) throw new ArgumentNullException($"{nameof(addon.Behavior)}/{nameof(addon.Resource)}");

                McAddonManager.SetName(addon.Name);
                BehaviorPackManager.SerName(addon.Name);
                ResourcePackManager.SerName(addon.Name);

                BehaviorPackManager.Create(addon.Name, addon.Behavior.Manifest);
                ResourcePackManager.Create(addon.Name, addon.Resource.Manifest);

                addon.Resource.TextureCollection = ResourcePack.Textures.TextureLoader.Load(addon.Resource.TextureCollection);
                addon.Resource.TextureCollection.CreateFiles();

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

                addon.MinVersion = versionAddon;
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
                addon.MinVersion = version;
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
            private IAddonBuilder AddBehavior()
            {
                if (addon.Behavior != null) throw new ArgumentException("Behavior has already been defined");

                if (String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifestB = new AddonManifest(addon.Name, addon.Description);
                manifestB.Modules.Add(new AddonModules(AddonType.Data, addon.Description));

                addon.Behavior = new BehaviorPackController(manifestB);
                return this;
            }

            /// <summary>
            /// Adds a resource pack to the addon.
            /// </summary>
            /// <returns>The current instance of the <see cref="CreateBuilder"/>.</returns>
            /// <exception cref="ArgumentException">Thrown when the resource pack is already defined or when the addon name/description is null or empty.</exception>
            private IAddonBuilder AddResource()
            {
                if (addon.Resource != null) throw new ArgumentException("Resource has already been defined");

                if (String.IsNullOrEmpty(addon.Description)) throw new ArgumentNullException(nameof(addon.Description));
                if (String.IsNullOrEmpty(addon.Name)) throw new ArgumentNullException(nameof(addon.Name));

                var manifestR = new AddonManifest(addon.Name, addon.Description);
                manifestR.Modules.Add(new AddonModules(AddonType.Resources, addon.Description));

                addon.Resource = new ResourcePack(manifestR);

                return this;
            }

            
            private readonly Addon addon;
            private const int VersionMaxLength = 3;
        }
    }
}
