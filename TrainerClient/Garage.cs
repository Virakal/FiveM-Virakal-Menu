using CitizenFX.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Garage
    {

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
            Debug.WriteLine($"Saved to {configName}: {Config[configName]}");
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

            Debug.WriteLine($"Loaded from {configName}: Model: {model} Mods: {modString}");

            return vehicle;
        }

        private string ToModString(VehicleModCollection mods)
        {
            var modList = new Dictionary<string, string>();

            if (mods.IsPrimaryColorCustom)
            {
                modList["CustomPrimary"] = $"{mods.CustomPrimaryColor.R},{mods.CustomPrimaryColor.G},{mods.CustomPrimaryColor.B}";
            }
            else
            {
                modList["PrimaryColour"] = Convert.ToString((int)mods.PrimaryColor);
            }

            if (mods.IsSecondaryColorCustom)
            {
                modList["CustomSecondary"] = $"{mods.CustomSecondaryColor.R},{mods.CustomSecondaryColor.G},{mods.CustomSecondaryColor.B}";
            }
            else
            {
                modList["SecondaryColour"] = Convert.ToString((int)mods.SecondaryColor);
            }

            modList["PearlescentColour"] = Convert.ToString((int)mods.PearlescentColor);
            modList["Livery"] = Convert.ToString(mods.Livery);
            modList["PlateText"] = mods.LicensePlate;
            modList["PlateStyle"] = Convert.ToString((int)mods.LicensePlateStyle);

            return JsonConvert.SerializeObject(modList);
        }

        private void ApplyModString(Vehicle vehicle, string modString)
        {
            var modList = JsonConvert.DeserializeObject<Dictionary<string, string>>(modString);
            VehicleModCollection mods = vehicle.Mods;

            if (modList.ContainsKey("CustomPrimary"))
            {
                var colour = Trainer.CommaSeparatedStringToColor(modList["CustomPrimary"]);
                mods.CustomPrimaryColor = colour;
            }

            if (modList.ContainsKey("PrimaryColour"))
            {
                var primary = int.Parse(modList["PrimaryColour"]);
                mods.PrimaryColor = (VehicleColor)primary;
            }

            if (modList.ContainsKey("CustomSecondary"))
            {
                var colour = Trainer.CommaSeparatedStringToColor(modList["CustomSecondary"]);
                mods.CustomSecondaryColor = colour;
            }

            if (modList.ContainsKey("SecondaryColour"))
            {
                var secondary = int.Parse(modList["SecondaryColour"]);
                mods.SecondaryColor = (VehicleColor)secondary;
            }

            if (modList.ContainsKey("PearlescentColour"))
            {
                var pearlescent = int.Parse(modList["PearlescentColour"]);
                mods.PearlescentColor = (VehicleColor)pearlescent;
            }

            if (modList.ContainsKey("Livery"))
            {
                var livery = int.Parse(modList["Livery"]);
                mods.Livery = livery;
            }

            if (modList.ContainsKey("PlateText"))
            {
                mods.LicensePlate = modList["PlateText"];
            }

            if (modList.ContainsKey("PlateStyle"))
            {
                var plateStyle = int.Parse(modList["PlateStyle"]);
                mods.LicensePlateStyle = (LicensePlateStyle)plateStyle;
            }
        }
    }
}
