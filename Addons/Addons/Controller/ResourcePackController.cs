﻿using Addons.Model;
using Addons.Texture;
using System.Reflection;

namespace Addons
{
	/// <summary>
	/// Represents a resource pack containing textures and manifest information.
	/// </summary>
	internal class ResourcePack : IResourcePack
	{
		/// <summary>
		/// Gets or sets the manifest information of the resource pack.
		/// </summary>
		public AddonManifest Manifest { get; set; } = new AddonManifest();

		/// <summary>
		/// Gets or sets the textures contained in the resource pack.
		/// </summary>
		public Textures TextureCollection { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ResourcePack"/> class with the specified manifest.
		/// </summary>
		/// <param name="manifest">The manifest information of the resource pack.</param>
		public ResourcePack(string name, string description)
		{
			ResourcePackManager.SerName(name);
			
			Manifest = new AddonManifest(name, description);
			Manifest.Modules.Add(new AddonModules(AddonType.Resources, description));
			TextureCollection = new Textures(name);
		}

		/// <summary>
		/// Represents a collection of textures categorized by type.
		/// </summary>
		public class Textures
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="Textures"/> class.
			/// </summary>
			/// <param name="name">The base name for the textures.</param>
			public Textures(string name)
			{
				if (string.IsNullOrEmpty(name))
					throw new ArgumentException("Name cannot be null or empty.", nameof(name));

				Item = new TexturePack($"{name}_Item", TextureType.Items, "/textures/item_texture.json");
				Terrain = new TexturePack($"{name}_Terrain", TextureType.Terrain, "/textures/terrain/terrain_textures.json");
				Entity = new TexturePack($"{name}_Entity", TextureType.Entity, "/textures/entity/entity_textures.json");
				Environment = new TexturePack($"{name}_Environment", TextureType.Environment, "/addons/environment/environment_config.json");
				Gui = new TexturePack($"{name}_Gui", TextureType.Gui, "/addons/gui/gui_config.json");
				Misc = new TexturePack($"{name}_Misc", TextureType.Misc, "/addons/misc/misc_config.json");
				Particles = new TexturePack($"{name}_Particles", TextureType.Particles, "/addons/particles/particle_effects.json");
			}

			/// <summary>
			/// Creates the necessary JSON files for each texture pack.
			/// </summary>
			internal void CreateFiles()
			{
				CreateFile(Item, "item_texture.json", 1);
				CreateFile(Terrain, "terrain_textures.json", 2);
				CreateFile(Entity, "entity_textures.json", 3);
				CreateFile(Environment, "environment_config.json", 4);
				CreateFile(Gui, "gui_config.json", 5);
				CreateFile(Misc, "misc_config.json", 6);
				CreateFile(Particles, "particle_effects.json", 7);
			}

			private void CreateFile(TexturePack texturePack, string fileName, int index)
			{
				ResourcePackManager.CreateJson(texturePack);
				Logs.Log($"Created Manifest: ( \"./{fileName}\" )", Logs.Status.Complete, index, 7);
			}

			/// <summary>
			/// Adds a texture to the appropriate texture pack based on the texture type.
			/// </summary>
			/// <param name="name">The name of the texture.</param>
			/// <param name="path">The path to the texture file.</param>
			/// <param name="type">The type of the texture.</param>
			/// <param name="folder">The folder where the texture is located (optional).</param>
			internal void AddTexture(string name, string path, TextureType type, string folder = "")
			{
				if (string.IsNullOrEmpty(name))
					throw new ArgumentException("Texture name cannot be null or empty.", nameof(name));

				if (string.IsNullOrEmpty(path))
					throw new ArgumentException("Texture path cannot be null or empty.", nameof(path));

				switch (type)
				{
					case TextureType.Items:
						Item.AddTexture(name, path, $"/items/{folder}");
						break;
					case TextureType.Terrain:
						Terrain.AddTexture(name, path, $"/terrain/{folder}");
						break;
					case TextureType.Entity:
						Entity.AddTexture(name, path, $"/entity/{folder}");
						break;
					case TextureType.Environment:
						Environment.AddTexture(name, path, $"/environment/{folder}");
						break;
					case TextureType.Gui:
						Gui.AddTexture(name, path, $"/gui/{folder}");
						break;
					case TextureType.Misc:
						Misc.AddTexture(name, path, $"/misc/{folder}");
						break;
					case TextureType.Particles:
						Particles.AddTexture(name, path, $"/particles/{folder}");
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(type), "Unknown texture type.");
				}
			}

			private TexturePack Item { get; set; }
			private TexturePack Terrain { get; set; }
			private TexturePack Entity { get; set; }
			private TexturePack Environment { get; set; }
			private TexturePack Gui { get; set; }
			private TexturePack Misc { get; set; }
			private TexturePack Particles { get; set; }
		}     
	}
}
