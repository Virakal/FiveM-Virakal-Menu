using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class UISection : BaseSection
    {
        private const Control MapKey = Control.PhoneDown;
        private const int MapShowTime = 2500;

        public UISection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("BigMap", "false");
            Config.SetDefault("BigMapOnDown", "true");

            Trainer.RegisterNUICallback("bigmap", ToggleBigMap);
            Trainer.RegisterNUICallback("bigmapondown", ToggleBigMapOnDown);

            Trainer.AddTick(MapOnDownTick);
        }

        private async Task MapOnDownTick()
        {
            if (!Trainer.ShowTrainer && Config["BigMapOnDown"] == "true" && Config["BigMap"] == "false")
            {
                if (Game.IsControlJustPressed(0, MapKey))
                {
                    API.SetRadarBigmapEnabled(true, false);
                }

                if (Game.IsControlJustReleased(0, MapKey))
                {
                    await BaseScript.Delay(MapShowTime);
                    API.SetRadarBigmapEnabled(false, false);
                }
            }

            await Task.FromResult(0);
        }

        private CallbackDelegate ToggleBigMap(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool) data["newstate"];
            Config["BigMap"] = state ? "true" : "false";

            API.SetRadarBigmapEnabled(state, false);

            callback("ok");
            return callback;
        }

        private CallbackDelegate ToggleBigMapOnDown(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["BigMapOnDown"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }
    }
}
