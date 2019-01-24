using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Data
{
    public class PedModelListItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Model { get; set; }
        public PedModelType Type { get; set; } = PedModelType.Human;
        public HashSet<string> Tags { get; set; }
        
        public int ModelHash => lazyHash.Value;
        private Lazy<int> lazyHash;

        public PedModelListItem()
        {
            lazyHash = new Lazy<int>(GetModelHashCode);
        }

        public bool HasTag(string tag) => Tags != null && Tags.Contains(tag);

        private int GetModelHashCode() => API.GetHashKey(Model);
    }
}
