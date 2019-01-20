using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class VehicleSection : BaseSection
    {
        private Vehicle LastPlayerVehicle { get; set; }
        private double RainbowSpeed { get; set; }

        public VehicleSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("AutoDespawnVehicle", "true");
            Config.SetDefault("BoostOnHorn", "true");
            Config.SetDefault("RainbowPaint", "false");
            Config.SetDefault("RainbowChrome", "false");
            Config.SetDefault("RainbowNeon", "false");
            Config.SetDefault("RainbowNeonInverse", "false");
            Config.SetDefault("InvincibleVehicle", "true");
            Config.SetDefault("SpawnInVehicle", "true");
            Config.SetDefault("MaintainVehicleVelocityOnSwitch", "true");
            Config.SetDefault("BoostPower", "75");
            Config.SetDefault("RainbowSpeed", "0.5");

            // General
            Trainer.RegisterNUICallback("veh", OnVeh);
            Trainer.RegisterAsyncNUICallback("vehspawn", OnVehSpawn);

            // Garage
            Trainer.RegisterNUICallback("vehsave", OnVehSave);
            Trainer.RegisterAsyncNUICallback("vehload", OnVehLoad);

            // Colours
            Trainer.RegisterNUICallback("vehprimary", OnVehPrimary);
            Trainer.RegisterNUICallback("vehsecondary", OnVehSecondary);
            Trainer.RegisterNUICallback("vehboth", OnVehBoth);
            Trainer.RegisterNUICallback("vehpearl", OnVehPearl);
            Trainer.RegisterNUICallback("vehcolor", OnVehColor);
            Trainer.RegisterAsyncNUICallback("vehlivery", OnVehLivery);
            Trainer.RegisterNUICallback("vehrooflivery", OnVehRoofLivery);
            Trainer.RegisterNUICallback("rainbowspeed", OnRainbowSpeed);
            Trainer.RegisterAsyncNUICallback("vehplatetext", OnVehPlateText);

            // Boost
            Trainer.RegisterNUICallback("boostpower", OnBoostPower);

            EventHandlers["virakal:newVehicle"] += new Action<int, int?>(OnNewVehicle);

            Trainer.AddTick(RainbowTick);
            Trainer.AddTick(BoostTick);
            Trainer.AddTick(InvincibleCarTick);
            Trainer.AddTick(CheckChangedCar);

            var success = double.TryParse(Config["RainbowSpeed"], out double rainbowSpeed);
            RainbowSpeed = success ? rainbowSpeed : 0.5;
        }

        private async void OnNewVehicle(int vehicleHandle, int? oldVehicleHandle)
        {
            Debug.WriteLine("Caught a vehicle change.");
            Vehicle vehicle = new Vehicle(vehicleHandle);

            if (Config["RainbowChrome"] == "true")
            {
                SetChrome(vehicle);
            }

            if (Config["InvincibleVehicle"] == "true")
            {
                vehicle.Health = vehicle.MaxHealth;
                vehicle.DirtLevel = 0f;
                vehicle.EngineHealth = 1000f;

                API.SetVehicleFixed(vehicleHandle);
            }

            await Task.FromResult(0);
        }

        private async Task CheckChangedCar()
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                LastPlayerVehicle = null;
            }
            else if (vehicle != LastPlayerVehicle)
            {
                BaseScript.TriggerEvent("virakal:newVehicle", vehicle.Handle, LastPlayerVehicle?.Handle);
                LastPlayerVehicle = vehicle;
            }

            await Task.FromResult(0);
        }

        private CallbackDelegate OnVehColor(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            VehicleModCollection mods = vehicle.Mods;
            Color colour = StringToColor((string)data["action"]);

            mods.CustomPrimaryColor = colour;
            mods.CustomSecondaryColor = colour;

            callback("ok");
            return callback;
        }

        private async Task<CallbackDelegate> OnVehLivery(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            int handle = vehicle.Handle;
            string livery = (string)data["action"];
            bool success = int.TryParse(livery, out int iLivery);

            if (!success)
            {
                Trainer.AddNotification($"~r~Invalid livery number: {livery}!");
                callback("ok");
                return callback;
            }

            VehicleModCollection mods = vehicle.Mods;
            mods.Livery = iLivery;
            var maxLivery = mods.LiveryCount;

            if (maxLivery == -1)
            {
                Trainer.AddNotification($"~r~{vehicle.LocalizedName} does not support liveries!");
                callback("ok");
                return callback;
            }

            if (iLivery >= maxLivery)
            {
                Trainer.AddNotification($"~r~{vehicle.LocalizedName} does not have enough liveries to set to {iLivery}!");
                callback("ok");
                return callback;
            }

            callback("ok");
            await mods.RequestAdditionTextFile();

            if (mods.LocalizedLiveryName != "")
            {
                Trainer.AddNotification($"~g~Set {vehicle.LocalizedName} livery to {mods.LocalizedLiveryName} ({iLivery}/{maxLivery - 1})!");
            }
            else
            {
                Trainer.AddNotification($"~g~Set {vehicle.LocalizedName} livery to {iLivery}/{maxLivery - 1}!");
            }

            return callback;
        }

        private CallbackDelegate OnVehRoofLivery(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            int handle = vehicle.Handle;
            string livery = (string)data["action"];
            bool success = int.TryParse(livery, out int iLivery);

            if (!success)
            {
                Trainer.AddNotification($"~r~Invalid livery number: {livery}!");
                callback("ok");
                return callback;
            }

            API.SetVehicleRoofLivery(handle, iLivery);

            Trainer.AddNotification($"~y~Note that very few vehicles support roof livery.");
            Trainer.AddNotification($"~g~Set {vehicle.LocalizedName} roof livery to {iLivery}!");

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehBoth(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.ClearCustomPrimaryColor();
                mods.ClearCustomSecondaryColor();
                mods.PrimaryColor = colour;
                mods.SecondaryColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehPrimary(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.ClearCustomPrimaryColor();
                mods.PrimaryColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehSecondary(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.ClearCustomSecondaryColor();
                mods.SecondaryColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehPearl(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.PearlescentColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVeh(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Ped ped = Game.PlayerPed;
            Vehicle veh = ped.CurrentVehicle;
            bool state = (bool)data["newstate"];

            switch ((string)data["action"])
            {
                case "fix":
                    if (veh == null)
                    {
                        Trainer.AddNotification("~r~Not in a vehicle!");
                        break;
                    }

                    veh.HealthFloat = 1.0f;
                    API.SetVehicleFixed(veh.Handle);
                    Trainer.AddNotification("~g~Vehicle repaired.");
                    break;
                case "clean":
                    if (veh == null)
                    {
                        Trainer.AddNotification("~r~Not in a vehicle!");
                        break;
                    }

                    veh.DirtLevel = 0f;
                    Trainer.AddNotification("~g~Vehicle cleaned.");
                    break;
                case "flip":
                    if (veh == null)
                    {
                        Trainer.AddNotification("~r~Not in a vehicle!");
                        break;
                    }

                    veh.PlaceOnGround();
                    Trainer.AddNotification("~g~Vehicle placed on ground.");
                    break;
                case "neonon":
                    if (veh == null)
                    {
                        Trainer.AddNotification("~r~Not in a vehicle!");
                        break;
                    }

                    for (var i = 0; i < 4; i++)
                    {
                        veh.Mods.SetNeonLightsOn((VehicleNeonLight)i, true);
                    }

                    Trainer.AddNotification("~g~Neons on.");
                    break;
                case "neonoff":
                    if (veh == null)
                    {
                        Trainer.AddNotification("~r~Not in a vehicle!");
                        break;
                    }

                    for (var i = 0; i < 4; i++)
                    {
                        veh.Mods.SetNeonLightsOn((VehicleNeonLight)i, false);
                    }

                    Trainer.AddNotification("~g~Neons off.");
                    break;
                case "boosthorn":
                    Config["BoostOnHorn"] = state ? "true" : "false";

                    if (state)
                    {
                        Trainer.AddNotification("~g~Boost on horn enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Boost on horn disabled.");
                    }

                    break;
                case "rainbowcar":
                    Config["RainbowPaint"] = state ? "true" : "false";

                    if (state)
                    {
                        Trainer.AddNotification("~g~Rainbow paint enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Rainbow paint disabled.");
                    }

                    break;
                case "rainbowchrome":
                    Config["RainbowChrome"] = state ? "true" : "false";

                    SetChrome(veh);

                    if (state)
                    {
                        Trainer.AddNotification("~g~Rainbow chrome enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Rainbow chrome disabled.");
                    }

                    break;
                case "rainbowneon":
                    Config["RainbowNeon"] = state ? "true" : "false";

                    if (state)
                    {
                        Trainer.AddNotification("~g~Rainbow neon enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Rainbow neon disabled.");
                    }

                    break;
                case "rainbowneoninverse":
                    Config["RainbowNeonInverse"] = state ? "true" : "false";

                    if (state)
                    {
                        Trainer.AddNotification("~g~Rainbow neon (inverse colours) enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Rainbow neon (inverse colours) disabled.");
                    }

                    break;
                case "invincible":
                    Config["InvincibleVehicle"] = state ? "true" : "false";

                    if (state)
                    {
                        Trainer.AddNotification("~g~Invincible vehicle enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Invincible vehicle disabled.");
                    }

                    break;
            }

            callback("ok");
            return callback;
        }

        private void SetChrome(Vehicle vehicle)
        {
            var chrome = VehicleColor.Chrome;
            VehicleModCollection mods = vehicle.Mods;
            
            mods.ClearCustomPrimaryColor();
            mods.ClearCustomSecondaryColor();
            mods.PrimaryColor = chrome;
            mods.SecondaryColor = chrome;
        }

        private async Task<CallbackDelegate> OnVehSpawn(IDictionary<string, object> data, CallbackDelegate callback)
        {
            // Callback first to allow async
            callback("ok");

            switch ((string)data["action"])
            {
                case "despawn":
                    Config["AutoBespawnVehicle"] = (bool)data["newstate"] ? "true" : "false";
                    break;
                case "spawninveh":
                    Config["SpawnInVehicle"] = (bool)data["newstate"] ? "true" : "false";
                    break;
                case "input":
                    await SpawnUserInputVehicle();
                    break;
                default:
                    Model model = new Model((string)data["action"]);
                    await SpawnVehicle(model, Game.PlayerPed.Position);
                    break;
            }

            return callback;
        }

        private CallbackDelegate OnVehSave(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var slot = (string)data["action"];

            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                SaveVehicle(slot, vehicle);
                Trainer.AddNotification($"~g~Saved {vehicle.LocalizedName} to slot {slot}!");
            }

            callback("ok");
            return callback;
        }

        private async Task<CallbackDelegate> OnVehLoad(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var slot = (string)data["action"];

            callback("ok");

            if (HasSavedVehicle(slot))
            {
                await LoadVehicle(slot);
            }
            else
            {
                Trainer.AddNotification($"~r~No vehicle saved in slot {slot}!");
            }

            return callback;
        }

        private CallbackDelegate OnBoostPower(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Config["BoostPower"] = (string)data["action"];

            Trainer.AddNotification($"~g~Boost power set to {Config["BoostPower"]}");

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnRainbowSpeed(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Config["RainbowSpeed"] = (string)data["action"];

            var success = double.TryParse(Config["RainbowSpeed"], out double rainbowSpeed);

            if (success)
            {
                RainbowSpeed = rainbowSpeed;
                Trainer.AddNotification($"~g~Rainbow speed set to {RainbowSpeed * 100}%");
            }
            else
            {
                RainbowSpeed = 0.5;
                Trainer.AddNotification($"~r~Failed to set rainbow speed! Set to {RainbowSpeed * 100}%");
            }

            callback("ok");
            return callback;
        }

        private async Task<CallbackDelegate> OnVehPlateText(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            callback("ok");
            Trainer.BlockInput = true;

            string plateText = await Game.GetUserInput(
                WindowTitle.FMMC_KEY_TIP8,
                64
            );

            vehicle.Mods.LicensePlate = plateText;

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            Trainer.AddNotification($"~g~Set number plate to '{vehicle.Mods.LicensePlate}'.");

            return callback;
        }

        private async Task<Vehicle> SpawnUserInputVehicle()
        {
            Trainer.BlockInput = true;

            string modelName = await Game.GetUserInput(
                WindowTitle.FMMC_KEY_TIP8,
                64
            );

            Vehicle vehicle = await SpawnVehicle(new Model(modelName), Game.PlayerPed.Position);

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            return vehicle;
        }

        private async Task<Vehicle> SpawnVehicle(Model model, Vector3 position)
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
                Trainer.AddNotification($"~r~Failed to load vehicle model '{model}'.");
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
                        Debug.Write($"Setting steering angle to {playerVeh.SteeringAngle}");
                        vehicle.Velocity = playerVeh.Velocity;
                        Debug.Write($"Setting velocity to {playerVeh.Velocity}");
                        vehicle.CurrentRPM = playerVeh.CurrentRPM;
                        Debug.Write($"Setting RPM to {playerVeh.CurrentRPM}");
                        vehicle.Heading = playerVeh.Heading;
                        Debug.Write($"Setting heading to {playerVeh.Heading}");
                        vehicle.HighGear = playerVeh.HighGear;
                        Debug.Write($"Setting highgear to {playerVeh.HighGear}");
                        vehicle.Rotation = playerVeh.Rotation;
                        Debug.Write($"Setting rotation to {playerVeh.Rotation}");
                        API.SetVehicleEngineOn(vehicle.Handle, true, true, true);
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

            Trainer.AddNotification($"~g~Spawned vehicle '{vehName}'.");

            return vehicle;
        }

        private async Task RainbowTick()
        {
            await BaseScript.Delay(100);

            if (!(
                Config["RainbowPaint"] == "true"
                || Config["RainbowChrome"] == "true"
                || Config["RainbowNeon"] == "true"
                || Config["RainbowNeonInverse"] == "true"
            ))
            {
                return;
            }

            Ped ped = Game.PlayerPed;
            Vehicle vehicle = ped.CurrentVehicle;

            if (vehicle == null || vehicle.Driver != ped)
            {
                return;
            }

            Color rgb = RainbowRGB(RainbowSpeed);
            VehicleModCollection mods = vehicle.Mods;

            if (Config["RainbowPaint"] == "true" || Config["RainbowChrome"] == "true")
            {
                mods.CustomPrimaryColor = rgb;
                mods.CustomSecondaryColor = rgb;
            }

            if (Config["RainbowNeonInverse"] == "true")
            {
                rgb = InvertColour(rgb);
                mods.NeonLightsColor = rgb;
            }
            else if (Config["RainbowNeon"] == "true")
            {
                mods.NeonLightsColor = rgb;
            }

            await BaseScript.Delay(150);
        }

        private async Task BoostTick()
        {
            if (Config["BoostOnHorn"] == "true")
            {
                Ped playerPed = Game.PlayerPed;
                Vehicle vehicle = playerPed.CurrentVehicle;

                if (vehicle != null)
                {
                    if (Game.IsControlPressed(1, Control.VehicleHorn))
                    {
                        var success = float.TryParse(Config["BoostPower"], out float power);

                        if (!success)
                        {
                            Debug.WriteLine("Failed to parse boost power config variable.");
                            power = 75;
                        }

                        if (Game.IsControlPressed(1, Control.VehicleAccelerate))
                        {
                            API.SetVehicleBoostActive(vehicle.Handle, true);
                            API.SetVehicleForwardSpeed(vehicle.Handle, power);
                        }
                        else if (Game.IsControlPressed(1, Control.VehicleBrake))
                        {
                            API.SetVehicleBoostActive(vehicle.Handle, true);
                            API.SetVehicleForwardSpeed(vehicle.Handle, -1 * power);
                        }
                    }

                    API.SetVehicleBoostActive(vehicle.Handle, false);
                }
            }

            await Task.FromResult(0);
        }

        private async Task InvincibleCarTick()
        {
            bool invincible = Config["InvincibleVehicle"] == "true";
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle != null)
            {
                int handle = vehicle.Handle;

                vehicle.CanBeVisiblyDamaged = !invincible;
                vehicle.CanTiresBurst = !invincible;
                vehicle.IsInvincible = invincible;
                vehicle.IsBulletProof = invincible;
                vehicle.IsCollisionProof = invincible;
                vehicle.IsExplosionProof = invincible;
                vehicle.IsFireProof = invincible;
                vehicle.IsMeleeProof = invincible;
                vehicle.CanWheelsBreak = !invincible;

                API.SetEntityCanBeDamaged(handle, !invincible);
                API.SetVehicleExplodesOnHighExplosionDamage(handle, !invincible);
            }

            await Task.FromResult(0);
        }

        private string GetGarageSlotName(string slot) => $"VehicleSlot{slot}";
        private bool HasSavedVehicle(string slot) => Config.ContainsKey(GetGarageSlotName(slot));

        private void SaveVehicle(string slot, Vehicle vehicle)
        {
            string sep = "<||>";
            string configName = GetGarageSlotName(slot);
            string modString = ToModString(vehicle.Mods);
            Config[configName] = $"{vehicle.Model.Hash}{sep}{modString}";
            Debug.WriteLine($"Saved to {configName}: {Config[configName]}");
        }

        private async Task<Vehicle> LoadVehicle(string slot)
        {
            string sep = "<||>";
            string configName = GetGarageSlotName(slot);
            string loaded = Config[configName];
            string[] split = loaded.Split(new string[] { sep }, StringSplitOptions.None);
            string model = split[0];
            string modString = split[1];

            var vehicle = await SpawnVehicle(new Model(int.Parse(model)), Game.PlayerPed.Position);

            ApplyModString(vehicle, modString);

            Debug.WriteLine($"Loaded from {configName}: Model: {model} Mods: {modString}");

            return vehicle;
        }

        private string ToModString(VehicleModCollection mods)
        {
            var modList = new Dictionary<string, string>();

            if (mods.IsPrimaryColorCustom)
            {
                modList["CustomPrimary"] = $"{mods.CustomPrimaryColor.R},{mods.CustomPrimaryColor.G},{mods.CustomPrimaryColor.B}";
            }
            else
            {
                modList["PrimaryColour"] = Convert.ToString((int)mods.PrimaryColor);
            }

            if (mods.IsSecondaryColorCustom)
            {
                modList["CustomSecondary"] = $"{mods.CustomSecondaryColor.R},{mods.CustomSecondaryColor.G},{mods.CustomSecondaryColor.B}";
            }
            else
            {
                modList["SecondaryColour"] = Convert.ToString((int)mods.SecondaryColor);
            }

            modList["PearlescentColour"] = Convert.ToString((int)mods.PearlescentColor);
            modList["Livery"] = Convert.ToString(mods.Livery);

            return JsonConvert.SerializeObject(modList);
        }

        private void ApplyModString(Vehicle vehicle, string modString)
        {
            var modList = JsonConvert.DeserializeObject<Dictionary<string, string>>(modString);
            VehicleModCollection mods = vehicle.Mods;

            if (modList.ContainsKey("CustomPrimary"))
            {
                var colour = StringToColor(modList["CustomPrimary"]);
                mods.CustomPrimaryColor = colour;
            }

            if (modList.ContainsKey("PrimaryColour"))
            {
                var primary = int.Parse(modList["PrimaryColour"]);
                mods.PrimaryColor = (VehicleColor)primary;
            }

            if (modList.ContainsKey("CustomSecondary"))
            {
                var colour = StringToColor(modList["CustomSecondary"]);
                mods.CustomSecondaryColor = colour;
            }

            if (modList.ContainsKey("SecondaryColour"))
            {
                var secondary = int.Parse(modList["SecondaryColour"]);
                mods.SecondaryColor = (VehicleColor)secondary;
            }

            if (modList.ContainsKey("PearlescentColour"))
            {
                var pearlescent = int.Parse(modList["PearlescentColour"]);
                mods.PearlescentColor = (VehicleColor)pearlescent;
            }

            if (modList.ContainsKey("Livery"))
            {
                var livery = int.Parse(modList["Livery"]);
                mods.Livery = livery;
            }
        }

        private Color StringToColor(string colourString)
        {
            string[] rgb = colourString.Split(',');
            int r = int.Parse(rgb[0]);
            int g = int.Parse(rgb[1]);
            int b = int.Parse(rgb[2]);

            return Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Provides a progressing rainbow colour based on the current game time
        /// </summary>
        /// <param name="frequency">The speed at which the colours cycle</param>
        /// <returns>An RGB object for the colour</returns>
        private Color RainbowRGB(double frequency)
        {
            int time = Game.GameTime;

            return Color.FromArgb(
                (int)(Math.Sin((time / 5000d) * frequency + 0) * 127 + 128),
                (int)(Math.Sin((time / 5000d) * frequency + 2) * 127 + 128),
                (int)(Math.Sin((time / 5000d) * frequency + 4) * 127 + 128)
            );
        }

        /// <summary>
        /// Provides the inverse colour for a given Color object. Pure red becomes cyan, for example.
        /// </summary>
        /// <param name="colour">the colour to invert</param>
        /// <returns>the inverted colour</returns>
        private Color InvertColour(Color colour)
        {
            return Color.FromArgb(255 - colour.R, 255 - colour.G, 255 - colour.B);
        }
    }
}
