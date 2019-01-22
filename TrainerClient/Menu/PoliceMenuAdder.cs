using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class PoliceMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["policemenu"] = new List<MenuItem>()
            {
                new MenuItem() {
                    text = "Disable Police For You",
                    action = "policedisable",
                    state = "OFF",
                    configkey = "PoliceDisable"
                },
                new MenuItem() {
                    text = "Police Ignore You",
                    action = "policeignore",
                    state = "OFF",
                    configkey = "PoliceIgnore"
                },
                new MenuItem() {
                    text = "Wanted Level 0",
                    action = "wantedlevel 0"
                },
                new MenuItem() {
                    text = "Wanted Level 1",
                    action = "wantedlevel 1"
                },
                new MenuItem() {
                    text = "Wanted Level 2",
                    action = "wantedlevel 2"
                },
                new MenuItem() {
                    text = "Wanted Level 3",
                    action = "wantedlevel 3"
                },
                new MenuItem() {
                    text = "Wanted Level 4",
                    action = "wantedlevel 4"
                },
                new MenuItem() {
                    text = "Wanted Level 5",
                    action = "wantedlevel 5"
                },

            };

            menus["policemenu"] = AddParentField("mainmenu", menus["policemenu"]);

            return menus;
        }
    }
}
