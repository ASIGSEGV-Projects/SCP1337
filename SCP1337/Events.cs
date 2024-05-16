using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using PlayerRoles.RoleAssign;
using PluginAPI.Roles;

namespace SCP1337
{
    public class Events
    {
        private Config config;
        public Events(Config config)
        {
            this.config = config;
        }
        
        // events
        public void GiveChance(ChangingRoleEventArgs ev)
        {
            if(ev.Reason!=SpawnReason.LateJoin&&ev.Reason!=SpawnReason.RoundStart) return;
            if(!ev.NewRole.ToString().ToLower().Contains("scp")) return;
            if(!Player.List.ToList().Where(p=> p.Role==RoleTypeId.Scp3114).IsEmpty()) return;
            // Meets all requirements, now do chance
            double probability = new Random().NextDouble() * 100;
            if (probability > config.SpawnProbability) return; // No Luck!
            ev.NewRole = RoleTypeId.Scp3114;
        }
    }
}