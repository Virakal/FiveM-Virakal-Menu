using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class VehiclesMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["vehiclesmenu"] = new List<MenuItem>()
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

            menus["vehiclesmodsmenu"] = new List<MenuItem>()
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

            menus["vehiclescolourmenu"] = new List<MenuItem>()
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

            menus["vehiclerainbowmenu"] = new List<MenuItem>()
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

            menus["vehiclecolourrainbowspeed"] = GetRainbowSpeedMenu();
            menus["boostpowermenu"] = GetBoostPowerMenu();
            menus["vehiclesnumberplatemenu"] = GetPlatesMenu();

            menus["vehiclescolourcustommenu"] = GetCustomColourMenu("vehcolor");

            menus["vehiclescolourbothmenu"] = GetPaintColourMenu("vehboth");
            menus["vehiclescolourprimarymenu"] = GetPaintColourMenu("vehprimary");
            menus["vehiclescoloursecondarymenu"] = GetPaintColourMenu("vehsecondary");
            menus["vehiclescolourpearlescentmenu"] = GetPaintColourMenu("vehpearl");
            menus["vehiclescolourrimmenu"] = GetPaintColourMenu("vehrim");
            menus["vehiclescolordashmenu"] = GetPaintColourMenu("vehdashcolour");

            // Populate "parent" fields so the back button works.
            menus["vehiclesmenu"] = AddParentField("mainmenu", menus["vehiclesmenu"]);
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
            menus["vehiclecolourrainbowspeed"] = AddParentField("vehiclerainbowmenu", menus["vehiclecolourrainbowspeed"]);
            menus["boostpowermenu"] = AddParentField("vehiclesmenu", menus["boostpowermenu"]);

            return menus;
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
            var list = new List<MenuItem>(150);

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
