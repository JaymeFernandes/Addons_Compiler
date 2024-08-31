using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons
{

    /// <summary>
    /// Represents the description of a Minecraft item.
    /// </summary>
    public sealed class Description
    {
        public Description(string identifier, ItemCategory category)
        {
            this.Identifier = identifier;
            this.Category = category switch
            {
                ItemCategory.Misc => "misc",
                ItemCategory.Construction => "construction",
                ItemCategory.Items => "items",
                ItemCategory.Nature => "nature",
                ItemCategory.Equipment => "equipment",
                _ => throw new NotImplementedException()
            };
        }

        [JsonProperty("identifier")]
        public string? Identifier { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }
    }
}
