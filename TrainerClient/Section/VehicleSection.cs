using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class VehicleSection : BaseSection
    {
        public VehicleSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("AutoDespawnVehicle", "true");
            Config.SetDefault("BoostOnHorn", "false");
            Config.SetDefault("RainbowPaint", "false");
            Config.SetDefault("RainbowChrome", "false");
            Config.SetDefault("RainbowNeon", "false");
            Config.SetDefault("RainbowneonInverse", "false");
            Config.SetDefault("InvincibleVehicle", "true");
            Config.SetDefault("SpawnInVehicle", "true");

            Trainer.RegisterNUICallback("vehspawn", OnVehSpawn);
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

            // Wait a frame so that the messagebox doesn't start again
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
    }
}
