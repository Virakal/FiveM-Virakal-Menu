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
                new SettingsMenuAdder(),
                new PoliceMenuAdder(),
                new UIMenuAdder(),
                new VehiclesMenuAdder(Trainer.Garage),
                new AnimationMenuAdder(),
                new WeaponsMenuAdder(),
                new AnimalBombMenuAdder(),
            };

            Trainer._EventHandlers["virakal:allMenusSent"] += new Action(OnMenusSent);

            InitialiseMenus();
        }

        private void OnMenusSent()
        {
            // We add these listeners after the menus are sent to avoid them interfering with each other
            Trainer._EventHandlers["playerSpawned"] += new Action<object>(OnPlayerSpawn);
            Trainer._EventHandlers["virakal:newVehicle"] += new Action<int, int>(OnNewVehicle);
            Trainer._EventHandlers["virakal:exitedVehicle"] += new Action<int, int>(OnNewVehicle);
            Trainer._EventHandlers["virakal:configChanged"] += new Action<string, string>(OnConfigChanged);

            // This doesn't load properly so early
            UpdateGarageMenus();
        }

        private void OnConfigChanged(string key, string value)
        {
            if (key.StartsWith(Garage.ConfigKeyPrefix))
            {
                UpdateGarageMenus();
            }

            if (key == "RecentSkins")
            {
                UpdateRecentSkinsMenu();
            }
        }

        private void UpdateRecentSkinsMenu()
        {
            var playerAdder = GetMenuAdderByType<PlayerMenuAdder>();
            Menus["player.skin.recent"] = playerAdder.GetRecentSkinMenu();

            SendMenu("player.skin.recent");
        }

        private void UpdateGarageMenus()
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            Menus["vehicles.save"] = vehiclesAdder.GetGarageSaveMenu();
            Menus["vehicles.load"] = vehiclesAdder.GetGarageLoadMenu();

            SendMenu("vehicles.save");
            SendMenu("vehicles.load");
        }

        private void OnNewVehicle(int vehicleHandle, int oldVehicleHandle)
        {
            var vehiclesAdder = GetMenuAdderByType<VehiclesMenuAdder>();
            Menus["vehicles.appearance.livery"] = vehiclesAdder.GetLiveryMenu();
            SendMenu("vehicles.appearance.livery");

            Trainer.DebugLine("Updated the livery menu because we entered a new vehicle.");
        }

        private void OnPlayerSpawn(object spawn)
        {
            // Would be nice to just do this on player connect, but we can't.
            var teleportMenuAdder = GetMenuAdderByType<TeleportMenuAdder>();
            Menus["teleport.toPlayer"] = teleportMenuAdder.MakePlayerMenu();
            SendMenu("teleport.toPlayer");

            Trainer.DebugLine("Updated the teleport to player menu because we had a player spawn.");
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
