using System.Numerics;

namespace Game.Simulation.Entities
{
    public class StandardBall : ISimulationEntity
    {
        private const float DragCoefficient = 0.05f;
        private const float Mass = 1.5f;
        private Vector3 _currentPosition;
        private Vector3 _currentVelocity;
        
        public Vector3 CurrentPosition => _currentPosition;
        public Vector3 CurrentVelocity => _currentVelocity;

        public void Tick(float deltaTime)
        {
            _currentPosition += _currentVelocity * deltaTime;
            _currentVelocity *= 1 - DragCoefficient;
        }

        public void ApplyForce(Vector3 direction, float magnitude)
        {
            if (direction.LengthSquared() < 0.0001f) return;
            var acceleration = Vector3.Normalize(direction) * (magnitude / Mass);
            _currentVelocity += acceleration;
        }
        
        public void Reset()
        {
            _currentPosition = Vector3.Zero;
            _currentVelocity = Vector3.Zero;
        }
    }
}