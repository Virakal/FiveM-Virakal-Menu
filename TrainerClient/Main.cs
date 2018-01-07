using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;


namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Main : BaseScript
    {
        public Control MenuKey { get; } = Control.SelectCharacterMichael; // F5
        public bool ShowTrainer { get; private set; } = false;

        public Main()
        {
            Tick += OnLoad;
            Tick += HandleMenuKeys;
        }

        private bool SendUIMessage(dynamic message)
        {
            string converted = JsonConvert.SerializeObject(message);
            Debug.Write($"Sending message '{converted}'.");
            return API.SendNuiMessage(converted);
        }

        private Task OnLoad()
        {
            // Unsubscribe this event immediately so the event only runs once
            Tick -= OnLoad;

            RegisterNUICallback("trainerclose", TrainerClose);

            return Task.FromResult(0);
        }

        private Task HandleMenuKeys()
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
                return Task.FromResult(0);
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

            return Task.FromResult(0);
        }

        private void RegisterNUICallback(string name, Func<IDictionary<string, object>, CallbackDelegate, CallbackDelegate> callback)
        {
            API.RegisterNuiCallbackType(name);

            EventHandlers[$"__cfx_nui:{name}"] += new Action<ExpandoObject, CallbackDelegate>((body, resultCallback) =>
            {
                CallbackDelegate err = callback.Invoke(body, resultCallback);
            });
        }

        private CallbackDelegate TrainerClose(IDictionary<string, object> data, CallbackDelegate callback)
        {
            ShowTrainer = false;
            callback("ok");
            return callback;
        }
    }
}
