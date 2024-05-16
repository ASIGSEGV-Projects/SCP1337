// See https://aka.ms/new-console-template for more information

using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles.PlayableScps.Scp3114;
using Player = Exiled.Events.Handlers.Player;

namespace SCP1337
{
    public class SCP1337 : Plugin<Config>
    {
        // Instance Tracking
        public static SCP1337 Instance = null!;

        // Plugin Configuration
        public override string Name => "SCP-1337"; // The name of the plugin
        public override string Prefix => "scp1337"; // As appears in configuration file
        public override string Author => "ASIGSEGV"; // Author name
        public override Version Version => new Version(1, 0, 1); // Version
        public override PluginPriority Priority { get; } = PluginPriority.Default;
        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 1); // Public Plugin Requirement

        // Sub-Instances Here  
        public Events events;
        
        // Methods
        public override void OnEnabled()
        {
            Instance = this;
            if (Instance.Config.SpawnProbability < 0 || Instance.Config.SpawnProbability > 100)
            {
                Log.Error("Spawn Probability is greater or smaller than 100. Please adjust config accordingly.");
                return;
            }
            events = new Events(Instance.Config);
            RegisterEvents();
            Log.Info("Done registering events.");
            // Public Plugin Requirement
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            Log.Info("Done unregistering events.");
            // Public Plugin Requirement
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            // Register Events Here
            Player.ChangingRole += events.GiveChance;
        }

        private void UnregisterEvents()
        {
            // UnRegister Events Here
            Player.ChangingRole -= events.GiveChance;
        }
    }
}