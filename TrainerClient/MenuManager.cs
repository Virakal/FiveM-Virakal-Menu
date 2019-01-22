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
        private Trainer Trainer { get; }
        private Dictionary<string, List<MenuItem>> Menus = new Dictionary<string, List<MenuItem>>();

        public MenuManager(Trainer trainer)
        {
            Trainer = trainer;
            InitialiseMenus();
        }

        public void SendAllMenus()
        {
            Trainer.DebugLine("Sending all menus");
            foreach (var kv in Menus)
            {
                Trainer.DebugLine($"Sending menu {kv.Key}");
                SendMenu(kv.Key);
            }
        }

        public void SendMenu(string menuName)
        {
            var menuItems = Menus[menuName];

            Trainer.SendUIMessage(new
            {
                setmenu = true,
                menuname = menuName,
                menudata = ToAnonymous(menuItems),
            });
        }

        private void InitialiseMenus()
        {
            Menus = new MainMenuAdder().AddMenus(Menus);
            Menus = new PlayerMenuAdder().AddMenus(Menus);
            Menus = new TeleportMenuAdder().AddMenus(Menus);
            Menus = new SettingsMenuAdder().AddMenus(Menus);
            Menus = new PoliceMenuAdder().AddMenus(Menus);
            Menus = new UIMenuAdder().AddMenus(Menus);
            Trainer.DebugLine($"Done adding menus: {Menus.Count} menus.");
        }

        private List<object> ToAnonymous(List<MenuItem> menu)
        {
            List<object> converted = new List<object>(menu.Count);

            foreach (var item in menu)
            {
                converted.Add(item.ToAnonymous());
            }

            return converted;
        }
    }
}
