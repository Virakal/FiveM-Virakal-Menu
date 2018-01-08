using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class TeleportSection : BaseSection
    {
        public TeleportSection(Trainer trainer) : base(trainer)
        {
            Trainer.RegisterNUICallback("coords", DisplayCoords);
        }

        private CallbackDelegate DisplayCoords(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vector3 location = Game.Player.Character.Position;
            string coords = $"~g~{location.X:#.##}, {location.Y:#.##}, {location.Z:#.##}";

            Trainer.AddNotification(coords);

            callback("ok");
            return callback;
        }
    }
}
