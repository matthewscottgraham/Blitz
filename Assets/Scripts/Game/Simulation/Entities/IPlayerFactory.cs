using Game.Simulation.Match;

namespace Game.Simulation.Entities
{
    public interface IPlayerFactory
    {
        Team GetNewTeam(int teamIndex);
        ITeamMember GetNewTeamMember(PlayerRole role, int teamIndex);
    }
}