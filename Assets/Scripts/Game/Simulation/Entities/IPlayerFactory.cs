namespace Game.Simulation.Entities
{
    public interface IPlayerFactory
    {
        Team GetNewTeam();
        SimulationEntity GetNewPlayer(PlayerRole role);
    }
}