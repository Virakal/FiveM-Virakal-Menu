using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class UIMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["uimenu"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Large Minimap",
                    action = "bigmap",
                    state = "OFF",
                    configkey = "BigMap"
                },
                new MenuItem()
                {
                    text = "Large Minimap on Down Arrow",
                    action = "bigmapondown",
                    state = "ON",
                    configkey = "BigMapOnDown"
                },

            };

            menus["uimenu"] = AddParentField("mainmenu", menus["uimenu"]);

            return menus;
        }
    }
}
