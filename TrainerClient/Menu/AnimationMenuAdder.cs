using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class AnimationMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["animationmenu"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Busted",
                    action = "animate arrested",
                },
            };

            menus["animationmenu"] = AddParentField("mainmenu", menus["animationmenu"]);

            return menus;
        }
    }
}
