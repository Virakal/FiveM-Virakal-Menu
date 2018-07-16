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
            Trainer.RegisterNUICallback("animate", OnAnimate);
        }

        private CallbackDelegate OnAnimate(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Ped playerPed = Game.PlayerPed;

            API.RequestAnimDict("random");
            API.RequestAnimDict("random@arrests");
            API.RequestAnimDict("random@arrests@busted");

            DateTime timeout = DateTime.Now.AddSeconds(2);

            while (!API.HasAnimDictLoaded("random@arrests@busted") && DateTime.Now < timeout)
            {
                Debug.WriteLine("Waitin'");
                BaseScript.Delay(1);
            }

            Debug.WriteLine(API.DoesAnimDictExist("random@arrests@busted") ? "exists" : "no existo");

            if (!API.HasAnimDictLoaded("random@arrests@busted"))
            {
                callback("anim not found");
                return callback;
            }

            API.TaskPlayAnim(playerPed.Handle, "random@arrests", "idle_2_hands_up", 8, -1, 10000, 0, 1, true, true, true);

            Debug.WriteLine("Animatin'");

            callback("ok");
            return callback;
        }
    }
}
