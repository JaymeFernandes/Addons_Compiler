using Addons.Texture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddonTest
{
    public class Class1
    {
        
        [Texture("D:/temp/luk_inicial.png", TextureType.Items)]
        public Texture Sword_Iron { get; set; } = new Texture("Sword-iron", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Items)]
        public Texture Sword_Iron2 { get; set; } = new Texture("Sword-iron2", "/swords");
    }
}
