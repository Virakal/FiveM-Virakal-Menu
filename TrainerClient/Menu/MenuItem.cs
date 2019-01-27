using Newtonsoft.Json;
using System.Collections.Generic;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MenuItem : Dictionary<string, object>
    {
        public string text;
        public string sub;
        public string action;
        public string state;
        public string image;
        public string configkey;
        public string key;
    }
}
