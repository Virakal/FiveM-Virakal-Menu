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
        private Time CurrentTime { get; set; }

        public ServerResource()
        {
            EventHandlers["virakal:changeWeather"] += new Action<Player, int>(OnChangeWeather);
            EventHandlers["virakal:requestWeather"] += new Action<Player>(OnRequestWeather);

            EventHandlers["virakal:changeTime"] += new Action<Player, int, int, int>(OnChangeTime);
            EventHandlers["virakal:requestTime"] += new Action<Player>(OnRequestTime);
        }

        private void OnChangeWeather([FromSource]Player source, int weather)
        {
            Debug.WriteLine($"Weather changed to {WeatherList.GetNiceName(weather)} by {source.Name}");
            CurrentWeather = weather;

            TriggerClientEvent("virakal:setWeather", weather, source.Name);
        }

        private void OnRequestWeather([FromSource]Player source)
        {
            Debug.WriteLine($"Weather requested by {source.Name}. Weather is {WeatherList.GetNiceName(CurrentWeather)}");
            if (CurrentWeather != -1)
            {
                TriggerClientEvent(source, "virakal:setWeather", CurrentWeather);
            }
        }

        private void OnChangeTime([FromSource]Player source, int hours, int minutes, int seconds)
        {
            CurrentTime = new Time(hours, minutes, seconds);
            Debug.WriteLine($"Time changed to {CurrentTime} by {source.Name}.");

            TriggerClientEvent("virakal:setTime", hours, minutes, seconds, source.Name);
        }

        private void OnRequestTime([FromSource]Player source)
        {
            Debug.WriteLine($"Time requested by {source.Name}. Time is {CurrentTime}");

            if (CurrentTime != null)
            {
                TriggerClientEvent(
                    source,
                    "virakal:setTime",
                    CurrentTime.Hours,
                    CurrentTime.Minutes,
                    CurrentTime.Seconds
                );
            }
        }

        private class Time
        {
            public int Hours { get; }
            public int Minutes { get; }
            public int Seconds { get; }

            public Time(int hours, int minutes, int seconds)
            {
                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
            }

            public override string ToString()
            {
                return $"{Hours:00}:{Minutes:00}:{Seconds:00}";
            }
        }
    }
}
