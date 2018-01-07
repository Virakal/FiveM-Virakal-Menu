using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class UISection : BaseSection
    {
        public UISection(Trainer trainer) : base(trainer)
        {
            Trainer.RegisterNUICallback("bigmap", ToggleBigMap);
        }

        private CallbackDelegate ToggleBigMap(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool) data["newstate"];
            Config["BigMap"] = state ? "true" : "false";

            API.SetRadarBigmapEnabled(state, false);

            callback("ok");
            return callback;
        }
    }
}
