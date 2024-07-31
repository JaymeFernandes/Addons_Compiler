
using Addons.Model;
using Addons.Services;

namespace Addons
{
    public partial class Addon : IAddon
    {
        public IBehaviorPack Behavior { get; set; }
        public IResourcePack Resource { get; set; }
        public string Name { get; private set; } = "";
        public string Description { get; private set; } = "";
        public List<int> Version { get; private set; } = new List<int> { 3, 0, 0 };
        public List<int> Minversion { get; private set; } = new List<int> { 1, 8, 0 };

        public void CreateMcAddonFile()
        {
            McAddonManager.CreateMcAddonFile();
        }
    }
}
