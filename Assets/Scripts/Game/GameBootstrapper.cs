using Game.Simulation;
using Game.Simulation.Logic;
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
            IPlayerFactory playerFactory = new StandardPlayerFactory();

            _model = new StandardMatch(new [] {playerFactory.GetNewTeam(), playerFactory.GetNewTeam()});
            _view = gameObject.AddChild<SimulationView>();
            _view.Initialise(_model);
            _model.StartMatch();
            
            var hudController = FindAnyObjectByType<HUDController>();
            hudController.SetMatch(_model);
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
