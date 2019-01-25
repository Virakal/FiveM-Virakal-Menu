﻿using System;
using System.Collections.Generic;
using Virakal.FiveM.Trainer.TrainerClient.Data;
using Virakal.FiveM.Trainer.TrainerClient.Menu;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class AnimalBombMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["animalbomb"] = GetAnimalBombMenu();

            return menus;
        }

        private List<MenuItem> GetAnimalBombMenu()
        {
            var actionPrefix = "anibomb";
            var menu = new List<MenuItem>();
            var animalModelInfo = PedModelList.GetByType(PedModelType.Animal);

            foreach (var info in animalModelInfo)
            {
                menu.Add(new MenuItem()
                {
                    text = info.Name,
                    action = $"{actionPrefix} {info.Model}",
                    key = info.Model,
                });
            }

            return menu;
        }
    }
}