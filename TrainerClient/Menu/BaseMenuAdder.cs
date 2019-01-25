using System.Collections.Generic;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    public abstract class BaseMenuAdder
    {
        public abstract Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus);
    }
}
