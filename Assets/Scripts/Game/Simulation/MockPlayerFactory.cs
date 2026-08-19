using System;
using System.Collections.Generic;
using Game.Simulation.Entities;
using Game.Simulation.Strategies;

namespace Game.Simulation
{
    public class MockPlayerFactory: IPlayerFactory
    {
        private readonly IStrategyFactory _strategyFactory = new MockStrategyFactory();

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
            var player = new Player(GetRandomPlayerStats(), role);
            player.SetStrategies(_strategyFactory.GetStrategies());
            return player;
        }

        private PlayerStats GetRandomPlayerStats()
        {
            var random = new Random();
            var playerStats = new PlayerStats
            {
                Intercept = random.Next(1, 11),
                TopSpeed = random.Next(1, 3)
            };
            return playerStats;
        }
    }
}