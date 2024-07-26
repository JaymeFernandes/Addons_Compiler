using Addons.Interfaces.Items;
using Newtonsoft.Json;

namespace Addons.Model.Items
{
    public sealed class ModelItemJson : IMinecraftItemJson
    {
        [JsonProperty("format_version")]
        public string Format { get; private set; } = "1.10";

        [JsonProperty("minecraft:item")]
        public Description MinecraftItem { get; private set; } = new Description();

        [JsonProperty("components")]
        public Dictionary<string, object> Propertys { get; private set; } = new Dictionary<string, object>();

        public string BuildJson()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }

        public void SetTexture(string name)
        {
            Propertys["minecraft:icon"] = name;
        }

        public void SetCategory(string category)
        {
            MinecraftItem.category = category;
        }

        public void SetIdentifier(string identifier)
        {
            MinecraftItem.identifier = identifier;
        }

        public void SetProperty(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Propertys[key] = value;
        }
    }

    public sealed class Description
    {
        [JsonProperty("identifier")]
        public string identifier { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }
    }
}
