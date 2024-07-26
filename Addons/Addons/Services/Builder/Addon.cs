using Addons.Interfaces.Bulder;
using Addons.Interfaces.Items;
using Addons.Model.Manifest;
using Addons.Services;

namespace Addons
{
    public partial class Addon : IAddon
    {
        public BehaviorPack? Behavior { get; set; }
        public ResourcePack? Resource { get; set; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public List<int> Version { get; private set; } = new List<int> { 3, 0, 0 };
        public List<int> Minversion { get; private set; } = new List<int> { 1, 8, 0 };

        public void RegisterItem(IMinecraftItem item)
        {
            
        }

        public partial class CreateBuilder : IAddonBuilder
        {

        }
    }
}
