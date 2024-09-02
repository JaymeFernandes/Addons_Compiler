using Addons.Model;

namespace Addons
{
    internal class BehaviorPackController : IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorPack"/> class.
        /// </summary>
        public BehaviorPackController(AddonManifest manifest) => Manifest = manifest;



        public void MapItem(Item item) 
        {
            if(item._Model == null) throw new ArgumentNullException(nameof(item));
            if(item._Model.Identifier == null) throw new ArgumentNullException(nameof(item));

            BehaviorPackManager.CreateItem(item.ToString(), item._Model.Identifier.Replace(":", "_") ?? throw new ArgumentNullException(nameof(item)));
        }

        public void MapItem(Action<IMinecraftItem> options)
        {
            var item = new Item(options);

            if(item._Model.Identifier == null) throw new ArgumentNullException(nameof(item));

            MapItem(item);
        }


        public void MapItems(ICollection<Item> items) => items.ToList().ForEach(item => MapItem(item));
    }
}
