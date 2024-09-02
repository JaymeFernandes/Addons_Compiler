using Addons.Model;

namespace Addons
{
    public interface IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        public void MapItem(Item item);
        public void MapItem(Action<IMinecraftItem> item);
        public void MapItems(ICollection<Item> items);

    }
}
