using Addons.Model;

namespace Addons
{
    public partial class Item 
    {
        internal ItemModel _Model = new ItemModel();

        public void Property(Action<IMinecraftItem> options)
        {
            options(_Model);
        }

        public override string ToString()
        {

            if (!string.IsNullOrEmpty(_Model.Identifier)) _Model._minecraftDescription.Identifier = _Model.Identifier;
            else throw new ArgumentNullException(nameof(_Model.Identifier));

            if (_Model.Category != null)
            {
                
                switch (_Model.Category)
                {
                    case ItemCategory.Misc:
                        _Model._minecraftDescription.Category = "misc";
                        break;
                    case ItemCategory.Construction:
                        _Model._minecraftDescription.Category = "construction";
                        break;
                    case ItemCategory.Items:
                        _Model._minecraftDescription.Category = "items";
                        break;
                    case ItemCategory.Nature:
                        _Model._minecraftDescription.Category = "nature";
                        break;
                    case ItemCategory.Equipment:
                        _Model._minecraftDescription.Category = "equipment";
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(_Model.Category));
            }

            
            return _Model.BuildJson();
        }
    }

}
