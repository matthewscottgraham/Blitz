using System.Numerics;

namespace Game.Simulation.Entities
{
    public interface ISimulationEntity
    {
        public Vector3 CurrentPosition { get; }
        public Vector3 CurrentVelocity { get; }
        
        public abstract void Tick(float deltaTime);

        public abstract void ApplyForce(Vector3 direction, float magnitude);

        public abstract void Reset();
    }
}