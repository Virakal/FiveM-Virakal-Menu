using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using Newtonsoft.Json;


namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Main : BaseScript
    {
        public Control MenuKey { get; } = Control.SelectCharacterMichael; // F5
        public bool ShowTrainer { get; private set; } = false;

        public Main()
        {
            Tick += HandleMenuKeys;
        }

        private bool SendUIMessage(dynamic message)
        {
            string converted = JsonConvert.SerializeObject(message);
            Debug.Write($"Sending message '{converted}'.");
            return SendNuiMessage(converted);
        }

        private async Task HandleMenuKeys()
        {
            // Check if the show key is pressed (F5, will change to F6)
            if (Game.IsControlJustReleased(1, MenuKey))
            {
                ShowTrainer = !ShowTrainer;

                if (ShowTrainer)
                {
                    SendUIMessage(new { showtrainer = true });
                }
                else
                {
                    SendUIMessage(new { hidetrainer = true });
                }
            }

            // If the trainer is hidden, no point parsing anything else
            if (!ShowTrainer)
            {
                return;
            }

            // Enter / Back
            if (Game.IsControlJustReleased(1, Control.PhoneSelect))
            {
                SendUIMessage(new { trainerenter = true });
            }
            else if (Game.IsControlJustReleased(1, Control.PhoneCancel))
            {
                SendUIMessage(new { trainerback = true });
            }

            // Up / Down
            if (Game.IsControlJustReleased(1, Control.PhoneUp))
            {
                SendUIMessage(new { trainerup = true });
            }
            else if (Game.IsControlJustReleased(1, Control.PhoneDown))
            {
                SendUIMessage(new { trainerdown = true });
            }

            // Left / Right
            if (Game.IsControlJustReleased(1, Control.PhoneLeft))
            {
                SendUIMessage(new { trainerleft = true });
            }
            else if (Game.IsControlJustReleased(1, Control.PhoneRight))
            {
                SendUIMessage(new { trainerright = true });
            }
        }
    }
}
