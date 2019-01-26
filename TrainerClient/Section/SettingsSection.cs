﻿using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using Virakal.FiveM.Trainer.TrainerShared;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    class SettingsSection : BaseSection
    {
        private bool firstSpawn = true;

        public SettingsSection(Trainer trainer) : base(trainer)
        {
            EventHandlers["playerSpawned"] += new Action<object>(OnFirstSpawn);
            EventHandlers["virakal:setWeather"] += new Action<int, string>(OnSetWeather);
            EventHandlers["virakal:setTime"] += new Action<int, int, int, string>(OnSetTime);
            EventHandlers["virakal:newVehicle"] += new Action<int, int>(OnNewVehicle);

            Trainer.RegisterNUICallback("weather", WeatherCallback);
            Trainer.RegisterNUICallback("time", TimeCallback);
            Trainer.RegisterNUICallback("defaultradio", OnDefaultRadio);
        }

        private void OnNewVehicle(int vehicleHandle, int oldVehicle)
        {
            if (Config.ContainsKey("DefaultRadioStation"))
            {
                string action = Config["DefaultRadioStation"];
                int stationIndex = int.Parse(action);

                // -1 means no default, so don't change the current station
                if (stationIndex != -1)
                {
                    var vehicle = Game.PlayerPed.CurrentVehicle;

                    if (vehicle != null)
                    {
                        var station = (RadioStation)stationIndex;
                        vehicle.RadioStation = station;
                    }
                }
            }
        }

        private CallbackDelegate OnDefaultRadio(IDictionary<string, object> data, CallbackDelegate callback)
        {
            string action = (string)data["action"];
            int stationIndex = int.Parse(action);

            // -1 means no default, so don't change the current station
            if (stationIndex != -1)
            {
                var vehicle = Game.PlayerPed.CurrentVehicle;

                if (vehicle != null)
                {
                    var station = (RadioStation)stationIndex;
                    vehicle.RadioStation = station;
                }
            }

            Config["DefaultRadioStation"] = action;

            callback("ok");
            return callback;
        }

        private void ChangeWeather(Weather weatherType)
        {
            World.Weather = weatherType;
            World.TransitionToWeather(weatherType, 5.0f);
        }

        private CallbackDelegate WeatherCallback(IDictionary<string, object> data, CallbackDelegate callback)
        {
            BaseScript.TriggerServerEvent("virakal:changeWeather", data["action"]);

            callback("ok");
            return callback;
        }

        private CallbackDelegate TimeCallback(IDictionary<string, object> data, CallbackDelegate callback)
        {
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
                Trainer.AddNotification($"~g~Weather changed to {WeatherList.GetNiceName(weather)} by {name}.");
            }
        }

        private void OnSetTime(int h, int m, int s, string name)
        {
            API.NetworkOverrideClockTime(h, m, s);
            World.CurrentDayTime = new TimeSpan(h, m, s);

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
