using Game.Simulation.Entities;
using Game.Simulation.Match;
using UnityEngine;

namespace Game.Simulation.Strategies
{
    public class ChaseBall : IStrategy
    {
        public void Execute(ISimulationContext simulationContext, Player player)
        {
            player.SetTargetPosition(simulationContext.Ball.CurrentPosition);
        }
    }
}