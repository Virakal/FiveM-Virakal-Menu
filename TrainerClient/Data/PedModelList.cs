using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Data
{
    public static class PedModelList
    {
        private static List<PedModelListItem> Models = new List<PedModelListItem>();
        private static bool initialised = false;

        public static IEnumerable<PedModelListItem> GetByType(PedModelType type)
        {
            Initialise();

            return Models
                .Where((item) => item.Type == type)
                .OrderBy((x) => x.Name);
        }

        private static void Initialise()
        {
            if (initialised)
            {
                return;
            }

            initialised = true;

            Models.AddRange(new List<PedModelListItem>()
            {
                // Animals
                new PedModelListItem()
                {
                    Name = "Boar",
                    Model = "A_C_Boar",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Cat",
                    Model = "A_C_Cat_01",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Chickenhawk (Can crash game)",
                    Model = "A_C_Chickenhawk",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Chimp",
                    Model = "A_C_Chimp",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Chop",
                    Model = "a_c_chop",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Cormorant",
                    Model = "A_C_Cormorant",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Cow",
                    Model = "A_C_Cow",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Coyote",
                    Model = "A_C_Coyote",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Crow",
                    Model = "A_C_Crow",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Deer",
                    Model = "A_C_Deer",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Dolphin",
                    Model = "A_C_Dolphin",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Fish",
                    Model = "A_C_Fish",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "German Shepherd",
                    Model = "A_C_shepherd",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Hen",
                    Model = "A_C_Hen",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Hammerhead Shark",
                    Model = "A_C_SharkHammer",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Humpback Whale",
                    Model = "A_C_HumpBack",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Husky",
                    Model = "A_C_Husky",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Killer Whale",
                    Model = "A_C_KillerWhale",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Mountain Lion",
                    Model = "A_C_MtLion",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Pig",
                    Model = "A_C_Pig",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Poodle",
                    Model = "A_C_Poodle",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Pug",
                    Model = "A_C_Pug",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Pigeon",
                    Model = "A_C_Pigeon",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Rabbit",
                    Model = "a_c_rabbit_01",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Rat (Can crash game)",
                    Model = "A_C_Rat",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Retriever",
                    Model = "a_c_retriever",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Rhesus Macaque",
                    Model = "a_c_rhesus",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Rottweiler",
                    Model = "a_c_rottweiler",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Seagull",
                    Model = "A_C_Seagull",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Stingray",
                    Model = "A_C_Stingray",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Tiger Shark",
                    Model = "A_C_SharkTiger",
                    Type = PedModelType.Animal,
                },
                new PedModelListItem()
                {
                    Name = "Westy",
                    Model = "a_c_westy",
                    Type = PedModelType.Animal,
                },

                // Humans
                new PedModelListItem()
                {
                    Name = "Abigail Mathers (CS)",
                    Model = "csb_abigail",
                },
                new PedModelListItem()
                {
                    Name = "Abigail Mathers (IG)",
                    Model = "ig_abigail",
                },
                new PedModelListItem()
                {
                    Name = "Abner",
                    Model = "u_m_y_abner",
                },
                new PedModelListItem()
                {
                    Name = "African American Male",
                    Model = "a_m_m_afriamer_01",
                },
                new PedModelListItem()
                {
                    Name = "Agent (CS)",
                    Model = "csb_agent",
                },
                new PedModelListItem()
                {
                    Name = "Agent (IG)",
                    Model = "ig_agent",
                },
                new PedModelListItem()
                {
                    Name = "Agent 14 (CS)",
                    Model = "csb_mp_agent14",
                },
                new PedModelListItem()
                {
                    Name = "Agent 14 (IG)",
                    Model = "ig_mp_agent14",
                },
                new PedModelListItem()
                {
                    Name = "Air Hostess",
                    Model = "s_f_y_airhostess_01",
                },
                new PedModelListItem()
                {
                    Name = "Air Worker Male",
                    Model = "s_m_y_airworker",
                },
                new PedModelListItem()
                {
                    Name = "Al Di Napoli Male",
                    Model = "u_m_m_aldinapoli",
                },
                new PedModelListItem()
                {
                    Name = "Alien",
                    Model = "s_m_m_movalien_01",
                },
                new PedModelListItem()
                {
                    Name = "Altruist Cult Mid-Age Male",
                    Model = "a_m_m_acult_01",
                },
                new PedModelListItem()
                {
                    Name = "Altruist Cult Old Male",
                    Model = "a_m_o_acult_01",
                },
                new PedModelListItem()
                {
                    Name = "Altruist Cult Old Male 2",
                    Model = "a_m_o_acult_02",
                },
                new PedModelListItem()
                {
                    Name = "Altruist Cult Young Male",
                    Model = "a_m_y_acult_01",
                },
                new PedModelListItem()
                {
                    Name = "Altruist Cult Young Male 2",
                    Model = "a_m_y_acult_02",
                },
                new PedModelListItem()
                {
                    Name = "Amanda De Santa (CS)",
                    Model = "cs_amandatownley",
                },
                new PedModelListItem()
                {
                    Name = "Amanda De Santa (IG)",
                    Model = "ig_amandatownley",
                },
                new PedModelListItem()
                {
                    Name = "Ammu-Nation City Clerk",
                    Model = "s_m_y_ammucity_01",
                },
                new PedModelListItem()
                {
                    Name = "Ammu-Nation Rural Clerk",
                    Model = "s_m_m_ammucountry",
                },
                new PedModelListItem()
                {
                    Name = "Andreas Sanchez (CS)",
                    Model = "cs_andreas",
                },
                new PedModelListItem()
                {
                    Name = "Andreas Sanchez (IG)",
                    Model = "ig_andreas",
                },
                new PedModelListItem()
                {
                    Name = "Anita Mendoza",
                    Model = "csb_anita",
                },
                new PedModelListItem()
                {
                    Name = "Anton Beaudelaire",
                    Model = "csb_anton",
                },
                new PedModelListItem()
                {
                    Name = "Anton Beaudelaire",
                    Model = "u_m_y_antonb",
                },
                new PedModelListItem()
                {
                    Name = "Armenian Boss",
                    Model = "g_m_m_armboss_01",
                },
                new PedModelListItem()
                {
                    Name = "Armenian Goon",
                    Model = "g_m_m_armgoon_01",
                },
                new PedModelListItem()
                {
                    Name = "Armenian Goon 2",
                    Model = "g_m_y_armgoon_02",
                },
                new PedModelListItem()
                {
                    Name = "Armenian Lieutenant",
                    Model = "g_m_m_armlieut_01",
                },
                new PedModelListItem()
                {
                    Name = "Armoured Van Security",
                    Model = "mp_s_m_armoured_01",
                },
                new PedModelListItem()
                {
                    Name = "Armoured Van Security",
                    Model = "s_m_m_armoured_01",
                },
                new PedModelListItem()
                {
                    Name = "Armoured Van Security 2",
                    Model = "s_m_m_armoured_02",
                },
                new PedModelListItem()
                {
                    Name = "Army Mechanic",
                    Model = "s_m_y_armymech_01",
                },
                new PedModelListItem()
                {
                    Name = "Ashley Butler (CS)",
                    Model = "cs_ashley",
                },
                new PedModelListItem()
                {
                    Name = "Ashley Butler (IG)",
                    Model = "ig_ashley",
                },
                new PedModelListItem()
                {
                    Name = "Autopsy Tech",
                    Model = "s_m_y_autopsy_01",
                },
                new PedModelListItem()
                {
                    Name = "Autoshop Worker",
                    Model = "s_m_m_autoshop_01",
                },
                new PedModelListItem()
                {
                    Name = "Autoshop Worker 2",
                    Model = "s_m_m_autoshop_02",
                },
                new PedModelListItem()
                {
                    Name = "Azteca",
                    Model = "g_m_y_azteca_01",
                },
                new PedModelListItem()
                {
                    Name = "Baby D",
                    Model = "u_m_y_babyd",
                },
                new PedModelListItem()
                {
                    Name = "Ballas East Male",
                    Model = "g_m_y_ballaeast_01",
                },
                new PedModelListItem()
                {
                    Name = "Ballas Female",
                    Model = "g_f_y_ballas_01",
                },
                new PedModelListItem()
                {
                    Name = "Ballas OG",
                    Model = "csb_ballasog",
                },
                new PedModelListItem()
                {
                    Name = "Ballas OG (IG)",
                    Model = "ig_ballasog",
                },
                new PedModelListItem()
                {
                    Name = "Ballas Original Male (IG)",
                    Model = "g_m_y_ballaorig_01",
                },
                new PedModelListItem()
                {
                    Name = "Ballas South Male",
                    Model = "g_m_y_ballasout_01",
                },
                new PedModelListItem()
                {
                    Name = "Bank Manager (CS)",
                    Model = "cs_bankman",
                },
                new PedModelListItem()
                {
                    Name = "Bank Manager (IG)",
                    Model = "ig_bankman",
                },
                new PedModelListItem()
                {
                    Name = "Bank Manager Male",
                    Model = "u_m_m_bankman",
                },
                new PedModelListItem()
                {
                    Name = "Barber Female",
                    Model = "s_f_m_fembarber",
                },
                new PedModelListItem()
                {
                    Name = "Barman",
                    Model = "s_m_y_barman_01",
                },
                new PedModelListItem()
                {
                    Name = "Barry (CS)",
                    Model = "cs_barry",
                },
                new PedModelListItem()
                {
                    Name = "Barry (IG)",
                    Model = "ig_barry",
                },
                new PedModelListItem()
                {
                    Name = "Bartender",
                    Model = "s_f_y_bartender_01",
                },
                new PedModelListItem()
                {
                    Name = "Bartender (Rural)",
                    Model = "s_m_m_cntrybar_01",
                },
                new PedModelListItem()
                {
                    Name = "Baywatch Female",
                    Model = "s_f_y_baywatch_01",
                },
                new PedModelListItem()
                {
                    Name = "Baywatch Male",
                    Model = "s_m_y_baywatch_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Female",
                    Model = "a_f_m_beach_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Male",
                    Model = "a_m_m_beach_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Male 2",
                    Model = "a_m_m_beach_02",
                },
                new PedModelListItem()
                {
                    Name = "Beach Muscle Male",
                    Model = "a_m_y_musclbeac_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Muscle Male 2",
                    Model = "a_m_y_musclbeac_02",
                },
                new PedModelListItem()
                {
                    Name = "Beach Old Male",
                    Model = "a_m_o_beach_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Tramp Female",
                    Model = "a_f_m_trampbeac_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Tramp Male",
                    Model = "a_m_m_trampbeac_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Young Female",
                    Model = "a_f_y_beach_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Young Male",
                    Model = "a_m_y_beach_01",
                },
                new PedModelListItem()
                {
                    Name = "Beach Young Male 2",
                    Model = "a_m_y_beach_02",
                },
                new PedModelListItem()
                {
                    Name = "Beach Young Male 3",
                    Model = "a_m_y_beach_03",
                },
                new PedModelListItem()
                {
                    Name = "Benny",
                    Model = "ig_benny",
                },
                new PedModelListItem()
                {
                    Name = "Best Man (IG)",
                    Model = "ig_bestmen",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Felton (CS)",
                    Model = "cs_beverly",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Felton (IG)",
                    Model = "ig_beverly",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Female",
                    Model = "a_f_m_bevhills_01",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Female 2",
                    Model = "a_f_m_bevhills_02",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Male",
                    Model = "a_m_m_bevhills_01",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Male 2",
                    Model = "a_m_m_bevhills_02",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Young Female",
                    Model = "a_f_y_bevhills_01",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Young Female 2",
                    Model = "a_f_y_bevhills_02",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Young Female 3",
                    Model = "a_f_y_bevhills_03",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Young Female 4",
                    Model = "a_f_y_bevhills_04",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Young Male",
                    Model = "a_m_y_bevhills_01",
                },
                new PedModelListItem()
                {
                    Name = "Beverly Hills Young Male 2",
                    Model = "a_m_y_bevhills_02",
                },
                new PedModelListItem()
                {
                    Name = "Bigfoot (CS)",
                    Model = "cs_orleans",
                },
                new PedModelListItem()
                {
                    Name = "Bigfoot (IG)",
                    Model = "ig_orleans",
                },
                new PedModelListItem()
                {
                    Name = "Bike Hire Guy",
                    Model = "u_m_m_bikehire_01",
                },
                new PedModelListItem()
                {
                    Name = "Biker Chic Female",
                    Model = "u_f_y_bikerchic",
                },
                new PedModelListItem()
                {
                    Name = "Black Ops Soldier",
                    Model = "s_m_y_blackops_01",
                },
                new PedModelListItem()
                {
                    Name = "Black Ops Soldier 2",
                    Model = "s_m_y_blackops_02",
                },
                new PedModelListItem()
                {
                    Name = "Black Ops Soldier 3",
                    Model = "s_m_y_blackops_03",
                },
                new PedModelListItem()
                {
                    Name = "Black Street Male",
                    Model = "a_m_y_stbla_01",
                },
                new PedModelListItem()
                {
                    Name = "Black Street Male 2",
                    Model = "a_m_y_stbla_02",
                },
                new PedModelListItem()
                {
                    Name = "Bodybuilder Female",
                    Model = "a_f_m_bodybuild_01",
                },
                new PedModelListItem()
                {
                    Name = "Bouncer",
                    Model = "s_m_m_bouncer_01",
                },
                new PedModelListItem()
                {
                    Name = "Brad (CS)",
                    Model = "cs_brad",
                },
                new PedModelListItem()
                {
                    Name = "Brad (IG)",
                    Model = "ig_brad",
                },
                new PedModelListItem()
                {
                    Name = "Brad's Cadaver (CS)",
                    Model = "cs_bradcadaver",
                },
                new PedModelListItem()
                {
                    Name = "Breakdancer Male",
                    Model = "a_m_y_breakdance_01",
                },
                new PedModelListItem()
                {
                    Name = "Bride",
                    Model = "csb_bride",
                },
                new PedModelListItem()
                {
                    Name = "Bride (IG)",
                    Model = "ig_bride",
                },
                new PedModelListItem()
                {
                    Name = "Burger Drug Worker",
                    Model = "csb_burgerdrug",
                },
                new PedModelListItem()
                {
                    Name = "Burger Drug Worker",
                    Model = "u_m_y_burgerdrug_01",
                },
                new PedModelListItem()
                {
                    Name = "Busboy",
                    Model = "s_m_y_busboy_01",
                },
                new PedModelListItem()
                {
                    Name = "Business Casual",
                    Model = "a_m_y_busicas_01",
                },
                new PedModelListItem()
                {
                    Name = "Business Female 2",
                    Model = "a_f_m_business_02",
                },
                new PedModelListItem()
                {
                    Name = "Business Male",
                    Model = "a_m_m_business_01",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Female",
                    Model = "a_f_y_business_01",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Female 2",
                    Model = "a_f_y_business_02",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Female 3",
                    Model = "a_f_y_business_03",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Female 4",
                    Model = "a_f_y_business_04",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Male",
                    Model = "a_m_y_business_01",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Male 2",
                    Model = "a_m_y_business_02",
                },
                new PedModelListItem()
                {
                    Name = "Business Young Male 3",
                    Model = "a_m_y_business_03",
                },
                new PedModelListItem()
                {
                    Name = "Busker",
                    Model = "s_m_o_busker_01",
                },
                new PedModelListItem()
                {
                    Name = "Car 3 Guy 1",
                    Model = "csb_car3guy1",
                },
                new PedModelListItem()
                {
                    Name = "Car 3 Guy 1 (IG)",
                    Model = "ig_car3guy1",
                },
                new PedModelListItem()
                {
                    Name = "Car 3 Guy 2",
                    Model = "csb_car3guy2",
                },
                new PedModelListItem()
                {
                    Name = "Car 3 Guy 2 (IG)",
                    Model = "ig_car3guy2",
                },
                new PedModelListItem()
                {
                    Name = "Car Buyer (CS)",
                    Model = "cs_carbuyer",
                },
                new PedModelListItem()
                {
                    Name = "Casey (CS)",
                    Model = "cs_casey",
                },
                new PedModelListItem()
                {
                    Name = "Casey (IG)",
                    Model = "ig_casey",
                },
                new PedModelListItem()
                {
                    Name = "Chef",
                    Model = "s_m_y_chef_01",
                },
                new PedModelListItem()
                {
                    Name = "Chef",
                    Model = "csb_chef",
                },
                new PedModelListItem()
                {
                    Name = "Chef (CS)",
                    Model = "csb_chef2",
                },
                new PedModelListItem()
                {
                    Name = "Chef (IG)",
                    Model = "ig_chef",
                },
                new PedModelListItem()
                {
                    Name = "Chef (IG)",
                    Model = "ig_chef2",
                },
                new PedModelListItem()
                {
                    Name = "Chemical Plant Security",
                    Model = "s_m_m_chemsec_01",
                },
                new PedModelListItem()
                {
                    Name = "Chemical Plant Worker",
                    Model = "g_m_m_chemwork_01",
                },
                new PedModelListItem()
                {
                    Name = "Chinese Boss",
                    Model = "g_m_m_chiboss_01",
                },
                new PedModelListItem()
                {
                    Name = "Chinese Goon",
                    Model = "g_m_m_chigoon_01",
                },
                new PedModelListItem()
                {
                    Name = "Chinese Goon",
                    Model = "csb_chin_goon",
                },
                new PedModelListItem()
                {
                    Name = "Chinese Goon 2",
                    Model = "g_m_m_chigoon_02",
                },
                new PedModelListItem()
                {
                    Name = "Chinese Goon Older",
                    Model = "g_m_m_chicold_01",
                },
                new PedModelListItem()
                {
                    Name = "Chip",
                    Model = "u_m_y_chip",
                },
                new PedModelListItem()
                {
                    Name = "Claude Speed",
                    Model = "mp_m_claude_01",
                },
                new PedModelListItem()
                {
                    Name = "Clay Jackson (The Pain Giver) (IG)",
                    Model = "ig_claypain",
                },
                new PedModelListItem()
                {
                    Name = "Clay Simons (The Lost) (CS)",
                    Model = "cs_clay",
                },
                new PedModelListItem()
                {
                    Name = "Clay Simons (The Lost) (IG)",
                    Model = "ig_clay",
                },
                new PedModelListItem()
                {
                    Name = "Cletus",
                    Model = "csb_cletus",
                },
                new PedModelListItem()
                {
                    Name = "Cletus (IG)",
                    Model = "ig_cletus",
                },
                new PedModelListItem()
                {
                    Name = "Clown",
                    Model = "s_m_y_clown_01",
                },
                new PedModelListItem()
                {
                    Name = "Construction Worker",
                    Model = "s_m_y_construct_01",
                },
                new PedModelListItem()
                {
                    Name = "Construction Worker 2",
                    Model = "s_m_y_construct_02",
                },
                new PedModelListItem()
                {
                    Name = "Cop",
                    Model = "csb_cop",
                },
                new PedModelListItem()
                {
                    Name = "Cop Female",
                    Model = "s_f_y_cop_01",
                },
                new PedModelListItem()
                {
                    Name = "Cop Male",
                    Model = "s_m_y_cop_01",
                },
                new PedModelListItem()
                {
                    Name = "Corpse Female",
                    Model = "u_f_m_corpse_01",
                },
                new PedModelListItem()
                {
                    Name = "Corpse Young Female",
                    Model = "u_f_y_corpse_01",
                },
                new PedModelListItem()
                {
                    Name = "Corpse Young Female 2",
                    Model = "u_f_y_corpse_02",
                },
                new PedModelListItem()
                {
                    Name = "Crew Member",
                    Model = "s_m_m_ccrew_01",
                },
                new PedModelListItem()
                {
                    Name = "Cris Formage (CS)",
                    Model = "cs_chrisformage",
                },
                new PedModelListItem()
                {
                    Name = "Cris Formage (IG)",
                    Model = "ig_chrisformage",
                },
                new PedModelListItem()
                {
                    Name = "Customer",
                    Model = "csb_customer",
                },
                new PedModelListItem()
                {
                    Name = "Cyclist Male",
                    Model = "a_m_y_cyclist_01",
                },
                new PedModelListItem()
                {
                    Name = "Cyclist Male",
                    Model = "u_m_y_cyclist_01",
                },
                new PedModelListItem()
                {
                    Name = "Dale (CS)",
                    Model = "cs_dale",
                },
                new PedModelListItem()
                {
                    Name = "Dale (IG)",
                    Model = "ig_dale",
                },
                new PedModelListItem()
                {
                    Name = "Dave Norton (CS)",
                    Model = "cs_davenorton",
                },
                new PedModelListItem()
                {
                    Name = "Dave Norton (IG)",
                    Model = "ig_davenorton",
                },
                new PedModelListItem()
                {
                    Name = "Dead Hooker",
                    Model = "mp_f_deadhooker",
                },
                new PedModelListItem()
                {
                    Name = "Dealer",
                    Model = "s_m_y_dealer_01",
                },
                new PedModelListItem()
                {
                    Name = "Debra (CS)",
                    Model = "cs_debra",
                },
                new PedModelListItem()
                {
                    Name = "Denise (CS)",
                    Model = "cs_denise",
                },
                new PedModelListItem()
                {
                    Name = "Denise (IG)",
                    Model = "ig_denise",
                },
                new PedModelListItem()
                {
                    Name = "Denise's Friend",
                    Model = "csb_denise_friend",
                },
                new PedModelListItem()
                {
                    Name = "Devin (CS)",
                    Model = "cs_devin",
                },
                new PedModelListItem()
                {
                    Name = "Devin (IG)",
                    Model = "ig_devin",
                },
                new PedModelListItem()
                {
                    Name = "Devin's Security",
                    Model = "s_m_y_devinsec_01",
                },
                new PedModelListItem()
                {
                    Name = "Dima Popov (CS)",
                    Model = "csb_popov",
                },
                new PedModelListItem()
                {
                    Name = "Dima Popov (IG)",
                    Model = "ig_popov",
                },
                new PedModelListItem()
                {
                    Name = "DOA Man",
                    Model = "u_m_m_doa_01",
                },
                new PedModelListItem()
                {
                    Name = "Dock Worker",
                    Model = "s_m_m_dockwork_01",
                },
                new PedModelListItem()
                {
                    Name = "Dock Worker",
                    Model = "s_m_y_dockwork_01",
                },
                new PedModelListItem()
                {
                    Name = "Doctor",
                    Model = "s_m_m_doctor_01",
                },
                new PedModelListItem()
                {
                    Name = "Dom Beasley (CS)",
                    Model = "cs_dom",
                },
                new PedModelListItem()
                {
                    Name = "Dom Beasley (IG)",
                    Model = "ig_dom",
                },
                new PedModelListItem()
                {
                    Name = "Doorman",
                    Model = "s_m_y_doorman_01",
                },
                new PedModelListItem()
                {
                    Name = "Downhill Cyclist",
                    Model = "a_m_y_dhill_01",
                },
                new PedModelListItem()
                {
                    Name = "Downtown Female",
                    Model = "a_f_m_downtown_01",
                },
                new PedModelListItem()
                {
                    Name = "Downtown Male",
                    Model = "a_m_y_downtown_01",
                },
                new PedModelListItem()
                {
                    Name = "Dr. Friedlander (CS)",
                    Model = "cs_drfriedlander",
                },
                new PedModelListItem()
                {
                    Name = "Dr. Friedlander (IG)",
                    Model = "ig_drfriedlander",
                },
                new PedModelListItem()
                {
                    Name = "Dressy Female",
                    Model = "a_f_y_scdressy_01",
                },
                new PedModelListItem()
                {
                    Name = "DW Airport Worker",
                    Model = "s_m_y_dwservice_01",
                },
                new PedModelListItem()
                {
                    Name = "DW Airport Worker 2",
                    Model = "s_m_y_dwservice_02",
                },
                new PedModelListItem()
                {
                    Name = "East SA Female",
                    Model = "a_f_m_eastsa_01",
                },
                new PedModelListItem()
                {
                    Name = "East SA Female 2",
                    Model = "a_f_m_eastsa_02",
                },
                new PedModelListItem()
                {
                    Name = "East SA Male",
                    Model = "a_m_m_eastsa_01",
                },
                new PedModelListItem()
                {
                    Name = "East SA Male 2",
                    Model = "a_m_m_eastsa_02",
                },
                new PedModelListItem()
                {
                    Name = "East SA Young Female",
                    Model = "a_f_y_eastsa_01",
                },
                new PedModelListItem()
                {
                    Name = "East SA Young Female 2",
                    Model = "a_f_y_eastsa_02",
                },
                new PedModelListItem()
                {
                    Name = "East SA Young Female 3",
                    Model = "a_f_y_eastsa_03",
                },
                new PedModelListItem()
                {
                    Name = "East SA Young Male",
                    Model = "a_m_y_eastsa_01",
                },
                new PedModelListItem()
                {
                    Name = "East SA Young Male 2",
                    Model = "a_m_y_eastsa_02",
                },
                new PedModelListItem()
                {
                    Name = "Ed Toh",
                    Model = "u_m_m_edtoh",
                },
                new PedModelListItem()
                {
                    Name = "Epsilon Female",
                    Model = "a_f_y_epsilon_01",
                },
                new PedModelListItem()
                {
                    Name = "Epsilon Male",
                    Model = "a_m_y_epsilon_01",
                },
                new PedModelListItem()
                {
                    Name = "Epsilon Male 2",
                    Model = "a_m_y_epsilon_02",
                },
                new PedModelListItem()
                {
                    Name = "Epsilon Tom (CS)",
                    Model = "cs_tomepsilon",
                },
                new PedModelListItem()
                {
                    Name = "Epsilon Tom (IG)",
                    Model = "ig_tomepsilon",
                },
                new PedModelListItem()
                {
                    Name = "Ex-Army Male",
                    Model = "mp_m_exarmy_01",
                },
                new PedModelListItem()
                {
                    Name = "Ex-Mil Bum",
                    Model = "u_m_y_militarybum",
                },
                new PedModelListItem()
                {
                    Name = "Fabien (CS)",
                    Model = "cs_fabien",
                },
                new PedModelListItem()
                {
                    Name = "Fabien (IG)",
                    Model = "ig_fabien",
                },
                new PedModelListItem()
                {
                    Name = "Factory Worker Female",
                    Model = "s_f_y_factory_01",
                },
                new PedModelListItem()
                {
                    Name = "Factory Worker Male",
                    Model = "s_m_y_factory_01",
                },
                new PedModelListItem()
                {
                    Name = "Families CA Male",
                    Model = "g_m_y_famca_01",
                },
                new PedModelListItem()
                {
                    Name = "Families DD Male",
                    Model = "mp_m_famdd_01",
                },
                new PedModelListItem()
                {
                    Name = "Families DNF Male",
                    Model = "g_m_y_famdnf_01",
                },
                new PedModelListItem()
                {
                    Name = "Families Female",
                    Model = "g_f_y_families_01",
                },
                new PedModelListItem()
                {
                    Name = "Families FOR Male",
                    Model = "g_m_y_famfor_01",
                },
                new PedModelListItem()
                {
                    Name = "Families Gang Member?",
                    Model = "csb_ramp_gang",
                },
                new PedModelListItem()
                {
                    Name = "Families Gang Member? (IG)",
                    Model = "ig_ramp_gang",
                },
                new PedModelListItem()
                {
                    Name = "Farmer",
                    Model = "a_m_m_farmer_01",
                },
                new PedModelListItem()
                {
                    Name = "Fat Black Female",
                    Model = "a_f_m_fatbla_01",
                },
                new PedModelListItem()
                {
                    Name = "Fat Cult Female",
                    Model = "a_f_m_fatcult_01",
                },
                new PedModelListItem()
                {
                    Name = "Fat Latino Male",
                    Model = "a_m_m_fatlatin_01",
                },
                new PedModelListItem()
                {
                    Name = "Fat White Female",
                    Model = "a_f_m_fatwhite_01",
                },
                new PedModelListItem()
                {
                    Name = "Female Agent",
                    Model = "a_f_y_femaleagent",
                },
                new PedModelListItem()
                {
                    Name = "Ferdinand Kerimov (Mr. K) (CS)",
                    Model = "cs_mrk",
                },
                new PedModelListItem()
                {
                    Name = "Ferdinand Kerimov (Mr. K) (IG)",
                    Model = "ig_mrk",
                },
                new PedModelListItem()
                {
                    Name = "FIB Architect",
                    Model = "u_m_m_fibarchitect",
                },
                new PedModelListItem()
                {
                    Name = "FIB Mugger",
                    Model = "u_m_y_fibmugger_01",
                },
                new PedModelListItem()
                {
                    Name = "FIB Office Worker",
                    Model = "s_m_m_fiboffice_01",
                },
                new PedModelListItem()
                {
                    Name = "FIB Office Worker 2",
                    Model = "s_m_m_fiboffice_02",
                },
                new PedModelListItem()
                {
                    Name = "FIB Security",
                    Model = "mp_m_fibsec_01",
                },
                new PedModelListItem()
                {
                    Name = "FIB Security",
                    Model = "s_m_m_fibsec_01",
                },
                new PedModelListItem()
                {
                    Name = "FIB Suit (CS)",
                    Model = "cs_fbisuit_01",
                },
                new PedModelListItem()
                {
                    Name = "FIB Suit (IG)",
                    Model = "ig_fbisuit_01",
                },
                new PedModelListItem()
                {
                    Name = "Financial Guru",
                    Model = "u_m_o_finguru_01",
                },
                new PedModelListItem()
                {
                    Name = "Fireman Male",
                    Model = "s_m_y_fireman_01",
                },
                new PedModelListItem()
                {
                    Name = "Fitness Female",
                    Model = "a_f_y_fitness_01",
                },
                new PedModelListItem()
                {
                    Name = "Fitness Female 2",
                    Model = "a_f_y_fitness_02",
                },
                new PedModelListItem()
                {
                    Name = "Floyd Hebert (CS)",
                    Model = "cs_floyd",
                },
                new PedModelListItem()
                {
                    Name = "Floyd Hebert (IG)",
                    Model = "ig_floyd",
                },
                new PedModelListItem()
                {
                    Name = "FOS Rep?",
                    Model = "csb_fos_rep",
                },
                new PedModelListItem()
                {
                    Name = "Gaffer",
                    Model = "s_m_m_gaffer_01",
                },
                new PedModelListItem()
                {
                    Name = "Garbage Worker",
                    Model = "s_m_y_garbage",
                },
                new PedModelListItem()
                {
                    Name = "Gardener",
                    Model = "s_m_m_gardener_01",
                },
                new PedModelListItem()
                {
                    Name = "Gay Male",
                    Model = "a_m_y_gay_01",
                },
                new PedModelListItem()
                {
                    Name = "Gay Male 2",
                    Model = "a_m_y_gay_02",
                },
                new PedModelListItem()
                {
                    Name = "General Fat Male",
                    Model = "a_m_m_genfat_01",
                },
                new PedModelListItem()
                {
                    Name = "General Fat Male 2",
                    Model = "a_m_m_genfat_02",
                },
                new PedModelListItem()
                {
                    Name = "General Hot Young Female",
                    Model = "a_f_y_genhot_01",
                },
                new PedModelListItem()
                {
                    Name = "General Street Old Female",
                    Model = "a_f_o_genstreet_01",
                },
                new PedModelListItem()
                {
                    Name = "General Street Old Male",
                    Model = "a_m_o_genstreet_01",
                },
                new PedModelListItem()
                {
                    Name = "General Street Young Male",
                    Model = "a_m_y_genstreet_01",
                },
                new PedModelListItem()
                {
                    Name = "General Street Young Male 2",
                    Model = "a_m_y_genstreet_02",
                },
                new PedModelListItem()
                {
                    Name = "Gerald",
                    Model = "csb_g",
                },
                new PedModelListItem()
                {
                    Name = "GLENSTANK? Male",
                    Model = "u_m_m_glenstank_01",
                },
                new PedModelListItem()
                {
                    Name = "Golfer Male",
                    Model = "a_m_m_golfer_01",
                },
                new PedModelListItem()
                {
                    Name = "Golfer Young Female",
                    Model = "a_f_y_golfer_01",
                },
                new PedModelListItem()
                {
                    Name = "Golfer Young Male",
                    Model = "a_m_y_golfer_01",
                },
                new PedModelListItem()
                {
                    Name = "Griff",
                    Model = "u_m_m_griff_01",
                },
                new PedModelListItem()
                {
                    Name = "Grip",
                    Model = "s_m_y_grip_01",
                },
                new PedModelListItem()
                {
                    Name = "Groom",
                    Model = "csb_groom",
                },
                new PedModelListItem()
                {
                    Name = "Groom (IG)",
                    Model = "ig_groom",
                },
                new PedModelListItem()
                {
                    Name = "Grove Street Dealer",
                    Model = "csb_grove_str_dlr",
                },
                new PedModelListItem()
                {
                    Name = "Guadalope (CS)",
                    Model = "cs_guadalope",
                },
                new PedModelListItem()
                {
                    Name = "Guido",
                    Model = "u_m_y_guido_01",
                },
                new PedModelListItem()
                {
                    Name = "Gun Vendor",
                    Model = "u_m_y_gunvend_01",
                },
                new PedModelListItem()
                {
                    Name = "GURK? (CS)",
                    Model = "cs_gurk",
                },
                new PedModelListItem()
                {
                    Name = "Hairdresser Male",
                    Model = "s_m_m_hairdress_01",
                },
                new PedModelListItem()
                {
                    Name = "Hao",
                    Model = "csb_hao",
                },
                new PedModelListItem()
                {
                    Name = "Hao (IG)",
                    Model = "ig_hao",
                },
                new PedModelListItem()
                {
                    Name = "Hasidic Jew Male",
                    Model = "a_m_m_hasjew_01",
                },
                new PedModelListItem()
                {
                    Name = "Hasidic Jew Young Male",
                    Model = "a_m_y_hasjew_01",
                },
                new PedModelListItem()
                {
                    Name = "Hick",
                    Model = "csb_ramp_hic",
                },
                new PedModelListItem()
                {
                    Name = "Hick (IG)",
                    Model = "ig_ramp_hic",
                },
                new PedModelListItem()
                {
                    Name = "High Security",
                    Model = "s_m_m_highsec_01",
                },
                new PedModelListItem()
                {
                    Name = "High Security 2",
                    Model = "s_m_m_highsec_02",
                },
                new PedModelListItem()
                {
                    Name = "Highway Cop",
                    Model = "s_m_y_hwaycop_01",
                },
                new PedModelListItem()
                {
                    Name = "Hiker Female",
                    Model = "a_f_y_hiker_01",
                },
                new PedModelListItem()
                {
                    Name = "Hiker Male",
                    Model = "a_m_y_hiker_01",
                },
                new PedModelListItem()
                {
                    Name = "Hillbilly Male",
                    Model = "a_m_m_hillbilly_01",
                },
                new PedModelListItem()
                {
                    Name = "Hillbilly Male 2",
                    Model = "a_m_m_hillbilly_02",
                },
                new PedModelListItem()
                {
                    Name = "Hippie Female",
                    Model = "a_f_y_hippie_01",
                },
                new PedModelListItem()
                {
                    Name = "Hippie Male",
                    Model = "u_m_y_hippie_01",
                },
                new PedModelListItem()
                {
                    Name = "Hippie Male",
                    Model = "a_m_y_hippy_01",
                },
                new PedModelListItem()
                {
                    Name = "Hipster",
                    Model = "csb_ramp_hipster",
                },
                new PedModelListItem()
                {
                    Name = "Hipster (IG)",
                    Model = "ig_ramp_hipster",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Female",
                    Model = "a_f_y_hipster_01",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Female 2",
                    Model = "a_f_y_hipster_02",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Female 3",
                    Model = "a_f_y_hipster_03",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Female 4",
                    Model = "a_f_y_hipster_04",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Male",
                    Model = "a_m_y_hipster_01",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Male 2",
                    Model = "a_m_y_hipster_02",
                },
                new PedModelListItem()
                {
                    Name = "Hipster Male 3",
                    Model = "a_m_y_hipster_03",
                },
                new PedModelListItem()
                {
                    Name = "Hooker",
                    Model = "s_f_y_hooker_01",
                },
                new PedModelListItem()
                {
                    Name = "Hooker 2",
                    Model = "s_f_y_hooker_02",
                },
                new PedModelListItem()
                {
                    Name = "Hooker 3",
                    Model = "s_f_y_hooker_03",
                },
                new PedModelListItem()
                {
                    Name = "Hospital Scrubs Female",
                    Model = "s_f_y_scrubs_01",
                },
                new PedModelListItem()
                {
                    Name = "Hot Posh Female",
                    Model = "u_f_y_hotposh_01",
                },
                new PedModelListItem()
                {
                    Name = "Hugh Welsh",
                    Model = "csb_hugh",
                },
                new PedModelListItem()
                {
                    Name = "Hunter (CS)",
                    Model = "cs_hunter",
                },
                new PedModelListItem()
                {
                    Name = "Hunter (IG)",
                    Model = "ig_hunter",
                },
                new PedModelListItem()
                {
                    Name = "IAA Security",
                    Model = "s_m_m_ciasec_01",
                },
                new PedModelListItem()
                {
                    Name = "Impotent Rage",
                    Model = "u_m_y_imporage",
                },
                new PedModelListItem()
                {
                    Name = "Imran Shinowa",
                    Model = "csb_imran",
                },
                new PedModelListItem()
                {
                    Name = "Indian Male",
                    Model = "a_m_m_indian_01",
                },
                new PedModelListItem()
                {
                    Name = "Indian Old Female",
                    Model = "a_f_o_indian_01",
                },
                new PedModelListItem()
                {
                    Name = "Indian Young Female",
                    Model = "a_f_y_indian_01",
                },
                new PedModelListItem()
                {
                    Name = "Indian Young Male",
                    Model = "a_m_y_indian_01",
                },
                new PedModelListItem()
                {
                    Name = "Jane",
                    Model = "u_f_y_comjane",
                },
                new PedModelListItem()
                {
                    Name = "Janet (CS)",
                    Model = "cs_janet",
                },
                new PedModelListItem()
                {
                    Name = "Janet (IG)",
                    Model = "ig_janet",
                },
                new PedModelListItem()
                {
                    Name = "Janitor",
                    Model = "csb_janitor",
                },
                new PedModelListItem()
                {
                    Name = "Janitor",
                    Model = "s_m_m_janitor",
                },
                new PedModelListItem()
                {
                    Name = "Jay Norris (IG)",
                    Model = "ig_jay_norris",
                },
                new PedModelListItem()
                {
                    Name = "Jesco White (Tapdancing Hillbilly)",
                    Model = "u_m_o_taphillbilly",
                },
                new PedModelListItem()
                {
                    Name = "Jesus",
                    Model = "u_m_m_jesus_01",
                },
                new PedModelListItem()
                {
                    Name = "Jetskier",
                    Model = "a_m_y_jetski_01",
                },
                new PedModelListItem()
                {
                    Name = "Jewel Heist Driver",
                    Model = "hc_driver",
                },
                new PedModelListItem()
                {
                    Name = "Jewel Heist Gunman",
                    Model = "hc_gunman",
                },
                new PedModelListItem()
                {
                    Name = "Jewel Heist Hacker",
                    Model = "hc_hacker",
                },
                new PedModelListItem()
                {
                    Name = "Jewel Thief",
                    Model = "u_m_m_jewelthief",
                },
                new PedModelListItem()
                {
                    Name = "Jeweller Assistant",
                    Model = "u_f_y_jewelass_01",
                },
                new PedModelListItem()
                {
                    Name = "Jeweller Assistant (CS)",
                    Model = "cs_jewelass",
                },
                new PedModelListItem()
                {
                    Name = "Jeweller Assistant (IG)",
                    Model = "ig_jewelass",
                },
                new PedModelListItem()
                {
                    Name = "Jeweller Security",
                    Model = "u_m_m_jewelsec_01",
                },
                new PedModelListItem()
                {
                    Name = "Jimmy Boston (CS)",
                    Model = "cs_jimmyboston",
                },
                new PedModelListItem()
                {
                    Name = "Jimmy Boston (IG)",
                    Model = "ig_jimmyboston",
                },
                new PedModelListItem()
                {
                    Name = "Jimmy De Santa (CS)",
                    Model = "cs_jimmydisanto",
                },
                new PedModelListItem()
                {
                    Name = "Jimmy De Santa (IG)",
                    Model = "ig_jimmydisanto",
                },
                new PedModelListItem()
                {
                    Name = "Jogger Female",
                    Model = "a_f_y_runner_01",
                },
                new PedModelListItem()
                {
                    Name = "Jogger Male",
                    Model = "a_m_y_runner_01",
                },
                new PedModelListItem()
                {
                    Name = "Jogger Male 2",
                    Model = "a_m_y_runner_02",
                },
                new PedModelListItem()
                {
                    Name = "John Marston",
                    Model = "mp_m_marston_01",
                },
                new PedModelListItem()
                {
                    Name = "Johnny Klebitz (CS)",
                    Model = "cs_johnnyklebitz",
                },
                new PedModelListItem()
                {
                    Name = "Johnny Klebitz (IG)",
                    Model = "ig_johnnyklebitz",
                },
                new PedModelListItem()
                {
                    Name = "Josef (CS)",
                    Model = "cs_josef",
                },
                new PedModelListItem()
                {
                    Name = "Josef (IG)",
                    Model = "ig_josef",
                },
                new PedModelListItem()
                {
                    Name = "Josh (CS)",
                    Model = "cs_josh",
                },
                new PedModelListItem()
                {
                    Name = "Josh (IG)",
                    Model = "ig_josh",
                },
                new PedModelListItem()
                {
                    Name = "Juggalo Female",
                    Model = "a_f_y_juggalo_01",
                },
                new PedModelListItem()
                {
                    Name = "Juggalo Male",
                    Model = "a_m_y_juggalo_01",
                },
                new PedModelListItem()
                {
                    Name = "Justin",
                    Model = "u_m_y_justin",
                },
                new PedModelListItem()
                {
                    Name = "Karen Daniels (CS)",
                    Model = "cs_karen_daniels",
                },
                new PedModelListItem()
                {
                    Name = "Karen Daniels (IG)",
                    Model = "ig_karen_daniels",
                },
                new PedModelListItem()
                {
                    Name = "Kerry McIntosh (IG)",
                    Model = "ig_kerrymcintosh",
                },
                new PedModelListItem()
                {
                    Name = "Kifflom Guy",
                    Model = "u_m_y_baygor",
                },
                new PedModelListItem()
                {
                    Name = "Korean Boss",
                    Model = "g_m_m_korboss_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Female",
                    Model = "a_f_m_ktown_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Female 2",
                    Model = "a_f_m_ktown_02",
                },
                new PedModelListItem()
                {
                    Name = "Korean Lieutenant",
                    Model = "g_m_y_korlieut_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Male",
                    Model = "a_m_m_ktown_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Old Female",
                    Model = "a_f_o_ktown_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Old Male",
                    Model = "a_m_o_ktown_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Young Male",
                    Model = "g_m_y_korean_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Young Male",
                    Model = "a_m_y_ktown_01",
                },
                new PedModelListItem()
                {
                    Name = "Korean Young Male 2",
                    Model = "g_m_y_korean_02",
                },
                new PedModelListItem()
                {
                    Name = "Korean Young Male 2",
                    Model = "a_m_y_ktown_02",
                },
                new PedModelListItem()
                {
                    Name = "Lamar Davis (CS)",
                    Model = "cs_lamardavis",
                },
                new PedModelListItem()
                {
                    Name = "Lamar Davis (IG)",
                    Model = "ig_lamardavis",
                },
                new PedModelListItem()
                {
                    Name = "Latino Handyman Male",
                    Model = "s_m_m_lathandy_01",
                },
                new PedModelListItem()
                {
                    Name = "Latino Street Male 2",
                    Model = "a_m_m_stlat_02",
                },
                new PedModelListItem()
                {
                    Name = "Latino Street Young Male",
                    Model = "a_m_y_stlat_01",
                },
                new PedModelListItem()
                {
                    Name = "Latino Young Male",
                    Model = "a_m_y_latino_01",
                },
                new PedModelListItem()
                {
                    Name = "Lazlow (CS)",
                    Model = "cs_lazlow",
                },
                new PedModelListItem()
                {
                    Name = "Lazlow (IG)",
                    Model = "ig_lazlow",
                },
                new PedModelListItem()
                {
                    Name = "Lester Crest (CS)",
                    Model = "cs_lestercrest",
                },
                new PedModelListItem()
                {
                    Name = "Lester Crest (IG)",
                    Model = "ig_lestercrest",
                },
                new PedModelListItem()
                {
                    Name = "Life Invader (CS)",
                    Model = "cs_lifeinvad_01",
                },
                new PedModelListItem()
                {
                    Name = "Life Invader (IG)",
                    Model = "ig_lifeinvad_01",
                },
                new PedModelListItem()
                {
                    Name = "Life Invader 2 (IG)",
                    Model = "ig_lifeinvad_02",
                },
                new PedModelListItem()
                {
                    Name = "Life Invader Male",
                    Model = "s_m_m_lifeinvad_01",
                },
                new PedModelListItem()
                {
                    Name = "Line Cook",
                    Model = "s_m_m_linecook",
                },
                new PedModelListItem()
                {
                    Name = "Love Fist Willy",
                    Model = "u_m_m_willyfist",
                },
                new PedModelListItem()
                {
                    Name = "LS Metro Worker Male",
                    Model = "s_m_m_lsmetro_01",
                },
                new PedModelListItem()
                {
                    Name = "Magenta (CS)",
                    Model = "cs_magenta",
                },
                new PedModelListItem()
                {
                    Name = "Magenta (IG)",
                    Model = "ig_magenta",
                },
                new PedModelListItem()
                {
                    Name = "Maid",
                    Model = "s_f_m_maid_01",
                },
                new PedModelListItem()
                {
                    Name = "Malibu Male",
                    Model = "a_m_m_malibu_01",
                },
                new PedModelListItem()
                {
                    Name = "Mani",
                    Model = "u_m_y_mani",
                },
                new PedModelListItem()
                {
                    Name = "Manuel (CS)",
                    Model = "cs_manuel",
                },
                new PedModelListItem()
                {
                    Name = "Manuel (IG)",
                    Model = "ig_manuel",
                },
                new PedModelListItem()
                {
                    Name = "Mariachi",
                    Model = "s_m_m_mariachi_01",
                },
                new PedModelListItem()
                {
                    Name = "Marine",
                    Model = "csb_ramp_marine",
                },
                new PedModelListItem()
                {
                    Name = "Marine",
                    Model = "s_m_m_marine_01",
                },
                new PedModelListItem()
                {
                    Name = "Marine 2",
                    Model = "s_m_m_marine_02",
                },
                new PedModelListItem()
                {
                    Name = "Marine Young",
                    Model = "s_m_y_marine_01",
                },
                new PedModelListItem()
                {
                    Name = "Marine Young 2",
                    Model = "s_m_y_marine_02",
                },
                new PedModelListItem()
                {
                    Name = "Marine Young 3",
                    Model = "s_m_y_marine_03",
                },
                new PedModelListItem()
                {
                    Name = "Mark Fostenburg",
                    Model = "u_m_m_markfost",
                },
                new PedModelListItem()
                {
                    Name = "Marnie Allen (CS)",
                    Model = "cs_marnie",
                },
                new PedModelListItem()
                {
                    Name = "Marnie Allen (IG)",
                    Model = "ig_marnie",
                },
                new PedModelListItem()
                {
                    Name = "Martin Madrazo (CS)",
                    Model = "cs_martinmadrazo",
                },
                new PedModelListItem()
                {
                    Name = "Mary-Ann Quinn (CS)",
                    Model = "cs_maryann",
                },
                new PedModelListItem()
                {
                    Name = "Mary-Ann Quinn (IG)",
                    Model = "ig_maryann",
                },
                new PedModelListItem()
                {
                    Name = "Maude",
                    Model = "csb_maude",
                },
                new PedModelListItem()
                {
                    Name = "Maude (IG)",
                    Model = "ig_maude",
                },
                new PedModelListItem()
                {
                    Name = "Maxim Rashkovsky (CS)",
                    Model = "csb_rashcosvki",
                },
                new PedModelListItem()
                {
                    Name = "Maxim Rashkovsky (IG)",
                    Model = "ig_rashcosvki",
                },
                new PedModelListItem()
                {
                    Name = "Mechanic",
                    Model = "s_m_y_xmech_01",
                },
                new PedModelListItem()
                {
                    Name = "Mechanic 2",
                    Model = "s_m_y_xmech_02",
                },
                new PedModelListItem()
                {
                    Name = "Merryweather Merc",
                    Model = "csb_mweather",
                },
                new PedModelListItem()
                {
                    Name = "Meth Addict",
                    Model = "a_m_y_methhead_01",
                },
                new PedModelListItem()
                {
                    Name = "Mexican",
                    Model = "csb_ramp_mex",
                },
                new PedModelListItem()
                {
                    Name = "Mexican (IG)",
                    Model = "ig_ramp_mex",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Boss",
                    Model = "g_m_m_mexboss_01",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Boss 2",
                    Model = "g_m_m_mexboss_02",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Gang Member",
                    Model = "g_m_y_mexgang_01",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Goon",
                    Model = "g_m_y_mexgoon_01",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Goon 2",
                    Model = "g_m_y_mexgoon_02",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Goon 3",
                    Model = "g_m_y_mexgoon_03",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Labourer",
                    Model = "a_m_m_mexlabor_01",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Rural",
                    Model = "a_m_m_mexcntry_01",
                },
                new PedModelListItem()
                {
                    Name = "Mexican Thug",
                    Model = "a_m_y_mexthug_01",
                },
                new PedModelListItem()
                {
                    Name = "Michelle (CS)",
                    Model = "cs_michelle",
                },
                new PedModelListItem()
                {
                    Name = "Michelle (IG)",
                    Model = "ig_michelle",
                },
                new PedModelListItem()
                {
                    Name = "Migrant Female",
                    Model = "s_f_y_migrant_01",
                },
                new PedModelListItem()
                {
                    Name = "Migrant Male",
                    Model = "s_m_m_migrant_01",
                },
                new PedModelListItem()
                {
                    Name = "Milton McIlroy (CS)",
                    Model = "cs_milton",
                },
                new PedModelListItem()
                {
                    Name = "Milton McIlroy (IG)",
                    Model = "ig_milton",
                },
                new PedModelListItem()
                {
                    Name = "Mime Artist",
                    Model = "s_m_y_mime",
                },
                new PedModelListItem()
                {
                    Name = "Minuteman Joe (CS)",
                    Model = "cs_joeminuteman",
                },
                new PedModelListItem()
                {
                    Name = "Minuteman Joe (IG)",
                    Model = "ig_joeminuteman",
                },
                new PedModelListItem()
                {
                    Name = "Miranda",
                    Model = "u_f_m_miranda",
                },
                new PedModelListItem()
                {
                    Name = "Mistress",
                    Model = "u_f_y_mistress",
                },
                new PedModelListItem()
                {
                    Name = "Misty",
                    Model = "mp_f_misty_01",
                },
                new PedModelListItem()
                {
                    Name = "Molly (CS)",
                    Model = "cs_molly",
                },
                new PedModelListItem()
                {
                    Name = "Molly (IG)",
                    Model = "ig_molly",
                },
                new PedModelListItem()
                {
                    Name = "Money Man (CS)",
                    Model = "csb_money",
                },
                new PedModelListItem()
                {
                    Name = "Money Man (IG)",
                    Model = "ig_money",
                },
                new PedModelListItem()
                {
                    Name = "Motocross Biker",
                    Model = "a_m_y_motox_01",
                },
                new PedModelListItem()
                {
                    Name = "Motocross Biker 2",
                    Model = "a_m_y_motox_02",
                },
                new PedModelListItem()
                {
                    Name = "Movie Astronaut",
                    Model = "s_m_m_movspace_01",
                },
                new PedModelListItem()
                {
                    Name = "Movie Director",
                    Model = "u_m_m_filmdirector",
                },
                new PedModelListItem()
                {
                    Name = "Movie Premiere Female",
                    Model = "s_f_y_movprem_01",
                },
                new PedModelListItem()
                {
                    Name = "Movie Premiere Female (CS)",
                    Model = "cs_movpremf_01",
                },
                new PedModelListItem()
                {
                    Name = "Movie Premiere Male",
                    Model = "s_m_m_movprem_01",
                },
                new PedModelListItem()
                {
                    Name = "Movie Premiere Male (CS)",
                    Model = "cs_movpremmale",
                },
                new PedModelListItem()
                {
                    Name = "Movie Star Female",
                    Model = "u_f_o_moviestar",
                },
                new PedModelListItem()
                {
                    Name = "Mrs. Phillips (CS)",
                    Model = "cs_mrsphillips",
                },
                new PedModelListItem()
                {
                    Name = "Mrs. Phillips (IG)",
                    Model = "ig_mrsphillips",
                },
                new PedModelListItem()
                {
                    Name = "Mrs. Thornhill (CS)",
                    Model = "cs_mrs_thornhill",
                },
                new PedModelListItem()
                {
                    Name = "Mrs. Thornhill (IG)",
                    Model = "ig_mrs_thornhill",
                },
                new PedModelListItem()
                {
                    Name = "Natalia (CS)",
                    Model = "cs_natalia",
                },
                new PedModelListItem()
                {
                    Name = "Natalia (IG)",
                    Model = "ig_natalia",
                },
                new PedModelListItem()
                {
                    Name = "Nervous Ron (CS)",
                    Model = "cs_nervousron",
                },
                new PedModelListItem()
                {
                    Name = "Nervous Ron (IG)",
                    Model = "ig_nervousron",
                },
                new PedModelListItem()
                {
                    Name = "Nigel (CS)",
                    Model = "cs_nigel",
                },
                new PedModelListItem()
                {
                    Name = "Nigel (IG)",
                    Model = "ig_nigel",
                },
                new PedModelListItem()
                {
                    Name = "Niko Bellic",
                    Model = "mp_m_niko_01",
                },
                new PedModelListItem()
                {
                    Name = "OG Boss",
                    Model = "a_m_m_og_boss_01",
                },
                new PedModelListItem()
                {
                    Name = "Old Man 1 (CS)",
                    Model = "cs_old_man1a",
                },
                new PedModelListItem()
                {
                    Name = "Old Man 1 (IG)",
                    Model = "ig_old_man1a",
                },
                new PedModelListItem()
                {
                    Name = "Old Man 2 (CS)",
                    Model = "cs_old_man2",
                },
                new PedModelListItem()
                {
                    Name = "Old Man 2 (IG)",
                    Model = "ig_old_man2",
                },
                new PedModelListItem()
                {
                    Name = "Omega (CS)",
                    Model = "cs_omega",
                },
                new PedModelListItem()
                {
                    Name = "Omega (IG)",
                    Model = "ig_omega",
                },
                new PedModelListItem()
                {
                    Name = "O'Neil Brothers (IG)",
                    Model = "ig_oneil",
                },
                new PedModelListItem()
                {
                    Name = "Ortega",
                    Model = "csb_ortega",
                },
                new PedModelListItem()
                {
                    Name = "Ortega (IG)",
                    Model = "ig_ortega",
                },
                new PedModelListItem()
                {
                    Name = "Oscar",
                    Model = "csb_oscar",
                },
                new PedModelListItem()
                {
                    Name = "Paige Harris (CS)",
                    Model = "csb_paige",
                },
                new PedModelListItem()
                {
                    Name = "Paige Harris (IG)",
                    Model = "ig_paige",
                },
                new PedModelListItem()
                {
                    Name = "Paparazzi Male",
                    Model = "a_m_m_paparazzi_01",
                },
                new PedModelListItem()
                {
                    Name = "Paparazzi Young Male",
                    Model = "u_m_y_paparazzi",
                },
                new PedModelListItem()
                {
                    Name = "Paramedic",
                    Model = "s_m_m_paramedic_01",
                },
                new PedModelListItem()
                {
                    Name = "Party Target",
                    Model = "u_m_m_partytarget",
                },
                new PedModelListItem()
                {
                    Name = "Partygoer",
                    Model = "u_m_y_party_01",
                },
                new PedModelListItem()
                {
                    Name = "Patricia (CS)",
                    Model = "cs_patricia",
                },
                new PedModelListItem()
                {
                    Name = "Patricia (IG)",
                    Model = "ig_patricia",
                },
                new PedModelListItem()
                {
                    Name = "Pest Control",
                    Model = "s_m_y_pestcont_01",
                },
                new PedModelListItem()
                {
                    Name = "Peter Dreyfuss (CS)",
                    Model = "cs_dreyfuss",
                },
                new PedModelListItem()
                {
                    Name = "Peter Dreyfuss (IG)",
                    Model = "ig_dreyfuss",
                },
                new PedModelListItem()
                {
                    Name = "Pilot",
                    Model = "s_m_m_pilot_01",
                },
                new PedModelListItem()
                {
                    Name = "Pilot",
                    Model = "s_m_y_pilot_01",
                },
                new PedModelListItem()
                {
                    Name = "Pilot 2",
                    Model = "s_m_m_pilot_02",
                },
                new PedModelListItem()
                {
                    Name = "Pogo the Monkey",
                    Model = "u_m_y_pogo_01",
                },
                new PedModelListItem()
                {
                    Name = "Polynesian",
                    Model = "a_m_m_polynesian_01",
                },
                new PedModelListItem()
                {
                    Name = "Polynesian Goon",
                    Model = "g_m_y_pologoon_01",
                },
                new PedModelListItem()
                {
                    Name = "Polynesian Goon 2",
                    Model = "g_m_y_pologoon_02",
                },
                new PedModelListItem()
                {
                    Name = "Polynesian Young",
                    Model = "a_m_y_polynesian_01",
                },
                new PedModelListItem()
                {
                    Name = "Poppy Mitchell",
                    Model = "u_f_y_poppymich",
                },
                new PedModelListItem()
                {
                    Name = "Porn Dude",
                    Model = "csb_porndudes",
                },
                new PedModelListItem()
                {
                    Name = "Postal Worker Male",
                    Model = "s_m_m_postal_01",
                },
                new PedModelListItem()
                {
                    Name = "Postal Worker Male 2",
                    Model = "s_m_m_postal_02",
                },
                new PedModelListItem()
                {
                    Name = "Priest (CS)",
                    Model = "cs_priest",
                },
                new PedModelListItem()
                {
                    Name = "Priest (IG)",
                    Model = "ig_priest",
                },
                new PedModelListItem()
                {
                    Name = "Princess",
                    Model = "u_f_y_princess",
                },
                new PedModelListItem()
                {
                    Name = "Prison Guard",
                    Model = "s_m_m_prisguard_01",
                },
                new PedModelListItem()
                {
                    Name = "Prisoner",
                    Model = "s_m_y_prisoner_01",
                },
                new PedModelListItem()
                {
                    Name = "Prisoner",
                    Model = "u_m_y_prisoner_01",
                },
                new PedModelListItem()
                {
                    Name = "Prisoner (Muscular)",
                    Model = "s_m_y_prismuscl_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Driver",
                    Model = "u_m_y_proldriver_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Driver",
                    Model = "csb_prologuedriver",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Host Female",
                    Model = "a_f_m_prolhost_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Host Male",
                    Model = "a_m_m_prolhost_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Host Old Female",
                    Model = "u_f_o_prolhost_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Mourner Female",
                    Model = "u_f_m_promourn_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Mourner Male",
                    Model = "u_m_m_promourn_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Security",
                    Model = "csb_prolsec",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Security",
                    Model = "u_m_m_prolsec_01",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Security 2 (CS)",
                    Model = "cs_prolsec_02",
                },
                new PedModelListItem()
                {
                    Name = "Prologue Security 2 (IG)",
                    Model = "ig_prolsec_02",
                },
                new PedModelListItem()
                {
                    Name = "PROS?",
                    Model = "mp_g_m_pros_01",
                },
                new PedModelListItem()
                {
                    Name = "Ranger Female",
                    Model = "s_f_y_ranger_01",
                },
                new PedModelListItem()
                {
                    Name = "Ranger Male",
                    Model = "s_m_y_ranger_01",
                },
                new PedModelListItem()
                {
                    Name = "Reporter",
                    Model = "csb_reporter",
                },
                new PedModelListItem()
                {
                    Name = "Republican Space Ranger",
                    Model = "u_m_y_rsranger_01",
                },
                new PedModelListItem()
                {
                    Name = "Rival Paparazzo",
                    Model = "u_m_m_rivalpap",
                },
                new PedModelListItem()
                {
                    Name = "Road Cyclist",
                    Model = "a_m_y_roadcyc_01",
                },
                new PedModelListItem()
                {
                    Name = "Robber",
                    Model = "s_m_y_robber_01",
                },
                new PedModelListItem()
                {
                    Name = "Rocco Pelosi",
                    Model = "csb_roccopelosi",
                },
                new PedModelListItem()
                {
                    Name = "Rocco Pelosi (IG)",
                    Model = "ig_roccopelosi",
                },
                new PedModelListItem()
                {
                    Name = "Rural Meth Addict Female",
                    Model = "a_f_y_rurmeth_01",
                },
                new PedModelListItem()
                {
                    Name = "Rural Meth Addict Male",
                    Model = "a_m_m_rurmeth_01",
                },
                new PedModelListItem()
                {
                    Name = "Russian Drunk (CS)",
                    Model = "cs_russiandrunk",
                },
                new PedModelListItem()
                {
                    Name = "Russian Drunk (IG)",
                    Model = "ig_russiandrunk",
                },
                new PedModelListItem()
                {
                    Name = "Sales Assistant (High-End)",
                    Model = "s_f_m_shop_high",
                },
                new PedModelListItem()
                {
                    Name = "Sales Assistant (Low-End)",
                    Model = "s_f_y_shop_low",
                },
                new PedModelListItem()
                {
                    Name = "Sales Assistant (Mask Stall)",
                    Model = "s_m_y_shop_mask",
                },
                new PedModelListItem()
                {
                    Name = "Sales Assistant (Mid-Price)",
                    Model = "s_f_y_shop_mid",
                },
                new PedModelListItem()
                {
                    Name = "Salton Female",
                    Model = "a_f_m_salton_01",
                },
                new PedModelListItem()
                {
                    Name = "Salton Male",
                    Model = "a_m_m_salton_01",
                },
                new PedModelListItem()
                {
                    Name = "Salton Male 2",
                    Model = "a_m_m_salton_02",
                },
                new PedModelListItem()
                {
                    Name = "Salton Male 3",
                    Model = "a_m_m_salton_03",
                },
                new PedModelListItem()
                {
                    Name = "Salton Male 4",
                    Model = "a_m_m_salton_04",
                },
                new PedModelListItem()
                {
                    Name = "Salton Old Female",
                    Model = "a_f_o_salton_01",
                },
                new PedModelListItem()
                {
                    Name = "Salton Old Male",
                    Model = "a_m_o_salton_01",
                },
                new PedModelListItem()
                {
                    Name = "Salton Young Male",
                    Model = "a_m_y_salton_01",
                },
                new PedModelListItem()
                {
                    Name = "Salvadoran Boss",
                    Model = "g_m_y_salvaboss_01",
                },
                new PedModelListItem()
                {
                    Name = "Salvadoran Goon",
                    Model = "g_m_y_salvagoon_01",
                },
                new PedModelListItem()
                {
                    Name = "Salvadoran Goon 2",
                    Model = "g_m_y_salvagoon_02",
                },
                new PedModelListItem()
                {
                    Name = "Salvadoran Goon 3",
                    Model = "g_m_y_salvagoon_03",
                },
                new PedModelListItem()
                {
                    Name = "Scientist",
                    Model = "s_m_m_scientist_01",
                },
                new PedModelListItem()
                {
                    Name = "Screenwriter",
                    Model = "csb_screen_writer",
                },
                new PedModelListItem()
                {
                    Name = "Screenwriter (IG)",
                    Model = "ig_screen_writer",
                },
                new PedModelListItem()
                {
                    Name = "Security Guard",
                    Model = "s_m_m_security_01",
                },
                new PedModelListItem()
                {
                    Name = "Sheriff Female",
                    Model = "s_f_y_sheriff_01",
                },
                new PedModelListItem()
                {
                    Name = "Sheriff Male",
                    Model = "s_m_y_sheriff_01",
                },
                new PedModelListItem()
                {
                    Name = "Shopkeeper",
                    Model = "mp_m_shopkeep_01",
                },
                new PedModelListItem()
                {
                    Name = "Simeon Yetarian (CS)",
                    Model = "cs_siemonyetarian",
                },
                new PedModelListItem()
                {
                    Name = "Simeon Yetarian (IG)",
                    Model = "ig_siemonyetarian",
                },
                new PedModelListItem()
                {
                    Name = "Skater Female",
                    Model = "a_f_y_skater_01",
                },
                new PedModelListItem()
                {
                    Name = "Skater Male",
                    Model = "a_m_m_skater_01",
                },
                new PedModelListItem()
                {
                    Name = "Skater Young Male",
                    Model = "a_m_y_skater_01",
                },
                new PedModelListItem()
                {
                    Name = "Skater Young Male 2",
                    Model = "a_m_y_skater_02",
                },
                new PedModelListItem()
                {
                    Name = "Skid Row Female",
                    Model = "a_f_m_skidrow_01",
                },
                new PedModelListItem()
                {
                    Name = "Skid Row Male",
                    Model = "a_m_m_skidrow_01",
                },
                new PedModelListItem()
                {
                    Name = "Snow Cop Male",
                    Model = "s_m_m_snowcop_01",
                },
                new PedModelListItem()
                {
                    Name = "Solomon Richards (CS)",
                    Model = "cs_solomon",
                },
                new PedModelListItem()
                {
                    Name = "Solomon Richards (IG)",
                    Model = "ig_solomon",
                },
                new PedModelListItem()
                {
                    Name = "South Central Female",
                    Model = "a_f_m_soucent_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Female 2",
                    Model = "a_f_m_soucent_02",
                },
                new PedModelListItem()
                {
                    Name = "South Central Latino Male",
                    Model = "a_m_m_socenlat_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Male",
                    Model = "a_m_m_soucent_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Male 2",
                    Model = "a_m_m_soucent_02",
                },
                new PedModelListItem()
                {
                    Name = "South Central Male 3",
                    Model = "a_m_m_soucent_03",
                },
                new PedModelListItem()
                {
                    Name = "South Central Male 4",
                    Model = "a_m_m_soucent_04",
                },
                new PedModelListItem()
                {
                    Name = "South Central MC Female",
                    Model = "a_f_m_soucentmc_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Old Female",
                    Model = "a_f_o_soucent_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Old Female 2",
                    Model = "a_f_o_soucent_02",
                },
                new PedModelListItem()
                {
                    Name = "South Central Old Male",
                    Model = "a_m_o_soucent_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Old Male 2",
                    Model = "a_m_o_soucent_02",
                },
                new PedModelListItem()
                {
                    Name = "South Central Old Male 3",
                    Model = "a_m_o_soucent_03",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Female",
                    Model = "a_f_y_soucent_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Female 2",
                    Model = "a_f_y_soucent_02",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Female 3",
                    Model = "a_f_y_soucent_03",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Male",
                    Model = "a_m_y_soucent_01",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Male 2",
                    Model = "a_m_y_soucent_02",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Male 3",
                    Model = "a_m_y_soucent_03",
                },
                new PedModelListItem()
                {
                    Name = "South Central Young Male 4",
                    Model = "a_m_y_soucent_04",
                },
                new PedModelListItem()
                {
                    Name = "Sports Biker",
                    Model = "u_m_y_sbike",
                },
                new PedModelListItem()
                {
                    Name = "Spy Actor",
                    Model = "u_m_m_spyactor",
                },
                new PedModelListItem()
                {
                    Name = "Spy Actress",
                    Model = "u_f_y_spyactress",
                },
                new PedModelListItem()
                {
                    Name = "Stag Party Groom",
                    Model = "u_m_y_staggrm_01",
                },
                new PedModelListItem()
                {
                    Name = "Steve Haines (CS)",
                    Model = "cs_stevehains",
                },
                new PedModelListItem()
                {
                    Name = "Steve Haines (IG)",
                    Model = "ig_stevehains",
                },
                new PedModelListItem()
                {
                    Name = "Street Performer",
                    Model = "s_m_m_strperf_01",
                },
                new PedModelListItem()
                {
                    Name = "Street Preacher",
                    Model = "s_m_m_strpreach_01",
                },
                new PedModelListItem()
                {
                    Name = "Street Punk",
                    Model = "g_m_y_strpunk_01",
                },
                new PedModelListItem()
                {
                    Name = "Street Punk 2",
                    Model = "g_m_y_strpunk_02",
                },
                new PedModelListItem()
                {
                    Name = "Street Vendor",
                    Model = "s_m_m_strvend_01",
                },
                new PedModelListItem()
                {
                    Name = "Street Vendor Young",
                    Model = "s_m_y_strvend_01",
                },
                new PedModelListItem()
                {
                    Name = "Stretch (CS)",
                    Model = "cs_stretch",
                },
                new PedModelListItem()
                {
                    Name = "Stretch (IG)",
                    Model = "ig_stretch",
                },
                new PedModelListItem()
                {
                    Name = "Stripper",
                    Model = "csb_stripper_01",
                },
                new PedModelListItem()
                {
                    Name = "Stripper",
                    Model = "s_f_y_stripper_01",
                },
                new PedModelListItem()
                {
                    Name = "Stripper 2",
                    Model = "csb_stripper_02",
                },
                new PedModelListItem()
                {
                    Name = "Stripper 2",
                    Model = "s_f_y_stripper_02",
                },
                new PedModelListItem()
                {
                    Name = "Stripper Lite",
                    Model = "s_f_y_stripperlite",
                },
                new PedModelListItem()
                {
                    Name = "Stripper Lite",
                    Model = "mp_f_stripperlite",
                },
                new PedModelListItem()
                {
                    Name = "Sunbather Male",
                    Model = "a_m_y_sunbathe_01",
                },
                new PedModelListItem()
                {
                    Name = "Surfer",
                    Model = "a_m_y_surfer_01",
                },
                new PedModelListItem()
                {
                    Name = "SWAT",
                    Model = "s_m_y_swat_01",
                },
                new PedModelListItem()
                {
                    Name = "Sweatshop Worker",
                    Model = "s_f_m_sweatshop_01",
                },
                new PedModelListItem()
                {
                    Name = "Sweatshop Worker Young",
                    Model = "s_f_y_sweatshop_01",
                },
                new PedModelListItem()
                {
                    Name = "Talina (IG)",
                    Model = "ig_talina",
                },
                new PedModelListItem()
                {
                    Name = "Tanisha (CS)",
                    Model = "cs_tanisha",
                },
                new PedModelListItem()
                {
                    Name = "Tanisha (IG)",
                    Model = "ig_tanisha",
                },
                new PedModelListItem()
                {
                    Name = "Tao Cheng (CS)",
                    Model = "cs_taocheng",
                },
                new PedModelListItem()
                {
                    Name = "Tao Cheng (IG)",
                    Model = "ig_taocheng",
                },
                new PedModelListItem()
                {
                    Name = "Tao's Translator (CS)",
                    Model = "cs_taostranslator",
                },
                new PedModelListItem()
                {
                    Name = "Tao's Translator (IG)",
                    Model = "ig_taostranslator",
                },
                new PedModelListItem()
                {
                    Name = "Tattoo Artist",
                    Model = "u_m_y_tattoo_01",
                },
                new PedModelListItem()
                {
                    Name = "Tennis Coach (CS)",
                    Model = "cs_tenniscoach",
                },
                new PedModelListItem()
                {
                    Name = "Tennis Coach (IG)",
                    Model = "ig_tenniscoach",
                },
                new PedModelListItem()
                {
                    Name = "Tennis Player Female",
                    Model = "a_f_y_tennis_01",
                },
                new PedModelListItem()
                {
                    Name = "Tennis Player Male",
                    Model = "a_m_m_tennis_01",
                },
                new PedModelListItem()
                {
                    Name = "Terry (CS)",
                    Model = "cs_terry",
                },
                new PedModelListItem()
                {
                    Name = "Terry (IG)",
                    Model = "ig_terry",
                },
                new PedModelListItem()
                {
                    Name = "The Lost MC Female",
                    Model = "g_f_y_lost_01",
                },
                new PedModelListItem()
                {
                    Name = "The Lost MC Male",
                    Model = "g_m_y_lost_01",
                },
                new PedModelListItem()
                {
                    Name = "The Lost MC Male 2",
                    Model = "g_m_y_lost_02",
                },
                new PedModelListItem()
                {
                    Name = "The Lost MC Male 3",
                    Model = "g_m_y_lost_03",
                },
                new PedModelListItem()
                {
                    Name = "Tom (CS)",
                    Model = "cs_tom",
                },
                new PedModelListItem()
                {
                    Name = "Tonya",
                    Model = "csb_tonya",
                },
                new PedModelListItem()
                {
                    Name = "Tonya (IG)",
                    Model = "ig_tonya",
                },
                new PedModelListItem()
                {
                    Name = "Topless",
                    Model = "a_f_y_topless_01",
                },
                new PedModelListItem()
                {
                    Name = "Tourist Female",
                    Model = "a_f_m_tourist_01",
                },
                new PedModelListItem()
                {
                    Name = "Tourist Male",
                    Model = "a_m_m_tourist_01",
                },
                new PedModelListItem()
                {
                    Name = "Tourist Young Female",
                    Model = "a_f_y_tourist_01",
                },
                new PedModelListItem()
                {
                    Name = "Tourist Young Female 2",
                    Model = "a_f_y_tourist_02",
                },
                new PedModelListItem()
                {
                    Name = "Tracey De Santa (CS)",
                    Model = "cs_tracydisanto",
                },
                new PedModelListItem()
                {
                    Name = "Tracey De Santa (IG)",
                    Model = "ig_tracydisanto",
                },
                new PedModelListItem()
                {
                    Name = "Traffic Warden",
                    Model = "csb_trafficwarden",
                },
                new PedModelListItem()
                {
                    Name = "Traffic Warden (IG)",
                    Model = "ig_trafficwarden",
                },
                new PedModelListItem()
                {
                    Name = "Tramp Female",
                    Model = "a_f_m_tramp_01",
                },
                new PedModelListItem()
                {
                    Name = "Tramp Male",
                    Model = "a_m_m_tramp_01",
                },
                new PedModelListItem()
                {
                    Name = "Tramp Old Male",
                    Model = "u_m_o_tramp_01",
                },
                new PedModelListItem()
                {
                    Name = "Tramp Old Male",
                    Model = "a_m_o_tramp_01",
                },
                new PedModelListItem()
                {
                    Name = "Transport Worker Male",
                    Model = "s_m_m_gentransport",
                },
                new PedModelListItem()
                {
                    Name = "Transvestite Male",
                    Model = "a_m_m_tranvest_01",
                },
                new PedModelListItem()
                {
                    Name = "Transvestite Male 2",
                    Model = "a_m_m_tranvest_02",
                },
                new PedModelListItem()
                {
                    Name = "Trucker Male",
                    Model = "s_m_m_trucker_01",
                },
                new PedModelListItem()
                {
                    Name = "Tyler Dixon (IG)",
                    Model = "ig_tylerdix",
                },
                new PedModelListItem()
                {
                    Name = "Undercover Cop",
                    Model = "csb_undercover",
                },
                new PedModelListItem()
                {
                    Name = "United Paper Man (CS)",
                    Model = "cs_paper",
                },
                new PedModelListItem()
                {
                    Name = "United Paper Man (IG)",
                    Model = "ig_paper",
                },
                new PedModelListItem()
                {
                    Name = "UPS Driver",
                    Model = "s_m_m_ups_01",
                },
                new PedModelListItem()
                {
                    Name = "UPS Driver 2",
                    Model = "s_m_m_ups_02",
                },
                new PedModelListItem()
                {
                    Name = "US Coastguard",
                    Model = "s_m_y_uscg_01",
                },
                new PedModelListItem()
                {
                    Name = "Vagos Female",
                    Model = "g_f_y_vagos_01",
                },
                new PedModelListItem()
                {
                    Name = "Vagos Male (CS)",
                    Model = "csb_vagspeak",
                },
                new PedModelListItem()
                {
                    Name = "Vagos Male (IG)",
                    Model = "ig_vagspeak",
                },
                new PedModelListItem()
                {
                    Name = "Vagos Male 2",
                    Model = "mp_m_g_vagfun_01",
                },
                new PedModelListItem()
                {
                    Name = "Valet",
                    Model = "s_m_y_valet_01",
                },
                new PedModelListItem()
                {
                    Name = "Vespucci Beach Male",
                    Model = "a_m_y_beachvesp_01",
                },
                new PedModelListItem()
                {
                    Name = "Vespucci Beach Male 2",
                    Model = "a_m_y_beachvesp_02",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Douche",
                    Model = "a_m_y_vindouche_01",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Female",
                    Model = "a_f_y_vinewood_01",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Female 2",
                    Model = "a_f_y_vinewood_02",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Female 3",
                    Model = "a_f_y_vinewood_03",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Female 4",
                    Model = "a_f_y_vinewood_04",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Male",
                    Model = "a_m_y_vinewood_01",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Male 2",
                    Model = "a_m_y_vinewood_02",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Male 3",
                    Model = "a_m_y_vinewood_03",
                },
                new PedModelListItem()
                {
                    Name = "Vinewood Male 4",
                    Model = "a_m_y_vinewood_04",
                },
                new PedModelListItem()
                {
                    Name = "Wade(CS)",
                    Model = "cs_wade",
                },
                new PedModelListItem()
                {
                    Name = "Wade(IG)",
                    Model = "ig_wade",
                },
                new PedModelListItem()
                {
                    Name = "Waiter",
                    Model = "s_m_y_waiter_01",
                },
                new PedModelListItem()
                {
                    Name = "Wei Cheng(CS)",
                    Model = "cs_chengsr",
                },
                new PedModelListItem()
                {
                    Name = "Wei Cheng(IG)",
                    Model = "ig_chengsr",
                },
                new PedModelListItem()
                {
                    Name = "White Street Male",
                    Model = "a_m_y_stwhi_01",
                },
                new PedModelListItem()
                {
                    Name = "White Street Male 2",
                    Model = "a_m_y_stwhi_02",
                },
                new PedModelListItem()
                {
                    Name = "Window Cleaner",
                    Model = "s_m_y_winclean_01",
                },
                new PedModelListItem()
                {
                    Name = "Yoga Female",
                    Model = "a_f_y_yoga_01",
                },
                new PedModelListItem()
                {
                    Name = "Yoga Male",
                    Model = "a_m_y_yoga_01",
                },
                new PedModelListItem()
                {
                    Name = "Zimbor(CS)",
                    Model = "cs_zimbor",
                },
                new PedModelListItem()
                {
                    Name = "Zimbor(IG)",
                    Model = "ig_zimbor",
                },
                new PedModelListItem()
                {
                    Name = "Zombie",
                    Model = "u_m_y_zombie_01",
                },
            });
        }
    }
}
