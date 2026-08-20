using Game.Simulation;
using Game.Simulation.Entities;
using Game.Simulation.Logic;
using Game.Simulation.Match;
using Game.View;
using Shared;
using UnityEngine;

namespace Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        private ISimulationContext _model;
        private IMatchController _controller;
        private SimulationView _view;
        
        private void Start()
        {
            Play();
        }

        private void Play()
        {
            IPlayerFactory playerFactory = new StandardPlayerFactory(new StandardLogicFactory());
            IBallFactory ballFactory = new StandardBallFactory();
            _model = new StandardMatch(ballFactory.GetNewBall(), new [] {playerFactory.GetNewTeam(), playerFactory.GetNewTeam()});
            _controller = (IMatchController)_model;
            _view = gameObject.AddChild<SimulationView>();
            _view.Initialise(_model);
            _controller.StartMatch();
            
            var hudController = FindAnyObjectByType<HUDController>();
            hudController.SetMatch(_model);
        }

        private void Update()
        {
            _controller?.Tick(Time.deltaTime);
        }

        private void Quit()
        {
            _model.Dispose();
            _model = null;
            Application.Quit();
        }
    }
}
