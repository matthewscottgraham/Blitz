using System;
using Game.Simulation.Logic;

namespace Game.Simulation.Entities
{
    public class StandardPlayerFactory: IPlayerFactory
    {
        private readonly ILogicFactory _logicFactory;

        public StandardPlayerFactory(ILogicFactory logicFactory)
        {
            _logicFactory = logicFactory;
        }
        
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

        public SimulationEntity GetNewPlayer(PlayerRole role)
        {
            var player = new Player(GetRandomPlayerStats(), role);
            player.SetLogic(_logicFactory.CreateLogicNodes(role));
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