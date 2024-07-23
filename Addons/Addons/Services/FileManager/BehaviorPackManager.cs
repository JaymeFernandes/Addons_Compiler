using Addons.Model.Manifest;
using Addons.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Logs.Title("Generating BehaviorPack");

            foreach (var path in Base)
            {
                Logs.Process($"Create Folder ( \"{path}\" )", Logs.Status.running);
                Directory.CreateDirectory($"{_Folder}{path}");
                Logs.Process($"Create Folder ( \"{path}\" )", Logs.Status.complete);
            }

            Logs.Process($"Create File ( \"{_Folder}/manifest.json\" )", Logs.Status.running);
            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented);

            File.WriteAllText($"{_Folder}manifest.json", json);
            Logs.Process($"Create File ( \"{_Folder}/manifest.json\" )", Logs.Status.complete);
        }
    }
}
