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
        [JsonProperty("identifier")]
        public string? Identifier { get; set; }

        [JsonProperty("category")]
        public string? Category { get; set; }
    }
}
