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
                GetNewPlayer(PlayerRole.ForwardLeft, teamIndex),
                GetNewPlayer(PlayerRole.ForwardRight, teamIndex),
                GetNewPlayer(PlayerRole.Center, teamIndex),
                GetNewPlayer(PlayerRole.DefenseLeft, teamIndex),
                GetNewPlayer(PlayerRole.DefenseRight, teamIndex),
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
                Accuracy = _random.Next(1, 11),
                Acceleration = _random.Next(1, 11),
                Speed = _random.Next(1, 11),
                Agility = _random.Next(1, 11),
                Intercept = _random.Next(1, 11),
                KickPower = _random.Next(1, 11),
                Mass = _random.Next(1, 11),
            };
            return playerStats;
        }
    }
}