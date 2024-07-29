using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Model.Items.Events
{
    public class EventCommand
    {
        [JsonProperty("command")]
        public string Command { get; private set; } = "";

        [JsonProperty("target")]
        public string Target { get; private set; } = "";
    }

}
