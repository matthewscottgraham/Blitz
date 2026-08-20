using System.Numerics;

namespace Game.Simulation.Entities
{
    public abstract class SimulationEntity : IResettable
    {
        public Vector3 CurrentPosition { get; protected set; }
        public Vector3 CurrentVelocity { get; protected set; }
        
        public PlayerStats Stats { get; protected set; }
        
        public abstract void Tick(float deltaTime);

        public void ApplyForce(Vector3 direction, float magnitude)
        {
            var acceleration = Vector3.Normalize(direction) * (magnitude / Stats.Mass);
            CurrentVelocity += acceleration;
        }
        
        public virtual void Reset()
        {
            CurrentPosition = Vector3.Zero;
            CurrentVelocity = Vector3.Zero;
        }

        protected void ApplyPhysics(float deltaTime, float drag = 0.95f)
        {
            CurrentPosition += CurrentVelocity * deltaTime;
            CurrentVelocity *= drag;
        }
    }
}