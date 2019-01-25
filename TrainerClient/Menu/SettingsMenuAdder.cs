using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virakal.FiveM.Trainer.TrainerShared;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class SettingsMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["settings"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Change Weather",
                    sub = "settings.weather"
                },
                new MenuItem()
                {
                    text = "Change Time",
                    sub = "settings.time"
                },
            };

            menus["settings.weather"] = GetWeatherMenu();
            menus["settings.time"] = GetTimeMenu();

            return menus;
        }

        private List<MenuItem> GetTimeMenu()
        {
            var list = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Morning",
                    action = "time 6"
                },
                new MenuItem()
                {
                    text = "Midday",
                    action = "time 12"
                },
                new MenuItem()
                {
                    text = "Evening",
                    action = "time 18"
                },
                new MenuItem()
                {
                    text = "Midnight",
                    action = "time 0"
                },
            };

            for (int i = 0; i < 24; i++)
            {
                list.Add(new MenuItem()
                {
                    text = $"{i:D2}:00",
                    action = $"time {i}"
                });
            }

            return list;
        }

        private List<MenuItem> GetWeatherMenu()
        {
            var weathers = WeatherList.internalNames;
            var list = new List<MenuItem>(weathers.Length);

            for (int i = 0; i < weathers.Length; i++)
            {
                list.Add(new MenuItem()
                {
                    text = WeatherList.GetNiceName(i),
                    action = $"weather {i}",
                });
            }

            return list;
        }
    }
}
