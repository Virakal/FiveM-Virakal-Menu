using CitizenFX.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Garage
    {
        public static int MaxCarSlots { get; } = 10;
        private string Sep { get; } = "<||>";
        private Trainer Trainer{ get; }
        private Config Config { get; }

        public Garage(Trainer trainer)
        {
            Trainer = trainer;
            Config = Trainer.Config;
        }

        public bool HasSavedVehicle(string slot) => Config.ContainsKey(GetGarageSlotName(slot));
        private string GetGarageSlotName(string slot) => $"VehicleSlot{slot}";

        public void SaveVehicle(string slot, Vehicle vehicle)
        {
            string configName = GetGarageSlotName(slot);
            string modString = ToModString(vehicle.Mods);
            Config[configName] = $"{vehicle.Model.Hash}{Sep}{modString}";
            Trainer.DebugLine($"Saved to car to {configName}");
        }

        public async Task<Vehicle> LoadVehicle(string slot)
        {
            string sep = "<||>";
            string configName = GetGarageSlotName(slot);
            string loaded = Config[configName];
            string[] split = loaded.Split(new string[] { sep }, StringSplitOptions.None);
            string model = split[0];
            string modString = split[1];

            var vehicle = await Trainer.SpawnVehicle(new Model(int.Parse(model)), Game.PlayerPed.Position);

            ApplyModString(vehicle, modString);

            Trainer.DebugLine($"Loaded from {configName}: Model: {model}");

            return vehicle;
        }

        private string ToModString(VehicleModCollection mods)
        {
            var modList = new Dictionary<string, string>();

            if (mods.IsPrimaryColorCustom)
            {
                modList["CustomPrimary"] = Trainer.ColorToRgbString(mods.CustomPrimaryColor);
            }
            else
            {
                modList["PrimaryColour"] = Convert.ToString((int)mods.PrimaryColor);
            }

            if (mods.IsSecondaryColorCustom)
            {
                modList["CustomSecondary"] = Trainer.ColorToRgbString(mods.CustomSecondaryColor);
            }
            else
            {
                modList["SecondaryColour"] = Convert.ToString((int)mods.SecondaryColor);
            }

            modList["PearlescentColour"] = Convert.ToString((int)mods.PearlescentColor);
            modList["Livery"] = Convert.ToString(mods.Livery);
            modList["PlateText"] = mods.LicensePlate;
            modList["PlateStyle"] = Convert.ToString((int)mods.LicensePlateStyle);
            modList["RimColour"] = Convert.ToString((int)mods.RimColor);
            modList["WindowTint"] = Convert.ToString((int)mods.WindowTint);
            modList["DashboardColour"] = Convert.ToString((int)mods.DashboardColor);
            modList["NeonColour"] = Trainer.ColorToRgbString(mods.NeonLightsColor);
            modList["TyreSmokeColour"] = Trainer.ColorToRgbString(mods.TireSmokeColor);
            modList["TyreSmoke"] = mods[VehicleToggleModType.TireSmoke].IsInstalled ? "true" : "false";
            modList["Turbo"] = mods[VehicleToggleModType.Turbo].IsInstalled ? "true" : "false";
            modList["XenonHeadlights"] = mods[VehicleToggleModType.XenonHeadlights].IsInstalled ? "true" : "false";

            for (var i = 0; i < 4; i++)
            {
                modList[$"NeonEnabled{i}"] = mods.IsNeonLightsOn((VehicleNeonLight)i) ? "true" : "false";
            }

            foreach (var mod in mods.GetAllMods())
            {
                var modTypeInt = (int)mod.ModType;
                modList[$"Mod#{modTypeInt}"] = Convert.ToString(mod.Index);
            }

            return JsonConvert.SerializeObject(modList);
        }

        private async void ApplyModString(Vehicle vehicle, string modString)
        {
            var modList = JsonConvert.DeserializeObject<Dictionary<string, string>>(modString);
            VehicleModCollection mods = vehicle.Mods;

            if (modList.ContainsKey("CustomPrimary"))
            {
                Trainer.DebugLine($"Setting CustomPrimary to {modList["CustomPrimary"]}");
                var colour = Trainer.CommaSeparatedStringToColor(modList["CustomPrimary"]);
                mods.CustomPrimaryColor = colour;
            }

            if (modList.ContainsKey("PrimaryColour"))
            {
                Trainer.DebugLine($"Setting PrimaryColour to {modList["PrimaryColour"]}");
                var primary = int.Parse(modList["PrimaryColour"]);
                mods.PrimaryColor = (VehicleColor)primary;
            }

            if (modList.ContainsKey("CustomSecondary"))
            {
                Trainer.DebugLine($"Setting CustomSecondary to {modList["CustomSecondary"]}");
                var colour = Trainer.CommaSeparatedStringToColor(modList["CustomSecondary"]);
                mods.CustomSecondaryColor = colour;
            }

            if (modList.ContainsKey("SecondaryColour"))
            {
                Trainer.DebugLine($"Setting SecondaryColour to {modList["SecondaryColour"]}");
                var secondary = int.Parse(modList["SecondaryColour"]);
                mods.SecondaryColor = (VehicleColor)secondary;
            }

            if (modList.ContainsKey("PearlescentColour"))
            {
                Trainer.DebugLine($"Setting PearlescentColour to {modList["PearlescentColour"]}");
                var pearlescent = int.Parse(modList["PearlescentColour"]);
                mods.PearlescentColor = (VehicleColor)pearlescent;
            }

            if (modList.ContainsKey("Livery"))
            {
                Trainer.DebugLine($"Setting Livery to {modList["Livery"]}");
                var livery = int.Parse(modList["Livery"]);
                mods.Livery = livery;
            }

            if (modList.ContainsKey("PlateText"))
            {
                Trainer.DebugLine($"Setting PlateText to {modList["PlateText"]}");
                mods.LicensePlate = modList["PlateText"];
            }

            if (modList.ContainsKey("PlateStyle"))
            {
                Trainer.DebugLine($"Setting PlateStyle to {modList["PlateStyle"]}");
                var plateStyle = int.Parse(modList["PlateStyle"]);
                mods.LicensePlateStyle = (LicensePlateStyle)plateStyle;
            }

            if (modList.ContainsKey("RimColour"))
            {
                Trainer.DebugLine($"Setting RimColour to {modList["RimColour"]}");
                var rimColour = int.Parse(modList["RimColour"]);
                mods.RimColor = (VehicleColor)rimColour;
            }

            // Installing the modkit allows additional mods
            mods.InstallModKit();

            await BaseScript.Delay(0);

            if (modList.ContainsKey("WindowTint"))
            {
                Trainer.DebugLine($"Setting WindowTint to {modList["WindowTint"]}");
                var windowTint = int.Parse(modList["WindowTint"]);
                mods.WindowTint = (VehicleWindowTint)windowTint;
            }

            if (modList.ContainsKey("DashboardColour"))
            {
                Trainer.DebugLine($"Setting DashboardColour to {modList["DashboardColour"]}");
                var dashboardColour = int.Parse(modList["DashboardColour"]);
                mods.DashboardColor = (VehicleColor)dashboardColour;
            }

            if (modList.ContainsKey("NeonColour"))
            {
                Trainer.DebugLine($"Setting NeonColour to {modList["NeonColour"]}");
                var colour = Trainer.CommaSeparatedStringToColor(modList["NeonColour"]);
                mods.NeonLightsColor = colour;
            }

            if (modList.ContainsKey("TyreSmokeColour"))
            {
                Trainer.DebugLine($"Setting TyreSmokeColour to {modList["TyreSmokeColour"]}");
                var colour = Trainer.CommaSeparatedStringToColor(modList["TyreSmokeColour"]);
                mods.TireSmokeColor = colour;
            }

            for (var i = 0; i < 4; i++)
            {
                if (modList.ContainsKey($"NeonEnabled{i}"))
                {
                    Trainer.DebugLine($"Setting NeonEnabled{i} to {modList[$"NeonEnabled{i}"]}");
                    mods.SetNeonLightsOn((VehicleNeonLight)i, modList[$"NeonEnabled{i}"] == "true");
                }
                else
                {
                    // We don't know about this neon so assume it isn't on
                    Trainer.DebugLine($"Skipping NeonEnabled{i} because it isn't set");
                    mods.SetNeonLightsOn((VehicleNeonLight)i, false);
                }
            }

            if (modList.ContainsKey("TyreSmoke"))
            {
                Trainer.DebugLine($"Setting TyreSmoke to {modList["TyreSmoke"]}");
                mods[VehicleToggleModType.TireSmoke].IsInstalled = modList["TyreSmoke"] == "true";
            }

            if (modList.ContainsKey("Turbo"))
            {
                Trainer.DebugLine($"Setting Turbo to {modList["Turbo"]}");
                mods[VehicleToggleModType.Turbo].IsInstalled = modList["Turbo"] == "true";
            }

            if (modList.ContainsKey("XenonHeadlights"))
            {
                Trainer.DebugLine($"Setting XenonHeadlights to {modList["XenonHeadlights"]}");
                mods[VehicleToggleModType.XenonHeadlights].IsInstalled = modList["XenonHeadlights"] == "true";
            }

            var modPrefix = "Mod#";

            Trainer.DebugLine("Starting applying mods");

            foreach (KeyValuePair<string, string> kv in modList)
            {
                if (kv.Key.StartsWith(modPrefix))
                {
                    var modTypeInt = int.Parse(kv.Key.Substring(modPrefix.Length));
                    var modType = (VehicleModType)modTypeInt;
                    mods[modType].Index = Convert.ToInt32(kv.Value);
                    Trainer.DebugLine($"Setting mod {modTypeInt} ({modType}) ({mods[modType].LocalizedModTypeName}) to {kv.Value} ({mods[modType].LocalizedModName})");
                }
            }

            Trainer.DebugLine("Finished applying mods");
        }
    }
}
