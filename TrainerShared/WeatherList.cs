using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace Virakal.FiveM.Trainer.TrainerShared
{
    public static class WeatherList
    {
        private static readonly string[] internalNames = {
            "EXTRASUNNY",
            "CLEAR",
            "CLOUDS",
            "SMOG",
            "FOGGY",
            "OVERCAST",
            "RAIN",
            "THUNDER",
            "CLEARING",
            "NEUTRAL",
            "SNOW",
            "BLIZZARD",
            "SNOWLIGHT",
            "XMAS"
        };

        private static readonly string[] niceNames = {
            "Extra Sunny",
            "Clear",
            "Cloudy",
            "Smoggy",
            "Foggy",
            "Overcast",
            "Rain",
            "Thunder",
            "Clearing",
            "Neutral",
            "Snowing",
            "Blizzard",
            "Light Snow",
            "Christmas"
        };

        public static string GetInternalName(int weather)
        {
            return internalNames[weather];
        }

        public static string GetNiceName(int weather)
        {
            return niceNames[weather];
        }
    }
}
