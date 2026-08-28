namespace Game.Simulation.Entities
{
    public interface IPlayerFactory
    {
        Team GetNewTeam(int teamIndex);
        ISimulationTeamMember GetNewTeamMember(PlayerRole role, int teamIndex);
    }
}