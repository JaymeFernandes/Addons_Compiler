using Addons.Model;

namespace Addons
{
    public interface IMinecraftItem
    {
        /// <summary>
        /// Gets or sets the identifier of the item.
        /// </summary>
        public string? Identifier { get; set; }

        /// <summary>
        /// Gets or sets the category of the item.
        /// </summary>
        public ItemCategory? Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item can stack by data.
        /// </summary>
        public bool StackedByData { get; set; }

        /// <summary>
        /// Gets or sets the maximum stack size of the item.
        /// </summary>
        public int MaxStackSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item has an enchantment glow.
        /// </summary>
        public bool Foil { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item can be equipped in hand.
        /// </summary>
        public bool HandEquipped { get; set; }

        /// <summary>
        /// Gets or sets the durability of an item
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the damage the item does
        /// </summary>
        public int Damage { get; set; }

        public bool DestroyBlocksInCreative { get; set; }
        public bool EquipWithSecondHand { get; set; }

        /// <summary>
        /// Sets the texture of the item.
        /// </summary>
        /// <param name="name">The texture name.</param>
        public void SetTexture(string name);

        /// <summary>
        /// Sets the display name of the item.
        /// </summary>
        /// <param name="name">The display name.</param>
        public void SetDisplayName(string name);

        /// <summary>
        /// Adds a render offset to the item.
        /// </summary>
        /// <param name="hand">The hand type.</param>
        /// <param name="view">The view type.</param>
        /// <param name="scale">The scale values (optional).</param>
        /// <param name="rotation">The rotation values (optional).</param>
        /// <param name="translation">The translation values (optional).</param>
        public void AddRenderOffset(HandTypes hand, ViewTypes view, float[]? scale = null, float[]? rotation = null, float[]? translation = null);

        /// <summary>
        /// Configures the item to be edible with specific properties.
        /// </summary>
        /// <param name="action">A delegate to configure the food properties.</param>
        public void IsFood(Action<Food> action);

        /// <summary>
        /// Configures the item to be edible with default properties.
        /// </summary>
        public void IsFood();
    }



    public enum ItemCategory
    {
        Misc,
        Construction,
        Items,
        Nature,
        Equipment
    }
}
