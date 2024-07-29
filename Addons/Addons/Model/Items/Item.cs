using Newtonsoft.Json;

namespace Addons.Model
{
    public sealed class ModelItemJson : IMinecraftItemJson
    {
        BaseJson _Json { get; set; } = new BaseJson();

        #region Base

        private string Format { get; set; } = "1.10";
        private Description MinecraftDescription { get; set; } = new Description();

        #endregion

        #region // Info minecraft:item

        private Dictionary<string, object> Minecraft_Item = new Dictionary<string, object>();
        public Dictionary<string, object> Components { get; set; } = new Dictionary<string, object>();
        public Dictionary<string, object> Render { get; private set; } = new Dictionary<string, object>();
        private object? DisplayName { get; set; } // name item
        public bool StackedByData { get; set; } = true; // can hold several in your hand
        public int Max { get; set; } = 64; // max size inventory
        public bool Foil { get; set; } = false; // if it has a glow of enchantment
        public bool HandEquipped { get; set; } = true;

        #endregion

        public string BuildJson()
        {
            Minecraft_Item.Add("description", MinecraftDescription);

            if (Render.Count > 0) Components.Add("minecraft:render_offsets", Render);
            if (DisplayName != null) Components.Add("minecraft:display_name", DisplayName);

            Components.Add("minecraft:stacked_by_data", StackedByData);
            Components.Add("minecraft:max_stack_size", Max);
            Components.Add("minecraft:foil", Foil);
            Components.Add("minecraft:hand_equipped", HandEquipped);

            Minecraft_Item.Add("components", Components);

            _Json.Propety(x =>
            {
                x.data.Add("format_version", Format);
                x.data.Add("minecraft:item", Minecraft_Item);
            });

            return _Json.ToString();
        }

        public void SetDisplayName(string name)
        {
            DisplayName = new { value = name };
        }

        public void SetTexture(string name)
        {
            Components["minecraft:icon"] = new
            {
                texture = name
            };
        }

        public void SetCategory(string category)
        {
            MinecraftDescription.category = category;
        }

        public void SetIdentifier(string identifier)
        {
            MinecraftDescription.identifier = identifier;
        }

        public void SetProperty(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Components[key] = value;
        }
    }

    public sealed class Description
    {
        [JsonProperty("identifier")]
        public string? identifier { get; set; }

        [JsonProperty("category")]
        public string? category { get; set; }
    }

    public class RenderItem
    {


        public RenderItem SetPosition(RenderTypes type, int  x, int y, int z)
        {
            return this;
        }
    }

    public enum RenderTypes
    {
        FirstPerson,
        ManHand,
        ThirdPerson
    }

}
