using Addons.Model.Texture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddonTest
{
    public class Class1
    {
        [Texture("temp", "temp2", TextureType.Items)]
        public string Sword_Iron { get; set; }
    }
}
