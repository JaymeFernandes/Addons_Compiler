using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Model
{
    public abstract class BaseJson
    {
        protected Dictionary<string, object> data { get; private set; } = new Dictionary<string, object>();

        public override string ToString()
        {
            return $"{JsonConvert.SerializeObject(data, Formatting.Indented)}";
        }
    }
}
