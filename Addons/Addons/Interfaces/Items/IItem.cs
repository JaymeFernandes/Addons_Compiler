namespace Addons
{
    public interface IMinecraftItem
    {
        public string? Name { get; set; }
        public string? Identifier { get; set; }
        public ItemCategory? Category { get; set; }
        public bool? StackedByData { get; set; }
        public int? Max { get; set; }
        public bool? Foil { get; set; }
        public bool? HandEquipped { get; set; }



        public void SetTexture(string name);

        public void Property(Action<IMinecraftItem> options);
    }

    public interface IMinecraftItemJson
    {
        public bool StackedByData { get; set; }
        public int Max { get; set; }
        public bool Foil { get; set; }
        public bool HandEquipped { get; set; }


        public string BuildJson();

        public void SetIdentifier(string identifier);

        public void SetProperty(string key, object value);

        public void SetCategory(string category);

        public void SetTexture(string name);

        public void SetDisplayName(string name);
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
