using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Text;
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
        public Garage Garage { get; }
        public EventHandlerDictionary _EventHandlers { get { return EventHandlers; } }
        public bool BlockInput { get; internal set; } = false;
        private MenuManager MenuManager { get; }

        public Trainer()
        {
            // Forcibly load the JSON DLL early
            JsonConvert.SerializeObject(new object());

            Garage = new Garage(this);
            MenuManager = new MenuManager(this);

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

        public async Task<Vehicle> SpawnVehicle(Model model, Vector3 position)
        {
            var playerPed = Game.PlayerPed;
            var playerVeh = playerPed.CurrentVehicle;

            if (Config["SpawnInVehicle"] == "false")
            {
                position = new Vector3(position.X + 2.5f, position.Y + 2.5f, position.Z + 1.0f);
            }

            Vehicle vehicle = await World.CreateVehicle(model, position, playerPed.Heading);

            if (vehicle == null)
            {
                // Newer DLC has a tendency to time out first time, so try again
                vehicle = await World.CreateVehicle(model, position, playerPed.Heading);
            }

            if (vehicle == null)
            {
                AddNotification($"~r~Failed to load vehicle model '{model}'.");
                return null;
            }

            if (Config["SpawnInVehicle"] == "true")
            {
                // Move the player to the new vehicle
                playerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);

                if (playerVeh != null)
                {
                    // Maintain old velocity if applicable
                    if (Config["MaintainVehicleVelocityOnSwitch"] == "true")
                    {
                        vehicle.IsEngineRunning = true;
                        vehicle.SteeringAngle = playerVeh.SteeringAngle;
                        DebugLine($"Setting steering angle to {playerVeh.SteeringAngle}");
                        vehicle.Velocity = playerVeh.Velocity;
                        DebugLine($"Setting velocity to {playerVeh.Velocity}");
                        vehicle.CurrentRPM = playerVeh.CurrentRPM;
                        DebugLine($"Setting RPM to {playerVeh.CurrentRPM}");
                        vehicle.Heading = playerVeh.Heading;
                        DebugLine($"Setting heading to {playerVeh.Heading}");
                        vehicle.HighGear = playerVeh.HighGear;
                        DebugLine($"Setting highgear to {playerVeh.HighGear}");
                        vehicle.Rotation = playerVeh.Rotation;
                        DebugLine($"Setting rotation to {playerVeh.Rotation}");
                        API.SetVehicleEngineOn(vehicle.Handle, true, true, true);
                        DebugLine("Enabling vehicle engine");
                    }

                    // Try to move other passengers over
                    foreach (var passenger in playerVeh.Passengers)
                    {
                        passenger.SetIntoVehicle(vehicle, VehicleSeat.Any);
                    }

                    // Remove the old vehicle
                    playerVeh.Delete();
                }
            }

            string vehName = vehicle.LocalizedName;

            AddNotification($"~g~Spawned vehicle '{vehName}'.");

            return vehicle;
        }

        /// <summary>
        /// Convert a comma-separated string of numbers (e.g. 255,128,0) to a Color object
        /// </summary>
        /// <param name="colourString">the string representing the colour</param>
        /// <returns>the colour object</returns>
        public static Color CommaSeparatedStringToColor(string colourString)
        {
            string[] rgb = colourString.Split(',');
            int r = int.Parse(rgb[0]);
            int g = int.Parse(rgb[1]);
            int b = int.Parse(rgb[2]);

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Convert a six-letter hexadecimal string to a Color
        ///
        /// Does not strip any prefixes
        /// </summary>
        /// <param name="hex">the hex string</param>
        /// <returns>the colour object</returns>
        public static Color HexToColor(string hex)
        {
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Convert a color into an R,G,B string for config storage
        /// </summary>
        /// <param name="color">the color to convert</param>
        /// <returns>the R,G,B string</returns>
        public string ColorToRgbString(Color color) => $"{color.R},{color.G},{color.B}";

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
            new Section.AnimalBombSection(this);

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

        public static void DebugLine(string format, params object[] args)
        {
            Debug.WriteLine($"[VT] {format}", args);
        }

        public static void DebugLine(string format)
        {
            DebugLine(format, new object[] { });
        }

        public static string AddSpacesToSentence(string text)
        {
            var preserveAcronyms = false;

            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            StringBuilder newText = new StringBuilder(text.Length * 2);

            newText.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {

                    if (
                        (text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    {
                        newText.Append(' ');
                    }
                }

                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public void ChangeCurrentRadioStation(int stationIndex)
        {
            var vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                return;
            }

            if (Enum.IsDefined(typeof(RadioStation), stationIndex))
            {
                var station = (RadioStation)stationIndex;
                vehicle.RadioStation = station;
            }
            else
            {
                // This is one that isn't in the game DLL yet
                int handle = vehicle.Handle;
                API.SetVehicleRadioEnabled(handle, true);

                if (stationIndex == 100)
                {
                    API.SetVehRadioStation(handle, "RADIO_21_DLC_XM17");
                }
                else if (stationIndex == 101)
                {
                    API.SetVehRadioStation(handle, "RADIO_22_DLC_BATTLE_MIX1_RADIO");
                }
            }
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
