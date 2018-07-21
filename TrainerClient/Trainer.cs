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
        public EventHandlerDictionary _EventHandlers { get { return EventHandlers; } }
        public bool BlockInput { get; internal set; } = false;

        public Trainer()
        {
            // Forcibly load the JSON DLL early
            JsonConvert.SerializeObject(new object());

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

            new ConfigCommsManager(this);

            // Add handlers for the menu sections
            new Section.UISection(this);
            new Section.PoliceSection(this);
            new Section.TeleportSection(this);
            new Section.WeaponSection(this);
            new Section.SettingsSection(this);
            new Section.PlayerSection(this);
            new Section.VehicleSection(this);
            new Section.AnimationSection(this);

            RegisterNUICallback("trainerclose", TrainerClose);
            RegisterNUICallback("playsound", PlaySound);

            MaxPlayerStats();

            AddNotification("~y~Trainer loaded!");

            return Task.FromResult(0);
        }

        private void MaxPlayerStats()
        {
            API.StatSetInt((uint)API.GetHashKey("MP0_STAMINA"), 100, true);
            API.StatSetInt((uint)API.GetHashKey("MP0_STRENGTH"), 100, true);
            API.StatSetInt((uint)API.GetHashKey("MP0_LUNG_CAPACITY"), 100, true);
            API.StatSetInt((uint)API.GetHashKey("MP0_WHEELIE_ABILITY"), 100, true);
            API.StatSetInt((uint)API.GetHashKey("MP0_FLYING_ABILITY"), 100, true);
            API.StatSetInt((uint)API.GetHashKey("MP0_SHOOTING_ABILITY"), 100, true);
            API.StatSetInt((uint)API.GetHashKey("MP0_STEALTH_ABILITY"), 100, true);
        }

        private Task HandleMenuKeys()
        {
            // Make sure input is enabled
            if (BlockInput)
            {
                return Task.FromResult(0);
            }

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

        public void RegisterAsyncNUICallback(string name, Func<IDictionary<string, object>, CallbackDelegate, Task<CallbackDelegate>> callback)
        {
            API.RegisterNuiCallbackType(name);

            EventHandlers[$"__cfx_nui:{name}"] += new Action<ExpandoObject, CallbackDelegate>(async (body, resultCallback) =>
            {
                CallbackDelegate err = await callback.Invoke(body, resultCallback);
            });
        }

        private CallbackDelegate TrainerClose(IDictionary<string, object> data, CallbackDelegate callback)
        {
            ShowTrainer = false;
            callback("ok");
            return callback;
        }

        private CallbackDelegate PlaySound(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Game.PlaySound((string)data["name"], "HUD_FRONTEND_DEFAULT_SOUNDSET");
            callback("ok");
            return callback;
        }
    }
}
