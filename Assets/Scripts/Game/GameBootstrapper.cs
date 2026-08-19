using Game.Simulation;
using Game.View;
using Shared;
using UnityEngine;

namespace Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IMatch _model;
        private SimulationView _view;
        
        private void Start()
        {
            Play();
        }

        private void Play()
        {
            IPlayerFactory playerFactory = new MockPlayerFactory();
            
            _model = new Match(new [] {playerFactory.GetNewTeam(), playerFactory.GetNewTeam()});
            _view = gameObject.AddChild<SimulationView>();
            _view.Initialise(_model);
            _model.StartMatch();
        }

        private void Update()
        {
            _model?.Tick(Time.deltaTime);
        }

        private void Quit()
        {
            _model.Dispose();
            _model = null;
            Application.Quit();
        }
    }
}
