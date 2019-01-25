using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virakal.FiveM.Trainer.TrainerClient.Data;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class VehiclesMenuAdder : BaseMenuAdder
    {
        private Garage Garage { get; set; }
        private Config Config { get; set; }

        public VehiclesMenuAdder(Config config, Garage garage) : base()
        {
            Config = config;
            Garage = garage;
        }

        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["vehicles"] = GetVehiclesMenu();

            menus["vehicles.spawn"] = GetSpawnMenu();
            menus["vehicles.save"] = GetGarageSaveMenu();
            menus["vehicles.load"] = GetGarageLoadMenu();
            menus["vehicles.appearance"] = GetAppearanceMenu();
            menus["vehicles.mods"] = GetModsMenu();

            // Add vehicle spawn menus
            menus["vehicles.spawn.boats"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Boats));
            menus["vehicles.spawn.commercial"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Commercial));
            menus["vehicles.spawn.compacts"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Compacts));
            menus["vehicles.spawn.coupes"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Coupes));
            menus["vehicles.spawn.pushbikes"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Cycles));
            menus["vehicles.spawn.emergency"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Emergency));
            menus["vehicles.spawn.helicopters"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Helicopters));
            menus["vehicles.spawn.industrial"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Industrial));
            menus["vehicles.spawn.military"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Military));
            menus["vehicles.spawn.motorbikes"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Motorcycles));
            menus["vehicles.spawn.offRoad"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.OffRoad));
            menus["vehicles.spawn.planes"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Planes));
            menus["vehicles.spawn.service"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Service));
            menus["vehicles.spawn.super"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Super));
            menus["vehicles.spawn.utility"] = AddVehicleSpawnMenu(VehicleList.GetByVehicleClass(VehicleClass.Utility));

            menus["vehicles.spawn.fun"] = AddVehicleSpawnMenu(VehicleList.GetByTag("fun"));

            menus = AddSpawnByDlcMenus(menus);

            // Add vehicle appearance menus
            menus["vehicles.appearance.rainbowSettings"] = GetRainbowMenu();
            menus["vehicles.appearance.rainbowSettings.speed"] = GetRainbowSpeedMenu();
            menus["vehicles.boostPower"] = GetBoostPowerMenu();
            menus["vehicles.appearance.numberPlateSettings"] = GetPlatesMenu();
            menus["vehicles.appearance.windowTintSettings"] = GetWindowTintMenu();
            menus["vehicles.appearance.livery"] = GetLiveryMenu();
            menus["vehicles.appearance.roofLivery"] = GetRoofLiveryMenu();
            menus["vehicles.appearance.colourCombinations"] = GetColourCombinationsMenu();

            menus["vehicles.appearance.customBothColour"] = GetCustomColourMenu("vehcustomboth");
            menus["vehicles.appearance.customPrimaryColour"] = GetCustomColourMenu("vehcustomprimary");
            menus["vehicles.appearance.customSecondaryColour"] = GetCustomColourMenu("vehcustomsecondary");

            menus["vehicles.appearance.bothColour"] = GetPaintColourMenu("vehboth");
            menus["vehicles.appearance.primaryColour"] = GetPaintColourMenu("vehprimary");
            menus["vehicles.appearance.secondaryColour"] = GetPaintColourMenu("vehsecondary");
            menus["vehicles.appearance.pearlescentColour"] = GetPaintColourMenu("vehpearl");
            menus["vehicles.appearance.rimColour"] = GetPaintColourMenu("vehrim");
            menus["vehicles.appearance.dashColour"] = GetPaintColourMenu("vehdashcolour");
            menus["vehicles.appearance.trimColour"] = GetPaintColourMenu("vehtrimcolour");

            // Add mods menus
            menus["vehicles.mods.lights"] = GetModLightsMenu();
            menus["vehicles.mods.lights.neonColour"] = GetCustomColourMenu("vehneon");
            menus["vehicles.mods.performance"] = GetModPerformanceMenu();
            menus["vehicles.mods.wheels"] = GetModWheelsMenu();
            menus["vehicles.mods.wheels.tyreSmokeColour"] = GetCustomColourMenu("vehtyresmokecolour");

            return menus;
        }

        private List<MenuItem> GetModPerformanceMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Add Turbo",
                    action = "vehmod turboon"
                },
                new MenuItem()
                {
                    text = "Remove Turbo",
                    action = "vehmod turbooff"
                },
            };
        }

        private List<MenuItem> GetModWheelsMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Enable Tyre Smoke",
                    action = "vehmod tyresmokeon"
                },
                new MenuItem()
                {
                    text = "Disable Tyre Smoke",
                    action = "vehmod tyresmokeoff"
                },
                new MenuItem()
                {
                    text = "Tyre Smoke Colour",
                    sub = "vehicles.mods.wheels.tyreSmokeColour"
                },
            };
        }

        public List<MenuItem> GetModLightsMenu()
        {
            // Would be nice to autogen this and update this depending on available lights maybe
            var list = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Enable Xenon Headlights",
                    action = "vehmod xenonon"
                },
                new MenuItem()
                {
                    text = "Disable Xenon Headlights",
                    action = "vehmod xenonoff"
                },
                new MenuItem()
                {
                    text = "All Neons On",
                    action = "vehneon allon"
                },
                new MenuItem()
                {
                    text = "All Neons Off",
                    action = "vehneon alloff"
                },
                new MenuItem()
                {
                    text = "Change Neon Colour",
                    sub = "vehicles.mods.lights.neonColour"
                },
            };

            foreach (var light in Enum.GetValues(typeof(VehicleNeonLight)))
            {
                list.Add(new MenuItem()
                {
                    text = $"Enable {light} Neon",
                    action = $"vehneon on{(int)light}",
                });
            }

            foreach (var light in Enum.GetValues(typeof(VehicleNeonLight)))
            {
                list.Add(new MenuItem()
                {
                    text = $"Disable {light} Neon",
                    action = $"vehneon off{(int)light}",
                });
            }

            return list;
        }

        private Dictionary<string, List<MenuItem>> AddSpawnByDlcMenus(Dictionary<string, List<MenuItem>> menus)
        {
            List<MenuItem> dlcMenuList = new List<MenuItem>();

            foreach (Dlc dlc in Enum.GetValues(typeof(Dlc)))
            {
                string submenuName = $"vehicles.spawn.dlc.{dlc.ToString().ToLower()}";

                dlcMenuList.Add(new MenuItem()
                {
                    text = dlc.GetTitle(),
                    sub = submenuName,
                });

                menus[submenuName] = AddVehicleSpawnMenu(VehicleList.GetByDlc(dlc));

                if (menus[submenuName].Count == 0)
                {
                    menus[submenuName].Add(new MenuItem()
                    {
                        text = "No vehicles added for this DLC yet"
                    });
                }
            }

            // Put the newer DLC at the top since they tend to be more interesting
            dlcMenuList.Reverse();

            menus["vehicles.spawn.dlc"] = dlcMenuList;

            return menus;
        }

        private List<MenuItem> AddVehicleSpawnMenu(IEnumerable<VehicleListItem> vehicleList)
        {
            List<MenuItem> list = new List<MenuItem>();

            foreach (var item in vehicleList)
            {
                list.Add(new MenuItem()
                {
                    text = item.Name,
                    action = $"vehspawn {item.Model}",
                    image = item.Image,
                });
            }

            return list;
        }

        private List<MenuItem> GetSpawnMenu()
        {
            // Another auto-generated one for the future
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Spawn Fun Stuff",
                    sub = "vehicles.spawn.fun"
                },
                new MenuItem()
                {
                    text = "Spawn Boat",
                    sub = "vehicles.spawn.boats"
                },
                new MenuItem()
                {
                    text = "Spawn Commercial Vehicles",
                    sub = "vehicles.spawn.commercial"
                },
                new MenuItem()
                {
                    text = "Spawn Compact Vehicles",
                    sub = "vehicles.spawn.compacts"
                },
                new MenuItem()
                {
                    text = "Spawn Coupés",
                    sub = "vehicles.spawn.coupes"
                },
                new MenuItem()
                {
                    text = "Spawn Emergency Vehicles",
                    sub = "vehicles.spawn.emergency"
                },
                new MenuItem()
                {
                    text = "Spawn Helicopter",
                    sub = "vehicles.spawn.helicopters"
                },
                new MenuItem()
                {
                    text = "Spawn Industrial",
                    sub = "vehicles.spawn.industrial"
                },
                new MenuItem()
                {
                    text = "Spawn Military",
                    sub = "vehicles.spawn.military"
                },
                new MenuItem()
                {
                    text = "Spawn Motorbike",
                    sub = "vehicles.spawn.motorbikes"
                },
                new MenuItem()
                {
                    text = "Spawn Off-Road Vehicles",
                    sub = "vehicles.spawn.offRoad"
                },
                new MenuItem()
                {
                    text = "Spawn Plane",
                    sub = "vehicles.spawn.planes"
                },
                new MenuItem()
                {
                    text = "Spawn Pushbike",
                    sub = "vehicles.spawn.pushbikes"
                },
                new MenuItem()
                {
                    text = "Spawn Service Vehicles",
                    sub = "vehicles.spawn.service"
                },
                new MenuItem()
                {
                    text = "Spawn Supercar",
                    sub = "vehicles.spawn.super"
                },
                new MenuItem()
                {
                    text = "Spawn Utility Vehicles",
                    sub = "vehicles.spawn.utility"
                },
                new MenuItem()
                {
                    text = "Spawn Vehicle by Name",
                    action = "vehspawn input"
                },
                new MenuItem()
                {
                    text = "Spawn Vehicle by DLC",
                    sub = "vehicles.spawn.dlc"
                },
                new MenuItem()
                {
                    text = "Automatic Despawn",
                    action = "vehspawn despawn",
                    state = "ON",
                    configkey = "AutoDespawnVehicle"
                },
                new MenuItem()
                {
                    text = "Spawn Inside Vehicle",
                    action = "vehspawn spawninveh",
                    state = "ON",
                    configkey = "SpawnInVehicle"
                },
            };
        }

        private List<MenuItem> GetRainbowMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Rainbow Car",
                    action = "veh rainbowcar",
                    state = "OFF",
                    configkey = "RainbowPaint"
                },
                new MenuItem()
                {
                    text = "Rainbow Chrome Car",
                    action = "veh rainbowchrome",
                    state = "OFF",
                    configkey = "RainbowChrome"
                },
                new MenuItem()
                {
                    text = "Rainbow Neons",
                    action = "veh rainbowneon",
                    state = "OFF",
                    configkey = "RainbowNeon"
                },
                new MenuItem()
                {
                    text = "Rainbow Neons (Inverse)",
                    action = "veh rainbowneoninverse",
                    state = "OFF",
                    configkey = "RainbowNeonInverse"
                },
                new MenuItem()
                {
                    text = "Rainbow Speed",
                    sub = "vehicles.appearance.rainbowSettings.speed"
                },
            };
        }

        private List<MenuItem> GetAppearanceMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Both Custom Colour",
                    sub = "vehicles.appearance.customBothColour"
                },
                new MenuItem()
                {
                    text = "Custom Primary Colour",
                    sub = "vehicles.appearance.customPrimaryColour"
                },
                new MenuItem()
                {
                    text = "Custom Secondary Colour",
                    sub = "vehicles.appearance.customSecondaryColour"
                },
                new MenuItem()
                {
                    text = "Both Paint Colour",
                    sub = "vehicles.appearance.bothColour"
                },
                new MenuItem()
                {
                    text = "Paint Primary Colour",
                    sub = "vehicles.appearance.primaryColour"
                },
                new MenuItem()
                {
                    text = "Paint Secondary Colour",
                    sub = "vehicles.appearance.secondaryColour"
                },
                new MenuItem()
                {
                    text = "Pearlescent Colour",
                    sub = "vehicles.appearance.pearlescentColour"
                },
                new MenuItem()
                {
                    text = "Rim Colour",
                    sub = "vehicles.appearance.rimColour"
                },
                new MenuItem()
                {
                    text = "Dashboard Colour",
                    sub = "vehicles.appearance.dashColour"
                },
                new MenuItem()
                {
                    text = "Trim Colour",
                    sub = "vehicles.appearance.trimColour"
                },
                new MenuItem()
                {
                    text = "Colour Combinations",
                    sub = "vehicles.appearance.colourCombinations"
                },
                new MenuItem()
                {
                    text = "Window Tint",
                    sub = "vehicles.appearance.windowTintSettings"
                },
                new MenuItem()
                {
                    text = "Vehicle Livery",
                    sub = "vehicles.appearance.livery"
                },
                new MenuItem()
                {
                    text = "Roof Livery",
                    sub = "vehicles.appearance.roofLivery"
                },
                new MenuItem()
                {
                    text = "Number Plates",
                    sub = "vehicles.appearance.numberPlateSettings"
                },
                new MenuItem()
                {
                    text = "Rainbow Car Settings",
                    sub = "vehicles.appearance.rainbowSettings"
                },
            };
        }

        private List<MenuItem> GetModsMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Quick Upgrade",
                    action = "vehmod quickupgrade"
                },
                new MenuItem()
                {
                    text = "Neons & Lights",
                    sub = "vehicles.mods.lights"
                },
                new MenuItem()
                {
                    text = "Performance",
                    sub = "vehicles.mods.performance"
                },
                new MenuItem()
                {
                    text = "Wheels & Tyres",
                    sub = "vehicles.mods.wheels"
                },
            };
        }

        private List<MenuItem> GetVehiclesMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Spawn Vehicle",
                    sub = "vehicles.spawn"
                },
                new MenuItem()
                {
                    text = "Load Vehicle from Garage",
                    sub = "vehicles.load"
                },
                new MenuItem()
                {
                    text = "Save Vehicle to Garage",
                    sub = "vehicles.save"
                },
                new MenuItem()
                {
                    text = "Vehicle Appearance",
                    sub = "vehicles.appearance"
                },
                new MenuItem()
                {
                    text = "Vehicle Mods",
                    sub = "vehicles.mods"
                },
                new MenuItem()
                {
                    text = "Fix Vehicle",
                    action = "veh fix"
                },
                new MenuItem()
                {
                    text = "Clean Vehicle",
                    action = "veh clean"
                },
                new MenuItem()
                {
                    text = "Flip Vehicle Onto Wheels",
                    action = "veh flip"
                },
                new MenuItem()
                {
                    text = "Invincible Vehicle",
                    action = "veh invincible",
                    state = "ON",
                    configkey = "InvincibleVehicle"
                },
                new MenuItem()
                {
                    text = "Boost on Horn",
                    action = "veh boosthorn",
                    state = "ON",
                    configkey = "BoostOnHorn"
                },
                new MenuItem()
                {
                    text = "Boost Power",
                    sub = "vehicles.boostPower"
                },
            };
        }

        public List<MenuItem> GetGarageSaveMenu()
        {
            return GetGarageMenu("vehsave", "Save in Slot");
        }

        public List<MenuItem> GetGarageLoadMenu()
        {
            return GetGarageMenu("vehload", "Load Slot");
        }

        private List<MenuItem> GetGarageMenu(string actionPrefix, string namePrefix)
        {
            var list = new List<MenuItem>(Garage.MaxVehicleSlots);

            for (var i = 1; i <= Garage.MaxVehicleSlots; i++)
            {
                string vehicleName = "Empty";
                string slot = i.ToString();
                string image = "";

                if (Garage.HasSavedVehicle(slot))
                {
                    var slotInfo = Garage.GetVehicleInfo(slot);
                    vehicleName = slotInfo.displayName;

                    VehicleListItem listItem = VehicleList.FindItemByHash(slotInfo.model);

                    if (listItem != null)
                    {
                        image = listItem.Image;
                    }
                }

                list.Add(new MenuItem()
                {
                    text = $"{namePrefix} {i} ({vehicleName})",
                    action = $"{actionPrefix} {i}",
                    image = image,
                });
            }

            return list;
        }

        public List<MenuItem> GetLiveryMenu()
        {
            var vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                return new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        text = "Enter a vehicle to view liveries",
                    }
                };
            }

            var mods = vehicle.Mods;

            mods.InstallModKit();

            if (mods.LiveryCount < 1)
            {
                return new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        text = "This vehicle doesn't support liveries",
                    }
                };
            }

            // Get a list of liveries from the mod collection
            var list = new List<MenuItem>(26)
            {
                new MenuItem()
                {
                    text = "No Livery",
                    action = $"vehlivery -1",
                }
            };

            for (var i = 0; i < mods.LiveryCount; i++)
            {
                var name = mods.GetLocalizedLiveryName(i);

                list.Add(new MenuItem()
                {
                    text = name == "" ? $"Livery {i}" : name,
                    action = $"vehlivery {i}",
                });
            }

            return list;
        }

        public List<MenuItem> GetColourCombinationsMenu()
        {
            var vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                return new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        text = "Enter a vehicle to view colour combinations",
                    }
                };
            }

            var mods = vehicle.Mods;

            mods.InstallModKit();

            if (mods.ColorCombinationCount < 1)
            {
                return new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        text = "This vehicle doesn't support colour combinations",
                    }
                };
            }
            
            // Get a list of liveries from the mod collection
            var list = new List<MenuItem>();

            for (var i = 1; i <= mods.ColorCombinationCount; i++)
            {
                list.Add(new MenuItem()
                {
                    text = $"Colour Combination {i}",
                    action = $"vehcolourcombo {i}",
                });
            }

            return list;
        }

        private List<MenuItem> GetRoofLiveryMenu()
        {
            var list = new List<MenuItem>(26)
            {
                new MenuItem()
                {
                    text = "No Livery",
                    action = $"vehrooflivery -1",
                }
            };

            for (var i = 0; i < 25; i++)
            {
                list.Add(new MenuItem()
                {
                    text = $"Livery {i}",
                    action = $"vehrooflivery {i}",
                });
            }

            return list;
        }

        private List<MenuItem> GetWindowTintMenu()
        {
            var list = new List<MenuItem>(10);

            foreach (var tint in Enum.GetValues(typeof(VehicleWindowTint)))
            {
                list.Add(new MenuItem()
                {
                    text = CleanColourName(tint.ToString()),
                    action = $"vehtint {(int)tint}",
                });
            }

            return list;
        }

        private List<MenuItem> GetRainbowSpeedMenu()
        {
            //return new List<MenuItem>();
            // We can automate this soon and add a spcifier for the current speed
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "10% Speed",
                    action = "rainbowspeed 0.1"
                },
                new MenuItem()
                {
                    text = "20% Speed",
                    action = "rainbowspeed 0.2"
                },
                new MenuItem()
                {
                    text = "30% Speed",
                    action = "rainbowspeed 0.3"
                },
                new MenuItem()
                {
                    text = "40% Speed",
                    action = "rainbowspeed 0.4"
                },
                new MenuItem()
                {
                    text = "50% Speed (Default)",
                    action = "rainbowspeed 0.5"
                },
                new MenuItem()
                {
                    text = "60% Speed",
                    action = "rainbowspeed 0.6"
                },
                new MenuItem()
                {
                    text = "70% Speed",
                    action = "rainbowspeed 0.7"
                },
                new MenuItem()
                {
                    text = "80% Speed",
                    action = "rainbowspeed 0.8"
                },
                new MenuItem()
                {
                    text = "90% Speed",
                    action = "rainbowspeed 0.9"
                },
                new MenuItem()
                {
                    text = "100% Speed",
                    action = "rainbowspeed 1.0"
                },
            };
        }

        private List<MenuItem> GetBoostPowerMenu()
        {
            // Another one to auto-generate and highlight the current option
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "25",
                    action = "boostpower 25"
                },
                new MenuItem()
                {
                    text = "50",
                    action = "boostpower 50"
                },
                new MenuItem()
                {
                    text = "75 (Default)",
                    action = "boostpower 75"
                },
                new MenuItem()
                {
                    text = "100",
                    action = "boostpower 100"
                },
                new MenuItem()
                {
                    text = "125",
                    action = "boostpower 125"
                },
                new MenuItem()
                {
                    text = "150",
                    action = "boostpower 150"
                },
            };
        }

        private List<MenuItem> GetPlatesMenu()
        {
            var list = new List<MenuItem>();

            var plateStyles = new List<string>();

            foreach (var style in Enum.GetValues(typeof(LicensePlateStyle))) {
                var name = AddSpacesToSentence(style.ToString());

                list.Add(new MenuItem()
                {
                    text = $"Style: {name}",
                    action = $"vehplatestyle {(int)style}",
                });
            }

            list.Sort((x, y) => x.text.CompareTo(y.text));

            list.Insert(0, new MenuItem()
            {
                text = "Change Text",
                action = "vehplatetext"
            });

            return list;
        }

        private List<MenuItem> GetPaintColourMenu(string actionPrefix)
        {
            var list = new List<MenuItem>(170);

            foreach (var colour in Enum.GetValues(typeof(VehicleColor)))
            {
                list.Add(new MenuItem()
                {
                    text = CleanColourName(colour.ToString()),
                    action = $"{actionPrefix} {(int)colour}",
                });
            }

            return list;
        }

        private List<MenuItem> GetCustomColourMenu(string actionPrefix)
        {
            var list = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Custom (HTML #RRGGBB or R,G,B)",
                    action = $"{actionPrefix} input"
                },
            };

            foreach (var kv in CustomColourList.Colours)
            {
                string colourName = kv.Key;
                string colourHex = kv.Value;
                var colour = CustomColourList.GetByName(colourName);
                var rgb = $"{colour.R},{colour.G},{colour.B}";

                list.Add(new MenuItem()
                {
                    text = AddSpacesToSentence(colourName),
                    action = $"{actionPrefix} {rgb}",
                    image = MakeDummyImageUrl(colourHex),
                });
            }

            return list;
        }

        private string MakeDummyImageUrl(string hex)
        {
            int width = 350;
            int height = 200;
            hex = hex.Substring(1);

            return $"https://dummyimage.com/{width}x{height}/{hex}/{hex}.png&text=Sample";
        }

        private string CleanColourName(string colourName)
        {
            colourName = colourName.Replace("Util", "Utility");
            colourName = colourName.Replace("Metallic", "");
            colourName = AddSpacesToSentence(colourName);

            return colourName;
        }

        private string AddSpacesToSentence(string text)
        {
            var preserveAcronyms = false;

            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            StringBuilder newText = new StringBuilder(text.Length * 2);

            newText.Append(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {

                    if (
                        (text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                    {
                        newText.Append(' ');
                    }
                }

                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}
