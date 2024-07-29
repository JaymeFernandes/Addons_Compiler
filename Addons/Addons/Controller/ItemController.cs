using Addons.Model;

namespace Addons
{
    public class Item : IMinecraftItem
    {
        public string? Name { get; set; }

        public string? Identifier { get; set; }

        public ItemCategory? Category { get; set; }

        public bool? StackedByData { get; set; }

        public int? Max { get; set; }

        public bool? Foil { get; set; }

        public bool? HandEquipped { get; set; }


        private IMinecraftItemJson json { get; set; } = new ModelItemJson();

        public void Property(Action<IMinecraftItem> options)
        {
            options(this);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name)) json.SetDisplayName(Name);
            else throw new ArgumentNullException(nameof(Name));

            if (!string.IsNullOrEmpty(Identifier)) json.SetIdentifier(Identifier);
            else throw new ArgumentNullException(nameof(Identifier));

            if (Category != null)
            {
                string categoryString = "";

                switch (Category)
                {
                    case ItemCategory.Misc:
                        categoryString = "misc";
                        break;
                    case ItemCategory.Construction:
                        categoryString = "construction";
                        break;
                    case ItemCategory.Items:
                        categoryString = "items";
                        break;
                    case ItemCategory.Nature:
                        categoryString = "nature";
                        break;
                    case ItemCategory.Equipment:
                        categoryString = "equipment";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                json.SetCategory(categoryString);
            }
            else
            {
                throw new ArgumentNullException(nameof(Category));
            }

            if (StackedByData != null) json.StackedByData = (bool)StackedByData;
            if (Max != null) json.Max = (int)Max;
            if (Foil != null) json.Foil = (bool)Foil;
            if (HandEquipped != null) json.HandEquipped = (bool)HandEquipped;

            return json.BuildJson();
        }

        public void SetTexture(string name)
        {
            json.SetTexture(name);
        }
    }

}
