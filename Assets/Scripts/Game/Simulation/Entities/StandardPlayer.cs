using System;
using System.Numerics;
using Game.Simulation.Formations;
using Game.Simulation.Logic;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Entities
{
    public class StandardPlayer : SimulationEntity, ITeamMember
    {
        private LogicNode[] _logicNodes = Array.Empty<LogicNode>();
        private ISimulationContext _simulationContext;
        
        public int Team { get; private set; }
        public PlayerRole Role { get; private set; }

        public StandardPlayer(PlayerStats playerStats, PlayerRole role, int teamIndex)
        {
            Stats = playerStats;
            Role = role;
            AssignTeam(teamIndex);
        }
        
        public override void Tick(float deltaTime)
        {
            foreach (var logicNode in _logicNodes)
            {
                if (logicNode.Evaluate(_simulationContext, this))
                    break;
            }
            
            ApplyMove(deltaTime);
        }

        public override void SetContext(ISimulationContext simulationContext)
        {
            _simulationContext = simulationContext;
        }

        public override void Reset()
        {
            CurrentPosition = _simulationContext.FormationFactory.GetFormationPosition(FormationType.Standard, Team, Role);
            CurrentVelocity = Vector3.Zero;
        }
        
        public void AssignTeam(int team)
        {
            Team = team;
        }

        public void SetLogic(LogicNode[] logicNodes)
        {
            _logicNodes = logicNodes;
        }

        private void ApplyMove(float deltaTime)
        {
            if (CurrentVelocity.Length() > Stats.TopSpeed)
                CurrentVelocity = Vector3.Normalize(CurrentVelocity) * Stats.TopSpeed;
            ApplyPhysics(deltaTime);
        }
    }
}
