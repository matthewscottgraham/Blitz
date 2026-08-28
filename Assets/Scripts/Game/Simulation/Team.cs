using System;
using System.Collections.Generic;
using Game.Simulation.Entities;
using Game.Simulation.Match;

namespace Game.Simulation
{
    public class Team : IDisposable
    {
        public ISimulationTeamMember[] TeamMembers;

        public Team(ISimulationTeamMember[] teamMembers)
        {
            TeamMembers = teamMembers;
        }

        public void Dispose()
        {
            TeamMembers = null;
        }
    }
}