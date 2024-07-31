namespace Addons.Texture
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TextureAttribute : Attribute
    {
        public string Path { get; private set; }
        public TextureType Type { get; private set; }

        public TextureAttribute(string path, TextureType type)
        {
            Path = path;
            Type = type;
        }
    }

    public class Texture
    {
        public string Name { get; set; }
        public string Folder { get; set; } = "";

        public Texture(string name)
        {
            Name = name;
        }

        public Texture(string name, string folder)
        {
            Name = name;
            Folder = folder;
        }
    }


    
}
