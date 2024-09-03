namespace Addons.Texture
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class TextureAttribute : Attribute
	{
		public string Image {get; set;} = string.Empty;
		
		public TextureAttribute(string image) => Image = image;
	}

	public class Texture
	{
		public string Name { get; set; } = string.Empty;
		public string FolderName { get; set; } = string.Empty;
		public TextureType Type { get; set; } = TextureType.Items;

		public Texture(string name, TextureType type)
		{
			Name = name;
			Type = type;
		}
		
		public Texture(string name, TextureType type, string folderName) : this(name, type) => this.FolderName = folderName;
	}


	
}
