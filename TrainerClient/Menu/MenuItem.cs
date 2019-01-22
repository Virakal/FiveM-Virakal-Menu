using System.Collections.Generic;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    public class MenuItem : Dictionary<string, object>
    {
        public string text;
        public string sub;
        public string action;
        public string state;
        public string image;
        public string parent;
        public string configkey;

        public object ToAnonymous()
        {
            return new {
                text,
                sub,
                action,
                state,
                image,
                parent,
                configkey,
            };
        }
    }

}