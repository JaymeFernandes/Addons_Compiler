namespace Addons.Interfaces.Items
{
    public interface IMinecraftItem
    {
        public string? Name { get; set; }

        public string? Identifier { get; set; }

        public ItemCategory? Category { get; set; }

        public void SetTexture(string name);

        public void Property(Action<IMinecraftItem> options);
    }

    public interface IMinecraftItemJson
    {
        public string BuildJson();

        public void SetIdentifier(string identifier);

        public void SetProperty(string key, object value);

        public void SetCategory(string category);

        public void SetTexture(string name);
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
