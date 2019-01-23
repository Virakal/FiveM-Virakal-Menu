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

        public VehiclesMenuAdder(Garage garage) : base()
        {
            Garage = garage;
        }

        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["vehiclesmenu"] = GetVehiclesMenu();

            menus["vehiclesspawnmenu"] = GetSpawnMenu();
            menus["vehiclessavemenu"] = GetGarageSaveMenu();
            menus["vehiclesloadmenu"] = GetGarageLoadMenu();
            menus["vehiclescolourmenu"] = GetAppearanceMenu();
            menus["vehiclesmodsmenu"] = GetModsMenu();
            menus["vehiclescolourmenu"] = GetAppearanceMenu();

            // Add vehicle spawn menus
            menus["boatspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Boats));
            menus["commercialspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Commercial));
            menus["compactspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Compacts));
            menus["coupespawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Coupes));
            menus["pushbikespawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Cycles));
            menus["emergencyspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Emergency));
            menus["helispawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Helicopters));
            menus["industrialspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Industrial));
            menus["militaryspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Military));
            menus["motorbikespawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Motorcycles));
            menus["offroadspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.OffRoad));
            menus["planespawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Planes));
            menus["servicespawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Service));
            menus["superspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Super));
            menus["utilityspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetList(VehicleClass.Utility));

            menus["funspawnmenu"] = AddVehicleSpawnMenu(VehicleList.GetByTag("fun"));

            // Add vehicle appearance menus
            menus["vehiclerainbowmenu"] = GetRainbowMenu();
            menus["vehiclecolourrainbowspeed"] = GetRainbowSpeedMenu();
            menus["boostpowermenu"] = GetBoostPowerMenu();
            menus["vehiclesnumberplatemenu"] = GetPlatesMenu();
            menus["vehiclewindowtintmenu"] = GetWindowTintMenu();
            menus["vehiclelivery"] = GetLiveryMenu();
            menus["vehiclerooflivery"] = GetRoofLiveryMenu();

            menus["vehiclescolourcustommenu"] = GetCustomColourMenu("vehcolor");

            menus["vehiclescolourbothmenu"] = GetPaintColourMenu("vehboth");
            menus["vehiclescolourprimarymenu"] = GetPaintColourMenu("vehprimary");
            menus["vehiclescoloursecondarymenu"] = GetPaintColourMenu("vehsecondary");
            menus["vehiclescolourpearlescentmenu"] = GetPaintColourMenu("vehpearl");
            menus["vehiclescolourrimmenu"] = GetPaintColourMenu("vehrim");
            menus["vehiclescolordashmenu"] = GetPaintColourMenu("vehdashcolour");

            // Populate "parent" fields so the back button works.
            menus["vehiclesmenu"] = AddParentField("mainmenu", menus["vehiclesmenu"]);
            menus["vehiclesspawnmenu"] = AddParentField("vehiclesmenu", menus["vehiclesspawnmenu"]);
            menus["vehiclesmodsmenu"] = AddParentField("vehiclesmenu", menus["vehiclesmodsmenu"]);
            menus["vehiclescolourmenu"] = AddParentField("vehiclesmenu", menus["vehiclescolourmenu"]);
            menus["vehiclescolourcustommenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescolourcustommenu"]);
            menus["vehiclescolourbothmenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescolourbothmenu"]);
            menus["vehiclescolourprimarymenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescolourprimarymenu"]);
            menus["vehiclescoloursecondarymenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescoloursecondarymenu"]);
            menus["vehiclescolourpearlescentmenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescolourpearlescentmenu"]);
            menus["vehiclescolourrimmenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescolourrimmenu"]);
            menus["vehiclescolordashmenu"] = AddParentField("vehiclescolourmenu", menus["vehiclescolordashmenu"]);
            menus["vehiclerainbowmenu"] = AddParentField("vehiclescolourmenu", menus["vehiclerainbowmenu"]);
            menus["vehiclesnumberplatemenu"] = AddParentField("vehiclescolourmenu", menus["vehiclesnumberplatemenu"]);
            menus["vehiclewindowtintmenu"] = AddParentField("vehiclescolourmenu", menus["vehiclewindowtintmenu"]);
            menus["vehiclelivery"] = AddParentField("vehiclescolourmenu", menus["vehiclelivery"]);
            menus["vehiclerooflivery"] = AddParentField("vehiclescolourmenu", menus["vehiclerooflivery"]);
            menus["vehiclecolourrainbowspeed"] = AddParentField("vehiclerainbowmenu", menus["vehiclecolourrainbowspeed"]);
            menus["boostpowermenu"] = AddParentField("vehiclesmenu", menus["boostpowermenu"]);
            menus["vehiclessavemenu"] = AddParentField("vehiclesmenu", menus["vehiclessavemenu"]);
            menus["vehiclesloadmenu"] = AddParentField("vehiclesmenu", menus["vehiclesloadmenu"]);
            menus["boatspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["boatspawnmenu"]);
            menus["helispawnmenu"] = AddParentField("vehiclesspawnmenu", menus["helispawnmenu"]);
            menus["militaryspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["militaryspawnmenu"]);
            menus["motorbikespawnmenu"] = AddParentField("vehiclesspawnmenu", menus["motorbikespawnmenu"]);
            menus["planespawnmenu"] = AddParentField("vehiclesspawnmenu", menus["planespawnmenu"]);
            menus["pushbikespawnmenu"] = AddParentField("vehiclesspawnmenu", menus["pushbikespawnmenu"]);
            menus["industrialspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["industrialspawnmenu"]);
            menus["superspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["superspawnmenu"]);
            menus["servicespawnmenu"] = AddParentField("vehiclesspawnmenu", menus["servicespawnmenu"]);
            menus["emergencyspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["emergencyspawnmenu"]);
            menus["commercialspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["commercialspawnmenu"]);
            menus["offroadspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["offroadspawnmenu"]);
            menus["compactspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["compactspawnmenu"]);
            menus["coupespawnmenu"] = AddParentField("vehiclesspawnmenu", menus["coupespawnmenu"]);
            menus["utilityspawnmenu"] = AddParentField("vehiclesspawnmenu", menus["utilityspawnmenu"]);

            return menus;
        }

        private List<MenuItem> AddVehicleSpawnMenu(List<VehicleListItem> vehicleList)
        {
            List<MenuItem> list = new List<MenuItem>(vehicleList.Count);

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
                    sub = "funspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Boat",
                    sub = "boatspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Commercial Vehicles",
                    sub = "commercialspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Compact Vehicles",
                    sub = "compactspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Coupés",
                    sub = "coupespawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Emergency Vehicles",
                    sub = "emergencyspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Helicopter",
                    sub = "helispawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Industrial",
                    sub = "industrialspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Military",
                    sub = "militaryspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Motorbike",
                    sub = "motorbikespawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Off-Road Vehicles",
                    sub = "offroadspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Plane",
                    sub = "planespawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Pushbike",
                    sub = "pushbikespawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Service Vehicles",
                    sub = "servicespawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Supercar",
                    sub = "superspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Utility Vehicles",
                    sub = "utilityspawnmenu"
                },
                new MenuItem()
                {
                    text = "Spawn Vehicle by Name",
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
                    sub = "vehiclecolourrainbowspeed"
                },
            };
        }

        private List<MenuItem> GetAppearanceMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Custom Colour",
                    sub = "vehiclescolourcustommenu"
                },
                new MenuItem()
                {
                    text = "Both Primary & Secondary Colour",
                    sub = "vehiclescolourbothmenu"
                },
                new MenuItem()
                {
                    text = "Primary Colour",
                    sub = "vehiclescolourprimarymenu"
                },
                new MenuItem()
                {
                    text = "Secondary Colour",
                    sub = "vehiclescoloursecondarymenu"
                },
                new MenuItem()
                {
                    text = "Pearlescent Colour",
                    sub = "vehiclescolourpearlescentmenu"
                },
                new MenuItem()
                {
                    text = "Rim Colour",
                    sub = "vehiclescolourrimmenu"
                },
                new MenuItem()
                {
                    text = "Dashboard Colour",
                    sub = "vehiclescolordashmenu"
                },
                new MenuItem()
                {
                    text = "Window Tint",
                    sub = "vehiclewindowtintmenu"
                },
                new MenuItem()
                {
                    text = "Vehicle Livery",
                    sub = "vehiclelivery"
                },
                new MenuItem()
                {
                    text = "Roof Livery",
                    sub = "vehiclerooflivery"
                },
                new MenuItem()
                {
                    text = "Number Plates",
                    sub = "vehiclesnumberplatemenu"
                },
                new MenuItem()
                {
                    text = "Rainbow Car Settings",
                    sub = "vehiclerainbowmenu"
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
                    sub = "vehiclesmodsneonsmenu"
                },
                new MenuItem()
                {
                    text = "Performance",
                    sub = "vehiclesmodsperfmenu"
                },
                new MenuItem()
                {
                    text = "Wheels & Tyres",
                    sub = "vehiclesmodswheelsmenu"
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
                    sub = "vehiclesspawnmenu"
                },
                new MenuItem()
                {
                    text = "Load Vehicle from Garage",
                    sub = "vehiclesloadmenu"
                },
                new MenuItem()
                {
                    text = "Save Vehicle to Garage",
                    sub = "vehiclessavemenu"
                },
                new MenuItem()
                {
                    text = "Vehicle Appearance",
                    sub = "vehiclescolourmenu"
                },
                new MenuItem()
                {
                    text = "Vehicle Mods",
                    sub = "vehiclesmodsmenu"
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
                    sub = "boostpowermenu"
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
                    text = name ?? $"Livery {i}",
                    action = $"vehlivery {i}",
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
                /*
                // 30% crashes Mary's PC - wtf?
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
                */
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
            // Could get this from the enum but seems like too much effort
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Change Text",
                    action = "vehplatetext"
                },
                new MenuItem()
                {
                    text = "Style: Blue on White 1",
                    action = "vehplatesyle 3"
                },
                new MenuItem()
                {
                    text = "Style: Blue on White 2",
                    action = "vehplatesyle 0"
                },
                new MenuItem()
                {
                    text = "Style: Blue on White 3",
                    action = "vehplatesyle 4"
                },
                new MenuItem()
                {
                    text = "Style: Yellow on Black",
                    action = "vehplatesyle 1"
                },
                new MenuItem()
                {
                    text = "Style: Yellow on Blue",
                    action = "vehplatesyle 2"
                },
                new MenuItem()
                {
                    text = "Style: North Yankton",
                    action = "vehplatesyle 5"
                },
            };
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
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Custom (HTML #RRGGBB or R,G,B)",
                    action = "vehcolor input"
                },
                new MenuItem()
                {
                    text = "Black",
                    action = "vehcolor 0,0,0"
                },
                new MenuItem()
                {
                    text = "Blue",
                    action = "vehcolor 0,0,255"
                },
                new MenuItem()
                {
                    text = "Green",
                    action = "vehcolor 0,255,0"
                },
                new MenuItem()
                {
                    text = "Red",
                    action = "vehcolor 255,0,0"
                },
                new MenuItem()
                {
                    text = "Fuchsia",
                    action = "vehcolor 255,0,255"
                },
                new MenuItem()
                {
                    text = "Yellow",
                    action = "vehcolor 255,255,0"
                },
                new MenuItem()
                {
                    text = "Cyan",
                    action = "vehcolor 0,255,255"
                },
                new MenuItem()
                {
                    text = "White",
                    action = "vehcolor 255,255,255"
                },
            };
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
