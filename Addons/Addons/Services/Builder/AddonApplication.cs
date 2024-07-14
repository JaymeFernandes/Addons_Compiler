using Addons.Model.Manifest;
using Addons.Model.PathModel;

namespace Addons
{
    public partial class Addon
    {
        public AddonManifest ManifestBehavior { get; set; }

        public AddonManifest ManifestResource { get; set; }

        public string Name { get; private set; } = "";

        public string Description { get; private set; } = "";

        public List<int> Version { get; private set; } = new List<int> { 3, 0, 0 };

        public List<int> Minversion { get; private set; } = new List<int> { 1, 8, 0 };


        public partial class Builder
        {
            private readonly Addon addon;

            public Builder()
            {
                addon = new Addon();
            }

            public Addon Build()
            {
                if(addon.ManifestBehavior != null && addon.ManifestResource != null)
                {
                    InitialModel.CreateBehaviorPack(addon.Name, addon.ManifestBehavior);
                    InitialModel.CreateResourcePack(addon.Name, addon.ManifestResource);
                }
                else
                {
                    throw new ArgumentException("Behavior or Resource is null");
                }

                return addon;
            }
        }
    }
}
