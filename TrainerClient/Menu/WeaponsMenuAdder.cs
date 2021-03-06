﻿using System;
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
            menus["weapons"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Spawn With All Weapons",
                    action = "spawngiveallweapons",
                    state = "ON",
                    configkey = "SpawnGiveAllWeapons",
                },
                new MenuItem()
                {
                    text = "Infinite Ammo",
                    action = "weaponconfig ammo",
                    state = "ON",
                    configkey = "InfiniteAmmo"
                },
                new MenuItem()
                {
                    text = "Infinite Clip",
                    action = "weaponconfig clip",
                    state = "ON",
                    configkey = "InfiniteClip"
                },
                new MenuItem()
                {
                    text = "Give All Weapons",
                    action = "giveallweapons",
                },
            };

            return menus;
        }
    }
}
