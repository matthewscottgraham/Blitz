using System.Numerics;

namespace Game.Simulation.Formations
{
    public interface IFormationFactory
    {
        Vector3 GetFormationPosition(FormationType formationType, int teamIndex, PlayerRole role);
        Vector3 GetStandardFormationPosition(int teamIndex, PlayerRole role);
        Vector3 GetVShapeFormationPosition(int teamIndex, PlayerRole role);
    }
}