using System.Reflection;
namespace Addons
{
	public partial class Addon : IAddon
	{
		public void CreateMcAddonFile()
		{
			Resource.TextureCollection.CreateFiles();
			McAddonManager.SetName(Name);
			McAddonManager.CreateMcAddonFile();
			
			Console.Clear();
			ColorConsole.WriteLine("All addon files were created successfully:", ConsoleColor.Green);
			ColorConsole.WriteLine(Path.Combine(AppContext.BaseDirectory, $"com.mojang/{Name}.mcaddon"), ConsoleColor.Blue);

			ColorConsole.WriteLine("\n\nCustom Minecraft Bedrock Addon\n", ConsoleColor.Blue);
			Console.WriteLine("This addon was generated using the Custom Addon Compiler for Minecraft Bedrock Edition.\n");

			ColorConsole.WriteLine("About\n", ConsoleColor.Blue);
			Console.WriteLine("This addon includes custom items, blocks, and behaviors designed to enhance your Minecraft experience. It was automatically compiled from C# code using our Custom Addon Compiler.\n");

			ColorConsole.WriteLine("Repository\n", ConsoleColor.Blue);
			Console.WriteLine("For more information, updates, and to contribute, please visit the GitHub repository:\n");

			ColorConsole.WriteLine("[GitHub Repository]", ConsoleColor.Green);
			ColorConsole.WriteLine("(https://github.com/JaymeFernandes/Addons_Compiler)\n", ConsoleColor.Blue);
			ColorConsole.WriteLine("Happy crafting!\n\n", ConsoleColor.Yellow);
		}

		public void AddTexture(string imagePath, Texture.Texture texture) =>
			Resource.TextureCollection.AddTexture(texture.Name, imagePath, texture.Type);
			
		public void AddTexture(string imagePath, Texture.Texture texture, string FolderName) =>
			Resource.TextureCollection.AddTexture(texture.Name, imagePath, texture.Type, FolderName);

		public void MapTextures()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => !a.IsDynamic && a.GetName().Name != "Addons")
				.SelectMany(a => a.GetTypes())
				.Where(t => t.IsClass && !t.IsAbstract)
				.Where(t => t.GetProperties().Any(p => Attribute.IsDefined(p, typeof(Texture.TextureAttribute)))) // Filter out the specific assembly
				.ToArray();

			foreach (var type in assemblies)
			{
				var properties = type.GetProperties()
					.Where(prop => Attribute.IsDefined(prop, typeof(Texture.TextureAttribute)))
					.ToArray();

				int position = 0;
				

				foreach (var property in properties)
				{
					position++;
					if (property.PropertyType == typeof(Texture.Texture))
					{
						var attribute = property.GetCustomAttribute<Texture.TextureAttribute>();
						Logs.Log($"Processing property '{property.Name}' in '{type.Name}'.", Logs.Status.Complete, position, properties.Length + 1);
						
						var instance = Activator.CreateInstance(type);
						var value = property.GetValue(instance) as Texture.Texture;

						if (attribute == null)
						{
							Logs.Log($"Attribute not found for property '{property.Name}' in '{type.Name}'.", Logs.Status.Failed, position, properties.Length + 1);
							throw new ArgumentNullException(nameof(attribute));
						}
						
						if (value == null)
						{
							Logs.Log($"Value is null for property '{property.Name}' in '{type.Name}'.", Logs.Status.Failed, position, properties.Length + 1);
							throw new ArgumentNullException(nameof(value));
						}
						
						Resource.TextureCollection.AddTexture(value.Name, attribute.Image, value.Type, value.FolderName ?? "");
						
						Logs.Log($"Processed property '{property.Name}' in '{type.Name}'.", Logs.Status.Complete, position, properties.Length + 1);
					}
				}
			}
			
			Resource.TextureCollection.CreateFiles();
		}

		public IBehaviorPack Behavior { get; set; }
		public IResourcePack Resource { get; set; }
		public string Name { get; private set; } = "";
		public string Description { get; private set; } = "";
		public List<int> Version { get; private set; } = new List<int> { 3, 0, 0 };
		public List<int> MinVersion { get; private set; } = new List<int> { 1, 8, 0 };
	}
}

internal static class ColorConsole
{
	internal static void WriteLine(string message, ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.WriteLine(message);
		Console.ResetColor();
	}
}
