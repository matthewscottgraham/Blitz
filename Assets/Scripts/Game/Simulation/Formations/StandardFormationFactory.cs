using System;
using System.Numerics;

namespace Game.Simulation.Formations
{
    public class StandardFormationFactory : IFormationFactory
    {
        public Vector3 GetFormationPosition(FormationType formationType, int teamIndex, PlayerRole role)
        {
            var position = formationType switch
            {
                FormationType.Standard => GetStandardFormationPosition(role),
                FormationType.VShape => GetVShapeFormationPosition(role),
                _ => throw new ArgumentOutOfRangeException(nameof(formationType), formationType, null)
            };
            
            return AdjustPositionForTeam(position, teamIndex);
        }

        private static Vector3 AdjustPositionForTeam(Vector3 position, int teamIndex)
        {
            var mult = teamIndex == 0 ? -1 : 1;
            return new Vector3(position.X * mult, position.Y, position.Z * mult);
        }

        private static Vector3 GetStandardFormationPosition(PlayerRole role)
        {
            
            return role switch
            {
                PlayerRole.Center => new Vector3(1, 0, 1),
                PlayerRole.Forward => new Vector3(3, 0, 2),
                PlayerRole.Defense => new Vector3(2, 0, 3),
                PlayerRole.Keeper => new Vector3(0, 0, 4.5f),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }

        private static Vector3 GetVShapeFormationPosition(PlayerRole role)
        {
            return role switch
            {
                PlayerRole.Center => new Vector3(0, 0, -1),
                PlayerRole.Forward => new Vector3(-1, 0, -2),
                PlayerRole.Defense => new Vector3(-2, 0, -3),
                PlayerRole.Keeper => new Vector3(0, 0, -4.5f),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}