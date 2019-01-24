using CitizenFX.Core;
using System.Collections.Generic;
using System.Dynamic;

namespace Virakal.FiveM.Trainer.TrainerClient.Menu
{
    public class TeleportMenuAdder : BaseMenuAdder
    {
        public override Dictionary<string, List<MenuItem>> AddMenus(Dictionary<string, List<MenuItem>> menus)
        {
            menus["teleport"] = new List<MenuItem>()
            {
                new MenuItem() {
                    text = "Show Coords",
                    action = "coords"
                },
                new MenuItem() {
                    text = "To Player",
                    sub = "teleport.toPlayer"
                },
                new MenuItem() {
                    text = "To Last Vehicle",
                    action = "telelastcar"
                },
                new MenuItem() {
                    text = "Donkey Punch Farm",
                    action = "teleport 428,6553,28"
                },
                new MenuItem() {
                    text = "FIB Building",
                    action = "teleport 134,-748,259"
                },
                new MenuItem() {
                    text = "LSIA Airport",
                    action = "teleport -1075,-2915,15"
                },
                new MenuItem() {
                    text = "Logging Camp Road Entrance",
                    action = "teleport -881,5417,36"
                },
                new MenuItem() {
                    text = "Mount Chiliad Summit",
                    action = "teleport 502,5604,798"
                },
                new MenuItem() {
                    text = "Observatory Road Entrance",
                    action = "teleport -408,1173,326"
                },
                new MenuItem() {
                    text = "Trevor's Airport",
                    action = "teleport 1777,3253,42"
                }
            };

            menus["teleport"] = AddParentField("mainmenu", menus["teleport"]);
            menus["teleport.toPlayer"] = AddParentField("teleport", MakePlayerMenu());

            return menus;
        }

        public List<MenuItem> MakePlayerMenu()
        {
            var list = new List<MenuItem>();

            foreach (var player in new PlayerList())
            {
                list.Add(new MenuItem()
                {
                    text = $"{player.Name} ({player.ServerId})",
                    action = $"teleplayer {player.ServerId}",
                });
            }

            return list;
        }
    }
}
