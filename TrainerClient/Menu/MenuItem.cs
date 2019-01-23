using Newtonsoft.Json;
using System.Collections.Generic;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    [JsonObject(MemberSerialization.OptIn)]
    public class MenuItem : Dictionary<string, object>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string text;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sub;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string action;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string state;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string image;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string parent;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string configkey;
    }

}