using System;
using System.Numerics;

namespace Game.Simulation.Utils
{
    public static class MatchUtility
    {
        public static Vector3 GetStartingPosition(PlayerRole role)
        {
            return role switch
            {
                PlayerRole.Center => new Vector3(-1, 0, -1),
                PlayerRole.Forward => new Vector3(-3, 0, -2),
                PlayerRole.Defense => new Vector3(-2, 0, -4),
                PlayerRole.Keeper => new Vector3(0, 0, -6),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}