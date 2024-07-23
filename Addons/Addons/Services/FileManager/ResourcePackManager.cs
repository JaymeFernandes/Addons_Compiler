using Addons.Model.Manifest;
using Addons.Texture;
using Addons.View;
using Newtonsoft.Json;

namespace Addons.Services.FileManager
{
    public static class ResourcePackManager
    {
        private static string _Folder = "";

        public static void SerName(string name)
        {
            _Folder = $"./bin/{name}_Resource/";
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
            Logs.Title("Generating ResourcePack");

            foreach (var path in Base)
            {
                Logs.Process($"Create Folder ( \"{path}\" )", Logs.Status.running);
                Directory.CreateDirectory($"./bin/{name}_Resource/{path}");
                Logs.Process($"Create Folder ( \"{path}\" )", Logs.Status.complete);
            }


            Logs.Process($"Create File ( \"{_Folder}/manifest.json\" )", Logs.Status.running);
            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented);

            File.WriteAllText($"{_Folder}/manifest.json", json);
            Logs.Process($"Create File ( \"{_Folder}/manifest.json\" )", Logs.Status.complete);
        }

        public static void CreateJson(TexturePack texturePack)
        {
            Logs.Process($"Create {_Folder}{texturePack.PathFile}".Replace("//", "/"), Logs.Status.running);

            foreach(var path in texturePack.TextureData)
            {
                string folder = $"{_Folder}";
                if (!String.IsNullOrEmpty(path.Value.Folder))
                {
                    folder = $"{folder}/{path.Value.Folder.Replace($"{path.Key}.png", "")}";
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
                    Console.WriteLine("Foi Criado a textura");
                    Console.ReadLine();
                }
            }

            string json = JsonConvert.SerializeObject(texturePack, Formatting.Indented);

            File.WriteAllText($"{_Folder}{texturePack.PathFile}", json);

            Logs.Process($"Create {_Folder}{texturePack.PathFile}", Logs.Status.complete);
        }
    }
}
