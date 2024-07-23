using Addons.Model.Manifest;
using Addons.Services.FileManager;
using Addons.Texture;
using Addons.View;
using System.Reflection;

namespace Addons
{
    public partial class Addon
    {
        /// <summary>
        /// Builder class for constructing <see cref="Addon"/> instances.
        /// </summary>
        public partial class Builder
        {
            private readonly Addon addon;

            public Builder() => addon = new Addon();


            /// <summary>
            /// Builds and returns the constructed <see cref="Addon"/> instance.
            /// </summary>
            /// <returns>The constructed <see cref="Addon"/> instance.</returns>
            /// <exception cref="ArgumentException">Thrown when Behavior or Resource is null.</exception>
            public Addon Build()
            {
                

                if (addon.Behavior?.Manifest != null && addon.Resource?.Manifest != null)
                {
                    BehaviorPackManager.SerName(addon.Name);
                    BehaviorPackManager.Create(addon.Name, addon.Behavior.Manifest);

                    ResourcePackManager.SerName(addon.Name);
                    ResourcePackManager.Create(addon.Name, addon.Resource.Manifest);

                    addon.Resource._Textures = ResourcePack.Textures.TextureLoader.Load(addon.Resource._Textures);
                    addon.Resource._Textures.CreateFiles();
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
                    Item = new TexturePack($"{name}_Item", TextureType.Items, "/textures/item_texture.json");
                    Terrain = new TexturePack($"{name}_Terrain", TextureType.Terrain, "/textures/terrain/terrain_textures.json");
                    Entity = new TexturePack($"{name}_Entity", TextureType.Entity, "/textures/entity/entity_textures.json");
                    Environment = new TexturePack($"{name}_Environment", TextureType.Environment, "/addons/environment/environment_config.json");
                    Gui = new TexturePack($"{name}_Gui", TextureType.Gui, "/addons/gui/gui_config.json");
                    Misc = new TexturePack($"{name}_Misc", TextureType.Misc, "/addons/misc/misc_config.json");
                    Particles = new TexturePack($"{name}_Particles", TextureType.Particles, "/addons/particles/particle_effects.json");
                }

                public void CreateFiles()
                {
                    Logs.Title("Create Jsons Textures");

                    ResourcePackManager.CreateJson(Item);
                    ResourcePackManager.CreateJson(Terrain);
                    ResourcePackManager.CreateJson(Entity);
                    ResourcePackManager.CreateJson(Environment);
                    ResourcePackManager.CreateJson(Gui);
                    ResourcePackManager.CreateJson(Misc);
                    ResourcePackManager.CreateJson(Particles);
                }

                internal void AddTexture(string name, string path, TextureType type, string folder = "")
                {
                    Logs.Process($"Add Texture: {name}", Logs.Status.running);
                    switch (type)
                    {
                        case TextureType.Items:
                            Item.AddTexture(name, path, $"/items/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                        case TextureType.Terrain:
                            Terrain.AddTexture(name, path, $"/terrain/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                        case TextureType.Entity:
                            Entity.AddTexture(name, path, $"/entity/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                        case TextureType.Environment:
                            Environment.AddTexture(name, path, $"/environment/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                        case TextureType.Gui:
                            Gui.AddTexture(name, path, $"/gui/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                        case TextureType.Misc:
                            Misc.AddTexture(name, path, $"/misc/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                        case TextureType.Particles:
                            Particles.AddTexture(name, path, $"/particles/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.complete);
                            break;
                    }
                }

                internal static class TextureLoader
                {
                    public static Textures Load(Textures texture)
                    {
                        Logs.Title("Loading Textures...");

                        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                            .Where(a => !a.IsDynamic && a.GetName().Name != "Addons") // Filtra o assembly específico
                            .ToArray();

                        var types = assemblies.SelectMany(a => a.GetTypes())
                            .Where(t => t.IsClass && !t.IsAbstract)
                            .Where(t => t.GetProperties().Any(p => Attribute.IsDefined(p, typeof(TextureAttribute))))
                            .ToArray();

                        foreach (var type in types)
                        {
                            var properties = type.GetProperties()
                                .Where(prop => Attribute.IsDefined(prop, typeof(TextureAttribute)))
                                .ToArray();

                            foreach (var property in properties)
                            {
                                if (property.PropertyType == typeof(Texture.Texture))
                                {
                                    var attribute = property.GetCustomAttribute<TextureAttribute>();

                                    Logs.Process($"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.running);

                                    var instance = Activator.CreateInstance(type);
                                    var value = property.GetValue(instance) as Texture.Texture;

                                    if (attribute is null)
                                    {
                                        Logs.Process($"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.failed);
                                        throw new ArgumentNullException(nameof(attribute));
                                    }
                                    if (value is null)
                                    {
                                        Logs.Process($"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.failed);
                                        throw new ArgumentNullException(nameof(value));
                                    }


                                    Logs.Process($"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.complete);
                                    texture.AddTexture(value.Name, attribute.Path, attribute.Type, value.Folder ?? "");
                                }
                            }
                        }

                        return texture;
                    }
                }
            }
        }
    }
}
