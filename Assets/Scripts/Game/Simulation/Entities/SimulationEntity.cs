using System.Numerics;

namespace Game.Simulation.Entities
{
    public abstract class SimulationEntity
    {
        protected float P = 0;
        
        public Vector3 CurrentPosition { get; protected set; }
        public Vector3 TargetPosition { get; protected set; }

        public abstract void SetMatch(IMatch match, int team = -1);
        
        public abstract void Tick(float deltaTime);

        public void SetTargetPosition(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
        
    }
}