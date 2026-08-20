using System;
using System.Collections.Generic;
using Game.Simulation.Entities;
using Game.Simulation.Logic;
using Game.Simulation.Strategies;

namespace Game.Simulation
{
    public class MockPlayerFactory: IPlayerFactory
    {
        private readonly ILogicFactory _logicFactory = new MockLogicFactory();

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
            player.SetLogic(_logicFactory.CreateLogicNodes());
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