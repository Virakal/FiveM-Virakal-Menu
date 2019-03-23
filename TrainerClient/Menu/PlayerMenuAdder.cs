using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virakal.FiveM.Trainer.TrainerClient.Data;
using Virakal.FiveM.Trainer.TrainerClient.Section;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    class PlayerMenuAdder : BaseMenuAdder
    {
        private Config Config { get; }

        public PlayerMenuAdder(Config config)
        {
            Config = config;
        }
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
                new MenuItem()
                {
                    text = "Autoload Default Skin",
                    action = "autoloaddefaultskin",
                    state = "ON",
                    configkey = "AutoLoadDefaultSkin"
                },
            };

            menus["player.skin.recent"] = GetRecentSkinMenu();
            menus["player.skin.animals"] = ToMenuItems(PedModelList.GetByType(PedModelType.Animal));
            menus["player.skin.mainCharacters"] = ToMenuItems(PedModelList.GetByType(PedModelType.MainCharacter));
            menus["player.skin.pedestrians"] = ToMenuItems(PedModelList.GetByType(PedModelType.Human));
            menus["player.skin.custom"] = ToMenuItems(PedModelList.GetByType(PedModelType.Custom));

            return menus;
        }

        public List<MenuItem> GetRecentSkinMenu()
        {
            var menu = new List<MenuItem>();
            var actionPrefix = "playerskin";

            if (Config.ContainsKey("RecentSkins"))
            {
                List<int> recentSkins = PlayerSection.ParseRecentSkins(Config["RecentSkins"]);

                foreach (var modelHash in recentSkins)
                {
                    PedModelListItem info = PedModelList.GetItemByHash(modelHash);

                    if (info != null)
                    {
                        menu.Add(new MenuItem()
                        {
                            text = info.Name,
                            key = info.ModelHash.ToString(),
                            action = $"{actionPrefix} {info.Model}",
                        });
                    }
                }
            }

            if (menu.Count == 0)
            {
                menu.Add(new MenuItem()
                {
                    text = "No recent skins yet!",
                });
            }

            return menu;
        }

        private List<MenuItem> ToMenuItems(IEnumerable<PedModelListItem> models)
        {
            var menu = new List<MenuItem>();
            var actionPrefix = "playerskin";

            foreach (var model in models)
            {
                menu.Add(new MenuItem()
                {
                    text = model.Name,
                    action = $"{actionPrefix} {model.Model}",
                    key = model.Model,
                });
            }

            return menu;
        }
    }
}
