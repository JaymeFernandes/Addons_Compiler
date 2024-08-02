using Addons.Model;
using Addons.Texture;
using Addons;
using Newtonsoft.Json;

namespace Addons
{
    internal static class ResourcePackManager
    {
        private static string _Folder = "";

        public static void SerName(string name)
        {
            _Folder = $"./com.mojang/development_resource_packs/{name}_Resource/";
        }


        public static List<string> Base = new List<string>()
        {
            "/addons/environment",
            "/addons/gui",
            "/addons/misc",
            "/addons/particles",
            "/animation_controllers",
            "/animations",
            "/attachables",
            "/entity",
            "/items",
            "/materials",
            "/models/entity",
            "/render_controllers/effects",
            "/texts",
            "/textures/entity",
            "/textures/items",
            "/textures/terrain"
        };

        public static void Create(string name, AddonManifest manifest)
        {
            foreach (var path in Base)
            {
                Logs.Loading("Generating ResourcePack", $"Create Folder ( \"{path}\" )", Logs.Status.Running, Base.IndexOf(path), Base.Count + 1);
                Directory.CreateDirectory($"{_Folder}/{path}");
                Logs.Loading("Generating ResourcePack", $"Create Folder ( \"{path}\" )", Logs.Status.Complete, Base.IndexOf(path), Base.Count + 1);
            }

            string json = manifest.ToString();

            File.WriteAllText($"{_Folder}README.md", ReadMe.Read);

            if (!File.Exists($"{_Folder}manifest.json")) File.WriteAllText($"{_Folder}/manifest.json", json);

            Logs.Loading("Generating ResourcePack", $"Create manifest ( \"./manifest.json\" )", Logs.Status.Complete, Base.Count + 1, Base.Count + 1);
        }

        public static void CreateJson(TexturePack texturePack)
        {
            foreach(var path in texturePack.TextureData)
            {
                string folder = $"{_Folder}";

                if (!String.IsNullOrEmpty(path.Value.Folder))
                {
                    folder = $"{folder}/{path.Value.Folder.Replace($"{path.Key}", "")}";
                }
                else
                {
                    folder = $"{folder}/textures";
                }

                if (!File.Exists(path.Value.PathTexture)) throw new ArgumentException($"Path file invalidated : {path.Value.PathTexture}");
                
                if (!Path.GetExtension(path.Value.PathTexture).Equals(".png", StringComparison.OrdinalIgnoreCase)) throw new ArgumentException($"File type is invalidated: {path.Value.PathTexture}");

                folder = folder.Replace("//", "/");

                Directory.CreateDirectory(folder);
                

                if (!File.Exists($"{folder}/{path.Key}.png"))
                {
                    File.Copy(path.Value.PathTexture, $"{folder}/{path.Key}.png".Replace("//", "/"));
                }
            }

            string json = JsonConvert.SerializeObject(texturePack, Formatting.Indented);

            File.WriteAllText($"{_Folder}{texturePack.PathFile}", json);
        }
    }
}
