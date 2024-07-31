using Addons.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Addons.ResourcePack;

namespace Addons
{
    public interface IResourcePack
    {
        internal AddonManifest Manifest { get; set; }
        internal Textures _Textures { get; set; }
    }
}
