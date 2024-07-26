using Addons.Texture;

namespace AddonTest
{
    public class Class1
    {
        
        [Texture("D:/temp/luk_inicial.png", TextureType.Items)]
        public Texture Texture1 { get; set; } = new Texture("Sword-iron", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Entity)]
        public Texture Texture2 { get; set; } = new Texture("Sword-iron1", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Environment)]
        public Texture Texture3 { get; set; } = new Texture("Sword-iron2", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Terrain)]
        public Texture Texture4 { get; set; } = new Texture("Sword-iron3", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Gui)]
        public Texture Texture5 { get; set; } = new Texture("Sword-iron4", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Misc)]
        public Texture Texture6 { get; set; } = new Texture("Sword-iron5", "/swords");

        [Texture("D:/temp/luk_inicial.png", TextureType.Particles)]
        public Texture Texture7 { get; set; } = new Texture("Sword-iron6", "/swords");
    }
}
