using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Virakal.FiveM.Trainer.TrainerClient.Data;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class PlayerSection : BaseSection
    {
        private bool justRunSpawnHandler = false;
        private List<int> RecentSkins { get; set; } = new List<int>();
        private static readonly int maxRecentSkins = 5;

        public PlayerSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("GodMode", "true");
            Config.SetDefault("InfiniteStamina", "false");
            Config.SetDefault("CurrentSkin", "");
            Config.SetDefault("InfiniteAmmo", "true");
            Config.SetDefault("InfiniteClip", "true");
            Config.SetDefault("AutoGiveParachute", "true");
            Config.SetDefault("AutoLoadDefaultSkin", "true");

            Trainer.RegisterNUICallback("player", OnPlayer);
            Trainer.RegisterAsyncNUICallback("playerskin", OnPlayerSkinChange);
            Trainer.RegisterNUICallback("savedefaultskin", OnSaveDefaultSkin);
            Trainer.RegisterNUICallback("loaddefaultskin", OnLoadDefaultSkin);
            Trainer.RegisterNUICallback("autoloaddefaultskin", OnAutoLoadDefaultSkin);

            EventHandlers["virakal:skinChange"] += new Action<int>(OnVirakalSkinChange);
            EventHandlers["playerSpawned"] += new Action(OnPlayerSpawnedRestoreSkin);
            EventHandlers["virakal:configFetched"] += new Action(OnConfigFetched);

            Trainer.AddTick(OnTick);
        }

        private void LoadRecentSkins()
        {
            if (!Config.ContainsKey("RecentSkins") || Config["RecentSkins"] == string.Empty)
            {
                return;
            }

            RecentSkins = ParseRecentSkins(Config["RecentSkins"]);
        }

        private CallbackDelegate OnSaveDefaultSkin(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Config["DefaultSkin"] = Config["CurrentSkin"];

            Trainer.AddNotification($"~g~Saved {Config["DefaultSkin"]} as your default skin.");

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnLoadDefaultSkin(IDictionary<string, object> data, CallbackDelegate callback)
        {
            if (Config.ContainsKey("DefaultSkin"))
            {
                LoadDefaultSkin();
                Trainer.AddNotification($"~g~Switched back to {Config["DefaultSkin"]}.");
            }
            else
            {
                Trainer.AddNotification($"~r~You don't have a default skin saved.");
            }

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnAutoLoadDefaultSkin(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["AutoLoadDefaultSkin"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        private async void OnConfigFetched()
        {
            LoadRecentSkins();

            if (Config.ContainsKey("DefaultSkin") && Config["AutoLoadDefaultSkin"] == "true")
            {
                // Wait to allow the game to load more fully
                await BaseScript.Delay(5000);
                LoadDefaultSkin();
            }
        }

        private async void LoadDefaultSkin()
        {
            Trainer.DebugLine($"Changing to default skin {Config["DefaultSkin"]}.");
            var skin = new Model(Config["DefaultSkin"]);
            skin.Request();

            while (!skin.IsLoaded)
            {
                Trainer.DebugLine("Waiting for skin to load.");
                await BaseScript.Delay(100);
            }

            var playerPed = Game.PlayerPed;

            if (skin == playerPed.Model)
            {
                Trainer.DebugLine("Same as current skin. Doing nothing.");
            }
            else
            {
                Trainer.DebugLine("Changing skin...");
                justRunSpawnHandler = true;
                await ChangePlayerSkin(playerPed, skin);
                Config["CurrentSkin"] = Config["DefaultSkin"];
                Trainer.DebugLine("Skin changed!");
            }
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

        private async Task<CallbackDelegate> OnPlayerSkinChange(IDictionary<string, object> data, CallbackDelegate callback)
        {
            var modelName = (string)data["action"];
            Model model = new Model(modelName);
            Ped playerPed = Game.Player.Character;

            await ChangePlayerSkin(playerPed, model);
            Config["CurrentSkin"] = modelName;

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

        private async void OnPlayerSpawnedRestoreSkin()
        {
            // Fixes some awkward bugs due to timing
            await BaseScript.Delay(0);

            // Guard against infinite recursion
            if (justRunSpawnHandler)
            {
                justRunSpawnHandler = false;
                return;
            }

            // Check if config has a skin stored
            string currentSkinHash = Config["CurrentSkin"];

            if (string.IsNullOrWhiteSpace(currentSkinHash))
            {
                return;
            }

            // Set skin to config skin if it is incorrect
            Model actualSkin = Game.PlayerPed.Model;
            Model configSkin = new Model(currentSkinHash);

            if (actualSkin != configSkin)
            {
                await Game.Player.ChangeModel(configSkin);
                justRunSpawnHandler = true;
                BaseScript.TriggerEvent("playerSpawned", configSkin.Hash);
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
                Trainer.AddNotification($"~r~Failed to load skin '{model}'!");
                return false;
            }

            UpdateRecentSkinsList(model);

            BaseScript.TriggerEvent("playerSpawned");
            BaseScript.TriggerEvent("virakal:skinChange", model.GetHashCode());

            if (playerSeat != VehicleSeat.None)
            {
                playerPed = Game.Player.Character;
                playerPed.SetIntoVehicle(vehicle, playerSeat);
            }

            Trainer.AddNotification($"~g~Changed player skin to '{model}'.");

            return true;
        }

        public static List<int> ParseRecentSkins(string skinString)
        {
            var skinList = skinString.Split(',');
            return skinList.Select((x) => int.Parse(x)).ToList();
        }

        public void UpdateRecentSkinsList(Model model)
        {
            var modelInfo = PedModelList.GetItemByHash(model.Hash);

            if (modelInfo == null)
            {
                return;
            }

            RecentSkins.Insert(0, model.Hash);
            // Remove duplicates
            RecentSkins = RecentSkins.Union(RecentSkins).ToList();

            if (RecentSkins.Count > maxRecentSkins)
            {
                RecentSkins.RemoveRange(maxRecentSkins, RecentSkins.Count - maxRecentSkins);
            }

            Config["RecentSkins"] = string.Join(",", RecentSkins);
        }

        private async Task OnTick()
        {
            Ped playerPed = Game.Player.Character;

            if (playerPed != null)
            {
                playerPed.IsInvincible = Config["GodMode"] == "true";

                if (Config["InfiniteStamina"] == "true")
                {
                    API.RestorePlayerStamina(Game.Player.Handle, 1.0f);
                }
            }

            await BaseScript.Delay(500);
        }
    }
}
