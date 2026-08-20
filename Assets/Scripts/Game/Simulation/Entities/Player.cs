using System;
using Game.Simulation.Formations;
using Game.Simulation.Logic;
using Game.Simulation.Match;
using Game.Simulation.Utilities;

namespace Game.Simulation.Entities
{
    public class Player : SimulationEntity, ITeamMember
    {
        public readonly PlayerStats Stats;
        private LogicNode[] _logicNodes = Array.Empty<LogicNode>();
        private ISimulationContext _simulationContext;
        
        public int Team { get; private set; }
        public PlayerRole Role { get; private set; }

        public Player(PlayerStats playerStats, PlayerRole role, int teamIndex)
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
            
            MoveTowardsTarget(deltaTime);
        }

        public override void SetContext(ISimulationContext simulationContext)
        {
            _simulationContext = simulationContext;
        }

        public override void Reset()
        {
            var position = _simulationContext.FormationFactory.GetFormationPosition(FormationType.Standard, Team, Role);
            SetTargetPosition(position);
            CurrentPosition = position;
            MoveProgress = 0;
        }
        
        public void AssignTeam(int team)
        {
            Team = team;
        }

        public void SetLogic(LogicNode[] logicNodes)
        {
            _logicNodes = logicNodes;
        }

        private void MoveTowardsTarget(float deltaTime)
        {
            CurrentPosition = MathUtility.Lerp(CurrentPosition, TargetPosition, MoveProgress);
            MoveProgress += deltaTime * Stats.TopSpeed * _simulationContext.SimulationSpeed;
            
            var hasArrived = MathUtility.ApproximatelyEqual(TargetPosition, CurrentPosition);
            if (hasArrived)
            {
                MoveProgress = 0;
            }
        }
    }
}
