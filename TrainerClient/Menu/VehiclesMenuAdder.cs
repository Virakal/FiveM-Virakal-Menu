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
            menus["vehicles.boostPower"] = GetBoostPowerMenu();

            // Add vehicle spawn menus
            menus["vehicles.spawn.search"] = GetSpawnSearchMenu();
            menus = AddSpawnByTypeMenus(menus);
            menus = AddSpawnByDlcMenus(menus);
            menus["vehicles.spawn.fun"] = GetVehicleSpawnMenu(VehicleList.GetByTag("fun"));

            // Add vehicle appearance menus
            menus["vehicles.appearance.rainbowSettings"] = GetRainbowMenu();
            menus["vehicles.appearance.rainbowSettings.speed"] = GetRainbowSpeedMenu();
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
            menus = AddOtherModsMenus(menus);

            return menus;
        }

        public Dictionary<string, List<MenuItem>> AddOtherModsMenus(Dictionary<string, List<MenuItem>> menus)
        {
            foreach (var kv in GetOtherModsMenus())
            {
                menus[kv.Key] = kv.Value;
            }

            return menus;
        }

        public Dictionary<string, List<MenuItem>> GetOtherModsMenus()
        {
            var menus = new Dictionary<string, List<MenuItem>>();

            Vehicle vehicle = Game.PlayerPed.CurrentVehicle;

            if (vehicle == null)
            {
                menus["vehicles.mods.other"] = new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        text = "Please enter a vehicle to view mods",
                    }
                };
            }
            else
            {
                VehicleModCollection mods = vehicle.Mods;

                var modTypeMenu = new List<MenuItem>();

                foreach (var mod in mods.GetAllMods())
                {
                    var modMenu = new List<MenuItem>();

                    for (var i = -1; i < mod.ModCount; i++)
                    {
                        var name = mod.GetLocalizedModName(i);

                        if (name == string.Empty)
                        {
                            name = $"{mod.LocalizedModTypeName} {i}";
                        }

                        if (mod.Index == i)
                        {
                            name += " (Current)";
                        }

                        modMenu.Add(new MenuItem()
                        {
                            text = name,
                            action = $"vehmodother {(int)mod.ModType}={i}",
                        });
                    }

                    menus[$"vehicles.mods.other.{mod.ModType}"] = modMenu;

                    modTypeMenu.Add(new MenuItem()
                    {
                        text = mod.LocalizedModTypeName,
                        sub = $"vehicles.mods.other.{mod.ModType}",
                    });
                }

                modTypeMenu.Sort((x, y) => x.text.CompareTo(y.text));

                menus["vehicles.mods.other"] = modTypeMenu;
            }

            return menus;
        }

        public List<MenuItem> GetSpawnSearchMenu()
        {
            var list = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Search for a name...",
                    action = "vehsearch",
                }
            };
            
            if (Config.ContainsKey("VehicleSpawnSearchTerm"))
            {
                var term = Config["VehicleSpawnSearchTerm"];
                term = term.ToLower();

                list.AddRange(GetVehicleSpawnMenu(VehicleList.GetBySearchTerm(term)));
            }

            return list;
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

                menus[submenuName] = GetVehicleSpawnMenu(VehicleList.GetByDlc(dlc));

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

        private Dictionary<string, List<MenuItem>> AddSpawnByTypeMenus(Dictionary<string, List<MenuItem>> menus)
        {
            var typeMenuList = new List<MenuItem>();

            foreach (VehicleClass vehicleClass in Enum.GetValues(typeof(VehicleClass)))
            {
                string submenuName = $"vehicles.spawn.type.{vehicleClass.ToString().ToLower()}";

                typeMenuList.Add(new MenuItem()
                {
                    text = Trainer.AddSpacesToSentence(vehicleClass.ToString()),
                    sub = submenuName,
                });

                menus[submenuName] = GetVehicleSpawnMenu(VehicleList.GetByVehicleClass(vehicleClass));

                if (menus[submenuName].Count == 0)
                {
                    menus[submenuName].Add(new MenuItem()
                    {
                        text = "No vehicles of this type added yet",
                    });
                }
            }

            typeMenuList = typeMenuList.OrderBy(x => x.text).ToList();

            menus["vehicles.spawn.type"] = typeMenuList;

            return menus;
        }

        private List<MenuItem> GetVehicleSpawnMenu(IEnumerable<VehicleListItem> vehicleList)
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
                    text = "Spawn by Searching",
                    sub = "vehicles.spawn.search"
                },
                new MenuItem()
                {
                    text = "Spawn Fun Stuff",
                    sub = "vehicles.spawn.fun"
                },
                new MenuItem()
                {
                    text = "Spawn by Type",
                    sub = "vehicles.spawn.type"
                },
                new MenuItem()
                {
                    text = "Spawn Vehicle by DLC",
                    sub = "vehicles.spawn.dlc"
                },
                new MenuItem()
                {
                    text = "Spawn Vehicle by Internal Name",
                    action = "vehspawn input"
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
                new MenuItem()
                {
                    text = "Other Mods",
                    sub = "vehicles.mods.other",
                }
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

        public List<MenuItem> GetRainbowSpeedMenu()
        {
            var list = new List<MenuItem>(10);
            bool success = false;
            double current = -1;

            if (Config.ContainsKeyOrHasDefault("RainbowSpeed"))
            {
                success = double.TryParse(Config["RainbowSpeed"], out current);
            }

            if (!success || current == 0)
            {
                current = 50;
            }
            else
            {
                current *= 100;
            }

            for (var speed = 0.1; speed <= 1; speed += 0.1)
            {
                var percentage = Math.Round(speed * 100);
                var name = $"{percentage}% Speed";

                Debug.WriteLine($"Comparing {current} to {percentage}.");
                if (percentage == current)
                {
                    name += " (Current)";
                }
                else if (percentage == 50)
                {
                    name += " (Default)";
                }

                list.Add(new MenuItem()
                {
                    text = name,
                    action = $"rainbowspeed {speed}",
                });
            }

            return list;
        }

        public List<MenuItem> GetBoostPowerMenu()
        {
            var list = new List<MenuItem>();
            int current = 0;
            bool success = false;

            if (Config.ContainsKeyOrHasDefault("BoostPower"))
            {
                success = int.TryParse(Config["BoostPower"], out current);
            }

            if (!success || current == 0)
            {
                current = 75;
            }

            for (var power = 25; power <= 150; power += 25)
            {
                var name = $"Power {power}";

                if (power == current)
                {
                    name += " (Current)";
                }
                else if (power == 75)
                {
                    name += " (Default)";
                }

                list.Add(new MenuItem()
                {
                    text = name,
                    action = $"boostpower {power}",
                });
            }

            return list;
        }

        private List<MenuItem> GetPlatesMenu()
        {
            var list = new List<MenuItem>();

            var plateStyles = new List<string>();

            foreach (var style in Enum.GetValues(typeof(LicensePlateStyle))) {
                var name = Trainer.AddSpacesToSentence(style.ToString());

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
                    text = Trainer.AddSpacesToSentence(colourName),
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
            colourName = Trainer.AddSpacesToSentence(colourName);

            return colourName;
        }
    }
}
