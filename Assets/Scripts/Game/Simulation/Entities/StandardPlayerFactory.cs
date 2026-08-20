using System;
using Game.Simulation.Logic;

namespace Game.Simulation.Entities
{
    public class StandardPlayerFactory: IPlayerFactory
    {
        private readonly ILogicFactory _logicFactory;
        private readonly Random _random;

        public StandardPlayerFactory(ILogicFactory logicFactory, Random random)
        {
            _logicFactory = logicFactory;
            _random = random;
        }
        
        public Team GetNewTeam(int teamIndex)
        {
            var players = new []
            {
                GetNewPlayer(PlayerRole.Forward, teamIndex),
                GetNewPlayer(PlayerRole.Forward, teamIndex),
                GetNewPlayer(PlayerRole.Center, teamIndex),
                GetNewPlayer(PlayerRole.Defense, teamIndex),
                GetNewPlayer(PlayerRole.Defense, teamIndex),
                GetNewPlayer(PlayerRole.Keeper, teamIndex)
            };
            return new Team(players);
        }

        public SimulationEntity GetNewPlayer(PlayerRole role, int teamIndex)
        {
            var player = new StandardPlayer(GetRandomPlayerStats(), role, teamIndex);
            player.SetLogic(_logicFactory.CreateLogicNodes(role));
            return player;
        }

        private PlayerStats GetRandomPlayerStats()
        {
            var playerStats = new PlayerStats
            {
                Accuracy = _random.Next(0, 10),
                Acceleration = _random.Next(0, 10),
                TopSpeed = _random.Next(0, 10),
                Agility = _random.Next(0, 10),
                Intercept = _random.Next(0, 10),
                KickPower = _random.Next(0, 10),
                Mass = _random.Next(0, 10),
            };
            return playerStats;
        }
    }
}