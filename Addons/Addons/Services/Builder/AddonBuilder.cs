using Addons.Model.Manifest;
using Addons.Services.FileManager;
using Addons.Texture;
using Addons.View;
using System.IO;
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
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./item_texture.json\" )", Logs.Status.Running, 1, 1);
                    ResourcePackManager.CreateJson(Item);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./item_texture.json\" )", Logs.Status.Complete, 1, 7);

                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./terrain_textures.json\" )", Logs.Status.Running, 2, 7);
                    ResourcePackManager.CreateJson(Terrain);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./terrain_textures.json\" )", Logs.Status.Complete, 2, 7);

                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./entity_textures.json\" )", Logs.Status.Running, 3, 7);
                    ResourcePackManager.CreateJson(Entity);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./entity_textures.json\" )", Logs.Status.Complete, 3, 7);

                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./environment_config.json\" )", Logs.Status.Running, 4, 7);
                    ResourcePackManager.CreateJson(Environment);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./environment_config.json\" )", Logs.Status.Complete, 4, 7);

                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./gui_config.json\" )", Logs.Status.Running, 5, 7);
                    ResourcePackManager.CreateJson(Gui);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./gui_config.json\" )", Logs.Status.Complete, 5, 7);

                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./misc_config.json\" )", Logs.Status.Running, 6, 7);
                    ResourcePackManager.CreateJson(Misc);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./misc_config.json\" )", Logs.Status.Complete, 6, 7);

                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./misc_config.json\" )", Logs.Status.Running, 7, 7);
                    ResourcePackManager.CreateJson(Particles);
                    Logs.Loading("Create Jsons Textures", $"Create Manifest: ( \"./particle_effects.json\" )", Logs.Status.Complete, 7, 7);
                }

                internal void AddTexture(string name, string path, TextureType type, string folder = "")
                {
                    Logs.Process($"Add Texture: {name}", Logs.Status.Running);
                    switch (type)
                    {
                        case TextureType.Items:
                            Item.AddTexture(name, path, $"/items/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                        case TextureType.Terrain:
                            Terrain.AddTexture(name, path, $"/terrain/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                        case TextureType.Entity:
                            Entity.AddTexture(name, path, $"/entity/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                        case TextureType.Environment:
                            Environment.AddTexture(name, path, $"/environment/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                        case TextureType.Gui:
                            Gui.AddTexture(name, path, $"/gui/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                        case TextureType.Misc:
                            Misc.AddTexture(name, path, $"/misc/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                        case TextureType.Particles:
                            Particles.AddTexture(name, path, $"/particles/{folder}");
                            Logs.Process($"Add Texture: {name}", Logs.Status.Complete);
                            break;
                    }
                }

                internal static class TextureLoader
                {
                    public static Textures Load(Textures texture)
                    {

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

                            int postition = 0;

                            foreach (var property in properties)
                            {
                                postition++;
                                if (property.PropertyType == typeof(Texture.Texture))
                                {
                                    var attribute = property.GetCustomAttribute<TextureAttribute>();

                                    

                                    Logs.Loading("Loading Textures...", $"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.Running, postition, properties.Length + 1);

                                    var instance = Activator.CreateInstance(type);
                                    var value = property.GetValue(instance) as Texture.Texture;

                                    if (attribute is null)
                                    {
                                        Logs.Loading("Loading Textures...", $"Processing property '{property.Name}' in '{type.Name}'.",             Logs.Status.Failed, postition, properties.Length + 1);
                                        throw new ArgumentNullException(nameof(attribute));
                                    }
                                    if (value is null)
                                    {
                                        Logs.Loading("Loading Textures...", $"Processing property '{property.Name}' in '{type.Name}'.",             Logs.Status.Failed, postition, properties.Length + 1);
                                        throw new ArgumentNullException(nameof(value));
                                    }

                                    Logs.Loading("Loading Textures...", $"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.Complete, postition, properties.Length + 1);

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
