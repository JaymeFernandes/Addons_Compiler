using Addons.Model;

namespace Addons
{
    internal class BehaviorPackController : IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorPack"/> class.
        /// </summary>
        public BehaviorPackController(AddonManifest manifest)
        {
            Manifest = manifest;
        }

        public void RegisterItem(Item item)
        {
            BehaviorPackManager.CreateItem(item.ToString(), item._Model.Identifier.Replace(":", "_"));
        }

        public void RegisterItem(List<Item> items)
        {
            foreach (Item item in items)
            {
                RegisterItem(item);
            }
        }
    }
}
