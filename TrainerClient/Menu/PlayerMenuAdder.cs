using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class PlayerMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["player"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Change Skin",
                    sub = "player.skin"
                },
                new MenuItem()
                {
                    text = "Godmode",
                    action = "player god",
                    state = "ON",
                    configkey = "GodMode"
                },
                new MenuItem()
                {
                    text = "Unlimited Stamina",
                    action = "player stamina",
                    state = "ON",
                    configkey = "InfiniteStamina"
                },
                new MenuItem()
                {
                    text = "Infinite Ammo",
                    action = "player ammo",
                    state = "ON",
                    configkey = "InfiniteAmmo"
                },
                new MenuItem()
                {
                    text = "Infinite Clip",
                    action = "player clip",
                    state = "ON",
                    configkey = "InfiniteClip"
                },
                new MenuItem()
                {
                    text = "Heal Player",
                    action = "player heal"
                },
                new MenuItem()
                {
                    text = "Add Armor",
                    action = "player armor"
                },
                new MenuItem()
                {
                    text = "Suicide",
                    action = "player suicide"
                },
                new MenuItem()
                {
                    text = "Auto Plane Parachute",
                    action = "player autochute",
                    state = "ON",
                    configkey = "AutoGiveParachute"
                },
                new MenuItem()
                {
                    text = "Give Parachute",
                    action = "wepgive GADGET_PARACHUTE"
                },
            };

            menus["player.skin"] = new List<MenuItem>()
            {
                new MenuItem()
                {
                    text = "Recent",
                    sub = "player.skin.recent"
                },
                new MenuItem()
                {
                    text = "Animals",
                    sub = "player.skin.animals"
                },
                new MenuItem()
                {
                    text = "Main Characters",
                    sub = "player.skin.mainCharacters"
                },
                new MenuItem()
                {
                    text = "Pedestrians",
                    sub = "player.skin.pedestrians"
                },
                new MenuItem()
                {
                    text = "Custom",
                    sub = "player.skin.custom"
                },
                new MenuItem()
                {
                    text = "Save Current Skin as Default",
                    action = "savedefaultskin"
                },
                new MenuItem()
                {
                    text = "Change to Default Skin",
                    action = "loaddefaultskin"
                },
            };

            return menus;
        }
    }
}
