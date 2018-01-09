using CitizenFX.Core;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    abstract class BaseSection : BaseScript
    {
        protected Trainer Trainer { get; }
        protected Config Config { get; }

        public BaseSection(Trainer trainer) : base()
        {
            Trainer = trainer;
            Config = trainer.Config;
        }
    }
}
