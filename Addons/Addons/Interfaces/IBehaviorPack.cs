using Addons.Model;

namespace Addons
{
    public interface IBehaviorPack
    {
        public AddonManifest Manifest { get; set; }

        public void AddItem(Item item);
        public void MapItem(Action<IMinecraftItem> item);
        public void AddItems(ICollection<Item> items);

    }
}
