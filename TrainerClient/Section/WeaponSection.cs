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
            Config.SetDefault("ExplosiveAmmo", "false");
            Config.SetDefault("FireAmmo", "false");
            Config.SetDefault("SpawnGiveAllWeapons", "true");

            Trainer.RegisterNUICallback("wepgive", GiveWeapon);
            Trainer.RegisterNUICallback("wepremove", RemoveWeapon);
            Trainer.RegisterNUICallback("explosiveammo", ToggleExplosiveAmmo);
            Trainer.RegisterNUICallback("fireammo", ToggleFireAmmo);
            Trainer.RegisterNUICallback("spawngiveallweapons", ToggleSpawnGiveAllWeapons);
            Trainer.RegisterNUICallback("giveallweapons", OnGiveAllWeapons);

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

            Trainer.AddTick(OnTick);
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

        private CallbackDelegate ToggleExplosiveAmmo(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["ExplosiveAmmo"] = state ? "true" : "false";

            callback("ok");
            return callback;
        }

        private CallbackDelegate ToggleFireAmmo(IDictionary<string, object> data, CallbackDelegate callback)
        {
            bool state = (bool)data["newstate"];
            Config["FireAmmo"] = state ? "true" : "false";

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

        private Task OnTick()
        {
            if (Config["ExplosiveAmmo"] == "true")
            {
                Game.Player.SetExplosiveAmmoThisFrame();
            }

            if (Config["FireAmmo"] == "true")
            {
                Game.Player.SetFireAmmoThisFrame();
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Give every available weapon from the weapons list to the player
        /// </summary>
        private void GiveAllWeapons()
        {
            var playerPed = Game.PlayerPed;

            // Randomly select a weapon to give last so that the user doesn't end up with the same one every time
            var randomWeapon = Weapons[random.Next(Weapons.Count)];

            foreach (WeaponHash weapon in Weapons)
            {
                if (weapon != randomWeapon)
                {
                    playerPed.Weapons.Give(weapon, 9999, true, true);
                }
            }

            // Give the randomly selected weapon last
            playerPed.Weapons.Give(randomWeapon, 9999, true, true);
        }

        private async void OnPlayerSpawn(object spawn)
        {
            if (Config["SpawnGiveAllWeapons"] == "true")
            {
                GiveAllWeapons();
            }

            await Task.FromResult(0);
        }
    }
}
