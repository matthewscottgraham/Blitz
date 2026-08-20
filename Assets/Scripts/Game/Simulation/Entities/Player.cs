using System;
using System.Numerics;
using Game.Simulation.Logic;
using Game.Simulation.Match;
using Game.Simulation.Utils;
using Shared;

namespace Game.Simulation.Entities
{
    public class Player : SimulationEntity
    {
        public readonly PlayerStats Stats;
        private PlayerRole _role;
        private LogicNode[] _logicNodes = Array.Empty<LogicNode>();
        private ISimulationContext _simulationContext;
        
        public int Team { get; private set; }

        public Player(PlayerStats playerStats, PlayerRole role)
        {
            Stats = playerStats;
            _role = role;
            CurrentPosition = MatchUtility.GetStartingPosition(_role);
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

        public override void SetMatch(ISimulationContext simulationContext, int team = -1)
        {
            _simulationContext = simulationContext;
            Team = team;
        }

        public void SetLogic(LogicNode[] logicNodes)
        {
            _logicNodes = logicNodes;
        }

        private void SetNewRandomPosition(ISimulationContext simulationContext)
        {
            TargetPosition = MathUtility.RandomPointInSphere(Vector3.Zero, simulationContext.FieldRadius, simulationContext.Random);
            MoveProgress = 0;
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
