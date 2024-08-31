using Addons.Model;

namespace Addons
{
    public partial class Item 
    {
        public Item() => _Model = new ItemModel();

        public Item(Action<IMinecraftItem> options) : this() => options(_Model);

        public Item(string Identifier) : this() => _Model.Identifier = Identifier ?? "NotDefined"; 
        public Item(string Identifier, string name) : this(Identifier) => _Model.SetDisplayName(name);
        public Item(string identifier, string name, ItemCategory category) : this(identifier, name) => _Model.Category = category;


        public void Property(Action<IMinecraftItem> options) => options(_Model);

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_Model.Identifier)) throw new ArgumentNullException(nameof(_Model.Identifier));
            _Model._minecraftDescription = new Description(_Model.Identifier, _Model.Category ?? ItemCategory.Items);
            
            return _Model.BuildJson();
        }

        internal ItemModel _Model;
    }

}
