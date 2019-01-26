using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Data
{
    public class VehicleListItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Model { get; set; }
        public HashSet<string> Tags { get; set; }
        public VehicleClass VehicleClass { get; set; }
        public Dlc Dlc { get; set; } = Dlc.BaseGame;
        public int ModelHash => lazyHash.Value;
        private Lazy<int> lazyHash;

        public VehicleListItem()
        {
            lazyHash = new Lazy<int>(GetModelHashCode);
        }

        public bool HasTag(string tag) => Tags != null && Tags.Contains(tag);

        private int GetModelHashCode() => API.GetHashKey(Model);

        internal bool MatchesSearchTerm(string term)
        {
            term.Replace(" ", "");

            return
                Model.Contains(term)
                || Name.ToLower().Replace(" ", "").Contains(term)
            ;
        }
    }
}
