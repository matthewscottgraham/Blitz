namespace Game.Simulation
{
    public interface IPlayerFactory
    {
        Team GetNewTeam();
        Player GetNewPlayer(PlayerRole role);
        
    }
}