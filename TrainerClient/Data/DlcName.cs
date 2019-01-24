using System.Collections.Generic;

namespace Virakal.FiveM.Trainer.TrainerClient.Data
{
    public enum Dlc
    {
        BaseGame,
        BeachBumContentUpdate,
        ValentinesDayMassacreSpecial,
        TheBusinessUpdate,
        HighLifeUpdate,
        ImNotaHipsterUpdate,
        IndependenceDaySpecial,
        SanAndreasFlightSchoolUpdate,
        LastTeamStandingUpdate,
        FestiveSurprise,
        HeistsUpdate,
        IllGottenGainsPart1,
        IllGottenGainsPart2,
        Lowriders,
        HalloweenSurprise,
        ExecutivesandOtherCriminals,
        FestiveSurprise2015,
        January2016Update,
        BeMyValentine,
        LowridersCustomClassics,
        FurtherAdventuresinFinanceandFelony,
        CunningStunts,
        Bikers,
        ImportExport,
        CunningStuntsSpecialVehicleCircuit,
        Gunrunning,
        SmugglersRun,
        TheDoomsdayHeist,
        SouthernSanAndreasSuperSportSeries,
        AfterHours,
        ArenaWar,
    }

    static class DlcMethods
    {
        // Would be nice to be able to get this from the game
        private static List<string> nameList = new List<string>()
        {
            "Base Game",
            "Beach Bum Content Update",
            "Valentine's Day Massacre Special",
            "The Business Update",
            "High Life Update",
            "I'm Not a Hipster Update",
            "Independence Day Special",
            "San Andreas Flight School Update",
            "Last Team Standing Update",
            "Festive Surprise",
            "Heists Update",
            "Ill-Gotten Gains Part 1",
            "Ill-Gotten Gains Part 2",
            "Lowriders",
            "Halloween Surprise",
            "Executives and Other Criminals",
            "Festive Surprise 2015",
            "January 2016 Update",
            "Be My Valentine",
            "Lowriders: Custom Classics",
            "Further Adventures in Finance and Felony",
            "Cunning Stunts",
            "Bikers",
            "Import/Export",
            "Cunning Stunts: Special Vehicle Circuit",
            "Gunrunning",
            "Smuggler's Run",
            "The Doomsday Heist",
            "Southern San Andreas Super Sport Series",
            "After Hours",
            "Arena War",
        };

        public static string GetTitle(this Dlc dlc)
        {
            return nameList[(int)dlc];
        }
    }
}
