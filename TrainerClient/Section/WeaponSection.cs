using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class WeaponSection : BaseSection
    {
        public WeaponSection(Trainer trainer) : base(trainer)
        {
            Trainer.RegisterNUICallback("explosiveammo", ToggleExplosiveAmmo);
            Trainer.RegisterNUICallback("fireammo", ToggleFireAmmo);

            Trainer.AddTick(OnTick);
        }

        private CallbackDelegate ToggleExplosiveAmmo(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["ExplosiveAmmo"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        private CallbackDelegate ToggleFireAmmo(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["FireAmmo"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        private async Task OnTick()
        {
            if (Config.ContainsKey("ExplosiveAmmo") && Config["ExplosiveAmmo"] == "true")
            {
                API.SetExplosiveAmmoThisFrame(Game.Player.Handle);
            }

            if (Config.ContainsKey("FireAmmo") && Config["FireAmmo"] == "true")
            {
                API.SetFireAmmoThisFrame(Game.Player.Handle);
            }

            await Trainer.Delay(1);
        }
    }
}
