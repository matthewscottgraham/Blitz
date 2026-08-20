namespace Game.Simulation.Match
{
    public interface ITeamMember
    {
        int Team { get; }
        PlayerRole Role { get; }
        public abstract void AssignTeam(int team);
        public abstract void SetContext(ISimulationContext simulationContext);
    }
}