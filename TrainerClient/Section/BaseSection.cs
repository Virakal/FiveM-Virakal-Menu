using CitizenFX.Core;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    abstract class BaseSection
    {
        protected Trainer Trainer { get; }
        protected Config Config { get; }
        protected EventHandlerDictionary EventHandlers { get; }

        public BaseSection(Trainer trainer)
        {
            Trainer = trainer;
            Config = trainer.Config;
            EventHandlers = trainer.EventHandlers;

            Trainer.DebugLine($"Loading {this.GetType().Name}.");
        }
    }
}
