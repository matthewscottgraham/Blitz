namespace Game.Simulation.Entities
{
    public interface IPlayerFactory
    {
        Team GetNewTeam(int teamIndex);
        SimulationEntity GetNewPlayer(PlayerRole role, int teamIndex);
    }
}