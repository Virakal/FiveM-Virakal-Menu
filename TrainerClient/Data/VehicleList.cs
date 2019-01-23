using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Data
{
    public static class VehicleList
    {
        private static Dictionary<VehicleClass, List<VehicleListItem>> Lists { get; } = new Dictionary<VehicleClass, List<VehicleListItem>>();
        private static bool initialised = false;

        public static List<VehicleListItem> GetList(VehicleClass listName)
        {
            Initialise();

            return Lists[listName];
        }

        private static void Initialise()
        {
            if (initialised)
            {
                return;
            }

            Lists[VehicleClass.Boats] = InitialiseBoats();
            Lists[VehicleClass.Helicopters] = InitialiseHelicopters();
            Lists[VehicleClass.Planes] = InitialisePlanes();
            initialised = true;
        }

        private static List<VehicleListItem> InitialiseBoats()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Dinghy",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b6/Dinghy-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170723192359",
                    Model = "dinghy",
                },
                new VehicleListItem()
                {
                    Name = "Dinghy (2-Seater)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a2/Dinghy2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170723192355",
                    Model = "dinghy2",
                },
                new VehicleListItem()
                {
                    Name = "Dinghy (Heist Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2d/Dinghy3-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170723192356",
                    Model = "dinghy3",
                },
                new VehicleListItem()
                {
                    Name = "Dinghy (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b4/Dinghy4-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170723192358",
                    Model = "dinghy4",
                },
                new VehicleListItem()
                {
                    Name = "Kraken",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8e/Kraken-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150604114553",
                    Model = "submersible2",
                },
                new VehicleListItem()
                {
                    Name = "Jetmax",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e8/Jetmax-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160207130439",
                    Model = "jetmax",
                },
                new VehicleListItem()
                {
                    Name = "Marquis",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/22/Marquis-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160410145220",
                    Model = "marquis",
                },
                new VehicleListItem()
                {
                    Name = "Police Predator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cb/PolicePredator-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160130165212",
                    Model = "predator",
                },
                new VehicleListItem()
                {
                    Name = "Seashark",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/60/Seashark-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160410145815",
                    Model = "seashark",
                },
                new VehicleListItem()
                {
                    Name = "Seashark (Lifeguard Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/81/Seashark2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160410145938",
                    Model = "seashark2",
                },
                new VehicleListItem()
                {
                    Name = "Seashark (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/94/Seashark3-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216190935",
                    Model = "seashark3",
                },
                new VehicleListItem()
                {
                    Name = "Speeder",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/33/Speeder-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117175437",
                    Model = "speeder",
                },
                new VehicleListItem()
                {
                    Name = "Speeder (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c2/Speeder2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216190736",
                    Model = "speeder2",
                },
                new VehicleListItem()
                {
                    Name = "Squalo",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/37/Squalo-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160916175317",
                    Model = "squalo",
                },
                new VehicleListItem()
                {
                    Name = "Submarine",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4c/Submersible-Front-GTAV.png/revision/latest/scale-to-width-down/350?cb=20140413124926",
                    Model = "submersible",
                },
                new VehicleListItem()
                {
                    Name = "Suntrap",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6c/Suntrap-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160410150037",
                    Model = "suntrap",
                },
                new VehicleListItem()
                {
                    Name = "Toro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/95/Toro-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151212235626",
                    Model = "toro",
                },
                new VehicleListItem()
                {
                    Name = "Toro (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ed/Toro2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216190811",
                    Model = "toro2",
                },
                new VehicleListItem()
                {
                    Name = "Tropic",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/23/Tropic-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160916175319",
                    Model = "tropic",
                },
                new VehicleListItem()
                {
                    Name = "Tropic (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/57/Tropic2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216190857",
                    Model = "tropic2",
                },
                new VehicleListItem()
                {
                    Name = "Tug",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/44/Tug-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609144857",
                    Model = "tug",
                },
            };
        }

        private static List<VehicleListItem> InitialiseHelicopters()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Akula",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/29/Akula-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218205054",
                    Model = "akula",
                },
                new VehicleListItem()
                {
                    Name = "Annihilator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/ac/Annihilator-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161111194433",
                    Model = "annihilator",
                },
                new VehicleListItem()
                {
                    Name = "Avenger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fe/Avenger-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218204931",
                    Model = "avenger",
                },
                new VehicleListItem()
                {
                    Name = "Buzzard",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/02/Buzzard-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160115184835",
                    Model = "buzzard",
                },
                new VehicleListItem()
                {
                    Name = "Buzzard Attack Chopper",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d1/BuzzardAttackChopper-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111194441",
                    Model = "buzzard2",
                },
                new VehicleListItem()
                {
                    Name = "Cargobob",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Cargobob-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111195100",
                    Model = "cargobob",
                },
                new VehicleListItem()
                {
                    Name = "Cargobob Jetsam",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/68/Cargobob2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111194444",
                    Model = "cargobob2",
                },
                new VehicleListItem()
                {
                    Name = "Cargobob TPE",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e0/Cargobob3-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111195058",
                    Model = "cargobob3",
                },
                new VehicleListItem()
                {
                    Name = "Cargobob Drop Zone",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/84/Cargobob4-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172624",
                    Model = "cargobob4",
                },
                new VehicleListItem()
                {
                    Name = "FH-1 Hunter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/dd/FH1-Hunter-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171121154009",
                    Model = "hunter",
                },
                new VehicleListItem()
                {
                    Name = "Frogger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/Frogger-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160116184549",
                    Model = "frogger",
                },
                new VehicleListItem()
                {
                    Name = "Frogger TPE Variant",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7b/Frogger2-GTAV-front.png/revision/latest/scale-to-width-down/185?cb=20161111195701",
                    Model = "frogger2",
                },
                new VehicleListItem()
                {
                    Name = "Havok",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3f/Havok-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153031",
                    Model = "havok",
                },
                new VehicleListItem()
                {
                    Name = "Maverick",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2b/Maverick-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160411164524",
                    Model = "maverick",
                },
                new VehicleListItem()
                {
                    Name = "Police Maverick",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/50/PoliceMaverick-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111195820",
                    Model = "polmav",
                },
                new VehicleListItem()
                {
                    Name = "Savage",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/36/Savage-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151212171103",
                    Model = "savage",
                },
                new VehicleListItem()
                {
                    Name = "Seasparrow",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5e/SeaSparrow-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180325183202",
                    Model = "seasparrow",
                },
                new VehicleListItem()
                {
                    Name = "Skylift",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f9/Skylift-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111200404",
                    Model = "skylift",
                },
                new VehicleListItem()
                {
                    Name = "SuperVolito",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4d/SuperVolito-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216173044",
                    Model = "supervolito",
                },
                new VehicleListItem()
                {
                    Name = "SuperVolito Carbon",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/91/SuperVolitoCarbon-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172545",
                    Model = "supervolito2",
                },
                new VehicleListItem()
                {
                    Name = "Swift",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9c/SwiftClassic-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117175814",
                    Model = "swift",
                },
                new VehicleListItem()
                {
                    Name = "Swift Deluxe",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4d/SwiftDeluxe-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117170332",
                    Model = "swift2",
                },
                new VehicleListItem()
                {
                    Name = "Valkyrie",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Valkyrie-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151212171243",
                    Model = "valkyrie",
                },
                new VehicleListItem()
                {
                    Name = "Valkyrie MOD.0",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/77/ValkyrieMOD0-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172704",
                    Model = "valkyrie2",
                },
                new VehicleListItem()
                {
                    Name = "Volatus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Volatus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609144955",
                    Model = "volatus",
                },

            };
        }

        private static List<VehicleListItem> InitialisePlanes()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Alpha-Z1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/50/AlphaZ1-GTAO-front.png/revision/latest?cb=20170902152931",
                    Model = "alphaz1",
                },
                new VehicleListItem()
                {
                    Name = "Avenger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fe/Avenger-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218204931",
                    Model = "avenger",
                },
                new VehicleListItem()
                {
                    Name = "B-11 Strikeforce",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/11/B11Strikeforce-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180742",
                    Model = "strikeforce",
                },
                new VehicleListItem()
                {
                    Name = "Besra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2a/Besra-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160927163752",
                    Model = "besra",
                },
                new VehicleListItem()
                {
                    Name = "Bombushka (No Addons)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/20/RM10-Bombushka-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151115",
                    Model = "bombushka",
                },
                new VehicleListItem()
                {
                    Name = "Cargo Plane",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/88/CargoPlane-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180303174828",
                    Model = "cargoplane",
                },
                new VehicleListItem()
                {
                    Name = "Cuban 800",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/bc/Cuban800-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160116190952",
                    Model = "cuban800",
                },
                new VehicleListItem()
                {
                    Name = "Dodo",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/23/Dodo-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150604111147",
                    Model = "dodo",
                },
                new VehicleListItem()
                {
                    Name = "Duster",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7a/Duster-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150724190610",
                    Model = "duster",
                },
                new VehicleListItem()
                {
                    Name = "Howard NX-25",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/89/Howard-NX25-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153213",
                    Model = "howard",
                },
                new VehicleListItem()
                {
                    Name = "Hydra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Hydra-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151211201554",
                    Model = "hydra",
                },
                new VehicleListItem()
                {
                    Name = "Jet",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ed/Jet-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20171009200518",
                    Model = "jet",
                },
                new VehicleListItem()
                {
                    Name = "LAZER",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/56/P996LAZER-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150724190806",
                    Model = "lazer",
                },
                new VehicleListItem()
                {
                    Name = "LF-22 Starling",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7d/LF22-Starling-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151441",
                    Model = "starling",
                },
                new VehicleListItem()
                {
                    Name = "Luxor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f4/Luxor-GTAV-FrontQuarter.png/revision/latest/scale-to-width-down/350?cb=20180717110504",
                    Model = "luxor",
                },
                new VehicleListItem()
                {
                    Name = "Luxor Deluxe",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1f/LuxorDeluxe-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150614102306",
                    Model = "luxor2",
                },
                new VehicleListItem()
                {
                    Name = "Mallard",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e5/Mallard-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150724182150",
                    Model = "stunt",
                },
                new VehicleListItem()
                {
                    Name = "Mammatus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/36/Mammatus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150724190456",
                    Model = "mammatus",
                },
                new VehicleListItem()
                {
                    Name = "Miljet",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/bb/Miljet-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117181440",
                    Model = "miljet",
                },
                new VehicleListItem()
                {
                    Name = "Mogul",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/31/Mogul-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151951",
                    Model = "mogul",
                },
                new VehicleListItem()
                {
                    Name = "Nimbus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/76/Nimbus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609145048",
                    Model = "nimbus",
                },
                new VehicleListItem()
                {
                    Name = "Pyro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/92/Pyro-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153300",
                    Model = "pyro",
                },
                new VehicleListItem()
                {
                    Name = "P-45 Nokota",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f7/P45-Nokota-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151754",
                    Model = "nokota",
                },
                new VehicleListItem()
                {
                    Name = "Rogue",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b7/Rogue-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902152244",
                    Model = "rogue",
                },
                new VehicleListItem()
                {
                    Name = "Seabreeze",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/77/Seabreeze-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153349",
                    Model = "seabreeze",
                },
                new VehicleListItem()
                {
                    Name = "Shamal",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/62/Shamal-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160116190447",
                    Model = "shamal",
                },
                new VehicleListItem()
                {
                    Name = "Titan",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8c/Titan-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117170647",
                    Model = "titan",
                },
                new VehicleListItem()
                {
                    Name = "Tula",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a9/Tula-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902152810",
                    Model = "tula",
                },
                new VehicleListItem()
                {
                    Name = "Ultralight",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b1/Ultralight-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153122",
                    Model = "microlight",
                },
                new VehicleListItem()
                {
                    Name = "V-65 Molotok",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a6/V65-Molotok-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902152647",
                    Model = "molotok",
                },
                new VehicleListItem()
                {
                    Name = "Velum",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/55/Velum-GTAV.jpg/revision/latest/scale-to-width-down/350?cb=20131019014643",
                    Model = "velum",
                },
                new VehicleListItem()
                {
                    Name = "Velum 5-Seater",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/38/Velum5Seater-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160302173740",
                    Model = "velum2",
                },
                new VehicleListItem()
                {
                    Name = "Vestra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/32/Vestra-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117175617",
                    Model = "vestra",
                },
                new VehicleListItem()
                {
                    Name = "Volatol",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/99/Volatol-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218203050",
                    Model = "volatol",
                },
            };
        }
    }
}
