using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Model.Texture
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TextureAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public TextureType Type { get; private set; }

        public string CustomFolder { get; private set; }

        public TextureAttribute(string name, string path, TextureType type, string customFolder = "")
        {
            Name = name;
            Path = path;
            Type = type;
        }
    }
}
