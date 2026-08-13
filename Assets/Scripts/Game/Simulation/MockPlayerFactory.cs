using System;
using System.Collections.Generic;

namespace Game.Simulation
{
    public class MockPlayerFactory: IPlayerFactory
    {
        public Team GetNewTeam()
        {
            var players = new SimulationEntity[]
            {
                GetNewPlayer(PlayerRole.Forward),
                GetNewPlayer(PlayerRole.Forward),
                GetNewPlayer(PlayerRole.Center),
                GetNewPlayer(PlayerRole.Defense),
                GetNewPlayer(PlayerRole.Defense),
                GetNewPlayer(PlayerRole.Keeper)
            };
            return new Team(players);
        }

        public Player GetNewPlayer(PlayerRole role)
        {
            return new Player(GetRandomPlayerStats(), role);
        }

        private PlayerStats GetRandomPlayerStats()
        {
            var random = new Random();
            var playerStats = new PlayerStats();
            playerStats.Acceleration = random.Next(1, 11);
            playerStats.TopSpeed = random.Next(1, 11);
            return playerStats;
        }
    }
}