using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virakal.FiveM.Trainer.TrainerClient.Menu;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    /// <summary>
    /// Manages updating the menus on the frontend UI
    /// </summary>
    public class MenuManager
    {
        public List<BaseMenuAdder> MenuAdders { get; }
        private Trainer Trainer { get; }
        private Dictionary<string, List<MenuItem>> Menus = new Dictionary<string, List<MenuItem>>();

        public MenuManager(Trainer trainer)
        {
            Trainer = trainer;
            MenuAdders = new List<BaseMenuAdder>()
            {
                new MainMenuAdder(),
                new PlayerMenuAdder(Trainer.Config),
                new TeleportMenuAdder(),
                new SettingsMenuAdder(Trainer.Config),
                new PoliceMenuAdder(),
                new UIMenuAdder(),
                new VehiclesMenuAdder(Trainer.Config, Trainer.Garage),
                new AnimationMenuAdder(),
                new WeaponsMenuAdder(),
                new AnimalBombMenuAdder(),
            };

            Trainer.EventHandlers["virakal:allMenusSent"] += new Action(OnMenusSent);
            Trainer.EventHandlers["virakal:configFetched"] += new Action(OnConfigFetched);
        }

        private void OnConfigFetched()
        {
            InitialiseMenus();
            SendAllMenus();
        }

        private void OnMenusSent()
        {
            // We add these listeners after the menus are sent to avoid them interfering with each other
            Trainer.EventHandlers["playerSpawned"] += new Action<object>(OnPlayerSpawn);
            Trainer.EventHandlers["virakal:newVehicle"] += new Action<int, int>(OnNewVehicle);
            Trainer.EventHandlers["virakal:exitedVehicle"] += new Action<int, int>(OnNewVehicle);
            Trainer.EventHandlers["virakal:vehicleModsChanged"] += new Action<int, int>(OnNewVehicleMods);
            Trainer.EventHandlers["virakal:configChanged"] += new Action<string, string>(OnConfigChanged);

            Trainer.AddTick(OnPeriodicUpdate);

            // This doesn't load properly so early
            UpdateGarageMenus();
        }

        private async Task OnPeriodicUpdate()
        {
            await BaseScript.Delay(10000);

            UpdateTeleportMenu();
        }

        private void OnConfigChanged(string key, string value)
        {
            if (key.StartsWith(Garage.ConfigKeyPrefix))
            {
                UpdateGarageMenus();
            }
            else if (key == "RecentSkins")
            {
                UpdateRecentSkinsMenu();
            }
            else if (key == "RainbowSpeed")
            {
                UpdateRainbowSpeedMenu();
            }
            else if (key == "DefaultRadioStation")
            {
                UpdateDefaultRadioMenu();
            }
            else if (key == "VehicleSpawnSearchTerm")
            {
                UpdateVehicleSpawnSearchMenu();
            }
            else if (key == "BoostPower")
            {
                UpdateBoostPowerMenu();
            }
        }

        public void UpdateAndSend(string key, List<MenuItem> menu)
        {
            Menus[key] = menu;
            SendMenu(key);
        }

        private void UpdateVehicleSpawnSearchMenu()
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            UpdateAndSend("vehicles.spawn.search", vehiclesAdder.GetSpawnSearchMenu());
        }

        private void UpdateBoostPowerMenu()
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            UpdateAndSend("vehicles.boostPower", vehiclesAdder.GetBoostPowerMenu());
        }

        private void UpdateDefaultRadioMenu()
        {
            var settingsAdder = GetMenuAdderByType<SettingsMenuAdder>();
            UpdateAndSend("settings.defaultRadio", settingsAdder.GetDefaultRadioMenu());
        }

        private void UpdateRainbowSpeedMenu()
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            UpdateAndSend("vehicles.appearance.rainbowSettings.speed", vehiclesAdder.GetRainbowSpeedMenu());
        }

        private void UpdateRecentSkinsMenu()
        {
            var playerAdder = GetMenuAdderByType<PlayerMenuAdder>();
            UpdateAndSend("player.skin.recent", playerAdder.GetRecentSkinMenu());
        }

        private void UpdateGarageMenus()
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            UpdateAndSend("vehicles.save", vehiclesAdder.GetGarageSaveMenu());
            UpdateAndSend("vehicles.load", vehiclesAdder.GetGarageLoadMenu());
        }

        private void OnNewVehicle(int vehicleHandle, int oldVehicleHandle)
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            UpdateAndSend("vehicles.appearance.livery", vehiclesAdder.GetLiveryMenu());
            UpdateAndSend("vehicles.appearance.colourCombinations", vehiclesAdder.GetColourCombinationsMenu());
            OnNewVehicleMods(-1, -1);
        }

        private void OnNewVehicleMods(int modTypeIndex, int modIndex)
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            var modMenus = vehiclesAdder.GetOtherModsMenus();

            foreach (var kv in modMenus)
            {
                UpdateAndSend(kv.Key, kv.Value);
            }
        }

        private void OnPlayerSpawn(object spawn)
        {
            // Would be nice to just do this on player connect, but we can't.
            UpdateTeleportMenu();
        }

        private void UpdateTeleportMenu()
        {
            var teleportMenuAdder = GetMenuAdderByType<TeleportMenuAdder>();
            UpdateAndSend("teleport.toPlayer", teleportMenuAdder.MakePlayerMenu());
        }

        public async void SendAllMenus()
        {
            Trainer.DebugLine("Sending all menus");

            await BaseScript.Delay(0);

            foreach (var kv in Menus)
            {
                // Trainer.DebugLine($"Sending menu {kv.Key}");
                SendMenu(kv.Key);
                await BaseScript.Delay(10);
            }

            BaseScript.TriggerEvent("virakal:allMenusSent");
        }

        public void SendMenu(string menuName)
        {
            var menuItems = Menus[menuName];

            Trainer.SendUIMessage(new
            {
                setmenu = true,
                menuname = menuName,
                menudata = menuItems,
            });
        }

        private T GetMenuAdderByType<T>() where T: BaseMenuAdder
        {
            foreach (var menuAdder in MenuAdders)
            {
                if (menuAdder.GetType() == typeof(T))
                {
                    return (T)menuAdder;
                }
            }

            throw new KeyNotFoundException($"Searched for missing menu adder type '{typeof(T).Name}'");
        }

        private void InitialiseMenus()
        {
            foreach (var menuAdder in MenuAdders) {
                Menus = menuAdder.AddMenus(Menus);
            }

            Trainer.DebugLine($"Done adding menus: {Menus.Count} menus.");
        }
    }
}
