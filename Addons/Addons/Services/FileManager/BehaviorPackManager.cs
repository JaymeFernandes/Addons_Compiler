using Addons.Model;

namespace Addons
{
    internal static class BehaviorPackManager
    {
        private static string _Folder = "";

        public static void SerName(string name)
        {
            _Folder = $"./com.mojang/development_behavior_packs/{name}_Behavior/";
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

            string json = manifest.ToString();

            File.WriteAllText($"{_Folder}README.md", ReadMe.Read);

            if (!File.Exists($"{_Folder}manifest.json")) File.WriteAllText($"{_Folder}manifest.json", json);
            Logs.Loading("Generating ResourcePack", $"Create File ( \"./manifest.json\" )", Logs.Status.Complete, Base.Count + 1, Base.Count + 1);
        }

        public static void CreateItem(string json, string name)
        {
            File.WriteAllText($"{_Folder}/items/{name}.json", json);
        }
    }
}
