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
            InitialiseMenus();
            MenuAdders = new List<BaseMenuAdder>()
            {
                new MainMenuAdder(),
                new PlayerMenuAdder(),
                new TeleportMenuAdder(),
                new SettingsMenuAdder(),
                new PoliceMenuAdder(),
                new UIMenuAdder(),
                new VehiclesMenuAdder(Trainer.Garage),
                new AnimationMenuAdder(),
                new WeaponsMenuAdder(),
            };
        }

        public async void SendAllMenus()
        {
            Trainer.DebugLine("Sending all menus");

            foreach (var kv in Menus)
            {
                Trainer.DebugLine($"Sending menu {kv.Key}");
                SendMenu(kv.Key);
                await BaseScript.Delay(100);
            }
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
