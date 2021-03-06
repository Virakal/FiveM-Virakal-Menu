﻿using System;
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
            menus["ui"] = new List<MenuItem>()
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
                    text = "Large Minimap on Z / D-Pad Down",
                    action = "bigmapondown",
                    state = "ON",
                    configkey = "BigMapOnDown"
                },
            };

            return menus;
        }
    }
}
