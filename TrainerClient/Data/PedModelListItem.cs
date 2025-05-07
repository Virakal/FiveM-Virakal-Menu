using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Data
{
    public class PedModelListItem
    {
        public string Name { get; set; }
        public string Image { get
            {
                if (this.Type == PedModelType.Custom || this.Type == PedModelType.MainCharacter) {
                    return null;
                }

                return $"https://docs.fivem.net/peds/{this.Model}.webp";
            }
        }

        public string Model { get; set; }
        public PedModelType Type { get; set; } = PedModelType.Human;
        public HashSet<string> Tags { get; set; }
        
        public int ModelHash => lazyHash.Value;
        private readonly Lazy<int> lazyHash;

        public PedModelListItem()
        {
            lazyHash = new Lazy<int>(GetModelHashCode);
        }

        public bool HasTag(string tag) => Tags != null && Tags.Contains(tag);

        private int GetModelHashCode() => API.GetHashKey(Model);
    }
}
