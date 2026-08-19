using System;
using System.Collections.Generic;
using Game.Simulation.Entities;

namespace Game.Simulation
{
    public class Team : IDisposable
    {
        public SimulationEntity[] Players;

        public Team(SimulationEntity[] players)
        {
            Players = players;
        }

        public void Dispose()
        {
            Players = null;
        }
    }
}