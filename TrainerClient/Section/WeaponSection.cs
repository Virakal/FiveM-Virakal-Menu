using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class WeaponSection : BaseSection
    {
        public List<WeaponHash> Weapons { get; private set; }
        private readonly Random random = new Random();

        public WeaponSection(Trainer trainer) : base(trainer)
        {
            Config.SetDefault("SpawnGiveAllWeapons", "true");
            Config.SetDefault("InfiniteAmmo", "true");
            Config.SetDefault("InfiniteClip", "true");

            Trainer.RegisterNUICallback("wepgive", GiveWeapon);
            Trainer.RegisterNUICallback("wepremove", RemoveWeapon);
            Trainer.RegisterNUICallback("spawngiveallweapons", ToggleSpawnGiveAllWeapons);
            Trainer.RegisterNUICallback("giveallweapons", OnGiveAllWeapons);
            Trainer.RegisterNUICallback("weaponconfig", OnWeaponConfig);

            WeaponHash[] weaponList = (WeaponHash[])Enum.GetValues(typeof(WeaponHash));
            EventHandlers["playerSpawned"] += new Action<object>(OnPlayerSpawn);
            Weapons = new List<WeaponHash>(weaponList)
            {
                // Add extra weapons that aren't in the WeaponHash enum yet
                (WeaponHash)Game.GenerateHash(@"weapon_stone_hatchet"),
                (WeaponHash)Game.GenerateHash(@"weapon_raypistol"),
                (WeaponHash)Game.GenerateHash(@"weapon_raycarbine"),
                (WeaponHash)Game.GenerateHash(@"weapon_rayminigun"),
            };
        }

        private CallbackDelegate GiveWeapon(IDictionary<string, object> data, CallbackDelegate callback)
        {
            string weapon = (string)data["action"];

            Game.Player.Character.Weapons.Give((WeaponHash)API.GetHashKey(weapon), 9999, true, true);

            callback("ok");
            return callback;
        }

        private CallbackDelegate RemoveWeapon(IDictionary<string, object> data, CallbackDelegate callback)
        {
            string weapon = (string)data["action"];

            Game.Player.Character.Weapons.Remove((WeaponHash)API.GetHashKey(weapon));

            callback("ok");
            return callback;
        }

        private CallbackDelegate ToggleSpawnGiveAllWeapons(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["SpawnGiveAllWeapons"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        /// <summary>
        /// Give all available weapons to the current user
        /// </summary>
        /// <param name="data">The message data</param>
        /// <param name="callback">The callback method</param>
        /// <returns>The callback</returns>
        private CallbackDelegate OnGiveAllWeapons(IDictionary<string, object> data, CallbackDelegate callback)
        {
            GiveAllWeapons();

            callback("ok");
            return callback;
        }

        private CallbackDelegate OnWeaponConfig(IDictionary<string, object> data, CallbackDelegate callback)
        {
            string action = (string)data["action"];
            bool newState = (bool)data["newstate"];
            string newStateString = newState ? "true" : "false";

            switch (action)
            {
                case "ammo":
                    Config["InfiniteAmmo"] = newStateString;

                    SetInfiniteAmmo(newState);

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

                    SetInfiniteClip(newState);

                    if (newState)
                    {
                        Trainer.AddNotification("~g~Infinite clip enabled.");
                    }
                    else
                    {
                        Trainer.AddNotification("~g~Infinite clip disabled.");
                    }
                    break;
            }

            callback("ok");
            return callback;
        }

        /// <summary>
        /// Set infinite ammo for the current player to the given state
        /// </summary>
        /// <param name="state">Whether the player should have infinite ammo</param>
        private void SetInfiniteAmmo(bool state)
        {
            API.SetPedInfiniteAmmo(Game.PlayerPed.Handle, state, 0);
        }

        /// <summary>
        /// Set infinite ammo clip for the current player to the given state
        /// </summary>
        /// <param name="state">Whether the player should have an infinite clip</param>
        private void SetInfiniteClip(bool state)
        {
            API.SetPedInfiniteAmmoClip(Game.PlayerPed.Handle, state);
        }

        /// <summary>
        /// Give every available weapon from the weapons list to the player
        /// </summary>
        private void GiveAllWeapons()
        {
            var weaponCollection = Game.PlayerPed.Weapons;

            // Randomly select a weapon to give last so that the user doesn't end up with the same one every time
            var randomWeapon = Weapons[random.Next(Weapons.Count)];

            foreach (WeaponHash weapon in Weapons)
            {
                if (weapon != randomWeapon)
                {
                    weaponCollection.Give(weapon, 9999, true, true);
                }
            }

            // Give the randomly selected weapon last
            weaponCollection.Give(randomWeapon, 9999, true, true);
        }

        private async void OnPlayerSpawn(object spawn)
        {
            if (Config["SpawnGiveAllWeapons"] == "true")
            {
                GiveAllWeapons();
            }

            SetInfiniteAmmo(Config["InfiniteAmmo"] == "true");
            SetInfiniteClip(Config["InfiniteClip"] == "true");

            await Task.FromResult(0);
        }
    }
}
