using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class TeleportSection : BaseSection
    {
        public TeleportSection(Trainer trainer) : base(trainer)
        {
            Trainer.RegisterNUICallback("coords", DisplayCoords);
            Trainer.RegisterNUICallback("teleplayer", TeleportToPlayer);
            Trainer.RegisterNUICallback("telelastcar", TeleportToLastCar);
            Trainer.RegisterNUICallback("teleport", TeleportToCoords);
        }

        private CallbackDelegate DisplayCoords(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Vector3 location = Game.Player.Character.Position;
            string coords = $"~g~{location.X:#.##}, {location.Y:#.##}, {location.Z:#.##}";

            Trainer.AddNotification(coords);

            callback("ok");
            return callback;
        }

        private CallbackDelegate TeleportToPlayer(IDictionary<string, object> data, CallbackDelegate callback)
        {
            int otherPlayerId = Convert.ToInt32(data["action"]);
            var playerList = new PlayerList();
            Player otherPlayer = playerList[otherPlayerId];


            if (otherPlayer == null)
            {
                Trainer.AddNotification($"~r~Player {otherPlayerId} is not in the game.");
                callback("ok");
                return callback;
            }

            if (otherPlayer == Game.Player)
            {
                Trainer.AddNotification($"~r~Player {otherPlayerId} is you!");
                callback("ok");
                return callback;
            }

            Ped playerPed = Game.Player.Character;
            Ped otherPed = otherPlayer.Character;
            Vehicle otherVehicle = otherPed.CurrentVehicle;

            Trainer.AddNotification($"Teleporting to {otherPlayer.Name} (Player {otherPlayerId})...");

            if (otherVehicle != null && API.AreAnyVehicleSeatsFree(otherVehicle.Handle))
            {
                otherPed.SetIntoVehicle(otherVehicle, VehicleSeat.Any);
            }
            else
            {
                playerPed.Position = otherPed.Position;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate TeleportToLastCar(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Player player = Game.Player;
            Ped playerPed = player.Character;
            Vehicle lastVehicle = player.LastVehicle;

            if (playerPed.IsInVehicle())
            {
                Trainer.AddNotification("~r~Can't teleport to last vehicle whilst already in a vehicle.");
                callback("ok");
                return callback;
            }

            if (lastVehicle != null && !lastVehicle.IsDead)
            {
                if (API.AreAnyVehicleSeatsFree(lastVehicle.Handle))
                {
                    lastVehicle.PlaceOnGround();

                    // Attempt to drive
                    playerPed.SetIntoVehicle(lastVehicle, VehicleSeat.Driver);

                    if (!playerPed.IsInVehicle(lastVehicle))
                    {
                        // If that didn't work, try any seat
                        playerPed.SetIntoVehicle(lastVehicle, VehicleSeat.Any);
                    }
                }
                else
                {
                    // No seats free, just teleport to the vehicle
                    playerPed.Position = lastVehicle.Position;
                }
            }
            else
            {
                Trainer.AddNotification("~r~Could not find your last vehicle.");
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate TeleportToCoords(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var coords = (string)data["action"];
            string[] splitCoords = coords.Split(',');
            var position = new Vector3(
                float.Parse(splitCoords[0]),
                float.Parse(splitCoords[1]),
                float.Parse(splitCoords[2])
            );

            Ped playerPed = Game.Player.Character;
            Entity entity = playerPed;

            // If the player is driving a vehicle, take it with them
            if (playerPed.IsInVehicle() && playerPed.CurrentVehicle.Driver == playerPed)
            {
                entity = playerPed.CurrentVehicle;
            }

            entity.Position = position;

            callback("ok");
            return callback;
        }
    }
}