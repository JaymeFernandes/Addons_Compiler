using Addons;
using Addons.Texture;

namespace Addons
{
	public interface IAddon
	{
		public void CreateMcAddonFile();
		
		public void AddTexture(string imagePath, Texture.Texture texture);
		
		public void AddTexture(string imagePath, Texture.Texture texture, string FolderName);
		
		public void MapTextures();
	}
}
