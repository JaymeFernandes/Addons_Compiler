using Addons.Model.Manifest;
using Addons.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Services.FileManager
{
    public static class BehaviorPackManager
    {
        private static string _Folder = "";

        public static void SerName(string name)
        {
            _Folder = $"./bin/{name}_Behavior/";
        }

        public static List<string> Base = new List<string>()
        {
            "/animations",
            "/entities",
            "/functions",
            "/items",
            "/loot_tables/entities",
            "/recipes",
            "/spawn_rules"
        };

        public static void Create(string name, AddonManifest manifest)
        {
            

            foreach (var path in Base)
            {
                Logs.Loading("Generating BehaviorPack", $"Create Folder ( \"{path}\" )", Logs.Status.Running, Base.IndexOf(path), Base.Count + 1);
                Directory.CreateDirectory($"{_Folder}{path}");
                Logs.Loading("Generating BehaviorPack", $"Create Folder ( \"{path}\" )", Logs.Status.Complete, Base.IndexOf(path), Base.Count + 1);
            }

            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented);

            File.WriteAllText($"{_Folder}manifest.json", json);
            Logs.Loading("Generating ResourcePack", $"Create File ( \"./manifest.json\" )", Logs.Status.Complete, Base.Count + 1, Base.Count + 1);
        }
    }
}
