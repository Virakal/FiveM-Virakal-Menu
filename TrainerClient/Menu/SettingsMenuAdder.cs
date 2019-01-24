using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            menus["settings.weather"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Extra Sunny",
                    action = "weather 0"
                },
                new MenuItem()
                {
                    text = "Clear",
                    action = "weather 1"
                },
                new MenuItem()
                {
                    text = "Clouds",
                    action = "weather 2"
                },
                new MenuItem()
                {
                    text = "Overcast",
                    action = "weather 5"
                },
                new MenuItem()
                {
                    text = "Rain",
                    action = "weather 6"
                },
                new MenuItem()
                {
                    text = "Clearing",
                    action = "weather 8"
                },
                new MenuItem()
                {
                    text = "Thunder",
                    action = "weather 7"
                },
                new MenuItem()
                {
                    text = "Smog",
                    action = "weather 3"
                },
                new MenuItem()
                {
                    text = "Foggy",
                    action = "weather 4"
                },
                new MenuItem()
                {
                    text = "Christmas",
                    action = "weather 13"
                },
                new MenuItem()
                {
                    text = "Light Snow",
                    action = "weather 12"
                },
                new MenuItem()
                {
                    text = "Snow",
                    action = "weather 10"
                },
                new MenuItem()
                {
                    text = "Blizzard",
                    action = "weather 11"
                },
                new MenuItem()
                {
                    text = "Neutral",
                    action = "weather 9"
                },
            };

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

            menus["settings"] = AddParentField("mainmenu", menus["settings"]);
            menus["settings.weather"] = AddParentField("settings", menus["settings.weather"]);
            menus["settings.time"] = AddParentField("settings", menus["settings.time"]);

            return menus;
        }
    }
}
