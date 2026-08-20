namespace Game.Simulation.Match
{
    public interface IMatchController
    {
        void AddPoint(int teamIndex);
        
        void StartMatch();
        void PauseMatch();
        void ResumeMatch();
        void EndMatch();

        void Tick(float deltaTime);
    }
}