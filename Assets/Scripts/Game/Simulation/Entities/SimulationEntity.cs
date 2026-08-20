using System.Numerics;
using Game.Simulation.Match;

namespace Game.Simulation.Entities
{
    public abstract class SimulationEntity : IResettable
    {
        protected float MoveProgress = 0;
        
        public Vector3 CurrentPosition { get; protected set; }
        public Vector3 TargetPosition { get; protected set; }
        public Vector3 StartPosition { get; protected set; } = Vector3.Zero;

        public abstract void SetContext(ISimulationContext simulationContext);
        public abstract void AssignTeam(int team = -1);
        
        public abstract void Tick(float deltaTime);

        public void SetTargetPosition(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
        
        public void Reset()
        {
            SetTargetPosition(StartPosition);
            CurrentPosition = StartPosition;
            MoveProgress = 0;
        }
    }
}