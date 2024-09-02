using Addons.Services;
using Newtonsoft.Json;

namespace Addons.Model
{
    public class AddonModules
    {
        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("uuid")]
        public string _UUID { get; set; } = UUID.Generate();

        [JsonProperty("version")]
        public List<int> Version { get; set; } = new List<int>() { 3, 0, 0 };

        public AddonModules(AddonType type, string description)
        {
            Type = type.GetString();
            Description = description;
        }
    }

    internal static class AddonTypeExtensions
    {
        internal static string GetString(this AddonType type) => type switch {
            AddonType.Data => "data",
            AddonType.Resources => "resources",
            AddonType.Scripting => "scripting",
            AddonType.Interface => "interface",
            AddonType.SkinPack => "skin_pack",
            AddonType.WorldTemplate => "world_template",
            _ => ""
        };
    }
}
