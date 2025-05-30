﻿using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Virakal.FiveM.Trainer.TrainerShared;
using CitizenFX.Core.Native;

namespace TrainerServer
{
    public class ServerResource : BaseScript
    {
        public string ConfigPath { get; private set; } = @"virakal-configs/";
        private int CurrentWeather { get; set; } = -1;
        private Time CurrentTime { get; set; }

        public ServerResource()
        {
            EventHandlers["virakal:changeWeather"] += new Action<Player, int>(OnChangeWeather);
            EventHandlers["virakal:requestWeather"] += new Action<Player>(OnRequestWeather);

            EventHandlers["virakal:changeTime"] += new Action<Player, int, int, int>(OnChangeTime);
            EventHandlers["virakal:requestTime"] += new Action<Player>(OnRequestTime);

            EventHandlers["virakal:setConfig"] += new Action<Player, string>(OnSetConfig);
            EventHandlers["virakal:getConfig"] += new Action<Player>(OnGetConfig);

            Directory.CreateDirectory(ConfigPath);
            Debug.WriteLine($"Virakal Trainer configs at {Path.GetFullPath(ConfigPath)}");
        }

        private string GetConfigPathForPlayer(Player player)
        {
            var handle = player.Identifiers.Where((identifier) => identifier.StartsWith("license:")).FirstOrDefault();

            if (API.GetConvar("sv_fxdkMode", "0") == "1")
            {
                handle = "developer";
            }
            else if (handle == null)
            {
                handle = "default";
            }
            else
            {
                handle = handle.Replace(':', '_');
            }

            return $"{ConfigPath}{handle}.json";
        }

        private async void OnGetConfig([FromSource]Player source)
        {
            var path = GetConfigPathForPlayer(source);

            if (!File.Exists(path))
            {
                Debug.WriteLine($"{source.Name} requested a config from file {path} but it doesn't exist yet.");

                // Send a dummy so we trigger sending the menus to the UI
                TriggerClientEvent(source, "virakal:returnConfig", "{}");
                return;
            }

            using (var reader = File.OpenText(path))
            {
                var contents = await reader.ReadToEndAsync();
                Debug.WriteLine($"Sending config from {path} to player {source.Name}");
                TriggerClientEvent(source, "virakal:returnConfig", contents);
            }
        }

        private async void OnSetConfig([FromSource]Player source, string config)
        {
            var path = GetConfigPathForPlayer(source);

            if (!File.Exists(path))
            {
                Debug.WriteLine($"No config for user {source.Name} yet. Making one at {path}.");
            }

            using (var writer = new StreamWriter(path))
            {
                await writer.WriteAsync(config);
                Debug.WriteLine($"Sent config to {source.Name}. Config length: {config.Length}");
            }
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
