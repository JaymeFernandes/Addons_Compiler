using Addons.Model;

namespace Addons
{
    public interface IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        public void RegisterItem(Item item);

        public void RegisterItem(List<Item> items);
    }
}
