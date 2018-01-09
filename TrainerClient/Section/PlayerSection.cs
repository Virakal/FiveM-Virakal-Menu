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
