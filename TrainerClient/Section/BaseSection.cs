using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient.Section
{
    abstract class BaseSection
    {
        protected Trainer Trainer { get; }
        protected Config Config { get; }

        public BaseSection(Trainer trainer)
        {
            Trainer = trainer;
            Config = trainer.Config;
        }
    }
}
