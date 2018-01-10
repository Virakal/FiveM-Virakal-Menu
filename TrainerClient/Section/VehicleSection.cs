using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class VehicleSection : BaseSection
    {
        private Vehicle LastPlayerVehicle { get; set; }

        public VehicleSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("AutoDespawnVehicle", "true");
            Config.SetDefault("BoostOnHorn", "false");
            Config.SetDefault("RainbowPaint", "false");
            Config.SetDefault("RainbowChrome", "false");
            Config.SetDefault("RainbowNeon", "false");
            Config.SetDefault("RainbowNeonInverse", "false");
            Config.SetDefault("InvincibleVehicle", "true");
            Config.SetDefault("SpawnInVehicle", "true");

            Trainer.RegisterNUICallback("veh", OnVeh);
            Trainer.RegisterNUICallback("vehspawn", OnVehSpawn);
            Trainer.RegisterNUICallback("vehprimary", OnVehPrimary);
            Trainer.RegisterNUICallback("vehpearl", OnVehPearl);

            Trainer.AddTick(RainbowTick);
            Trainer.AddTick(BoostTick);
            Trainer.AddTick(InvincibleCarTick);
        }

        private CallbackDelegate OnVehPrimary(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            int colour = Convert.ToInt32(data["action"]);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                // TODO: Rewrite using VehicleModCollection
                int handle = vehicle.Handle;
                API.ClearVehicleCustomPrimaryColour(handle);
                API.ClearVehicleCustomSecondaryColour(handle);

                API.SetVehicleColours(handle, colour, colour);
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnVehPearl(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;
            int colour = Convert.ToInt32(data["action"]);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Not in a vehicle!");
            }
            else
            {
                // TODO: Rewrite using VehicleModCollection
                int handle = vehicle.Handle;
                int oldPearl = 0;
                int wheelColour = 0;

                API.GetVehicleExtraColours(handle, ref oldPearl, ref wheelColour);
                API.SetVehicleExtraColours(handle, colour, wheelColour);
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
                    Trainer.AddNotification("~g~Vehicle repaired.");
                    break;
                case "clean":
                    if (veh == null)
                    {
                        Trainer.AddNotification("~r~Not in a vehicle!");
                        break;
                    }

                    veh.DirtLevel = 0;
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
                        API.SetVehicleNeonLightEnabled(veh.Handle, i, true);
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
                        API.SetVehicleNeonLightEnabled(veh.Handle, i, false);
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

                    // TODO: Rewrite as VehicleModCollection
                    API.ClearVehicleCustomPrimaryColour(veh.Handle);
                    API.ClearVehicleCustomSecondaryColour(veh.Handle);
                    API.SetVehicleColours(veh.Handle, (int)VehicleColor.Chrome, (int)VehicleColor.Chrome);

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

        private CallbackDelegate OnVehSpawn(IDictionary<string, object> data, CallbackDelegate callback)
        {
            switch ((string)data["action"])
            {
                case "despawn":
                    Config["AutoBespawnVehicle"] = (bool)data["newstate"] ? "true" : "false";
                    break;
                case "spawninveh":
                    Config["SpawnInVehicle"] = (bool)data["newstate"] ? "true" : "false";
                    break;
                case "input":
                    _ = SpawnUserInputVehicle();
                    break;
                default:
                    Model model = new Model((string)data["action"]);
                    _ = SpawnVehicle(model, Game.PlayerPed.Position);
                    break;
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

            Vehicle vehicle = await SpawnVehicle(new Model(modelName), Game.PlayerPed.Position);

            // Wait a few frames so that the messagebox doesn't start again immediately
            await BaseScript.Delay(10);
            Trainer.BlockInput = false;

            return vehicle;
        }

        private async Task<Vehicle> SpawnVehicle(Model model, Vector3 position, int heading = 0)
        {
            if (Config["SpawnInVehicle"] == "false")
            {
                position = new Vector3(position.X + 2.5f, position.Y + 2.5f, position.Z + 1.0f);
            }

            Vehicle vehicle = await World.CreateVehicle(model, position);

            if (vehicle == null)
            {
                Trainer.AddNotification("~r~Failed to load vehicle model.");
                return null;
            }

            if (Config["SpawnInVehicle"] == "true")
            {
                Ped playerPed = Game.PlayerPed;
                Vehicle playerVeh = playerPed.CurrentVehicle;

                // Move the player to the new vehicle
                playerPed.SetIntoVehicle(vehicle, VehicleSeat.Driver);

                if (playerVeh != null)
                {
                    // Try to move other passengers over
                    foreach (var passenger in playerVeh.Passengers)
                    {
                        passenger.SetIntoVehicle(vehicle, VehicleSeat.Any);
                    }

                    // Remove the old vehicle
                    playerVeh.Delete();
                }
            }

            return vehicle;
        }

        private async Task RainbowTick()
        {
            // TODO: Rewrite as VehicleModCollection
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

            RGB rgb = RainbowRGB(0.5);

            if (Config["RainbowPaint"] == "true" || Config["RainbowChrome"] == "true")
            {
                API.SetVehicleCustomPrimaryColour(vehicle.Handle, rgb.R, rgb.G, rgb.B);
                API.SetVehicleCustomSecondaryColour(vehicle.Handle, rgb.R, rgb.G, rgb.B);
            }

            if (Config["RainbowNeonInverse"] == "true")
            {
                rgb = rgb.Inverted();
                API.SetVehicleNeonLightsColour(vehicle.Handle, rgb.R, rgb.G, rgb.B);
            }
            else if (Config["RainbowNeon"] == "true")
            {
                API.SetVehicleNeonLightsColour(vehicle.Handle, rgb.R, rgb.G, rgb.B);
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
                        if (Game.IsControlPressed(1, Control.VehicleAccelerate))
                        {
                            API.SetVehicleBoostActive(vehicle.Handle, true);
                            API.SetVehicleForwardSpeed(vehicle.Handle, 75f);
                        }
                        else if (Game.IsControlPressed(1, Control.VehicleBrake))
                        {
                            API.SetVehicleBoostActive(vehicle.Handle, true);
                            API.SetVehicleForwardSpeed(vehicle.Handle, -75f);
                        }
                    }

                    API.SetVehicleBoostActive(vehicle.Handle, false);
                }
            }

            await BaseScript.Delay(0);
        }

        private Task InvincibleCarTick()
        {
            bool invincible = Config["InvincibleVehicle"] == "true";
            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                LastPlayerVehicle = null;
                return Task.FromResult(0);
            }

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

            if (invincible && vehicle != LastPlayerVehicle)
            {
                LastPlayerVehicle = vehicle;
                vehicle.Health = vehicle.MaxHealth;
                vehicle.DirtLevel = 0f;
                vehicle.EngineHealth = 1000f;

                API.SetVehicleFixed(handle);
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Provides a progressing rainbow colour based on the current game time
        /// </summary>
        /// <param name="frequency">The speed at which the colours cycle</param>
        /// <returns>An RGB object for the colour</returns>
        private RGB RainbowRGB(double frequency)
        {
            int time = Game.GameTime;

            return new RGB(
                (int)(Math.Sin((time / 5000d) * frequency + 0) * 127 + 128),
                (int)(Math.Sin((time / 5000d) * frequency + 2) * 127 + 128),
                (int)(Math.Sin((time / 5000d) * frequency + 4) * 127 + 128)
            );
        }

        private struct RGB
        {
            public int R { get; }
            public int G { get; }
            public int B { get; }

            public RGB(int r, int g, int b)
            {
                R = r;
                G = g;
                B = b;
            }

            public RGB Inverted()
            {
                return new RGB(255 - R, 255 - G, 255 - B);
            }

            public override string ToString()
            {
                return $"R: {R} G: {G} B: {B}";
            }
        }
    }
}
