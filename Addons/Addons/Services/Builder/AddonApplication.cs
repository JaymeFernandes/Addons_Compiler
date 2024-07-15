using Addons.Model.Manifest;
using Addons.Model.PathModel;
using Addons.Model.Texture;

namespace Addons
{
    public partial class Addon
    {
        public BehaviorPack Behavior { get; set; }
        public ResourcePack Resource { get; set; }
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
            public Texture Textures { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ResourcePack"/> class.
            /// </summary>
            public ResourcePack(AddonManifest manifest)
            {
                Manifest = manifest;
                Textures = new Texture(manifest.Header.Name);
            }

            /// <summary>
            /// Represents the textures in the resource pack.
            /// </summary>
            public class Texture
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
                public Texture(string name)
                {
                    Item = new TexturePack($"{name}_Item", TextureType.Items);
                    Terrain = new TexturePack($"{name}_Terrain", TextureType.Terrain);
                    Entity = new TexturePack($"{name}_Entity", TextureType.Entity);
                    Environment = new TexturePack($"{name}_Environment", TextureType.Environment);
                    Gui = new TexturePack($"{name}_Gui", TextureType.gui);
                    Misc = new TexturePack($"{name}_Misc", TextureType.misc);
                    Particles = new TexturePack($"{name}_Particles", TextureType.particles);
                }
            }
        }
    }
}
