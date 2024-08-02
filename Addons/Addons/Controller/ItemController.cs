using Addons.Model;

namespace Addons
{
    partial class Item : IMinecraftItem
    {
        public void Property(Action<IMinecraftItem> options)
        {
            options(this);
        }

        public override string ToString()
        {

            if (!string.IsNullOrEmpty(Identifier)) _minecraftDescription.Identifier = Identifier;
            else throw new ArgumentNullException(nameof(Identifier));

            if (Category != null)
            {
                
                switch (Category)
                {
                    case ItemCategory.Misc:
                        _minecraftDescription.Category = "misc";
                        break;
                    case ItemCategory.Construction:
                        _minecraftDescription.Category = "construction";
                        break;
                    case ItemCategory.Items:
                        _minecraftDescription.Category = "items";
                        break;
                    case ItemCategory.Nature:
                        _minecraftDescription.Category = "nature";
                        break;
                    case ItemCategory.Equipment:
                        _minecraftDescription.Category = "equipment";
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(Category));
            }

            
            return BuildJson();
        }
    }

}
