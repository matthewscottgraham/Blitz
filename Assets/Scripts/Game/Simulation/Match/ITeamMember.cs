using Game.Simulation.Logic;

namespace Game.Simulation.Match
{
    public interface ITeamMember
    {
        int Team { get; }
        int OpposingTeam { get; }
        PlayerRole Role { get; }
        PlayerRole MarkedPlayerRole { get; }
        public abstract void AssignTeam(int team);
        public abstract void AssignOpposingTeam(int opposingTeam);
        public abstract void SetContext(ISimulationContext simulationContext);
        public abstract void SetLogic(LogicNode[]  logicNodes);
    }
}