using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class WeaponsMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["weaponsmenu"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Spawn With All Weapons",
                    action = "giveallweapons",
                    state = "ON",
                },
            };

            menus["weaponsmenu"] = AddParentField("mainmenu", menus["weaponsmenu"]);

            return menus;
        }
    }
}
