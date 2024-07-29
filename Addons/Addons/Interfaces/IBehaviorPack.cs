using Addons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons
{
    public interface IBehaviorPack
    {
        public AddonManifest? Manifest { get; set; }

        public void RegisterItem(IMinecraftItem item);
    }
}
