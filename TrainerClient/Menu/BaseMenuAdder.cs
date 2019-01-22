using System.Collections.Generic;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    public abstract class BaseMenuAdder
    {
        public abstract Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus);

        public List<MenuItem> AddParentField(string parentName, List<MenuItem> menu)
        {
            menu.ForEach((obj) => obj.parent = parentName);

            return menu;
        }
    }
}
