using System;
using System.Numerics;

namespace Game.Simulation.Formations
{
    public class StandardFormationFactory : IFormationFactory
    {
        public Vector3 GetFormationPosition(FormationType formationType, int teamIndex, PlayerRole role)
        {
            return formationType switch
            {
                FormationType.Standard => GetStandardFormationPosition(teamIndex, role),
                FormationType.VShape => GetVShapeFormationPosition(teamIndex, role),
                _ => throw new ArgumentOutOfRangeException(nameof(formationType), formationType, null)
            };
        }

        public Vector3 GetStandardFormationPosition(int teamIndex, PlayerRole role)
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

        public Vector3 GetVShapeFormationPosition(int teamIndex, PlayerRole role)
        {
            return role switch
            {
                PlayerRole.Center => new Vector3(0, 0, -1),
                PlayerRole.Forward => new Vector3(-1, 0, -2),
                PlayerRole.Defense => new Vector3(-2, 0, -3),
                PlayerRole.Keeper => new Vector3(0, 0, -6),
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
            };
        }
    }
}