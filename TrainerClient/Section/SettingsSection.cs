﻿using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class SettingsSection : BaseSection
    {
        private bool firstSpawn = true;
        internal static readonly string[] _weatherNames = {
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

        public SettingsSection(Trainer trainer) : base(trainer)
        {
            EventHandlers["playerSpawned"] += new Action<object>(OnFirstSpawn);
            EventHandlers["virakal:setWeather"] += new Action<int, string>(OnSetWeather);
            EventHandlers["virakal:setTime"] += new Action<int, int, int, string>(OnSetTime);

            Trainer.RegisterNUICallback("weather", WeatherCallback);
            Trainer.RegisterNUICallback("time", TimeCallback);
        }

        private void ChangeWeather(Weather weatherType)
        {
            string weather = _weatherNames[(int)weatherType];
            API.SetWeatherTypePersist(weather);
            API.SetWeatherTypeNowPersist(weather);
            API.SetWeatherTypeNow(weather);
            API.SetOverrideWeather(weather);
        }

        private CallbackDelegate WeatherCallback(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Debug.Write($"Changing weather, {data["action"]}");
            BaseScript.TriggerServerEvent("virakal:changeWeather", data["action"]);

            callback("ok");
            return callback;
        }

        private CallbackDelegate TimeCallback(IDictionary<string, object> data, CallbackDelegate callback)
        {
            Debug.Write($"Changing time, {data["action"]}");
            int hour = Convert.ToInt32(data["action"]);
            BaseScript.TriggerServerEvent("virakal:changeTime", hour, 0, 0);

            callback("ok");
            return callback;
        }

        private void OnSetWeather(int weather, string name)
        {
            if (weather < 0)
            {
                return;
            }

            ChangeWeather((Weather)weather);

            if (!string.IsNullOrWhiteSpace(name))
            {
                Trainer.AddNotification($"~g~Weather changed to {Enum.GetName(typeof(Weather), weather)} by {name}.");
            }
        }

        private void OnSetTime(int h, int m, int s, string name)
        {
            API.NetworkOverrideClockTime(h, m, s);

            if (!string.IsNullOrWhiteSpace(name))
            {
                Trainer.AddNotification($"~g~Time changed to {h:00}:{m:00} by {name}.");
            }
        }

        private void OnFirstSpawn(object spawn)
        {
            if (!firstSpawn)
            {
                return;
            }

            firstSpawn = false;

            BaseScript.TriggerServerEvent("virakal:requestWeather");
            BaseScript.TriggerServerEvent("virakal:requestTime");
            BaseScript.TriggerServerEvent("virakal:requestConfig");
        }
    }
}
