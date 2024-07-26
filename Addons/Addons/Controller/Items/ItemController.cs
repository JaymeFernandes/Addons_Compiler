using Addons.Interfaces.Items;
using Addons.Model.Items;
using System.Xml.Linq;

namespace Addons.Controller.Items
{
    public class Item : IMinecraftItem
    {
        public string? Name { get; set; }

        public string? Identifier { get; set; }

        public ItemCategory? Category { get; set; }

        private IMinecraftItemJson json { get; set; } = new ModelItemJson();

        public void Property(Action<IMinecraftItem> options)
        {
            options(this);
        }

        public override string ToString()
        {
            if(!string.IsNullOrEmpty(Name)) json.SetProperty("minecraft:render_offsets", Name);
            else throw new ArgumentNullException(nameof(Name));

            if (!string.IsNullOrEmpty(Identifier)) json.SetIdentifier(Identifier);
            else throw new ArgumentNullException(nameof(Identifier));

            if(Category != null)
            {
                string categoryString = "";

                switch (Category)
                {
                    case ItemCategory.Misc:
                        categoryString = "Misc";
                        break;
                    case ItemCategory.Construction:
                        categoryString = "Construction";
                        break;
                    case ItemCategory.Items:
                        categoryString = "Items";
                        break;
                    case ItemCategory.Nature:
                        categoryString = "Nature";
                        break;
                    case ItemCategory.Equipment:
                        categoryString = "Equipment";
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

            return json.BuildJson();
        }

        public void SetTexture(string name)
        {
            json.SetTexture(name);
        }
    }

}
