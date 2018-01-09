using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class PlayerSection : BaseSection
    {
        public PlayerSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("GodMode", "false");
            Config.SetDefault("InfiniteStamina", "false");
            Config.SetDefault("CurrentSkin", "");
            Config.SetDefault("InfiniteAmmo", "true");
            Config.SetDefault("InfiniteClip", "false");
            Config.SetDefault("AutoGiveParachute", "true");

            Trainer.RegisterNUICallback("player", OnPlayer);
            Trainer.RegisterNUICallback("playerskin", OnPlayerSkinChange);
            
            EventHandlers["virakal:skinChange"] += new Action<int>(OnVirakalSkinChange);

            Trainer.AddTick(OnTick);
        }

        private CallbackDelegate OnPlayer(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Ped playerPed = Game.Player.Character;
            string action = (string)data["action"];
            bool newState = (bool)data["newstate"];
            string newStateString = newState ? "true" : "false";

            switch (action)
            {
                case "heal":
                    playerPed.Health = 200;
                    Trainer.AddNotification("~g~Player healed.");
                    break;
                case "armor":
                    playerPed.Armor = 100;
                    Trainer.AddNotification("~g~Player given armour.");
                    break;
                case "suicide":
                    playerPed.Kill();
                    Trainer.AddNotification("~g~Committed suicide.");
                    break;
                case "god":
                    Config["GodMode"] = newStateString;

                    if (newState)
                    {
                        Trainer.AddNotification("~g~God mode enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~God mode disabled.");
                    }
                    break;
                case "stamina":
                    Config["InfiniteStamina"] = newStateString;

                    if (newState)
                    {
                        Trainer.AddNotification("~g~Infinite stamina enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Infinite stamina disabled.");
                    }
                    break;
                case "ammo":
                    Config["InfiniteAmmo"] = newStateString;

                    API.SetPedInfiniteAmmo(playerPed.Handle, newState, 0);

                    if (newState)
                    {
                        Trainer.AddNotification("~g~Infinite ammo enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Infinite ammo disabled.");
                    }
                    break;
                case "clip":
                    Config["InfiniteClip"] = newStateString;

                    API.SetPedInfiniteAmmoClip(playerPed.Handle, newState);

                    if (newState)
                    {
                        Trainer.AddNotification("~g~Infinite clip enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Infinite clip disabled.");
                    }
                    break;
                case "autochute":
                    Config["AutoParachute"] = newStateString;

                    API.SetAutoGiveParachuteWhenEnterPlane(playerPed.Handle, newState);

                    if (newState)
                    {
                        Trainer.AddNotification("~g~Auto parachute enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Auto parachute disabled.");
                    }
                    break;
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnPlayerSkinChange(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Model model = new Model((string)data["action"]);
            Ped playerPed = Game.Player.Character;

            _ = ChangePlayerSkin(playerPed, model);
            Config["CurrentSkin"] = (string)data["action"];

            callback("ok");
            return callback;
        }

        private async void OnVirakalSkinChange(int modelHash)
        {
            // Awaiting 0 fixes the game trying to load things too quickly
            await BaseScript.Delay(0);

            Ped playerPed = Game.Player.Character;
            Model model = new Model(modelHash);

            if (!playerPed.IsHuman)
            {
                // This fixes crashes on some animal skins
                API.SetPedComponentVariation(playerPed.Handle, 0, 0, 0, 0);
            }
            else if (model.Hash == Game.GenerateHash(@"mp_m_freemode_01"))
            {
                // Generic MP Male setup
                API.SetPedHeadBlendData(playerPed.Handle, 4, 4, 0, 4, 4, 0, 1.0f, 1.0f, 0.0f, false);
                API.SetPedComponentVariation(playerPed.Handle, 2, 2, 4, 0);
                API.SetPedComponentVariation(playerPed.Handle, 3, 1, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 4, 33, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 5, 45, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 6, 25, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 8, 56, 1, 0);
                API.SetPedComponentVariation(playerPed.Handle, 11, 49, 0, 0);
            }
            else if (model.Hash == Game.GenerateHash(@"mp_f_freemode_01"))
            {
                // Generic MP Female setup
                API.SetPedHeadBlendData(playerPed.Handle, 25, 25, 0, 25, 25, 0, 1.0f, 1.0f, 0.0f, false);
                API.SetPedComponentVariation(playerPed.Handle, 2, 13, 3, 0);
                API.SetPedComponentVariation(playerPed.Handle, 3, 3, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 5, 45, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 6, 25, 0, 0);
                API.SetPedComponentVariation(playerPed.Handle, 8, 33, 1, 0);
                API.SetPedComponentVariation(playerPed.Handle, 11, 42, 0, 0);
            }
        }

        private async Task<bool> ChangePlayerSkin(Ped playerPed, Model model)
        {
            Vehicle vehicle = playerPed.CurrentVehicle;
            VehicleSeat playerSeat = VehicleSeat.None;

            // If in a vehicle, remember their seat so we can put them back in it
            if (vehicle != null)
            {
                int seatCount = API.GetVehicleModelNumberOfSeats((uint)vehicle.Model.Hash);

                for (var i = -1; i < seatCount; i++)
                {
                    VehicleSeat iSeat = (VehicleSeat)i;

                    if (vehicle.GetPedOnSeat(iSeat) == playerPed)
                    {
                        playerSeat = iSeat;
                        break;
                    }
                }
            }

            bool success = await Game.Player.ChangeModel(model);

            if (!success)
            {
                Trainer.AddNotification("~r~Failed to load skin!");
                return false;
            }

            BaseScript.TriggerEvent("playerSpawned");
            BaseScript.TriggerEvent("virakal:skinChange", model.GetHashCode());

            if (playerSeat != VehicleSeat.None)
            {
                playerPed = Game.Player.Character;
                playerPed.SetIntoVehicle(vehicle, playerSeat);
            }

            Trainer.AddNotification("~g~Changed player skin.");

            return true;
        }

        private Task OnTick()
        {
            Ped playerPed = Game.Player.Character;

            if (playerPed == null)
            {
                return Task.FromResult(0);
            }

            playerPed.IsInvincible = Config["GodMode"] == "true";

            if (Config["InfiniteStamina"] == "true")
            {
                API.RestorePlayerStamina(Game.Player.Handle, 1.0f);
            }

            return Task.FromResult(0);
        }
    }
}
