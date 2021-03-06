﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class MainMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["mainmenu"] = new List<MenuItem>()
            {
                new MenuItem() {
                    text = "Player",
                    sub = "player"
                },
                new MenuItem() {
                    text = "Teleport",
                    sub = "teleport"
                },
                new MenuItem() {
                    text = "Vehicles",
                    sub = "vehicles"
                },
                new MenuItem() {
                    text = "Weapons",
                    sub = "weapons"
                },
                new MenuItem() {
                    text = "Police",
                    sub = "police"
                },
                new MenuItem() {
                    text = "Settings",
                    sub = "settings"
                },
                new MenuItem() {
                    text = "Animate",
                    sub = "animation"
                },
                new MenuItem() {
                    text = "UI",
                    sub = "ui"
                },
                new MenuItem() {
                    text = "Animal Bombs",
                    sub = "animalbomb"
                }
            };

            return menus;
        }
    }
}
