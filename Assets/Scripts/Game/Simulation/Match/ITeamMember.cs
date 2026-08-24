namespace Game.Simulation.Match
{
    public interface ITeamMember
    {
        int Team { get; }
        int OtherTeam { get; }
        PlayerRole Role { get; }
        PlayerRole MarkedPlayerRole { get; }
        public abstract void AssignTeam(int team);
        public abstract void SetContext(ISimulationContext simulationContext);
    }
}