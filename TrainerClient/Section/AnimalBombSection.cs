using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class AnimalBombSection : BaseSection
    {
        private int bombCount = 10;

        public AnimalBombSection(Trainer trainer) : base(trainer)
        {
            Trainer.RegisterAsyncNUICallback("anibomb", OnAniBomb);
        }

        private async Task<CallbackDelegate> OnAniBomb(IDictionary<string, object> data, CallbackDelegate callback)
        {
            callback("ok");

            var modelName = (string)data["action"];
            var model = new Model(modelName);
            var rand = new Random();
            int variance = 10;
            int halfVariance = variance / 2;
            int height = 20;
            int heightVariance = 5;

            Trainer.DebugLine($"Loading model {modelName}");

            model.Request();

            while (!model.IsLoaded)
            {
                Trainer.DebugLine("Waiting...");
                await BaseScript.Delay(1);
            }

            Trainer.DebugLine("Loaded.");

            for (var i = 0; i < bombCount; ++i)
            {
                var position = Game.PlayerPed.Position;
                var heading = 360 * (float)rand.NextDouble();

                position.X += halfVariance - rand.Next(variance);
                position.Y += halfVariance - rand.Next(variance);
                position.Z += height + (heightVariance * (float)rand.NextDouble());

                Trainer.DebugLine($"Dropping animal #{1 + i} at {position}, heading {heading}");

                // Stagger spawns
                await BaseScript.Delay(rand.Next(15));

                var ped = await World.CreatePed(model, position, heading);
            }

            return callback;
        }
    }
}
