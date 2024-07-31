using Addons.Model;

namespace Addons
{
    public interface IMinecraftItem
    {
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string? Name { get; set; }

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

        public void SetTexture(string name);

        public void Property(Action<IMinecraftItem> options);

        public void SetDisplayName(string name);

        public void AddRenderOffset(HandTypes hand, ViewTypes view, float[]? scale = null, float[]? rotation = null, float[]? translation = null);

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
