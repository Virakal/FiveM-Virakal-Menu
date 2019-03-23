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

        private async void OnPlayerSpawn(object spawn)
        {
            if (Config["SpawnGiveAllWeapons"] == "true")
            {
                var playerPed = Game.PlayerPed;
                var randomWeapon = Weapons[random.Next(Weapons.Count)];

                foreach (WeaponHash weapon in Weapons)
                {
                    if (weapon != randomWeapon)
                    {
                        playerPed.Weapons.Give(weapon, 9999, true, true);
                    }
                }

                // Give a random weapon so the player doesn't always spawn with the same thing
                playerPed.Weapons.Give(randomWeapon, 9999, true, true);
            }

            await Task.FromResult(0);
        }
    }
}
