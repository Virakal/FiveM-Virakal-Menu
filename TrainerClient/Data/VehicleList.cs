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
        private static List<VehicleListItem> Vehicles => lazyList.Value;
        private static Lazy<List<VehicleListItem>> lazyList = new Lazy<List<VehicleListItem>>(InitialiseList);

        public static IEnumerable<VehicleListItem> GetByVehicleClass(VehicleClass vehicleClass)
        {
            return Vehicles
                .Where(item => item.VehicleClass == vehicleClass)
                .OrderBy(x => x.Name);
        }

        public static IEnumerable<VehicleListItem> GetByTag(string tag)
        {
            return Vehicles
                .Where(item => item.HasTag(tag))
                .OrderBy(x => x.Name);
        }

        public static IEnumerable<VehicleListItem> GetByDlc(Dlc dlc)
        {
            return Vehicles
                .Where(item => item.Dlc == dlc)
                .OrderBy(x => x.Name);
        }

        public static IEnumerable<VehicleListItem> GetBySearchTerm(string term)
        {
            return Vehicles
                .Where(item => item.MatchesSearchTerm(term))
                .OrderBy(x => x.Name);
        }

        public static VehicleListItem FindItemByHash(int hash)
        {
            return Vehicles
                .Where(item => item.ModelHash == hash)
                .FirstOrDefault();
        }

        private static List<VehicleListItem> InitialiseList()
        {
            var list = new List<VehicleListItem>();

            InitialiseBoats(list);
            InitialiseCommercial(list);
            InitialiseCompacts(list);
            InitialiseCoupes(list);
            InitialiseCycles(list);
            InitialiseEmergency(list);
            InitialiseHelicopters(list);
            InitialiseIndustrial(list);
            InitialiseMilitary(list);
            InitialiseMotorcycles(list);
            InitialiseOffRoad(list);
            InitialisePlanes(list);
            InitialiseSedans(list);
            InitialiseService(list);
            InitialiseSport(list);
            InitialiseSuper(list);
            InitialiseUtility(list);

            return list;
        }

        private static void InitialiseBoats(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Boats, new List<VehicleListItem>()
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
                    Dlc = Dlc.ExecutivesandOtherCriminals,
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
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Speeder",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/33/Speeder-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117175437",
                    Model = "speeder",
                    Dlc = Dlc.BeachBumContentUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Speeder (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c2/Speeder2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216190736",
                    Model = "speeder2",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
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
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Toro (Yacht Version)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ed/Toro2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216190811",
                    Model = "toro2",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
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
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Tug",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/44/Tug-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609144857",
                    Model = "tug",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
            }));
        }

        private static void InitialiseCommercial(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Commercial, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Benson",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e8/Benson-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160918135526",
                    Model = "benson",
                },
                new VehicleListItem()
                {
                    Name = "Biff",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/30/Biff-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160429175112",
                    Model = "biff",
                },
                new VehicleListItem()
                {
                    Name = "Cerberus (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0c/ApocalypseCerberus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181213171922",
                    Model = "cerberus",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Cerberus (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e1/FutureShockCerberus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181213171922",
                    Model = "cerberus2",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Cerberus (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3c/NightmareCerberus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181213171923",
                    Model = "cerberus3",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Hauler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2d/Hauler-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180550",
                    Model = "hauler",
                },
                new VehicleListItem()
                {
                    Name = "Hauler Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/54/HaulerCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170621151444",
                    Model = "hauler2",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Mule",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Mule-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626145603",
                    Model = "mule",
                },
                new VehicleListItem()
                {
                    Name = "Mule (Ramp Door)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6d/Mule2-GTAO-RampdoorCloseUp.png/revision/latest/scale-to-width-down/350?cb=20180809102310",
                    Model = "mule2",
                },
                new VehicleListItem()
                {
                    Name = "Mule (Heist)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6a/Mule3-GTAO-front.png/revision/latest?cb=20160929163213",
                    Model = "mule3",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Mule Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/16/MuleCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180057",
                    Model = "mule4",
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Packer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/68/Packer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160308175915",
                    Model = "packer",
                },
                new VehicleListItem()
                {
                    Name = "Phantom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/ff/Phantom-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702200418",
                    Model = "phantom",
                },
                new VehicleListItem()
                {
                    Name = "Phantom Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/70/PhantomCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170621151532",
                    Model = "phantom3",
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Phantom Wedge",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1a/PhantomWedge-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202825",
                    Model = "phantom2",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Pounder",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1d/Pounder-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160918143632",
                    Model = "pounder",
                },
                new VehicleListItem()
                {
                    Name = "Pounder Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/85/PounderCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180226",
                    Model = "pounder2",
                },
                new VehicleListItem()
                {
                    Name = "Stockade",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/50/Stockade-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160918143634",
                    Model = "stockade",
                },
                new VehicleListItem()
                {
                    Name = "Stockade (Bobcat Snow-Covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/65/Stockade3-GTAV-front.png/revision/latest/scale-to-width-down/270?cb=20160918143635",
                    Model = "stockade3",
                },
                new VehicleListItem()
                {
                    Name = "Terrorbyte",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/96/Terrorbyte-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725175825",
                    Model = "terbyte",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
                },
            }));
        }

        private static void InitialiseCompacts(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Compacts, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Blista",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c0/Blista-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409171328",
                    Model = "blista",
                },
                new VehicleListItem()
                {
                    Name = "Brioso R/A",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/80/BriosoRA-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123349",
                    Model = "brioso",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Dilettante",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/80/Dilettante-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305172849",
                    Model = "dilettante",
                },
                new VehicleListItem()
                {
                    Name = "Dilettante (Merryweather)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5b/DilettanteSecurity-GTAV-FrontQuarter.jpg/revision/latest/scale-to-width-down/350?cb=20160312012125",
                    Model = "dilettante2",
                },
                new VehicleListItem()
                {
                    Name = "Issi",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9c/IssiDown-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305190500",
                    Model = "issi2",
                },
                new VehicleListItem()
                {
                    Name = "Issi (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ea/ApocalypseIssi-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193634",
                    Model = "issi4",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Issi (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7a/FutureShockIssi-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193634",
                    Model = "issi5",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Issi (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b0/NightmareIssi-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193635",
                    Model = "issi6",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Issi Classic",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9f/IssiClassic-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180325152715",
                    Model = "issi3",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Panto",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/ad/Panto-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160406180025",
                    Model = "panto",
                    Dlc = Dlc.ImNotaHipsterUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Prairie",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/06/Prairie-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160429175108",
                    Model = "prairie",
                },
                new VehicleListItem()
                {
                    Name = "Rhapsody",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cc/Rhapsody-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302171656",
                    Model = "rhapsody",
                },
            }));
        }

        private static void InitialiseCoupes(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Coupes, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Cognoscenti Cabrio",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/28/CognoscentiCabrioUp-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917231450",
                    Model = "cogcabrio",
                },
                new VehicleListItem()
                {
                    Name = "Exemplar",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/de/Exemplar-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150530112831",
                    Model = "exemplar",
                },
                new VehicleListItem()
                {
                    Name = "F620",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f8/F620-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929162327",
                    Model = "f620",
                },
                new VehicleListItem()
                {
                    Name = "Felon",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/de/Felon-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111225437",
                    Model = "felon",
                },
                new VehicleListItem()
                {
                    Name = "Felon GT",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0f/FelonGTDown-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180313",
                    Model = "felon2",
                },
                new VehicleListItem()
                {
                    Name = "Jackal",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/48/Jackal-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702195507",
                    Model = "jackal",
                },
                new VehicleListItem()
                {
                    Name = "Oracle",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a4/Oracle-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160406180530",
                    Model = "oracle2",
                },
                new VehicleListItem()
                {
                    Name = "Oracle XS",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/22/OracleXS-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409181541",
                    Model = "oracle",
                },
                new VehicleListItem()
                {
                    Name = "Sentinel",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/75/SentinelUp-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702195218",
                    Model = "sentinel2",
                },
                new VehicleListItem()
                {
                    Name = "Sentinel XS",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/22/OracleXS-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409181541",
                    Model = "sentinel",
                },
                new VehicleListItem()
                {
                    Name = "Windsor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/26/Windsor-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150614114420",
                    Model = "windsor",
                },
                new VehicleListItem()
                {
                    Name = "Windsor Drop",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/31/WindsorDropUp-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160607131007",
                    Model = "windsor2",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
                new VehicleListItem()
                {
                    Name = "Zion",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cc/Zion-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929171027",
                    Model = "zion",
                },
                new VehicleListItem()
                {
                    Name = "Zion Cabrio",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cb/ZionCabrioDown-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929171022",
                    Model = "zion2",
                },
            }));
        }

        private static void InitialiseCycles(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Cycles, new List<VehicleListItem>()
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
            }));
        }

        private static void InitialiseEmergency(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Emergency, new List<VehicleListItem>()
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
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.TheDoomsdayHeist,
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
            }));
        }

        private static void InitialiseHelicopters(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Helicopters, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Akula",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/29/Akula-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218205054",
                    Model = "akula",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Annihilator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/ac/Annihilator-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161111194433",
                    Model = "annihilator",
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
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "FH-1 Hunter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/dd/FH1-Hunter-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171121154009",
                    Model = "hunter",
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Sea Sparrow",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5e/SeaSparrow-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180325183202",
                    Model = "seasparrow",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
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
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "SuperVolito Carbon",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/91/SuperVolitoCarbon-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172545",
                    Model = "supervolito2",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Swift",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9c/SwiftClassic-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117175814",
                    Model = "swift",
                    Dlc = Dlc.SanAndreasFlightSchoolUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Swift Deluxe",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4d/SwiftDeluxe-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117170332",
                    Model = "swift2",
                    Dlc = Dlc.IllGottenGainsPart1,
                },
                new VehicleListItem()
                {
                    Name = "Valkyrie",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Valkyrie-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151212171243",
                    Model = "valkyrie",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Valkyrie MOD.0",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/77/ValkyrieMOD0-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172704",
                    Model = "valkyrie2",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Volatus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Volatus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609144955",
                    Model = "volatus",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },

            }));
        }

        private static void InitialiseIndustrial(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Industrial, new List<VehicleListItem>()
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
                    Tags = new HashSet<string>() { "fun" },
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
            }));
        }

        private static void InitialiseMilitary(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Military, new List<VehicleListItem>()
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
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
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
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Barrage",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/ba/Barrage-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202613",
                    Model = "barrage",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Chernobog",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c2/Chernobog-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202730",
                    Model = "chernobog",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.TheDoomsdayHeist,
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
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Rhino Tank",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/af/RhinoTank-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111195824",
                    Model = "rhino",
                    Tags = new HashSet<string>() { "fun" },
                },
                new VehicleListItem()
                {
                    Name = "Scarab (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d5/ApocalypseScarab-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193632",
                    Model = "scarab",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Scarab (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d9/FutureShockScarab-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214193633",
                    Model = "scarab2",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Scarab (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7d/NightmareScarab-GTAO-front.png/revision/latest?cb=20181214193633",
                    Model = "scarab3",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Thruster",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a9/Thruster-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218195041",
                    Model = "thruster",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "TM-02 Khanjali",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/97/Khanjali-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202915",
                    Model = "khanjali",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.TheDoomsdayHeist,
                },
            }));
        }

        private static void InitialiseMotorcycles(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Motorcycles, new List<VehicleListItem>()
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
                    Dlc = Dlc.Bikers,
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
                    Dlc = Dlc.CunningStunts,
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
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Cliffhanger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/78/Cliffhanger-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164545",
                    Model = "cliffhanger",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Daemon",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f7/Daemon-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160208212049",
                    Model = "daemon",
                    Dlc = Dlc.Bikers,
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
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Deathbike (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/ba/FutureShockDeathbike-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181215165020",
                    Model = "deathbike2",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Deathbike (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6e/NightmareDeathbike-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181215165021",
                    Model = "deathbike3",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Defiler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f5/Defiler-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165056",
                    Model = "defiler",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Diabolus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/47/Diabolus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=201612141852073",
                    Model = "diablous",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Diabolus Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/11/DiabolusCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202213",
                    Model = "diablous2",
                    Dlc = Dlc.ImportExport,
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
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Esskey",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4e/Esskey-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165149",
                    Model = "esskey",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Faggio",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/91/Faggio-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160204205826",
                    Model = "faggio2",
                },
                new VehicleListItem()
                {
                    Name = "Faggio Mod",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/FaggioMod-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182448",
                    Model = "faggio3",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Faggio Sport",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/50/FaggioSport-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182412",
                    Model = "faggio",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "FCR 1000",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/95/FCR1000-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202343",
                    Model = "fcr",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "FCR 1000 Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/87/FCR1000Custom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202416",
                    Model = "fcr2",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Gargoyle",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ea/Gargoyle-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014164757",
                    Model = "gargoyle",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Hakuchou",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/ab/Hakuchou-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302173513",
                    Model = "hakuchou",
                    Dlc = Dlc.LastTeamStandingUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Hakuchou Drag",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fd/HakuchouDrag-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165253",
                    Model = "hakuchou2",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Hexer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/64/Hexer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160211212015",
                    Model = "hexer",
                },
                new VehicleListItem()
                {
                    Name = "Innovation",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/13/Innovation-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302173556",
                    Model = "innovation",
                    Dlc = Dlc.LastTeamStandingUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Lectro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/de/Lectro-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160302174105",
                    Model = "lectro",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Manchez",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c6/Manchez-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165403",
                    Model = "manchez",
                    Dlc = Dlc.Bikers,
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
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Oppressor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/16/Oppressor-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143950",
                    Model = "oppressor",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Oppressor Mk. II",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/85/OppressorMkII-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725181109",
                    Model = "oppressor2",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "PCJ-600",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/74/PCJ600-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160121201111",
                    Model = "pcj",
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
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Sanctus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/be/Sanctus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004182302",
                    Model = "sanctus",
                    Dlc = Dlc.Bikers,
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
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Sovereign",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/98/Sovereign-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302172751",
                    Model = "sovereign",
                    Dlc = Dlc.IndependenceDaySpecial,
                },
                new VehicleListItem()
                {
                    Name = "Thrust",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4e/Thrust-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917232329",
                    Model = "thrust",
                    Dlc = Dlc.HighLifeUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Vader",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9b/Vader-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160130222000",
                    Model = "vader",
                },
                new VehicleListItem()
                {
                    Name = "Vindicator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5f/Vindicator-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160304215542",
                    Model = "vindicator",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Vortex",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/71/Vortex-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004181943",
                    Model = "vortex",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Wolfsbane",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/ff/Wolfsbane-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014165611",
                    Model = "wolfsbane",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Zombie Bobber",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/af/ZombieBobber-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004181721",
                    Model = "zombiea",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Zombie Chopper",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/70/ZombieChopper-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004181804",
                    Model = "zombieb",
                    Dlc = Dlc.Bikers,
                },
            }));
        }

        private static void InitialiseOffRoad(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.OffRoad, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Bifta",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Bifta-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302170310",
                    Model = "bifta",
                    Dlc = Dlc.BeachBumContentUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Blazer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/35/Blazer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175627",
                    Model = "blazer",
                },
                new VehicleListItem()
                {
                    Name = "Blazer (Aqua)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/BlazerAqua-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213201629",
                    Model = "blazer5",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Blazer (Hot Rod)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/HotRodBlazer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160927172000",
                    Model = "blazer3",
                },
                new VehicleListItem()
                {
                    Name = "Blazer (Lifeguard)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b4/BlazerLifeguard-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111194438",
                    Model = "blazer2",
                },
                new VehicleListItem()
                {
                    Name = "Blazer (Street)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6e/StreetBlazer-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004180649",
                    Model = "blazer4",
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Bodhi",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8f/Bodhi-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175819",
                    Model = "bodhi2",
                },
                new VehicleListItem()
                {
                    Name = "Brawler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6c/Brawler-GTAV-front.png/revision/latest?cb=20160929162450",
                    Model = "brawler",
                    Dlc = Dlc.IllGottenGainsPart2,
                },
                new VehicleListItem()
                {
                    Name = "Bruiser (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c0/ApocalypseBruiser-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214173051",
                    Model = "bruiser",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Bruiser (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f4/FutureShockBruiser-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214173052",
                    Model = "bruiser2",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Bruiser (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/61/NightmareBruiser-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214173052",
                    Model = "bruiser3",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Brutus (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a0/ApocalypseBrutus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190106171159",
                    Model = "brutus",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Brutus (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/25/FutureShockBrutus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190106171159",
                    Model = "brutus2",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Brutus (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2c/NightmareBrutus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190106171153",
                    Model = "brutus3",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Caracara",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/17/Caracara-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180325152615",
                    Model = "caracara",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Desert Raid",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6b/DesertRaid-GTAO-front.png/revision/latest?cb=20160712123124",
                    Model = "trophytruck2",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Dubsta 6x6",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/10/Dubsta6x6-GTAV-front.png/revision/latest?cb=20160304215944",
                    Model = "dubsta3",
                    Dlc = Dlc.ImNotaHipsterUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Dune Buggy",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cb/DuneBuggy-GTAV-front.png/revision/latest?cb=20160529141843",
                    Model = "dune",
                },
                new VehicleListItem()
                {
                    Name = "Dune FAV",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/65/DuneFAV-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143657",
                    Model = "dune3",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Duneloader",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e6/Duneloader-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180142",
                    Model = "dloader",
                },
                new VehicleListItem()
                {
                    Name = "Freecrawler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a4/Freecrawler-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180458",
                    Model = "freecrawler",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Injection",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/80/Injection-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626144335",
                    Model = "bfinject",
                },
                new VehicleListItem()
                {
                    Name = "Insurgent",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fb/Insurgent-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160929162538",
                    Model = "insurgent2",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Insurgent Pick-Up",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/12/InsurgentPickUp-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160929162614",
                    Model = "insurgent",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Insurgent Pick-Up Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/88/InsurgentPickupCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170621145807",
                    Model = "insurgent3",
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Kalahari",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b7/Kalahari-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302170553",
                    Model = "kalahari",
                    Dlc = Dlc.BeachBumContentUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Kamacho",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/47/Kamacho-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218203725",
                    Model = "kamacho",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Liberator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e0/Liberator-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929162837",
                    Model = "monster",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.IndependenceDaySpecial,
                },
                new VehicleListItem()
                {
                    Name = "Marshall",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a2/Marshall-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929162725",
                    Model = "marshall",
                    Tags = new HashSet<string>() { "fun" },
                },
                new VehicleListItem()
                {
                    Name = "Menacer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a7/Menacer-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180613",
                    Model = "menacer",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Mesa",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/97/Mesa-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626145559",
                    Model = "mesa",
                },
                new VehicleListItem()
                {
                    Name = "Mesa (Merryweather)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fd/Mesa3-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929163600",
                    Model = "mesa3",
                },
                new VehicleListItem()
                {
                    Name = "Mesa (Snow-Covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/ac/Mesa2-GTAV-front.png/revision/latest/scale-to-width-down/185?cb=20160916164929",
                    Model = "mesa2",
                },
                new VehicleListItem()
                {
                    Name = "Nightshark",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0c/Nightshark-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143609",
                    Model = "nightshark",
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Ramp Buggy",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/51/RampBuggy-GTAO-FrontQuarter.png/revision/latest/scale-to-width-down/350?cb=20161215155004",
                    Model = "dune4",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Ramp Buggy (Spoilerless)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/55/RampBuggy2-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202129",
                    Model = "dune5",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Rancher XL",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/59/RancherXL-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305190849",
                    Model = "rancherxl",
                },
                new VehicleListItem()
                {
                    Name = "Rancher XL (Snow-Covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/92/RancherXL2-GTAV-FrontQuarter.png/revision/latest/scale-to-width-down/350?cb=20180505142334",
                    Model = "rancherxl2",
                },
                new VehicleListItem()
                {
                    Name = "RC Bandito",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/14/RCBandito-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181217131322",
                    Model = "rcbandito",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Rebel",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/6a/Rebel2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702195655",
                    Model = "rebel2",
                },
                new VehicleListItem()
                {
                    Name = "Rusty Rebel",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/65/RustyRebel-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702195908",
                    Model = "rebel",
                },
                new VehicleListItem()
                {
                    Name = "Space Docker",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fe/SpaceDocker-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929163022",
                    Model = "dune2",
                },
                new VehicleListItem()
                {
                    Name = "Technical",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/41/Technical-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20150530113418",
                    Model = "technical",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Technical Aqua",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/19/TechnicalAqua-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171201201845",
                    Model = "technical2",
                    Tags = new HashSet<string>() { "fun" },
                },
                new VehicleListItem()
                {
                    Name = "Technical Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/74/TechnicalCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170621150631",
                    Model = "technical3",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Riata",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/67/Riata-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218203640",
                    Model = "riata",
                },
                new VehicleListItem()
                {
                    Name = "Sandking XL",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/39/SandkingXL-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626150711",
                    Model = "sandking",
                },
                new VehicleListItem()
                {
                    Name = "Sandking SWB",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d7/SandkingSWB-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626150709",
                    Model = "sandking2",
                },
                new VehicleListItem()
                {
                    Name = "Sasquatch (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/28/ApocalypseSasquatch-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181213201703",
                    Model = "monster3",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Sasquatch (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/44/FutureShockSasquatch-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181213201704",
                    Model = "monster4",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Sasquatch (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/30/NightmareSasquatch-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181213201704",
                    Model = "monster5",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Trophy Truck",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ec/TrophyTruck-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712122948",
                    Model = "trophytruck",
                    Dlc = Dlc.CunningStunts,
                },
            }));
        }

        private static void InitialisePlanes(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Planes, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Alpha-Z1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/50/AlphaZ1-GTAO-front.png/revision/latest?cb=20170902152931",
                    Model = "alphaz1",
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Avenger",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fe/Avenger-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218204931",
                    Model = "avenger",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "B-11 Strikeforce",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/11/B11Strikeforce-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180742",
                    Model = "strikeforce",
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Besra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2a/Besra-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160927163752",
                    Model = "besra",
                    Dlc = Dlc.SanAndreasFlightSchoolUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Blimp",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a5/Blimp-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180347",
                    Model = "blimp3",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Blimp (Atomic)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c3/AtomicBlimp-LSIA-GTAV.png/revision/latest/scale-to-width-down/350?cb=20141021193529",
                    Model = "blimp",
                    Tags = new HashSet<string>() { "fun" },
                },
                new VehicleListItem()
                {
                    Name = "Blimp (Xero)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5c/Blimp2-GTAV-FrontQuarter.png/revision/latest/scale-to-width-down/350?cb=20180708090330",
                    Model = "blimp2",
                    Tags = new HashSet<string>() { "fun" },
                },
                new VehicleListItem()
                {
                    Name = "Bombushka (No Addons)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/20/RM10-Bombushka-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151115",
                    Model = "bombushka",
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Hydra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Hydra-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151211201554",
                    Model = "hydra",
                    Dlc = Dlc.HeistsUpdate,
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
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.IllGottenGainsPart1,
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
                    Dlc = Dlc.SanAndreasFlightSchoolUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Mogul",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/31/Mogul-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151951",
                    Model = "mogul",
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Nimbus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/76/Nimbus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609145048",
                    Model = "nimbus",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
                new VehicleListItem()
                {
                    Name = "Pyro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/92/Pyro-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153300",
                    Model = "pyro",
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "P-45 Nokota",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f7/P45-Nokota-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902151754",
                    Model = "nokota",
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Rogue",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b7/Rogue-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902152244",
                    Model = "rogue",
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Seabreeze",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/77/Seabreeze-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153349",
                    Model = "seabreeze",
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Ultralight",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b1/Ultralight-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902153122",
                    Model = "microlight",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "V-65 Molotok",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a6/V65-Molotok-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170902152647",
                    Model = "molotok",
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Vestra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/32/Vestra-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160117175617",
                    Model = "vestra",
                    Dlc = Dlc.TheBusinessUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Volatol",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/99/Volatol-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218203050",
                    Model = "volatol",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
            }));
        }

        private static void InitialiseSedans(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Sedans, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Asea",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/58/Asea-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160406180243",
                    Model = "asea",
                },
                new VehicleListItem()
                {
                    Name = "Asea (Snow-covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e3/Asea2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917180857",
                    Model = "asea2",
                },
                new VehicleListItem()
                {
                    Name = "Asterope",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ec/Asterope-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175632",
                    Model = "asterope",
                },
                new VehicleListItem()
                {
                    Name = "Cognoscenti",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/ff/Cognoscenti-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160117195014",
                    Model = "cognoscenti",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Cognoscenti (Armored)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/30/CognoscentiArmored-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160117195043",
                    Model = "cognoscenti2",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Cognoscenti 55",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b4/Cognoscenti55-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160117195125",
                    Model = "cog55",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Cognoscenti 55 (Armored)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b0/Cognoscenti55Armored-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160117195143",
                    Model = "cog552",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Emperor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4c/Emperor-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180208",
                    Model = "emperor",
                },
                new VehicleListItem()
                {
                    Name = "Emperor (Beaten)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c8/Emperor2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626144224",
                    Model = "emperor2",
                },
                new VehicleListItem()
                {
                    Name = "Emperor (Snow-covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f5/Emperor3-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160916164928",
                    Model = "emperor3",
                },
                new VehicleListItem()
                {
                    Name = "Fugitive",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5c/Fugitive-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180444",
                    Model = "fugitive",
                },
                new VehicleListItem()
                {
                    Name = "Glendale",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/47/Glendale-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150530113232",
                    Model = "glendale",
                    Dlc = Dlc.ImNotaHipsterUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Ingot",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/62/Ingot-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160411170058",
                    Model = "ingot",
                },
                new VehicleListItem()
                {
                    Name = "Intruder",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7c/Intruder-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305191559",
                    Model = "intruder",
                },
                new VehicleListItem()
                {
                    Name = "Premier",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/ca/Premier-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180637",
                    Model = "premier",
                },
                new VehicleListItem()
                {
                    Name = "Primo",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/10/Primo-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160406175756",
                    Model = "primo",
                },
                new VehicleListItem()
                {
                    Name = "Primo Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/ca/PrimoCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151021162950",
                    Model = "primo2",
                    Dlc = Dlc.Lowriders,
                },
                new VehicleListItem()
                {
                    Name = "Regina",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/71/Regina-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160625231110",
                    Model = "regina",
                },
                new VehicleListItem()
                {
                    Name = "Schafter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/57/Schafter-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409181945",
                    Model = "schafter2",
                },
                new VehicleListItem()
                {
                    Name = "Schafter LWB (Armoured)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c3/SchafterLWBArmored-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172313",
                    Model = "schafter6",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Schafter V12 (Armoured)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7c/SchafterV12Armored-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172126",
                    Model = "schafter5",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Stafford",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/38/Stafford-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725175405",
                    Model = "stafford",
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Stanier",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7b/Stanier-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305182639",
                    Model = "stanier",
                },
                new VehicleListItem()
                {
                    Name = "Stratum",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/38/Stratum-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305185828",
                    Model = "stratum",
                },
                new VehicleListItem()
                {
                    Name = "Super Diamond",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d8/SuperDiamond-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409182331",
                    Model = "superd",
                },
                new VehicleListItem()
                {
                    Name = "Surge",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c2/Surge-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018181104",
                    Model = "surge",
                },
                new VehicleListItem()
                {
                    Name = "Tailgater",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e1/Tailgater-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917232330",
                    Model = "tailgater",
                },
                new VehicleListItem()
                {
                    Name = "Turreted Limo",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/39/TurretedLimo-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160119163948",
                    Model = "limo2",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Warrener",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3c/Warrener-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302171843",
                    Model = "warrener",
                    Dlc = Dlc.ImNotaHipsterUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Washington",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/12/Washington-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160410151922",
                    Model = "washington",
                },
                new VehicleListItem()
                {
                    Name = "Romero Hearse",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/15/RomeroHearse-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929173527",
                    Model = "romero",
                },
                new VehicleListItem()
                {
                    Name = "Stretch",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/48/Stretch-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409182123",
                    Model = "stretch",
                },
            }));
        }

        private static void InitialiseService(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Service, new List<VehicleListItem>()
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
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Festival Bus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/88/FestivalBus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180725180922",
                    Model = "pbus2",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
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
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Wastelander",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e3/Wastelander-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213203148",
                    Model = "wastelander",
                },
            }));
        }

        private static void InitialiseSport(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Sports, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "9F",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2d/9F-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150529201705",
                    Model = "ninef",
                },
                new VehicleListItem()
                {
                    Name = "9F Cabrio",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a1/9FCabrio-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150529201708",
                    Model = "ninef2",
                },
                new VehicleListItem()
                {
                    Name = "Alpha",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/94/Alpha-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917231444",
                    Model = "alpha",
                    Dlc = Dlc.TheBusinessUpdate,
                },
                new VehicleListItem()
                {
                    Name = "ZR380 (Apocalypse)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/20/ApocalypseZR380-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214201711",
                    Model = "zr380",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "ZR380 (Future Shock)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9e/FutureShockZR380-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214201713",
                    Model = "zr3802",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "ZR380 (Nightmare)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/06/NightmareZR380-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214201719",
                    Model = "zr3803",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Banshee",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/82/Banshee-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929173524",
                    Model = "banshee",
                },
                new VehicleListItem()
                {
                    Name = "Bestia GTS",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a5/BestiaGTS-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014162647",
                    Model = "bestiagts",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
                new VehicleListItem()
                {
                    Name = "Blista Compact",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/06/BlistaCompact-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929162026",
                    Model = "blista2",
                },
                new VehicleListItem()
                {
                    Name = "Blista Compact (Go Go Monkey)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/76/GoGoMonkeyBlista-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929162113",
                    Model = "blista3",
                },
                new VehicleListItem()
                {
                    Name = "Buffalo",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7d/Buffalo-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183432",
                    Model = "buffalo",
                },
                new VehicleListItem()
                {
                    Name = "Buffalo S",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e1/BuffaloS-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150531171438",
                    Model = "buffalo2",
                },
                new VehicleListItem()
                {
                    Name = "Buffalo Sprunk",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/34/SprunkBuffalo-GTAVPC-front.png/revision/latest/scale-to-width-down/350?cb=20150529175841",
                    Model = "buffalo3",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Carbonizzare",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7b/CarbonizzareDown-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917231442",
                    Model = "carbonizzare",
                },
                new VehicleListItem()
                {
                    Name = "Comet",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d2/Comet-GTAV-front.png/revision/latest?cb=20160702195302",
                    Model = "comet2",
                },
                new VehicleListItem()
                {
                    Name = "Comet Retro Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a0/CometRetroCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213201950",
                    Model = "comet3",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Comet Safari",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/aa/CometSafari-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218202452",
                    Model = "comet4",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Comet SR",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0f/CometSR-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218193000",
                    Model = "comet5",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Coquette",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/08/Coquette-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160429175114",
                    Model = "coquette",
                },
                new VehicleListItem()
                {
                    Name = "Drift Tampa",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/51/DriftTampa-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123654",
                    Model = "tampa2",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Elegy RH8",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4f/ElegyRH8-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160525194616",
                    Model = "elegy2",
                },
                new VehicleListItem()
                {
                    Name = "Elegy Retro Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/68/ElegyRetroCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202302",
                    Model = "elegy",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Feltzer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8f/Feltzer-GTAVPC-Front.png/revision/latest/scale-to-width-down/350?cb=20150718115304",
                    Model = "feltzer2",
                },
                new VehicleListItem()
                {
                    Name = "Flash GT",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3b/FlashGT-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180901173617",
                    Model = "flashgt",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Furore GT",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/56/FuroreGT-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302175246",
                    Model = "furoregt",
                    Dlc = Dlc.LastTeamStandingUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Fusilade",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a0/Fusilade-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160409171753",
                    Model = "fusilade",
                },
                new VehicleListItem()
                {
                    Name = "Futo",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/67/Futo-GTAV-front.PNG/revision/latest/scale-to-width-down/350?cb=20180726155611",
                    Model = "futo",
                },
                new VehicleListItem()
                {
                    Name = "GB200",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/36/GB200-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180329205448",
                    Model = "gb200",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Hotring Sabre",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8f/HotringSabre-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180325152713",
                    Model = "hotring",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Itali GTO",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ec/ItaliGTO-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20181214181625",
                    Model = "italigto",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Jester",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/af/Jester-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917231438",
                    Model = "jester",
                    Dlc = Dlc.TheBusinessUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Jester Classic",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1a/JesterClassic-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190121092851",
                    Model = "jester3",
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Jester (Racecar)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fd/Jester%28Racecar%29-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111195702",
                    Model = "jester2",
                    Dlc = Dlc.FestiveSurprise,
                },
                new VehicleListItem()
                {
                    Name = "Khamelion",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/1f/Khamelion-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160917231447",
                    Model = "khamelion",
                },
                new VehicleListItem()
                {
                    Name = "Kuruma",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/53/Kuruma-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160501145849",
                    Model = "kuruma",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Kuruma (Armoured)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/97/ArmoredKuruma-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151212172101",
                    Model = "kuruma2",
                    Dlc = Dlc.HeistsUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Lynx",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a7/Lynx-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123941",
                    Model = "lynx",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Massacro",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/12/Massacro-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183607",
                    Model = "massacro",
                    Dlc = Dlc.HighLifeUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Massacro (Racecar)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/d0/Massacro%28Racecar%29-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183605",
                    Model = "massacro2",
                    Dlc = Dlc.FestiveSurprise,
                },
                new VehicleListItem()
                {
                    Name = "Neon",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c0/Neon-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171220191339",
                    Model = "neon",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Omnis",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e7/Omnis-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712122549",
                    Model = "omnis",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Pariah",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/ff/Pariah-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218203236",
                    Model = "pariah",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Penumra",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cc/Penumbra-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20171024163859",
                    Model = "penumbra",
                },
                new VehicleListItem()
                {
                    Name = "Raiden",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b5/Raiden-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218192549",
                    Model = "raiden",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Rapid GT",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/42/RapidGT-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150529203102",
                    Model = "rapidgt",
                },
                new VehicleListItem()
                {
                    Name = "Rapid GT (Convertible)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f8/RapidGT2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150529203104",
                    Model = "rapidgt2",
                },
                new VehicleListItem()
                {
                    Name = "Raptor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/cc/Raptor-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161004180544",
                    Model = "raptor",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Bikers,
                },
                new VehicleListItem()
                {
                    Name = "Revolter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e8/Revolter-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218203456",
                    Model = "revolter",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Ruston",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2c/Ruston-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170314170818",
                    Model = "ruston",
                    Dlc = Dlc.CunningStuntsSpecialVehicleCircuit,
                },
                new VehicleListItem()
                {
                    Name = "Seven-70",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/21/Seven70-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014163258",
                    Model = "seven70",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
                new VehicleListItem()
                {
                    Name = "Schafter LWB",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/22/SchafterLWB-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172307",
                    Model = "schafter4",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Schafter V12",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/a/a6/SchafterV12-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20151216172122",
                    Model = "schafter3",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Schlagen GT",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/42/SchlagenGT-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190107163325",
                    Model = "schlagen",
                    Dlc = Dlc.ArenaWar,
                },
                new VehicleListItem()
                {
                    Name = "Schwartzer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/ff/Schwartzer-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160929173528",
                    Model = "schwarzer",
                },
                new VehicleListItem()
                {
                    Name = "Sentinel Classic",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/dc/SentinelClassic-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218204330",
                    Model = "sentinel3",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Specter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/7b/Specter-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202907",
                    Model = "specter",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Specter Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/01/SpecterCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202941",
                    Model = "specter2",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Streiter",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/38/Streiter-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20171218193930",
                    Model = "streiter",
                    Dlc = Dlc.TheDoomsdayHeist,
                },
                new VehicleListItem()
                {
                    Name = "Sultan",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/bb/Sultan-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183641",
                    Model = "sultan",
                },
                new VehicleListItem()
                {
                    Name = "Surano",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/fd/SuranoDown-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160305181513",
                    Model = "surano",
                },
                new VehicleListItem()
                {
                    Name = "Tropos Rallye",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/d/df/TroposRallye-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014163622",
                    Model = "tropos",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "Verlierer",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8c/Verlierer-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183730",
                    Model = "verlierer2",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },

            }));
        }

        private static void InitialiseSuper(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Super, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "811",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c7/811A-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014163127",
                    Model = "pfister811",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
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
                    Dlc = Dlc.January2016Update,
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
                    Dlc = Dlc.SmugglersRun,
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
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "ETR-1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/76/ETR1-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123550",
                    Model = "sheava",
                    Dlc = Dlc.CunningStunts,
                },
                new VehicleListItem()
                {
                    Name = "FMJ",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8c/FMJ-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161014163347",
                    Model = "fmj",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
                new VehicleListItem()
                {
                    Name = "GP1",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8a/GP1-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170314170715",
                    Model = "gp1",
                    Dlc = Dlc.CunningStuntsSpecialVehicleCircuit,
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
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Itali GTB Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c5/ItaliGTBCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202528",
                    Model = "italigtb2",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Nero",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/5e/Nero-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202624",
                    Model = "nero",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Nero Custom",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/40/NeroCustom-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183629",
                    Model = "nero2",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Osiris",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/53/Osiris-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20150614104749",
                    Model = "osiris",
                    Dlc = Dlc.IllGottenGainsPart1,
                },
                new VehicleListItem()
                {
                    Name = "Penetrator",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/9c/Penetrator-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213202741",
                    Model = "penetrator",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "RE-7B",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/7/77/RE7B-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712123452",
                    Model = "le7b",
                    Dlc = Dlc.CunningStunts,
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
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.AfterHours,
                },
                new VehicleListItem()
                {
                    Name = "Sultan RS",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/c1/SultanRS-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160128182129",
                    Model = "sultanrs",
                    Dlc = Dlc.January2016Update,
                },
                new VehicleListItem()
                {
                    Name = "T20",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/20/T20-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20180331183732",
                    Model = "t20",
                    Dlc = Dlc.ExecutivesandOtherCriminals,
                },
                new VehicleListItem()
                {
                    Name = "Taipan",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4c/Taipan-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180328210610",
                    Model = "taipan",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Tempesta",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/35/Tempesta-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20161213203018",
                    Model = "tempesta",
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "Tezeract",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/c/ca/Tezeract-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183737",
                    Model = "tezeract",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Turismo R",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/61/TurismoR-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161111200407",
                    Model = "turismor",
                    Dlc = Dlc.TheBusinessUpdate,
                },
                new VehicleListItem()
                {
                    Name = "Tyrant",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f7/Tyrant-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20190106193204",
                    Model = "tyrant",
                    Dlc = Dlc.SouthernSanAndreasSuperSportSeries,
                },
                new VehicleListItem()
                {
                    Name = "Tyrus",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/8/8f/Tyrus-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160712122822",
                    Model = "tyrus",
                    Dlc = Dlc.CunningStunts,
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
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Vigilante",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/ec/Vigilante-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20180331183732",
                    Model = "vigilante",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.SmugglersRun,
                },
                new VehicleListItem()
                {
                    Name = "Visione",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/5/57/Visione-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170916171115",
                    Model = "visione",
                    Dlc = Dlc.SmugglersRun,
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
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.ImportExport,
                },
                new VehicleListItem()
                {
                    Name = "X80 Proto",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/b3/X80Proto-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20160609144552",
                    Model = "prototipo",
                    Dlc = Dlc.FurtherAdventuresinFinanceandFelony,
                },
                new VehicleListItem()
                {
                    Name = "XA-21",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/69/XA21-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143529",
                    Model = "xa21",
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Zentorno",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/6/60/Zentorno-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160302171211",
                    Model = "zentorno",
                    Dlc = Dlc.HighLifeUpdate,
                },
            }));
        }

        private static void InitialiseUtility(List<VehicleListItem> list)
        {
            list.AddRange(AddVehicleClass(VehicleClass.Utility, new List<VehicleListItem>()
            {
                new VehicleListItem()
                {
                    Name = "Airtug",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f9/Airtug-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175626",
                    Model = "airtug",
                },
                new VehicleListItem()
                {
                    Name = "Caddy",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/0e/Caddy-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018175900",
                    Model = "caddy",
                    Tags = new HashSet<string>() { "fun" },
                    Dlc = Dlc.Gunrunning,
                },
                new VehicleListItem()
                {
                    Name = "Caddy (Citizen)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/05/Caddy2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626144109",
                    Model = "caddy2",
                },
                new VehicleListItem()
                {
                    Name = "Caddy (Bunker)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4f/Caddy3-GTAO-front.png/revision/latest/scale-to-width-down/350?cb=20170614143908",
                    Model = "caddy3",
                },
                new VehicleListItem()
                {
                    Name = "Docktug",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f4/Docktug-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180059",
                    Model = "docktug",
                },
                new VehicleListItem()
                {
                    Name = "Fieldmaster",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/11/Fieldmaster-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626144225",
                    Model = "tractor2",
                },
                new VehicleListItem()
                {
                    Name = "Fieldmaster (Snow-Covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f8/Fieldmaster2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160916164933",
                    Model = "tractor3",
                },
                new VehicleListItem()
                {
                    Name = "Forklift",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/9/97/Forklift-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702195405",
                    Model = "forklift",
                },
                new VehicleListItem()
                {
                    Name = "Lawnmower",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/20/LawnMower-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180609",
                    Model = "mower",
                    Tags = new HashSet<string>() { "fun" },
                },
                new VehicleListItem()
                {
                    Name = "Ripley",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/08/Ripley-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180754",
                    Model = "ripley",
                },
                new VehicleListItem()
                {
                    Name = "Sadler",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/0/07/Sadler-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018180756",
                    Model = "sadler",
                },
                new VehicleListItem()
                {
                    Name = "Sadler (Snow-Covered)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/e/e2/Sadler2-GTAV-front.png/revision/latest/scale-to-width-down/270?cb=20160916164931",
                    Model = "sadler2",
                },
                new VehicleListItem()
                {
                    Name = "Scrap Truck",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/3/3a/ScrapTruck-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160520164314",
                    Model = "scrap",
                },
                new VehicleListItem()
                {
                    Name = "Towtruck",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/24/Towtruck2-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160625224220",
                    Model = "towtruck",
                },
                new VehicleListItem()
                {
                    Name = "Towtruck (Variant)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/b/be/Towtruck-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160702195216",
                    Model = "towtruck2",
                },
                new VehicleListItem()
                {
                    Name = "Tractor",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/f/f4/Tractor-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20161018181109",
                    Model = "tractor",
                },
                new VehicleListItem()
                {
                    Name = "Utility Truck (Crane)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/4/4d/UtilityTruckCrane-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626153900",
                    Model = "utillitruck",
                },
                new VehicleListItem()
                {
                    Name = "Utility Truck (Box)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/2/2d/UtilityTruck2Box-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626153858",
                    Model = "utillitruck2",
                },
                new VehicleListItem()
                {
                    Name = "Utility Truck (Pickup)",
                    Image = "https://vignette.wikia.nocookie.net/gtawiki/images/1/10/UtilityTruck3-GTAV-front.png/revision/latest/scale-to-width-down/350?cb=20160626155333",
                    Model = "utillitruck3",
                },
            }));
        }

        private static List<VehicleListItem> AddVehicleClass(VehicleClass vehicleClass, List<VehicleListItem> list)
        {
            list.ForEach((item) => item.VehicleClass = vehicleClass);
            return list;
        }
    }
}
