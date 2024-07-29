using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Addons.Texture
{
    public class TexturePack
    {
        [JsonProperty("resource_pack_name")]
        private string ResourceName { get; set; } = "";

        [JsonProperty("texture_name")]
        private string TextureType { get; set; } = "";

        [JsonProperty("texture_data")]
        public Dictionary<string, Data> TextureData { get; private set; } = new Dictionary<string, Data>();

        [JsonIgnore]
        public string PathFile { get; private set; }

        public TexturePack(string resourceName, TextureType type, string path)
        {
            if (String.IsNullOrEmpty(resourceName)) throw new ArgumentNullException(nameof(resourceName));

            PathFile = path;
            ResourceName = resourceName;
            TextureType = type.GetString();
        }

        public void AddTexture(string name, string path, string folder = "")
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (String.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            var textureKey = name.Replace(' ', '_');

            var finalFolder = $"textures/{folder}/{name}".Replace(@"\", "/");

            while (finalFolder.Contains("//", StringComparison.InvariantCulture))
            {
                finalFolder = finalFolder.Replace("//", "/");
            }

            TextureData[textureKey] = new Data { PathTexture = path, Folder = finalFolder };
        }

        public class Data
        {
            [JsonIgnore]
            public string PathTexture { get; set; } = "";
            
            [JsonProperty("textures")]
            public string Folder { get; set; } = "";
        }


    }

    public static class ExtensionTexture
    {
        public static string GetString(this TextureType texture)
        {
            return texture switch
            {
                TextureType.Items => "atlas.items",
                TextureType.Terrain => "atlas.terrain",
                TextureType.Entity => "atlas.entity",
                TextureType.Environment => "atlas.environment",
                TextureType.Gui => "atlas.gui",
                TextureType.Misc => "atlas.misc",
                TextureType.Particles => "atlas.particles",
                _ => throw new ArgumentOutOfRangeException(nameof(texture), texture, null)
            };
        }
    }
}

