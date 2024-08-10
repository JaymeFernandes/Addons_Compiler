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
            try
            {
                foreach (var path in Base)
                {
                    Directory.CreateDirectory($"{_Folder}{path}");

                    Logs.Status status = (Path.Exists($"{_Folder}{path}") ? Logs.Status.Complete : Logs.Status.Failed);

                    Logs.Log($"Create Folder ( \"{path}\" )", status, Base.IndexOf(path), Base.Count + 1);
                }

                string json = manifest.ToString();

                File.WriteAllText($"{_Folder}README.md", ReadMe.Read);

                if (!File.Exists($"{_Folder}manifest.json")) File.WriteAllText($"{_Folder}manifest.json", json);

                Logs.Log($"Create File ( \"./manifest.json\" )", Logs.Status.Complete, Base.Count + 1, Base.Count + 1);
            }
            catch(Exception ex)
            {
                Logs.Log(ex.Message, Logs.Status.Failed, 0, 0);
            }

            
        }

        public static void CreateItem(string json, string name)
        {
            File.WriteAllText($"{_Folder}/items/{name}.json", json);
        }
    }
}
