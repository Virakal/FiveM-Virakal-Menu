using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;


namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Trainer : BaseScript
    {
        public Control MenuKey { get; } = Control.SelectCharacterFranklin; // F6
        public bool ShowTrainer { get; private set; } = false;
        public Config Config { get; } = new Config();

        public Trainer()
        {
            Tick += OnLoad;
            Tick += HandleMenuKeys;
        }

        public bool SendUIMessage(dynamic message)
        {
            string converted = JsonConvert.SerializeObject(message);
            return API.SendNuiMessage(converted);
        }

        public void AddNotification(string message)
        {
            API.SetNotificationTextEntry("STRING");
            API.AddTextComponentString(message);
            API.DrawNotification(false, false);
        }

        public void AddTick(Func<Task> tickFunction)
        {
            Tick += tickFunction;
        }

        private Task OnLoad()
        {
            // Unsubscribe this event immediately so the event only runs once
            Tick -= OnLoad;

            // Add handlers for the menu sections
            new Section.UISection(this);
            new Section.PoliceSection(this);

            RegisterNUICallback("trainerclose", TrainerClose);

            return Task.FromResult(0);
        }

        private Task HandleMenuKeys()
        {
            // Check if the show key is pressed (F6)
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

        public void RegisterNUICallback(string name, Func<IDictionary<string, object>, CallbackDelegate, CallbackDelegate> callback)
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
