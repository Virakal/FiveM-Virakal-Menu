using CitizenFX.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Garage
    {
        public const string ConfigKeyPrefix = "VehicleSlot";
        public const int MaxVehicleSlots = 10;
        private const string Sep = "<||>";
        private const int CurrentSerialVersion = 2;

        private Trainer Trainer { get; }
        private Config Config { get; }

        public Garage(Trainer trainer)
        {
            Trainer = trainer;
            Config = Trainer.Config;
        }

        public bool HasSavedVehicle(string slot) => Config.ContainsKey(GetGarageSlotName(slot));
        private string GetGarageSlotName(string slot) => $"{ConfigKeyPrefix}{slot}";

        public void SaveVehicle(string slot, Vehicle vehicle)
        {
            string configName = GetGarageSlotName(slot);
            string modString = ToModString(vehicle.Mods);
            string modelName = vehicle.LocalizedName;

            Config[configName] = $"v{CurrentSerialVersion}{Sep}{vehicle.Model.Hash}{Sep}{modelName}{Sep}{modString}";

            Trainer.DebugLine($"Saved to car to {configName}");
        }

        public GarageSlotInfo GetVehicleInfo(string slot)
        {
            string configName = GetGarageSlotName(slot);
            string loaded = Config[configName];

            return DeserialiseVehicleInfo(loaded);
        }

        public async Task<Vehicle> LoadVehicle(string slot)
        {
            string configName = GetGarageSlotName(slot);
            GarageSlotInfo info = GetVehicleInfo(slot);
            var vehicle = await Trainer.SpawnVehicle(new Model(info.model), Game.PlayerPed.Position);

            ApplyModString(vehicle, info.modString);

            Trainer.DebugLine($"Loaded from {configName}. Name: {info.displayName} Model: {info.model}");

            return vehicle;
        }

        private GarageSlotInfo DeserialiseVehicleInfo(string text)
        {
            string[] split = text.Split(new string[] { Sep }, StringSplitOptions.None);
            int version;

            if (split[0].StartsWith("v"))
            {
                version = int.Parse(split[0].Substring(1));
            }
            else
            {
                // First version had no version number
                version = 1;
            }

            switch (version)
            {
                case 1:
                    return new GarageSlotInfo(split[0], "Unknown", split[1]);
                case 2:
                    return new GarageSlotInfo(split[1], split[2], split[3]);
                default:
                    throw new SerializationException("Failed to deserialise garage vehicle - not sure of the version.");
            }
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
            modList["TrimColour"] = Convert.ToString((int)mods.TrimColor);
            modList["ColourCombo"] = Convert.ToString(mods.ColorCombination);
            modList["WheelType"] = Convert.ToString((int)mods.WheelType);

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

            if (modList.ContainsKey("ColourCombo"))
            {
                Trainer.DebugLine($"Setting Colour Combination to {modList["ColourCombo"]}");
                var combo = int.Parse(modList["ColourCombo"]);
                mods.ColorCombination = combo;
            }

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

            if (modList.ContainsKey("TrimColour"))
            {
                Trainer.DebugLine($"Setting TrimColour to {modList["TrimColour"]}");
                var trimColour = int.Parse(modList["TrimColour"]);
                mods.TrimColor = (VehicleColor)trimColour;
            }

            if (modList.ContainsKey("WheelType"))
            {
                Trainer.DebugLine($"Setting wheel type to {modList["WheelType"]}");
                var wheelType = int.Parse(modList["WheelType"]);
                mods.WheelType = (VehicleWheelType)wheelType;
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
