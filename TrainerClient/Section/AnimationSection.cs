using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class AnimationSection : BaseSection
    {
        public AnimationSection(Trainer trainer) : base(trainer)
        {
            Trainer.RegisterAsyncNUICallback("animate", OnAnimate);
        }

        private async Task<CallbackDelegate> OnAnimate(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Ped playerPed = Game.PlayerPed;

            API.RequestAnimDict("random");
            API.RequestAnimDict("random@arrests");
            API.RequestAnimDict("random@arrests@busted");

            DateTime timeout = DateTime.Now.AddSeconds(2);

            while (!API.HasAnimDictLoaded("random@arrests@busted") && DateTime.Now < timeout)
            {
                Trainer.DebugLine("Waiting for animation to load");
                await BaseScript.Delay(1);
            }

            Trainer.DebugLine(API.DoesAnimDictExist("random@arrests@busted") ? "Animation exists" : "Animation doesn't exist");

            if (!API.HasAnimDictLoaded("random@arrests@busted"))
            {
                callback("anim not found");
                return callback;
            }

            API.TaskPlayAnim(playerPed.Handle, "random@arrests", "idle_2_hands_up", 8, -1, 10000, 0, 1, true, true, true);

            Trainer.DebugLine("Animating");

            callback("ok");
            return callback;
        }
    }
}
