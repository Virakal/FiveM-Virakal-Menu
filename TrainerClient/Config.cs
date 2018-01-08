﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virakal.FiveM.Trainer.TrainerClient
{
    public class Config
    {
        private IDictionary<string, string> store = new Dictionary<string, string>();
        private IDictionary<string, string> defaults = new Dictionary<string, string>();

        public string this[string key]
        {
            get { return Get(key); }
            set { Set(key, value); }
        }

        public string Get(string key)
        {
            if (store.ContainsKey(key))
            {
                return store[key];
            }

            if (defaults.ContainsKey(key))
            {
                return defaults[key];
            }

            // Trigger the exception
            return store[key];
        }

        public void Set(string key, string value)
        {
            store[key] = value;
        }

        public void SetDefault(string key, string value)
        {
            defaults[key] = value;
        }

        public bool ContainsKey(string key)
        {
            return store.ContainsKey(key);
        }

        public bool ContainsKeyOrHasDefault(string key)
        {
            return ContainsKey(key) || defaults.ContainsKey(key);
        }
    }
}
