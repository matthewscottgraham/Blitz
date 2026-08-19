using Game.Simulation.Entities;
using UnityEngine;

namespace Game.Simulation.Strategies
{
    public class ChaseBall : IStrategy
    {
        public void Execute(IMatch match, Player player)
        {
            player.SetTargetPosition(match.Ball.CurrentPosition);
        }
    }
}