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
            Trainer.RegisterNUICallback("policeignore", TogglePoliceIgnore);
            Trainer.RegisterNUICallback("wantedlevel", SetWantedLevel);
        }

        private CallbackDelegate SetWantedLevel(IDictionary<string, object> data, CallbackDelegate callback)
        {
            int level = Convert.ToInt32(data["action"]);
            int playerId = Game.Player.Handle;

            API.SetPlayerWantedLevel(playerId, level, false);
            API.SetPlayerWantedLevelNow(playerId, false);

            Trainer.AddNotification($"~g~Changed wanted level to {level}.");

            callback("ok");
            return callback;
        }

        private CallbackDelegate TogglePoliceIgnore(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["PoliceIgnore"] = state ? "true" : "false";

            API.SetPoliceIgnorePlayer(Game.Player.Handle, state);

            callback("ok");
            return callback;
        }
    }
}
