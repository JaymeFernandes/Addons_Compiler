using Addons.Model.Manifest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Model.PathModel
{
    public static partial class InitialModel
    {
        public static List<string> PathInitialB = new List<string>()
        {
            "/animations",
            "/entities",
            "/functions",
            "/items",
            "/loot_tables/entities",
            "/recipes",
            "/spawn_rules"
        };

        public static List<string> PathInitialR = new List<string>()
        {
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
            "/textures/items"
        };

        public static void CreateBehaviorPack(string name, AddonManifest manifest)
        {
            foreach (var path in PathInitialB)
            {
                Directory.CreateDirectory($"./bin/{name}_Behavior/{path}");
            }

            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented);

            File.WriteAllText($"./bin/{name}_Behavior/manifest.json", json);
        }

        public static void CreateResourcePack(string name, AddonManifest manifest)
        {
            foreach (var path in PathInitialR)
            {
                Directory.CreateDirectory($"./bin/{name}_Resource/{path}");
            }

            string json = JsonConvert.SerializeObject(manifest, Formatting.Indented);

            File.WriteAllText($"./bin/{name}_Resource/manifest.json", json);
        }

        
    }
}
