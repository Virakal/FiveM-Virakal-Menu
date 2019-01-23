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
            Lists[VehicleClass.Cycles] = InitialiseCycles();
            Lists[VehicleClass.Emergency] = InitialiseEmergency();
            Lists[VehicleClass.Helicopters] = InitialiseHelicopters();
            Lists[VehicleClass.Industrial] = InitialiseIndustrial();
            Lists[VehicleClass.Military] = InitialiseMilitary();
            Lists[VehicleClass.Motorcycles] = InitialiseMotorcycles();
            Lists[VehicleClass.Planes] = InitialisePlanes();
            Lists[VehicleClass.Service] = InitialiseService();
            Lists[VehicleClass.Super] = InitialiseSuper();

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

        private static List<VehicleListItem> InitialiseCycles()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "BMX",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/64/BMX-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175629",
                    Model = "bmx",
                },
                new VehicleListItem()
                {
                    Name = "Cruiser",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/bd/Cruiser-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175937",
                    Model = "cruiser",
                },
                new VehicleListItem()
                {
                    Name = "Endurex Race Bike",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/53/EndurexRaceBike-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180230",
                    Model = "tribike2",
                },
                new VehicleListItem()
                {
                    Name = "Fixter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/74/Fixter-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180352",
                    Model = "fixter",
                },
                new VehicleListItem()
                {
                    Name = "Scorcher",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/be/Scorcher-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180738",
                    Model = "scorcher",
                },
                new VehicleListItem()
                {
                    Name = "Tri-Cycles Race Bike",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5d/Tri-CyclesRaceBike-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018181013",
                    Model = "tribike3",
                },
                new VehicleListItem()
                {
                    Name = "Whippet Race Bike",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3b/WhippetRaceBike-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018181058",
                    Model = "tribike",
                },
            };
        }

        private static List<VehicleListItem> InitialiseEmergency()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Ambulance",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ee/Ambulance-GTAV-front-LSMC.png/revision/latest/scale-to-width-down/350?cb=20160116221217",
                    Model = "ambulance",
                },
                new VehicleListItem()
                {
                    Name = "FIB (Sedan)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/87/FIB-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151222203022",
                    Model = "fbi",
                },
                new VehicleListItem()
                {
                    Name = "FIB (SUV)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cf/FIB2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151217204743",
                    Model = "fbi2",
                },
                new VehicleListItem()
                {
                    Name = "Fire Truck",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6d/Firetruck-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917180852",
                    Model = "firetruk",
                },
                new VehicleListItem()
                {
                    Name = "Lifeguard",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/69/Lifeguard-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160111205940",
                    Model = "lguard",
                },
                new VehicleListItem()
                {
                    Name = "Park Ranger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/92/ParkRanger-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160313204018",
                    Model = "pranger",
                },
                new VehicleListItem()
                {
                    Name = "Police Bike",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/70/PoliceBike-GTAV-front.png/revision/latest?cb=20170524183918",
                    Model = "policeb",
                },
                new VehicleListItem()
                {
                    Name = "Police Cruiser",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/bd/PoliceCruiser-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160311203102",
                    Model = "police",
                },
                new VehicleListItem()
                {
                    Name = "Police Cruiser (Buffalo)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b1/PoliceCruiser2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183631",
                    Model = "police2",
                },
                new VehicleListItem()
                {
                    Name = "Police Cruiser (Interceptor)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6b/PoliceCruiser3-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170524182142",
                    Model = "police3",
                },
                new VehicleListItem()
                {
                    Name = "Police Rancher",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/66/PoliceRancher-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151212235205",
                    Model = "policeold1",
                },
                new VehicleListItem()
                {
                    Name = "Police Riot",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/16/PoliceRiot-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151231203648",
                    Model = "riot",
                },
                new VehicleListItem()
                {
                    Name = "Police Roadcruiser",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/37/PoliceRoadcruiser-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151212235053",
                    Model = "policeold2",
                },
                new VehicleListItem()
                {
                    Name = "Police Prison Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/55/PolicePrisonBus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170530185420",
                    Model = "pbus",
                },
                new VehicleListItem()
                {
                    Name = "Police Transporter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/60/PoliceTransporter-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160111211416",
                    Model = "policet",
                },
                new VehicleListItem()
                {
                    Name = "RCV",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/db/RCV-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180513190138",
                    Model = "riot2",
                },
                new VehicleListItem()
                {
                    Name = "Sheriff Cruiser",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7e/SheriffCruiser-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160311204301",
                    Model = "sheriff",
                },
                new VehicleListItem()
                {
                    Name = "Unmarked Cruiser",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7b/UnmarkedCruiser-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160308181831",
                    Model = "police4",
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

        private static List<VehicleListItem> InitialiseIndustrial()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Cutter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b4/Cutter-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917180851",
                    Model = "cutter",
                },
                new VehicleListItem()
                {
                    Name = "Dock Handler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/51/DockHandler-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160606124706",
                    Model = "handler",
                },
                new VehicleListItem()
                {
                    Name = "Dozer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/Dozer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160928192618",
                    Model = "bulldozer",
                },
                new VehicleListItem()
                {
                    Name = "Dump",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/18/Dump-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180117",
                    Model = "dump",
                },
                new VehicleListItem()
                {
                    Name = "Flatbed",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/71/Flatbed-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180424",
                    Model = "flatbed",
                },
                new VehicleListItem()
                {
                    Name = "Guardian",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/57/Guardian-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160929163508",
                    Model = "guardian",
                },
                new VehicleListItem()
                {
                    Name = "Mixer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5d/Mixer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160625231645",
                    Model = "mixer",
                },
                new VehicleListItem()
                {
                    Name = "Mixer (Biff Chassis)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/12/Mixer2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626145602",
                    Model = "mixer2",
                },
                new VehicleListItem()
                {
                    Name = "Rubble",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d5/Rubble-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626150707",
                    Model = "rubble",
                },
                new VehicleListItem()
                {
                    Name = "Tipper",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Tipper2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018181106",
                    Model = "tiptruck",
                },
                new VehicleListItem()
                {
                    Name = "Tipper (6 Wheels)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/11/Tipper-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018181108",
                    Model = "tiptruck2",
                },
            };
        }

        private static List<VehicleListItem> InitialiseMilitary()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Anti-Aircraft Trailer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fb/AntiAircraftTrailer-GTAO-front.png/revision/latest?cb=20170621145352",
                    Model = "trailersmall2",
                },
                new VehicleListItem()
                {
                    Name = "APC",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5d/APC-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614144137",
                    Model = "apc",
                },
                new VehicleListItem()
                {
                    Name = "Barracks",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d4/Barracks-GTAV-front.png/revision/latest?cb=20160529142937",
                    Model = "barracks",
                },
                new VehicleListItem()
                {
                    Name = "Barracks (Semi)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/14/BarracksSemi-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151217203705",
                    Model = "barracks2",
                },
                new VehicleListItem()
                {
                    Name = "Barracks (Short Canvas)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/91/Barracks3-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160916175322",
                    Model = "barracks3",
                },
                new VehicleListItem()
                {
                    Name = "Barrage",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/ba/Barrage-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202613",
                    Model = "barrage",
                },
                new VehicleListItem()
                {
                    Name = "Chernobog",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c2/Chernobog-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202730",
                    Model = "chernobog",
                },
                new VehicleListItem()
                {
                    Name = "Crusader",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/37/Crusader-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20151214201316",
                    Model = "crusader",
                },
                new VehicleListItem()
                {
                    Name = "Half-Track",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3f/Halftrack-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170621144406",
                    Model = "halftrack",
                },
                new VehicleListItem()
                {
                    Name = "Rhino Tank",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/af/RhinoTank-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111195824",
                    Model = "rhino",
                },
                new VehicleListItem()
                {
                    Name = "Scarab (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d5/ApocalypseScarab-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193632",
                    Model = "scarab",
                },
                new VehicleListItem()
                {
                    Name = "Scarab (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d9/FutureShockScarab-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193633",
                    Model = "scarab2",
                },
                new VehicleListItem()
                {
                    Name = "Scarab (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7d/NightmareScarab-GTAO-front.png/revision/latest?cb=20181214193633",
                    Model = "scarab3",
                },
                new VehicleListItem()
                {
                    Name = "Thruster",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a9/Thruster-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218195041",
                    Model = "thruster",
                },
                new VehicleListItem()
                {
                    Name = "TM-02 Khanjali",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/97/Khanjali-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202915",
                    Model = "khanjali",
                },
            };
        }

        private static List<VehicleListItem> InitialiseMotorcycles()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Akuma",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9a/Akuma-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160127214020",
                    Model = "akuma",
                },
                new VehicleListItem()
                {
                    Name = "Avarus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1a/Avarus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164948",
                    Model = "avarus",
                },
                new VehicleListItem()
                {
                    Name = "Bagger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/10/Bagger-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160121202520",
                    Model = "bagger",
                },
                new VehicleListItem()
                {
                    Name = "Bati 801",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d9/Bati801-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160127211358",
                    Model = "bati",
                },
                new VehicleListItem()
                {
                    Name = "Bati 801RR",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e3/Bati801RR-GTAV-front-Sprunk.png/revision/latest/scale-to-width-down/350?cb=20160214210359",
                    Model = "bati2",
                },
                new VehicleListItem()
                {
                    Name = "BF400",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/00/BF400-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164436",
                    Model = "bf400",
                },
                new VehicleListItem()
                {
                    Name = "Blazer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/35/Blazer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175627",
                    Model = "blazer",
                },
                new VehicleListItem()
                {
                    Name = "Blazer Aqua",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/BlazerAqua-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213201629",
                    Model = "blazer5",
                },
                new VehicleListItem()
                {
                    Name = "Blazer Lifeguard",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b4/BlazerLifeguard-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111194438",
                    Model = "blazer2",
                },
                new VehicleListItem()
                {
                    Name = "Carbon RS",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2d/CarbonRS-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160130214329",
                    Model = "carbonrs",
                },
                new VehicleListItem()
                {
                    Name = "Chimera",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8a/Chimera-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164901",
                    Model = "chimera",
                },
                new VehicleListItem()
                {
                    Name = "Cliffhanger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/78/Cliffhanger-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164545",
                    Model = "cliffhanger",
                },
                new VehicleListItem()
                {
                    Name = "Daemon",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f7/Daemon-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160208212049",
                    Model = "daemon",
                },
                new VehicleListItem()
                {
                    Name = "Daemon (Gangless)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6b/Daemon2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164637",
                    Model = "daemon2",
                },
                new VehicleListItem()
                {
                    Name = "Deathbike (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/ApocalypseDeathbike-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181215165020",
                    Model = "deathbike",
                },
                new VehicleListItem()
                {
                    Name = "Deathbike (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/ba/FutureShockDeathbike-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181215165020",
                    Model = "deathbike2",
                },
                new VehicleListItem()
                {
                    Name = "Deathbike (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6e/NightmareDeathbike-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181215165021",
                    Model = "deathbike3",
                },
                new VehicleListItem()
                {
                    Name = "Defiler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f5/Defiler-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165056",
                    Model = "defiler",
                },
                new VehicleListItem()
                {
                    Name = "Diabolus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/47/Diabolus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=201612141852073",
                    Model = "diablous",
                },
                new VehicleListItem()
                {
                    Name = "Diabolus Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/11/DiabolusCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202213",
                    Model = "diablous2",
                },
                new VehicleListItem()
                {
                    Name = "Double T",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8c/DoubleT-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160126212153",
                    Model = "double",
                },
                new VehicleListItem()
                {
                    Name = "Enduro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ef/Enduro-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160302173841",
                    Model = "enduro",
                },
                new VehicleListItem()
                {
                    Name = "Esskey",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4e/Esskey-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165149",
                    Model = "esskey",
                },
                new VehicleListItem()
                {
                    Name = "Faggio",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/91/Faggio-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160204205826",
                    Model = "faggio2",
                },
                new VehicleListItem()
                {
                    Name = "Faggio Sport",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/50/FaggioSport-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182412",
                    Model = "faggio",
                },
                new VehicleListItem()
                {
                    Name = "Faggio Mod",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/FaggioMod-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182448",
                    Model = "faggio3",
                },
                new VehicleListItem()
                {
                    Name = "FCR 1000",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/95/FCR1000-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202343",
                    Model = "fcr",
                },
                new VehicleListItem()
                {
                    Name = "FCR 1000 Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/87/FCR1000Custom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202416",
                    Model = "fcr2",
                },
                new VehicleListItem()
                {
                    Name = "Gargoyle",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ea/Gargoyle-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164757",
                    Model = "gargoyle",
                },
                new VehicleListItem()
                {
                    Name = "Hakuchou",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/ab/Hakuchou-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302173513",
                    Model = "hakuchou",
                },
                new VehicleListItem()
                {
                    Name = "Hakuchou Drag",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fd/HakuchouDrag-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165253",
                    Model = "hakuchou2",
                },
                new VehicleListItem()
                {
                    Name = "Hexer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/64/Hexer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160211212015",
                    Model = "hexer",
                },
                new VehicleListItem()
                {
                    Name = "Hot Rod Blazer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/HotRodBlazer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160927172000",
                    Model = "blazer3",
                },
                new VehicleListItem()
                {
                    Name = "Innovation",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/13/Innovation-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302173556",
                    Model = "innovation",
                },
                new VehicleListItem()
                {
                    Name = "Lectro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/de/Lectro-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160302174105",
                    Model = "lectro",
                },
                new VehicleListItem()
                {
                    Name = "Manchez",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c6/Manchez-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165403",
                    Model = "manchez",
                },
                new VehicleListItem()
                {
                    Name = "Nemesis",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4b/Nemesis-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160126214050",
                    Model = "nemesis",
                },
                new VehicleListItem()
                {
                    Name = "Nightblade",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6b/Nightblade-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165516",
                    Model = "nightblade",
                },
                new VehicleListItem()
                {
                    Name = "Oppressor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/16/Oppressor-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143950",
                    Model = "oppressor",
                },
                new VehicleListItem()
                {
                    Name = "Oppressor Mk. II",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/85/OppressorMkII-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725181109",
                    Model = "oppressor2",
                },
                new VehicleListItem()
                {
                    Name = "PCJ-600",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/74/PCJ600-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160121201111",
                    Model = "pcj",
                },
                new VehicleListItem()
                {
                    Name = "Police Bike",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/70/PoliceBike-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20170524183918",
                    Model = "policeb",
                },
                new VehicleListItem()
                {
                    Name = "Ruffian",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b5/Ruffian-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160204203142",
                    Model = "ruffian",
                },
                new VehicleListItem()
                {
                    Name = "Rat Bike",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b5/RatBike-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182129",
                    Model = "ratbike",
                },
                new VehicleListItem()
                {
                    Name = "Sanctus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/be/Sanctus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182302",
                    Model = "sanctus",
                },
                new VehicleListItem()
                {
                    Name = "Sanchez",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/93/Sanchez2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160222221404",
                    Model = "sanchez2",
                },
                new VehicleListItem()
                {
                    Name = "Sanchez Livery",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5f/Sanchez-GTAV-front-Shrewsbury.png/revision/latest/scale-to-width-down/350?cb=20160222221201",
                    Model = "sanchez",
                },
                new VehicleListItem()
                {
                    Name = "Shotaro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/df/Shotaro-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182220",
                    Model = "shotaro",
                },
                new VehicleListItem()
                {
                    Name = "Sovereign",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/98/Sovereign-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302172751",
                    Model = "sovereign",
                },
                new VehicleListItem()
                {
                    Name = "Street Blazer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6e/StreetBlazer-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004180649",
                    Model = "blazer4",
                },
                new VehicleListItem()
                {
                    Name = "Thrust",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4e/Thrust-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917232329",
                    Model = "thrust",
                },
                new VehicleListItem()
                {
                    Name = "Vader",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9b/Vader-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160130222000",
                    Model = "vader",
                },
                new VehicleListItem()
                {
                    Name = "Vortex",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/71/Vortex-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004181943",
                    Model = "vortex",
                },
                new VehicleListItem()
                {
                    Name = "Wolfsbane",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/ff/Wolfsbane-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165611",
                    Model = "wolfsbane",
                },
                new VehicleListItem()
                {
                    Name = "Zombie Bobber",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/af/ZombieBobber-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004181721",
                    Model = "zombiea",
                },
                new VehicleListItem()
                {
                    Name = "Zombie Chopper",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/70/ZombieChopper-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004181804",
                    Model = "zombieb",
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

        private static List<VehicleListItem> InitialiseService()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Airport Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/aa/AirportBus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917180854",
                    Model = "airbus",
                },
                new VehicleListItem()
                {
                    Name = "Brickade",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/65/Brickade-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160607131817",
                    Model = "brickade",
                },
                new VehicleListItem()
                {
                    Name = "Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/93/Bus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183551",
                    Model = "bus",
                },
                new VehicleListItem()
                {
                    Name = "Dashound",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/41/Dashound-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180031",
                    Model = "coach",
                },
                new VehicleListItem()
                {
                    Name = "Dune",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/46/Dune-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123223",
                    Model = "rallytruck",
                },
                new VehicleListItem()
                {
                    Name = "Festival Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/88/FestivalBus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180922",
                    Model = "pbus2",
                },
                new VehicleListItem()
                {
                    Name = "Rental Shuttle Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c8/RentalShuttleBus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160916175326",
                    Model = "rentalbus",
                },
                new VehicleListItem()
                {
                    Name = "Taxi",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4f/Taxi2-GTAIV-front.png/revision/latest/scale-to-width-down/350?cb=20170223191809",
                    Model = "taxi",
                },
                new VehicleListItem()
                {
                    Name = "Tour Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/58/Tourbus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160916175327",
                    Model = "tourbus",
                },
                new VehicleListItem()
                {
                    Name = "Trashmaster",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/58/Trashmaster-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160606122714",
                    Model = "trash",
                },
                new VehicleListItem()
                {
                    Name = "Trashmaster (Heist)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fa/Trashmaster-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160929163342",
                    Model = "trash2",
                },
                new VehicleListItem()
                {
                    Name = "Wastelander",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e3/Wastelander-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213203148",
                    Model = "wastelander",
                },
            };
        }

        private static List<VehicleListItem> InitialiseSuper()
        {
            return new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "811",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c7/811A-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014163127",
                    Model = "pfister811",
                },
                new VehicleListItem()
                {
                    Name = "Adder",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9e/Adder-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20190106193205",
                    Model = "adder",
                },
                new VehicleListItem()
                {
                    Name = "Banshee 900R",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0b/Banshee900R-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180513190135",
                    Model = "banshee2",
                },
                new VehicleListItem()
                {
                    Name = "Bullet",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3d/Bullet-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183434",
                    Model = "bullet",
                },
                new VehicleListItem()
                {
                    Name = "Cheetah",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1e/Cheetah-GTAV-Front.png/revision/latest/scale-to-width-down/350?cb=20180331183553",
                    Model = "cheetah",
                },
                new VehicleListItem()
                {
                    Name = "Cyclone",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Cyclone-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183602",
                    Model = "cyclone",
                },
                new VehicleListItem()
                {
                    Name = "Deveste Eight",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7b/Deveste-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214181626",
                    Model = "deveste",
                },
                new VehicleListItem()
                {
                    Name = "Entity XF",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/95/EntityXF-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111225624",
                    Model = "entityxf",
                },
                new VehicleListItem()
                {
                    Name = "Entity XXR",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9a/EntityXXR-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180325152709",
                    Model = "entity2",
                },
                new VehicleListItem()
                {
                    Name = "ETR-1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/76/ETR1-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123550",
                    Model = "sheava",
                },
                new VehicleListItem()
                {
                    Name = "FMJ",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8c/FMJ-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014163347",
                    Model = "fmj",
                },
                new VehicleListItem()
                {
                    Name = "GP1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8a/GP1-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170314170715",
                    Model = "gp1",
                },
                new VehicleListItem()
                {
                    Name = "Infernus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Infernus-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160429175116",
                    Model = "infernus",
                },
                new VehicleListItem()
                {
                    Name = "Itali GTB",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/44/ItaliGTB-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171103095537",
                    Model = "italigtb",
                },
                new VehicleListItem()
                {
                    Name = "Itali GTB Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c5/ItaliGTBCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202528",
                    Model = "italigtb2",
                },
                new VehicleListItem()
                {
                    Name = "Nero",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5e/Nero-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202624",
                    Model = "nero",
                },
                new VehicleListItem()
                {
                    Name = "Nero Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/40/NeroCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183629",
                    Model = "nero2",
                },
                new VehicleListItem()
                {
                    Name = "Osiris",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/53/Osiris-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150614104749",
                    Model = "osiris",
                },
                new VehicleListItem()
                {
                    Name = "Penetrator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9c/Penetrator-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202741",
                    Model = "penetrator",
                },
                new VehicleListItem()
                {
                    Name = "RE-7B",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/77/RE7B-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123452",
                    Model = "le7b",
                },
                new VehicleListItem()
                {
                    Name = "Reaper",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5f/Reaper-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183637",
                    Model = "reaper",
                },
                new VehicleListItem()
                {
                    Name = "SC1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3a/SC1-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218192734",
                    Model = "sc1",
                },
                new VehicleListItem()
                {
                    Name = "Scramjet",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3a/Scramjet-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725181214",
                    Model = "scramjet",
                },
                new VehicleListItem()
                {
                    Name = "Sultan RS",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c1/SultanRS-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160128182129",
                    Model = "sultanrs",
                },
                new VehicleListItem()
                {
                    Name = "T20",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/20/T20-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183732",
                    Model = "t20",
                },
                new VehicleListItem()
                {
                    Name = "Taipan",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4c/Taipan-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180328210610",
                    Model = "taipan",
                },
                new VehicleListItem()
                {
                    Name = "Tempesta",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/35/Tempesta-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213203018",
                    Model = "tempesta",
                },
                new VehicleListItem()
                {
                    Name = "Tezeract",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/ca/Tezeract-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183737",
                    Model = "tezeract",
                },
                new VehicleListItem()
                {
                    Name = "Turismo R",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/61/TurismoR-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111200407",
                    Model = "turismor",
                },
                new VehicleListItem()
                {
                    Name = "Tyrant",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f7/Tyrant-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190106193204",
                    Model = "tyrant",
                },
                new VehicleListItem()
                {
                    Name = "Vacca",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b4/Vacca-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183726",
                    Model = "vacca",
                },
                new VehicleListItem()
                {
                    Name = "Vagner",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/14/Vagner-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171220190908",
                    Model = "vagner",
                },
                new VehicleListItem()
                {
                    Name = "Vigilante",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ec/Vigilante-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183732",
                    Model = "vigilante",
                },
                new VehicleListItem()
                {
                    Name = "Visione",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/57/Visione-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170916171115",
                    Model = "visione",
                },
                new VehicleListItem()
                {
                    Name = "Voltic",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/87/Voltic-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111200411",
                    Model = "voltic",
                },
                new VehicleListItem()
                {
                    Name = "Voltic (Rocket)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/95/RocketVoltic-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213203222",
                    Model = "voltic2",
                },
                new VehicleListItem()
                {
                    Name = "X80 Proto",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b3/X80Proto-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609144552",
                    Model = "prototipo",
                },
                new VehicleListItem()
                {
                    Name = "XA-21",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/69/XA21-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143529",
                    Model = "xa21",
                },
                new VehicleListItem()
                {
                    Name = "Zentorno",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/60/Zentorno-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302171211",
                    Model = "zentorno",
                },
            };
        }
    }
}
