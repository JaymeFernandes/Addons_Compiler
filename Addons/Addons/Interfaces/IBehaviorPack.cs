using Addons.Model;

namespace Addons
{
    public interface IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        public void RegisterItem(IMinecraftItem item);

        public void RegisterItem(List<IMinecraftItem> items);
    }
}
