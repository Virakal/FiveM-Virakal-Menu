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
            Trainer.RegisterAsyncNUICallback("cowbomb", OnCowBomb);
        }

        private async Task<CallbackDelegate> OnCowBomb(IDictionary<string, object> data, CallbackDelegate callback)
        {
            callback("ok");

            var rand = new Random();
            var cowModel = new Model(@"A_C_Cow");

            Debug.WriteLine("Loading cow model");

            cowModel.Request();

            while (!cowModel.IsLoaded)
            {
                Debug.WriteLine("Waiting...");
                await BaseScript.Delay(1);
            }

            Debug.WriteLine("Loaded.");

            for (var i = 0; i < 10; ++i)
            {
                var position = Game.PlayerPed.Position;
                var heading = (float)rand.NextDouble();

                position.X += (5 - rand.Next(10)) / 10;
                position.Y += (5 - rand.Next(10)) / 10;
                position.Z += 20 + (5 * (float)rand.NextDouble());

                Debug.WriteLine($"Dropping cow #{1 + i} at {position}");

                // Stagger spawns
                await BaseScript.Delay(rand.Next(15));

                var cow = await World.CreatePed(cowModel, position, heading);
            }

            return callback;
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
                Debug.WriteLine("Waitin'");
                await BaseScript.Delay(1);
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
