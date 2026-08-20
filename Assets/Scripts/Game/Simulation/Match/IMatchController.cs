using System;

namespace Game.Simulation.Match
{
    public interface IMatchController : IDisposable
    {
        void StartMatch();
        void PauseMatch();
        void ResumeMatch();
        void EndMatch();
        void ResetPlay();
        
        void Tick(float deltaTime);
    }
}