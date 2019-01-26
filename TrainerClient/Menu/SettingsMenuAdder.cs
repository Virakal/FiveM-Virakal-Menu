using CitizenFX.Core;
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
        private Config Config { get; }

        public SettingsMenuAdder(Config config)
        {
            Config = config;
        }

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
                new MenuItem()
                {
                    text = "Default Radio Station",
                    sub = "settings.defaultRadio"
                },
            };

            menus["settings.weather"] = GetWeatherMenu();
            menus["settings.time"] = GetTimeMenu();
            menus["settings.defaultRadio"] = GetDefaultRadioMenu();

            return menus;
        }

        public List<MenuItem> GetDefaultRadioMenu()
        {
            var list = new List<MenuItem>();
            var defaultText = "No Default";
            int currentDefaultStation = -1;

            if (Config.ContainsKey("DefaultRadioStation") && int.TryParse(Config["DefaultRadioStation"], out int result))
            {
                currentDefaultStation = result;
            }

            if (currentDefaultStation == -1)
            {
                defaultText += " (Current)";
            }

            list.Add(new MenuItem()
            {
                text = defaultText,
                action = "defaultradio -1",
            });

            foreach (var station in Enum.GetValues(typeof(RadioStation)))
            {
                string menuText = Trainer.AddSpacesToSentence(station.ToString());
                int stationIndex = (int)station;

                if (currentDefaultStation == stationIndex)
                {
                    menuText += " (Current)";
                }

                list.Add(new MenuItem()
                {
                    text = menuText,
                    action = $"defaultradio {stationIndex}",
                });
            }

            return list;
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
