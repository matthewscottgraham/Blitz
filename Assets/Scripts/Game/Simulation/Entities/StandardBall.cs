using Game.Simulation.Match;

namespace Game.Simulation.Entities
{
    public class StandardBall : SimulationEntity
    {
        public StandardBall(PlayerStats stats)
        {
            Stats = stats;
        }
        
        public override void Tick(float deltaTime)
        {
            ApplyPhysics(deltaTime);
        }
    }
}