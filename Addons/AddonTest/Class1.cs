using Addons.Texture;

namespace AddonTest
{
    public class Class1
    {
        [Texture("D:/temp/celula_h.png", TextureType.Items)]
        public Texture Texture1 { get; set; } = new Texture("chakra");

        [Texture("D:/temp/nitirintou_yoriichi.png", TextureType.Items)]
        public Texture Texture2 { get; set; } = new Texture("sword_dragon");
    }
}
