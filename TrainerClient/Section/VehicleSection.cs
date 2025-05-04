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
        private Garage Garage { get; }
        private Vehicle LastPlayerVehicle { get; set; }
        private double RainbowSpeed { get; set; }

        public VehicleSection(Trainer trainer) : base(trainer)
        {
            Garage = Trainer.Garage;

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
            Trainer.RegisterAsyncNUICallback("vehsearch", OnVehSearch);
            Trainer.RegisterNUICallback("vehseat", OnVehSeat);

            // Garage
            Trainer.RegisterNUICallback("vehsave", OnVehSave);
            Trainer.RegisterAsyncNUICallback("vehload", OnVehLoad);

            // Colours
            Trainer.RegisterNUICallback("vehprimary", OnVehPrimary);
            Trainer.RegisterNUICallback("vehsecondary", OnVehSecondary);
            Trainer.RegisterNUICallback("vehboth", OnVehBoth);
            Trainer.RegisterNUICallback("vehpearl", OnVehPearl);
            Trainer.RegisterNUICallback("vehcustomboth", OnVehCustomBoth);
            Trainer.RegisterNUICallback("vehcustomprimary", OnVehCustomPrimary);
            Trainer.RegisterNUICallback("vehcustomsecondary", OnVehCustomSecondary);
            Trainer.RegisterAsyncNUICallback("vehlivery", OnVehLivery);
            Trainer.RegisterNUICallback("vehrooflivery", OnVehRoofLivery);
            Trainer.RegisterNUICallback("vehrim", OnVehRim);
            Trainer.RegisterNUICallback("vehdashcolour", OnVehDashColour);
            Trainer.RegisterNUICallback("vehdashtrimcolour", OnVehTrimColour);
            Trainer.RegisterNUICallback("vehtint", OnVehTint);
            Trainer.RegisterNUICallback("vehcolourcombo", OnVehColourCombo);
            Trainer.RegisterNUICallback("rainbowspeed", OnRainbowSpeed);
            Trainer.RegisterAsyncNUICallback("vehplatetext", OnVehPlateText);
            Trainer.RegisterNUICallback("vehplatestyle", OnVehPlateStyle);
            Trainer.RegisterAsyncNUICallback("vehneon", OnVehNeon);
            Trainer.RegisterAsyncNUICallback("vehtyresmokecolour", OnVehTyreSmokeColour);
            Trainer.RegisterNUICallback("vehmod", OnVehMod);
            Trainer.RegisterNUICallback("vehmodother", OnVehModOther);

            // Boost
            Trainer.RegisterNUICallback("boostpower", OnBoostPower);

            EventHandlers["virakal:newVehicle"] += new Action<int, int>(OnNewVehicle);

            Trainer.AddTick(RainbowTick);
            Trainer.AddTick(BoostTick);
            Trainer.AddTick(InvincibleCarTick);
            Trainer.AddTick(CheckChangedCar);

            var success = double.TryParse(Config["RainbowSpeed"], out double rainbowSpeed);
            RainbowSpeed = success ? rainbowSpeed : 0.5;
        }

        private async Task<CallbackDelegate> OnVehSearch(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Trainer.BlockInput = true;

            string searchTerm = await Game.GetUserInput(
                WindowTitle.FMMC_KEY_TIP8,
                64
            );
            
            if (searchTerm != null)
            {
                Config["VehicleSpawnSearchTerm"] = searchTerm;
            }

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            return callback;
        }

        private CallbackDelegate OnVehSeat(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Ped playerPed = Game.PlayerPed;
            Vehicle vehicle = Trainer.GetPedVehicle(playerPed);
            var action = (string)data["action"];
            var actionInt = int.Parse(action);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            playerPed.SetIntoVehicle(vehicle, (VehicleSeat)actionInt);

            callback("ok");
            return callback;
        }

        private async void OnNewVehicle(int vehicleHandle, int oldVehicleHandle)
        {
            Trainer.DebugLine("Caught a vehicle change.");
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
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                if (LastPlayerVehicle != null)
                {
                    BaseScript.TriggerEvent("virakal:exitedVehicle", LastPlayerVehicle.Handle);
                }

                LastPlayerVehicle = null;
            }
            else if (vehicle != LastPlayerVehicle)
            {
                BaseScript.TriggerEvent("virakal:newVehicle", vehicle.Handle, LastPlayerVehicle == null ? -1 : LastPlayerVehicle.Handle);
                LastPlayerVehicle = vehicle;
            }

            await BaseScript.Delay(50);
        }

        private CallbackDelegate OnVehCustomBoth(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            var action = (string)data["action"];
            callback("ok");
            ChangeCustomColours(vehicle, action, true, true);

            return callback;
        }

        private CallbackDelegate OnVehCustomPrimary(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            var action = (string)data["action"];
            callback("ok");
            ChangeCustomColours(vehicle, action, true, false);

            return callback;
        }

        private CallbackDelegate OnVehCustomSecondary(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            var action = (string)data["action"];
            callback("ok");
            ChangeCustomColours(vehicle, action, false, true);

            return callback;
        }

        private async void ChangeCustomColours(Vehicle vehicle, string action, bool changePrimary = true, bool changeSecondary = true)
        {
            VehicleModCollection mods = vehicle.Mods;
            Color colour;

            if (action == "input")
            {
                colour = await GetInputColour();
            }
            else
            {
                colour = Trainer.CommaSeparatedStringToColor(action);
                await Task.FromResult(0);
            }

            if (changePrimary)
            {
                mods.CustomPrimaryColor = colour;
            }

            if (changeSecondary)
            {
                mods.CustomSecondaryColor = colour;
            }
        }

        private async Task<CallbackDelegate> OnVehLivery(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

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
            var maxLivery = mods.LiveryCount;

            callback("ok");

            if (maxLivery == -1)
            {
                Trainer.DebugLine($"No basic liveries supported, {mods[VehicleModType.Livery].ModCount} mod liveries instead.");
                mods.InstallModKit();

                if (mods[VehicleModType.Livery].ModCount > 0)
                {
                    mods[VehicleModType.Livery].Index = iLivery;
                }
                else
                {
                    Trainer.AddNotification($"~r~{vehicle.LocalizedName} does not support liveries!");
                }
            }
            else if (iLivery >= maxLivery)
            {
                Trainer.AddNotification($"~r~{vehicle.LocalizedName} does not have enough liveries to set to {iLivery}!");
            }
            else
            {
                mods.Livery = iLivery;

                await mods.RequestAdditionTextFile();

                if (mods.LocalizedLiveryName != "")
                {
                    Trainer.AddNotification($"~g~Set {vehicle.LocalizedName} livery to {mods.LocalizedLiveryName} ({iLivery}/{maxLivery - 1})!");
                }
                else
                {
                    Trainer.AddNotification($"~g~Set {vehicle.LocalizedName} livery to {iLivery}/{maxLivery - 1}!");
                }

            }

            return callback;
        }

        private CallbackDelegate OnVehRoofLivery(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

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

        private CallbackDelegate OnVehColourCombo(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
                callback("ok");
                return callback;
            }

            string combo = (string)data["action"];
            bool success = int.TryParse(combo, out int iCombo);

            if (!success)
            {
                Trainer.AddNotification($"~r~Invalid colour combination: {combo}!");
                callback("ok");
                return callback;
            }
            
            var mods = vehicle.Mods;
            mods.ColorCombination = iCombo;

            Trainer.AddNotification($"~g~Set {vehicle.LocalizedName} colour combination to combination {combo}!");

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehBoth(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
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
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
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
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
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
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
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

        private CallbackDelegate OnVehRim(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.RimColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehDashColour(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.InstallModKit();
                mods.DashboardColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehTrimColour(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
            int iColour = Convert.ToInt32(data["action"]);
            var colour = (VehicleColor)iColour;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;
                mods.InstallModKit();
                mods.TrimColor = colour;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehTint(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);
            int iTint = Convert.ToInt32(data["action"]);
            var tint = (VehicleWindowTint)iTint;

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                Trainer.DebugLine($"Setting tint to {tint} / {iTint}");
                VehicleModCollection mods = vehicle.Mods;
                mods.InstallModKit();
                mods.WindowTint = tint;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVeh(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Ped ped = Game.PlayerPed;
            Vehicle veh = Trainer.GetPedVehicle(ped);
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
                    await Trainer.SpawnVehicle(model, Game.PlayerPed.Position);
                    break;
            }

            return callback;
        }

        private CallbackDelegate OnVehSave(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var slot = (string)data["action"];

            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                Garage.SaveVehicle(slot, vehicle);
                Trainer.AddNotification($"~g~Saved {vehicle.LocalizedName} to slot {slot}!");
            }

            callback("ok");
            return callback;
        }

        private async Task<CallbackDelegate> OnVehLoad(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var slot = (string)data["action"];

            callback("ok");

            if (Garage.HasSavedVehicle(slot))
            {
                await Garage.LoadVehicle(slot);
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
            var vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

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
                7 // Numberplates max out at 8 chars but this seems to be off by one
            );

            vehicle.Mods.LicensePlate = plateText;

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            Trainer.AddNotification($"~g~Set number plate to '{vehicle.Mods.LicensePlate}'.");

            return callback;
        }

        private CallbackDelegate OnVehPlateStyle(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                var style = int.Parse((string)data["action"]);
                vehicle.Mods.LicensePlateStyle = (LicensePlateStyle)style;
            }

            callback("ok");
            return callback;
        }

        private async Task<CallbackDelegate> OnVehNeon(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            callback("ok");

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                var action = (string)data["action"];
                var mods = vehicle.Mods;

                if (action == "allon")
                {
                    for (var i = 0; i < 4; i++)
                    {
                        mods.SetNeonLightsOn((VehicleNeonLight)i, true);
                    }

                    Trainer.AddNotification("~g~Neons on.");
                }
                else if (action == "alloff")
                {
                    for (var i = 0; i < 4; i++)
                    {
                        mods.SetNeonLightsOn((VehicleNeonLight)i, false);
                    }

                    Trainer.AddNotification("~g~Neons off.");
                }
                else if (action == "input")
                {
                    mods.NeonLightsColor = await GetInputColour();
                    Trainer.AddNotification("~g~Neon colour changed.");
                }
                else if (action.StartsWith("on") && action.Length == 3)
                {
                    var i = int.Parse(action.Substring(2, 1));
                    var light = (VehicleNeonLight)i;
                    mods.SetNeonLightsOn(light, true);
                    Trainer.AddNotification($"~g~Enabled {light} neon.");
                }
                else if (action.StartsWith("off") && action.Length == 4)
                {
                    var i = int.Parse(action.Substring(3, 1));
                    var light = (VehicleNeonLight)i;
                    mods.SetNeonLightsOn(light, false);
                    Trainer.AddNotification($"~g~Disabled {light} neon.");
                }
                else if (action.IndexOf(',') != -1)
                {
                    var colour = Trainer.CommaSeparatedStringToColor(action);
                    mods.NeonLightsColor = colour;
                }
                else
                {
                    Trainer.AddNotification("~r~Invalid neon instruction!");
                }
            }

            return callback;
        }

        private async Task<CallbackDelegate> OnVehTyreSmokeColour(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            callback("ok");

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                var action = (string)data["action"];
                var mods = vehicle.Mods;

                if (action == "input")
                {
                    mods.TireSmokeColor = await GetInputColour();
                    Trainer.AddNotification("~g~Tyre smoke colour changed.");
                }
                else if (action.IndexOf(',') != -1)
                {
                    var colour = Trainer.CommaSeparatedStringToColor(action);
                    mods.TireSmokeColor = colour;
                    Trainer.AddNotification("~g~Tyre smoke colour changed.");
                }
                else
                {
                    Trainer.AddNotification("~r~Invalid tyre smoke colour instruction!");
                }
            }

            return callback;
        }

        private CallbackDelegate OnVehMod(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            callback("ok");

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                var action = (string)data["action"];
                var mods = vehicle.Mods;

                if (action == "quickupgrade")
                {
                    mods.InstallModKit();
                    mods[VehicleToggleModType.Turbo].IsInstalled = true;
                    mods[VehicleToggleModType.XenonHeadlights].IsInstalled = true;
                    mods[VehicleToggleModType.TireSmoke].IsInstalled = true;
                    mods[VehicleModType.Suspension].Index = 3;
                    mods[VehicleModType.Transmission].Index = 2;
                    mods[VehicleModType.Armor].Index = 4;
                    mods[VehicleModType.Brakes].Index = 2;
                    mods[VehicleModType.Engine].Index = 2;
                    mods.TireSmokeColor = Color.FromArgb(0, 0, 0);

                    Trainer.AddNotification("~g~Quick upgrade complete!");
                }
                else if (action == "turboon")
                {
                    mods[VehicleToggleModType.Turbo].IsInstalled = true;
                    Trainer.AddNotification("~g~Enabled turbo.");
                }
                else if (action == "turbooff")
                {
                    mods[VehicleToggleModType.Turbo].IsInstalled = false;
                    Trainer.AddNotification("~g~Disabled turbo.");
                }
                else if (action == "xenonon")
                {
                    mods[VehicleToggleModType.XenonHeadlights].IsInstalled = true;
                    Trainer.AddNotification("~g~Enabled Xenon headlights.");
                }
                else if (action == "xenonoff")
                {
                    mods[VehicleToggleModType.XenonHeadlights].IsInstalled = false;
                    Trainer.AddNotification("~g~Disabled Xenon headlights.");
                }
                else if (action == "tyresmokeon")
                {
                    mods[VehicleToggleModType.TireSmoke].IsInstalled = true;
                    Trainer.AddNotification("~g~Enabled tyre smoke.");
                }
                else if (action == "tyresmokeoff")
                {
                    mods[VehicleToggleModType.TireSmoke].IsInstalled = false;
                    Trainer.AddNotification("~g~Disabled tyre smoke.");
                }
            }

            return callback;
        }

        private CallbackDelegate OnVehModOther(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

            if (vehicle != null)
            {
                VehicleModCollection mods = vehicle.Mods;
                var action = (string)data["action"];
                var split = action.Split('=');
                var iModType = int.Parse(split[0]);
                var iModIndex = int.Parse(split[1]);

                mods.InstallModKit();

                mods[(VehicleModType)iModType].Index = iModIndex;
                BaseScript.TriggerEvent("virakal:vehicleModsChanged", iModType, iModIndex);
            }

            callback("ok");
            return callback;
        }

        private async Task<Vehicle> SpawnUserInputVehicle()
        {
            Trainer.BlockInput = true;

            string modelName = await Game.GetUserInput(
                WindowTitle.FMMC_KEY_TIP8,
                64
            );

            Vehicle vehicle = await Trainer.SpawnVehicle(new Model(modelName), Game.PlayerPed.Position);

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            return vehicle;
        }

        private async Task<Color> GetInputColour()
        {
            Trainer.BlockInput = true;

            string colourText = await Game.GetUserInput(
                WindowTitle.FMMC_KEY_TIP8,
                64
            );

            Color colour;

            try
            {
                if (colourText.Contains(','))
                {
                    // Assume it's a comma-separated colour
                    // Remove any whitespace
                    colourText = colourText.Replace(" ", "");
                    colour = Trainer.CommaSeparatedStringToColor(colourText);
                }
                else if (colourText.StartsWith("#") || colourText.StartsWith("0x") || colourText.Length == 6)
                {
                    // HTML-style hex colour?
                    colourText = colourText.Substring(colourText.Length - 6);
                    colour = Trainer.HexToColor(colourText);
                } else
                {
                    throw new Exception("Invalid colour fallthrough");
                }
            }
            catch (Exception)
            {
                Trainer.AddNotification($"~r~Invalid colour {colourText}");
                colour = Color.FromArgb(0);
            }

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            return colour;
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
            Vehicle vehicle = Trainer.GetPedVehicle(ped);

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
                Vehicle vehicle = Trainer.GetPedVehicle(playerPed);

                if (vehicle != null)
                {
                    if (Game.IsControlPressed(1, Control.VehicleHorn))
                    {
                        var success = float.TryParse(Config["BoostPower"], out float power);

                        if (!success)
                        {
                            Trainer.DebugLine("Failed to parse boost power config variable.");
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
            Vehicle vehicle = Trainer.GetPedVehicle(Game.PlayerPed);

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
