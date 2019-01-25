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

            // We can build this from the enum in future
            menus["settings.weather"] = GetWeatherMenu();

            menus["settings.time"] = new List<MenuItem>()
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
                new MenuItem()
                {
                    text = "00:00",
                    action = "time 0"
                },
                new MenuItem()
                {
                    text = "01:00",
                    action = "time 1"
                },
                new MenuItem()
                {
                    text = "02:00",
                    action = "time 2"
                },
                new MenuItem()
                {
                    text = "03:00",
                    action = "time 3"
                },
                new MenuItem()
                {
                    text = "04:00",
                    action = "time 4"
                },
                new MenuItem()
                {
                    text = "05:00",
                    action = "time 5"
                },
                new MenuItem()
                {
                    text = "06:00",
                    action = "time 6"
                },
                new MenuItem()
                {
                    text = "07:00",
                    action = "time 7"
                },
                new MenuItem()
                {
                    text = "08:00",
                    action = "time 8"
                },
                new MenuItem()
                {
                    text = "09:00",
                    action = "time 9"
                },
                new MenuItem()
                {
                    text = "10:00",
                    action = "time 10"
                },
                new MenuItem()
                {
                    text = "11:00",
                    action = "time 11"
                },
                new MenuItem()
                {
                    text = "12:00",
                    action = "time 12"
                },
                new MenuItem()
                {
                    text = "13:00",
                    action = "time 13"
                },
                new MenuItem()
                {
                    text = "14:00",
                    action = "time 14"
                },
                new MenuItem()
                {
                    text = "15:00",
                    action = "time 15"
                },
                new MenuItem()
                {
                    text = "16:00",
                    action = "time 16"
                },
                new MenuItem()
                {
                    text = "17:00",
                    action = "time 17"
                },
                new MenuItem()
                {
                    text = "18:00",
                    action = "time 18"
                },
                new MenuItem()
                {
                    text = "19:00",
                    action = "time 19"
                },
                new MenuItem()
                {
                    text = "20:00",
                    action = "time 20"
                },
                new MenuItem()
                {
                    text = "21:00",
                    action = "time 21"
                },
                new MenuItem()
                {
                    text = "22:00",
                    action = "time 22"
                },
                new MenuItem()
                {
                    text = "23:00",
                    action = "time 23"
                },
            };

            return menus;
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
