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
    /// <summary>
    /// The main entry point for the whole trainer
    /// </summary>
    public class Trainer : BaseScript
    {
        /// <summary>
        /// The key to press to view the menu (F6 - the keyboard shortcut for Franklin)
        /// </summary>
        public Control MenuKey { get; } = Control.SelectCharacterFranklin;

        /// <summary>
        /// Whether the trainer is currently shown on screen
        /// </summary>
        public bool ShowTrainer { get; private set; } = false;

        /// <summary>
        /// The user configuration
        /// </summary>
        public Config Config { get; } = new Config();

        /// <summary>
        /// The user's vehicle garage
        /// </summary>
        public Garage Garage { get; }

        /// <summary>
        /// Public access to the event handler dictionary
        /// </summary>
        public new EventHandlerDictionary EventHandlers { get { return base.EventHandlers; } }

        /// <summary>
        /// Whether to ignore user input (useful for showing input boxes, for example)
        /// </summary>
        public bool BlockInput { get; internal set; } = false;

        /// <summary>
        /// The menu manager
        /// </summary>
        internal MenuManager MenuManager { get; }

        /// <summary>
        /// Create and initialise a new trainer
        /// </summary>
        public Trainer()
        {
            Garage = new Garage(this);
            MenuManager = new MenuManager(this);

            Tick += OnLoad;
            Tick += HandleMenuKeys;
        }

        /// <summary>
        /// Send a message ot the NUI user interface
        /// </summary>
        /// <param name="message">The message contents</param>
        /// <returns></returns>
        public bool SendUIMessage(dynamic message)
        {
            string converted = JsonConvert.SerializeObject(message);
            return API.SendNuiMessage(converted);
        }

        /// <summary>
        /// Add a pop-up notification to the game UI
        /// </summary>
        /// 
        /// This can include control codes, like <code>~r~</code> which changes the text to red.
        /// 
        /// <param name="message">The message on the notification</param>
        public void AddNotification(string message)
        {
            API.SetNotificationTextEntry("STRING");
            API.AddTextComponentString(message);
            API.DrawNotification(false, false);
        }

        /// <summary>
        /// Add a callback for each game tick
        /// </summary>
        /// <param name="tickFunction">The method to call on each tick</param>
        public void AddTick(Func<Task> tickFunction)
        {
            Tick += tickFunction;
        }

        /// <summary>
        /// Spawn a vehicle in the game world
        /// </summary>
        /// <param name="model">The model of the vehicle to spawn</param>
        /// <param name="position">The current player position</param>
        /// <returns>The created vehicle</returns>
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
                    foreach (Ped passenger in playerVeh.Passengers)
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
        /// <param name="colourString">The string representing the colour</param>
        /// <returns>The Color object represented by the string</returns>
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
        /// </summary>
        /// 
        /// Does not strip any prefixes
        ///
        /// <param name="hex">The hex string</param>
        /// <returns>The Color object represented by the string</returns>
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
        /// <param name="color">The Color to convert</param>
        /// <returns>The R,G,B string</returns>
        public string ColorToRgbString(Color color) => $"{color.R},{color.G},{color.B}";

        /// <summary>
        /// Perform initialisation tasks on the first tick and immediately deregisters itself
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Set the current player's stats to their maximums
        /// </summary>
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

        /// <summary>
        /// Check if the trainer should handle the given control for this frame
        /// </summary>
        /// <param name="control">The control to check</param>
        /// <param name="CheckShowTrainer">Whether to check if the trainer is currently shown or not</param>
        /// <returns>Whether this control is currently pressed and should be handled</returns>
        private bool ShouldHandleControl(Control control, bool CheckShowTrainer = true)
        {
            // Make sure input is enabled
            if (BlockInput)
            {
                return false;
            }

            // If the trainer is hidden, don't handle keypresses, unless we explicitly want to
            if (CheckShowTrainer && !ShowTrainer)
            {
                return false;
            }

            return Game.IsControlJustReleased(1, control);
        }

        /// <summary>
        /// Handle keypresses for the trainer and update the UI
        /// </summary>
        /// <returns></returns>
        private async Task HandleMenuKeys()
        {
            // Check if the show key is pressed (F6)
            if (ShouldHandleControl(MenuKey, false))
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

            // Enter / Back
            if (ShouldHandleControl(Control.PhoneSelect))
            {
                SendUIMessage(new { trainerenter = true });
            }
            else if (ShouldHandleControl(Control.PhoneCancel))
            {
                SendUIMessage(new { trainerback = true });
            }

            // Up / Down
            if (ShouldHandleControl(Control.PhoneUp))
            {
                SendUIMessage(new { trainerup = true });
            }
            else if (ShouldHandleControl(Control.PhoneDown))
            {
                SendUIMessage(new { trainerdown = true });
            }

            // Left / Right
            if (ShouldHandleControl(Control.PhoneLeft))
            {
                SendUIMessage(new { trainerleft = true });
            }
            else if (ShouldHandleControl(Control.PhoneRight))
            {
                SendUIMessage(new { trainerright = true });
            }

            await Task.FromResult(0);
        }

        /// <summary>
        /// Register a callback for messages from the NUI user interface
        /// </summary>
        /// <param name="name">The name of the message to listen for</param>
        /// <param name="callback">The method that handles the message</param>
        public void RegisterNUICallback(string name, Func<IDictionary<string, object>, CallbackDelegate, CallbackDelegate> callback)
        {
            API.RegisterNuiCallbackType(name);

            base.EventHandlers[$"__cfx_nui:{name}"] += new Action<ExpandoObject, CallbackDelegate>((body, resultCallback) =>
            {
                CallbackDelegate err = callback.Invoke(body, resultCallback);
            });
        }

        /// <summary>
        /// Register an asynchronous callback for messages from the NUI user interface
        /// </summary>
        /// <param name="name">The name of the message to listen for</param>
        /// <param name="callback">The method that handles the message</param>
        public void RegisterAsyncNUICallback(string name, Func<IDictionary<string, object>, CallbackDelegate, Task<CallbackDelegate>> callback)
        {
            API.RegisterNuiCallbackType(name);

            base.EventHandlers[$"__cfx_nui:{name}"] += new Action<ExpandoObject, CallbackDelegate>(async (body, resultCallback) =>
            {
                CallbackDelegate err = await callback.Invoke(body, resultCallback);
            });
        }

        /// <summary>
        /// Write debug output to the FiveM console
        /// </summary>
        /// <param name="format">The text to write</param>
        /// <param name="args">Arguments to fill message palceholders with</param>
        public static void DebugLine(string format, params object[] args)
        {
            Debug.WriteLine($"[VT] {format}", args);
        }

        /// <summary>
        /// Turn a camelCase sentence into a regular sentence with spaces
        /// </summary>
        /// <param name="text">The text to transform</param>
        /// <returns>The given text with spaces instead of camelcasing</returns>
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

        /// <summary>
        /// Change the current vehicle's radio to the given station
        /// </summary>
        /// <param name="stationIndex">The internal station index</param>
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

        /// <summary>
        /// Close the trainer, hiding the UI and ignoring keypresses
        /// </summary>
        /// <param name="data">The message data</param>
        /// <param name="callback">The callback method</param>
        /// <returns>The callback</returns>
        private CallbackDelegate TrainerClose(IDictionary<string, object> data, CallbackDelegate callback)
        {
            ShowTrainer = false;
            callback("ok");
            return callback;
        }

        /// <summary>
        /// Play a sound on the user's game
        /// </summary>
        /// 
        /// Expects a "name" key in the data with the internal name of the sound file to play.
        /// 
        /// <param name="data">The message data</param>
        /// <param name="callback">The callback method</param>
        /// <returns>The callback</returns>
        private CallbackDelegate PlaySound(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Game.PlaySound((string)data["name"], "HUD_FRONTEND_DEFAULT_SOUNDSET");
            callback("ok");
            return callback;
        }
    }
}
