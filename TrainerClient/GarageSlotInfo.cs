using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    public struct GarageSlotInfo
    {
        public int model;
        public string modString;
        public string displayName;

        public GarageSlotInfo(string model, string displayName, string modString)
        {
            this.model = int.Parse(model);
            this.displayName = displayName;
            this.modString = modString;
        }
    }
}
