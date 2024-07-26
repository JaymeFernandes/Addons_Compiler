using Addons.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Interfaces.Bulder
{
    public interface IAddon
    {
        public void RegisterItem(IMinecraftItem item);
    }
}
