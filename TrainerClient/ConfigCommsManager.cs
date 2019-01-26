using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virakal.FiveM.Trainer.TrainerClient.Section;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    class ConfigCommsManager : BaseSection
    { 
        public ConfigCommsManager(Trainer trainer) : base(trainer)
        {
            Trainer._EventHandlers["virakal:returnConfig"] += new Action<string>(OnReturnConfig);
            BaseScript.TriggerServerEvent("virakal:getConfig");
        }

        private async void OnReturnConfig(string config)
        {
            Config.FromJson(config);
            Trainer.SendUIMessage(new { configupdate = true, config });

            await BaseScript.Delay(1);

            BaseScript.TriggerEvent("virakal:configFetched");
        }
    }
}
