using Addons.Model;
using Newtonsoft.Json;

namespace Addons
{
    /// <summary>
    /// Represents a Minecraft item with various properties and methods for manipulation.
    /// </summary>
    public partial class Item
    {
        private readonly BaseJson _json = new BaseJson();

        #region Base

        private const string FormatVersion = "1.16.100";
        private readonly Description _minecraftDescription = new Description();
        public string? Name { get; set; }
        public string? Identifier { get; set; }
        public ItemCategory? Category { get; set; }

        #endregion

        #region Minecraft Item properties

        private readonly Dictionary<string, object> _minecraftItem = new Dictionary<string, object>();
        public Dictionary<string, object> Components { get; private set; } = new Dictionary<string, object>();
        public RenderItem Render { get; set; } = new RenderItem();
        private object? _displayName; // Display name of the item
        public bool StackedByData { get; set; } = true;  
        public int MaxStackSize { get; set; } = 64;
        public bool Foil { get; set; } = false;
        public bool HandEquipped { get; set; } = true;
        public int Duration { get; set; } = 0;
        public int Damage { get; set; } = 0;

        #endregion

        /// <summary>
        /// Builds the JSON representation of the item.
        /// </summary>
        /// <returns>The JSON string representing the item.</returns>
        public string BuildJson()
        {
            _minecraftItem["description"] = _minecraftDescription;

            Components["minecraft:render_offsets"] = Render.Renders;
            if (_displayName != null) Components["minecraft:display_name"] = _displayName;
            Components["minecraft:stacked_by_data"] = StackedByData;
            Components["minecraft:max_stack_size"] = MaxStackSize;
            Components["minecraft:foil"] = Foil;
            Components["minecraft:hand_equipped"] = HandEquipped;
            if (Duration > 0) Components["minecraft:use_duration"] = Duration;
            if (Damage > 0) Components["minecraft:damage"] = Damage;
            _minecraftItem["components"] = Components;

            _json.Propety(x =>
            {
                x.data["format_version"] = FormatVersion;
                x.data["minecraft:item"] = _minecraftItem;
            });

            return _json.ToString();
        }

        #region Definition methods

        /// <summary>
        /// Sets the display name of the item.
        /// </summary>
        /// <param name="name">The display name.</param>
        public void SetDisplayName(string name)
        {
            _displayName = new { value = name };
        }

        /// <summary>
        /// Sets the texture of the item.
        /// </summary>
        /// <param name="name">The texture name.</param>
        public void SetTexture(string name)
        {
            Components["minecraft:icon"] = new { texture = name };
        }

        /// <summary>
        /// Sets the category of the item.
        /// </summary>
        /// <param name="category">The category name.</param>
        public void SetCategory(string category)
        {
            _minecraftDescription.Category = category;
        }

        /// <summary>
        /// Sets the identifier of the item.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        public void SetIdentifier(string identifier)
        {
            _minecraftDescription.Identifier = identifier;
        }

        /// <summary>
        /// Sets a property of the item.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="value">The property value.</param>
        /// <exception cref="ArgumentNullException">Thrown when the key is null or empty.</exception>
        public void SetProperty(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Components[key] = value;
        }

        /// <summary>
        /// Adds a render offset to the item.
        /// </summary>
        /// <param name="hand">The hand type.</param>
        /// <param name="view">The view type.</param>
        /// <param name="scale">The scale values.</param>
        /// <param name="rotation">The rotation values.</param>
        /// <param name="translation">The translation values.</param>
        public void AddRenderOffset(HandTypes hand, ViewTypes view, float[]? scale = null, float[]? rotation = null, float[]? translation = null)
        {
            Render.AddRenderOffset(hand, view, scale, rotation, translation);
        }

        #endregion
    }

    /// <summary>
    /// Represents the description of a Minecraft item.
    /// </summary>
    public sealed class Description
    {
        [JsonProperty("identifier")]
        public string? Identifier { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }
    }

    /// <summary>
    /// Represents render properties of a Minecraft item.
    /// </summary>
    public class RenderItem
    {
        public Dictionary<string, object> Renders { get; set; } = new Dictionary<string, object>();

        public RenderItem()
        {
            AddRenderOffset(HandTypes.MainHand, ViewTypes.FirstPerson);
            AddRenderOffset(HandTypes.MainHand, ViewTypes.ThirdPerson, scale:new float[] { 0.002f, 0.002f, 0.002f });
        }

        public void AddRenderOffset(HandTypes hand, ViewTypes view, float[]? scale = null, float[]? rotation = null, float[]? translation = null)
        {
            if (scale == null) scale = new float[] { 0.001f, 0.001f, 0.001f };

            if (!Renders.ContainsKey(hand.GetString()))
            {
                Renders[hand.GetString()] = new Dictionary<string, object>();
            }

            var handDict = (Dictionary<string, object>)Renders[hand.GetString()];

            var viewDict = new Dictionary<string, object>
            {
                ["scale"] = scale
            };
            if (rotation != null) viewDict["rotation"] = rotation;
            if (translation != null) viewDict["translation"] = translation;

            handDict[view.GetString()] = viewDict;
        }
    }

    internal static class RenderExtension
    {
        internal static string GetString(this ViewTypes type)
        {
            return type switch
            {
                ViewTypes.FirstPerson => "first_person",
                ViewTypes.ThirdPerson => "third_person",
                _ => string.Empty,
            };
        }

        internal static string GetString(this HandTypes type)
        {
            return type switch
            {
                HandTypes.MainHand => "main_hand",
                HandTypes.OffHand => "off_hand",
                _ => string.Empty,
            };
        }
    }
}
