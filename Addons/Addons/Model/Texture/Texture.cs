using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Addons.Model.Texture
{
    public class TexturePack
    {
        [JsonProperty("resource_pack_name")]
        private string ResourceName { get; set; } = "";

        [JsonProperty("texture_name")]
        private string TextureName { get; set; } = "";

        [JsonProperty("texture_data")]
        private Dictionary<string, Data> _Data { get; set; } = new Dictionary<string, Data>();


        public TexturePack(string resourceName, TextureType type)
        {
            if (String.IsNullOrEmpty(resourceName)) throw new ArgumentNullException(nameof(resourceName));

            ResourceName = resourceName;
            TextureName = type.GetString();
        }


        public void AddTexture(string name, string path)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (String.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            _Data[name.Replace(' ', '_')] = new Data {  PathTexture = path };
        }


        protected class Data
        {
            [JsonProperty("textures")]
            public string PathTexture { get; set; } = "";
        }

        
    }

    public enum TextureType
    {
        Items,
        Terrain,
        Entity,
        Environment,
        gui,
        misc,
        particles
    }

    public static class ExtensionTexture
    {
        public static string GetString(this TextureType texture)
        {
            switch(texture)
            {
                case TextureType.Items:
                    return "atlas.items";
                case TextureType.Terrain:
                    return "atlas.terrain";
                case TextureType.Entity:
                    return "atlas.entity";
                case TextureType.Environment:
                    return "atlas.environment";
                case TextureType.gui:
                    return "atlas.gui";
                case TextureType.misc:
                    return "atlas.misc";
                case TextureType.particles:
                    return "atlas.particles";
                default:
                    throw new ArgumentOutOfRangeException(nameof(texture), texture, null);
            }
        }
    }
}
