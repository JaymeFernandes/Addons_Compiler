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
        internal static string GetString(this AddonType type)
        {
            switch (type)
            {
                case AddonType.Data:
                    return "data";
                case AddonType.Resources:
                    return "resources";
                case AddonType.Scripting:
                    return "scripting";
                case AddonType.Interface:
                    return "interface";
                case AddonType.SkinPack:
                    return "skin_pack";
                case AddonType.WorldTemplate:
                    return "world_template";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
