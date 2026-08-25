using System;
using Game.Simulation.Logic;
using Game.Simulation.Match;

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
                GetNewTeamMember(PlayerRole.ForwardLeft, teamIndex),
                GetNewTeamMember(PlayerRole.ForwardRight, teamIndex),
                GetNewTeamMember(PlayerRole.Center, teamIndex),
                GetNewTeamMember(PlayerRole.DefenseLeft, teamIndex),
                GetNewTeamMember(PlayerRole.DefenseRight, teamIndex),
                GetNewTeamMember(PlayerRole.Keeper, teamIndex)
            };
            return new Team(players);
        }

        public ITeamMember GetNewTeamMember(PlayerRole role, int teamIndex)
        {
            var player = new StandardTeamMember(GetRandomPlayerStats(), role, teamIndex) as ITeamMember;
            player.SetLogic(_logicFactory.CreateLogicNodes(role));
            return player;
        }

        private PlayerStats GetRandomPlayerStats()
        {
            var playerStats = new PlayerStats
            {
                Accuracy = _random.Next(1, 11),
                Range = _random.Next(1, 11),
                Speed = _random.Next(1, 11),
                Agility = _random.Next(1, 11),
                Intercept = _random.Next(1, 11),
                KickPower = _random.Next(1, 11),
                Mass = _random.Next(1, 11),
                Drag = _random.Next(1, 11),
            };
            return playerStats;
        }
    }
}