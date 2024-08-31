using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addons.Model
{
    public class BaseJson
    {
        public Dictionary<string, object> data { get; private set; } = new Dictionary<string, object>();

        public void Property(Action<BaseJson> action)
        {
            action(this);
        }

        public override string ToString()
        {
            return $"{JsonConvert.SerializeObject(data, Formatting.Indented)}";
        }
    }
}
