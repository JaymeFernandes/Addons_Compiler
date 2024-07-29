using Addons.Model;
using Addons.Services.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons
{
    public class BehaviorPackController : IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorPack"/> class.
        /// </summary>
        public BehaviorPackController(AddonManifest manifest)
        {
            Manifest = manifest;
        }

        public void RegisterItem(IMinecraftItem item)
        {
            BehaviorPackManager.CreateItem(item.ToString(), item.Name);
        }
    }
}
