using Addons.Model;
using Newtonsoft.Json;

namespace Addons
{
    /// <summary>
    /// Represents a Minecraft item with various properties and methods for manipulation.
    /// </summary>
    internal partial class ItemModel : BaseJson, IMinecraftItem
    {
        /// <summary>
        /// Builds the JSON representation of the item.
        /// </summary>
        /// <returns>The JSON string representing the item.</returns>
        public string BuildJson()
        {
            // Set optional components only if they have valid values
            SetOptionalComponent("minecraft:can_destroy_in_creative", DestroyBlocksInCreative);
            SetOptionalComponent("minecraft:allow_off_hand", EquipWithSecondHand);
            SetOptionalComponent("minecraft:use_duration", Duration, 0);
            SetOptionalComponent("minecraft:damage", Damage, 0);
            SetOptionalComponent("minecraft:display_name", _displayName);
            if(Render != null) SetOptionalComponent("minecraft:render_offsets", Render.Renders);

            // Set required components
            Components["minecraft:stacked_by_data"] = StackedByData;
            Components["minecraft:max_stack_size"] = MaxStackSize;
            Components["minecraft:foil"] = Foil;
            Components["minecraft:hand_equipped"] = HandEquipped;

            _minecraftItem["description"] = _minecraftDescription ?? throw new ArgumentNullException(nameof(_minecraftDescription));
            _minecraftItem["components"] = Components;

            data["format_version"] = FormatVersion;
            data["minecraft:item"] = _minecraftItem;

            return base.ToString();
        }

        /// <summary>
        /// Sets an optional component in the components dictionary if the value is not null.
        /// </summary>
        /// <param name="key">The component key.</param>
        /// <param name="value">The component value.</param>
        private void SetOptionalComponent(string key, object? value) { if (value != null) Components[key] = value; }

        /// <summary>
        /// Sets an optional component in the components dictionary if the value is greater than the default value.
        /// </summary>
        /// <param name="key">The component key.</param>
        /// <param name="value">The component value.</param>
        /// <param name="defaultValue">The default value to compare against.</param>
        private void SetOptionalComponent(string key, int value, int defaultValue) { if (value > defaultValue) Components[key] = value; }
        private void SetOptionalComponent(string key, bool value) { if (value) Components[key] = value; }

        /// <summary>
        /// Sets the display name of the item.
        /// </summary>
        /// <param name="name">The display name.</param>
        public void SetDisplayName(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Display name cannot be null or empty.", nameof(name));
            _displayName = new { value = name };
        }

        /// <summary>
        /// Sets the texture of the item.
        /// </summary>
        /// <param name="name">The texture name.</param>
        public void SetTexture(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Texture name cannot be null or empty.", nameof(name));
            Components["minecraft:icon"] = new { texture = name };
        }

        /// <summary>
        /// Adds a render offset to the item.
        /// </summary>
        /// <param name="hand">The hand type.</param>
        /// <param name="view">The view type.</param>
        /// <param name="scale">The scale values (optional).</param>
        /// <param name="rotation">The rotation values (optional).</param>
        /// <param name="translation">The translation values (optional).</param>
        public void AddRenderOffset(HandTypes hand, ViewTypes view, float[]? scale = null, float[]? rotation = null, float[]? translation = null)
                => Render = new RenderItem(hand, view, scale, rotation, translation);

        public void IsFood(Action<Food> action)
        {
            var food = new Food();
            action(food);
            
            SetOptionalComponent("minecraft:use_duration", food.UseDuration);
            SetOptionalComponent("minecraft:use_animation", "eat");
            SetOptionalComponent("minecraft:food", food.GetData());
        }

        public void IsFood()
        {
            var food = new Food();
            SetOptionalComponent("minecraft:use_duration", food.UseDuration);
            SetOptionalComponent("minecraft:use_animation", "eat");
            SetOptionalComponent("minecraft:food", food.GetData());
        }

        
        internal const string FormatVersion = "1.16.100";
        internal Description? _minecraftDescription;
        public string? Identifier { get; set; }
        public ItemCategory? Category { get; set; }
        internal readonly Dictionary<string, object> _minecraftItem = new Dictionary<string, object>();
        private Dictionary<string, object> Components { get; set; } = new Dictionary<string, object>();
        private RenderItem? Render { get; set; }
        private object? _displayName;
        public bool StackedByData { get; set; } = true;
        public bool Foil { get; set; } = false;
        public bool HandEquipped { get; set; } = true;
        public bool DestroyBlocksInCreative { get; set; } = false;
        public bool EquipWithSecondHand { get; set; } = false;
        public int MaxStackSize { get; set; } = 64;
        public int Duration { get; set; } = 0;
        public int Damage { get; set; } = 0;
    }
}
