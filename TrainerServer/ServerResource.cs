using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virakal.FiveM.Trainer.TrainerShared;

namespace TrainerServer
{
    public class ServerResource : BaseScript
    {
        private int CurrentWeather { get; set; } = -1;

        public ServerResource()
        {
            EventHandlers["virakal:changeWeather"] += new Action<Player, int>(OnChangeWeather);
            EventHandlers["virakal:requestWeather"] += new Action<Player>(OnRequestWeather);
        }

        private void OnChangeWeather([FromSource]Player source, int weather)
        {
            Debug.WriteLine($"Weather changed to {WeatherList.GetNiceName(weather)} by {source.Name}");
            CurrentWeather = weather;

            TriggerClientEvent("virakal:setWeather", weather, source.Name);
        }

        private void OnRequestWeather([FromSource]Player source)
        {
            Debug.WriteLine($"Weather requested by {source.Name}. Weather is {CurrentWeather}");
            if (CurrentWeather != -1)
            {
                TriggerClientEvent(source, "virakal:setWeather", CurrentWeather);
            }
        }
    }
}
