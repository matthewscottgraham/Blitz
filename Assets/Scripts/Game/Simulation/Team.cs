using System;
using System.Collections.Generic;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation
{
    public class Team : IDisposable
    {
        public ITeamMember[] TeamMembers;
        public ISimulationEntity[] Entities;

        public Team(ITeamMember[] teamMembers)
        {
            TeamMembers = teamMembers;
            Entities = new ISimulationEntity[TeamMembers.Length];
            for (var i = 0; i < TeamMembers.Length; i++)
            {
                Entities[i] = (ISimulationEntity) TeamMembers[i];
            }
        }

        public void Dispose()
        {
            TeamMembers = null;
            Entities = null;
        }
    }
}