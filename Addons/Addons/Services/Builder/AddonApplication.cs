using Addons.Model.Manifest;
using Addons.Model.PathModel;
using Addons.Model.Texture;
using System.Reflection;

namespace Addons
{
    public partial class Addon
    {
        public BehaviorPack? Behavior { get; set; }
        public ResourcePack? Resource { get; set; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public List<int> Version { get; private set; } = new List<int> { 3, 0, 0 };
        public List<int> Minversion { get; private set; } = new List<int> { 1, 8, 0 };

        /// <summary>
        /// Builder class for constructing <see cref="Addon"/> instances.
        /// </summary>
        public partial class Builder
        {
            private readonly Addon addon;

            public Builder()
            {
                addon = new Addon();
            }


            /// <summary>
            /// Builds and returns the constructed <see cref="Addon"/> instance.
            /// </summary>
            /// <returns>The constructed <see cref="Addon"/> instance.</returns>
            /// <exception cref="ArgumentException">Thrown when Behavior or Resource is null.</exception>
            public Addon Build()
            {
                if (addon.Behavior?.Manifest != null && addon.Resource?.Manifest != null)
                {
                    InitialModel.CreateBehaviorPack(addon.Name, addon.Behavior.Manifest);
                    InitialModel.CreateResourcePack(addon.Name, addon.Resource.Manifest);
                    addon.Resource._Textures = ResourcePack.Textures.TextureLoader.Load(addon.Resource._Textures);
                }
                else
                {
                    throw new ArgumentException("Behavior or Resource is null");
                }

                return addon;
            }
        }

        public class BehaviorPack
        {
            public AddonManifest Manifest { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="BehaviorPack"/> class.
            /// </summary>
            public BehaviorPack(AddonManifest manifest)
            {
                Manifest = manifest;
            }
        }

        public class ResourcePack
        {
            public AddonManifest Manifest { get; set; }
            public Textures _Textures { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ResourcePack"/> class.
            /// </summary>
            public ResourcePack(AddonManifest manifest)
            {
                Manifest = manifest;
                _Textures = new Textures(manifest.Header.Name);
            }

            /// <summary>
            /// Represents the textures in the resource pack.
            /// </summary>
            public class Textures
            {
                private TexturePack Item { get; set; } 
                private TexturePack Terrain { get; set; }
                private TexturePack Entity { get; set; }
                private TexturePack Environment { get; set; }
                private TexturePack Gui { get; set; }
                private TexturePack Misc { get; set; }
                private TexturePack Particles { get; set; }

                /// <summary>
                /// Initializes a new instance of the <see cref="Texture"/> class.
                /// </summary>
                /// <param name="name">The name of the texture.</param>
                public Textures(string name)
                {
                    Item = new TexturePack($"{name}_Item", TextureType.Items);
                    Terrain = new TexturePack($"{name}_Terrain", TextureType.Terrain);
                    Entity = new TexturePack($"{name}_Entity", TextureType.Entity);
                    Environment = new TexturePack($"{name}_Environment", TextureType.Environment);
                    Gui = new TexturePack($"{name}_Gui", TextureType.gui);
                    Misc = new TexturePack($"{name}_Misc", TextureType.misc);
                    Particles = new TexturePack($"{name}_Particles", TextureType.particles);
                }

                public void AddTexture(string name, string path, TextureType type)
                {
                    switch (type)
                    {
                        case TextureType.Items:
                            Item.AddTexture(name, path);
                            break;
                        case TextureType.Terrain:
                            Terrain.AddTexture(name, path);
                            break;
                        case TextureType.Entity: 
                            Entity.AddTexture(name, path); 
                            break;
                        case TextureType.Environment: 
                            Environment.AddTexture(name, path); 
                            break;
                        case TextureType.gui:
                            Gui.AddTexture(name, path);
                            break;
                        case TextureType.misc:
                            Misc.AddTexture(name, path);
                            break;
                        case TextureType.particles:
                            Particles.AddTexture(name, path);
                            break;
                    }
                }

                internal static class TextureLoader
                {
                    public static Textures Load(Textures texture)
                    {
                        var types = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(type => type.IsClass && !type.IsAbstract);

                        foreach (var type in types)
                        {
                            var properties = type.GetProperties()
                                .Where(prop => Attribute.IsDefined(prop, typeof(TextureAttribute)));

                            foreach (var property in properties)
                            {
                                var attribute = property.GetCustomAttribute<TextureAttribute>();
                            }
                        }

                        return texture;
                    }
                }
            }
        }
    }
}
