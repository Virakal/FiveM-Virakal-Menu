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

            menus["vehiclesmenu"] = AddParentField("mainmenu", menus["vehiclesmenu"]);

            return menus;
        }
    }
}
