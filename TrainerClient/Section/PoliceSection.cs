using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class PoliceSection : BaseSection
    {
        public PoliceSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("PoliceDisable", "false");
            Config.SetDefault("PoliceIgnore", "false");

            Trainer.RegisterNUICallback("policeignore", TogglePoliceIgnore);
            Trainer.RegisterNUICallback("wantedlevel", SetWantedLevel);
            Trainer.RegisterNUICallback("policedisable", TogglePoliceDisable);

            Trainer.AddTick(DisablePolice);
        }

        private CallbackDelegate TogglePoliceDisable(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["PoliceDisable"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        private CallbackDelegate SetWantedLevel(IDictionary<string, object> data, CallbackDelegate callback)
        {
            int level = int.Parse((string)data["action"]);

            Game.Player.WantedLevel = level;

            Trainer.AddNotification($"~g~Changed wanted level to {level}.");

            callback("ok");
            return callback;
        }

        private CallbackDelegate TogglePoliceIgnore(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["PoliceIgnore"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        public async Task DisablePolice()
        {
            if (Config["PoliceDisable"] == "true")
            {
                Game.Player.WantedLevel = 0;
            }

            Game.Player.IgnoredByPolice = Config["PoliceIgnore"] == "true";

            await Task.FromResult(10);
        }
    }
}
