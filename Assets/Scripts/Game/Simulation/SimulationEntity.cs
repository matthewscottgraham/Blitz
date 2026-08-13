using System.Numerics;

namespace Game.Simulation
{
    public abstract class SimulationEntity
    {
        public Vector3 CurrentVelocity { get; protected set; }
        public Vector3 CurrentPosition { get; protected set; }
        public Vector3 TargetPosition { get; protected set; }
        
        public abstract void Tick(float deltaTime);
    }
}