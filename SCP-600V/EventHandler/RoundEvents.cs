﻿using Exiled.API.Features;
using System.Linq;
using PlayerRoles;
using SCP_600V.API.Role;
using System.Collections.Generic;
using Exiled.API.Extensions;

namespace SCP_600V.EventHandler
{
    internal class RoundEvents
    {
        /// <summary>
        /// determines whether a player will be selected for role 600 or not
        /// </summary>
        internal void OnRoundStarted()
        {
            bool Spawnable = IsSpawnable();
            if (Spawnable & Server.PlayerCount > 3)
            {
                List<Player> players = new List<Player>();
                foreach (Player p in Player.List.Where(x => x.IsAlive && x.Role.Type == RoleTypeId.ClassD))
                {
                    players.Add(p);
                }
                Role.Spawn(players.GetRandomValue());
                Log.Debug("Spawned random players");
            }
            else 
            {
                return;
            }
        }
        /// <summary>
        /// determines by random selection whether an event will occur
        /// </summary>
        /// <returns><para>returns True if the event can occur</para><para>returns False if the event cannot occur</para></returns>
        internal bool IsSpawnable()
        {
            if (UnityEngine.Random.value <= Sai.Instance.Config.PercentToSpawn/100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
