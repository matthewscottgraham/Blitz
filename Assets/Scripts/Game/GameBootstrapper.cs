using Game.Simulation.Conditions;
using Game.Simulation.Entities;
using Game.Simulation.Logic;
using Game.Simulation.Match;
using Game.Simulation.Strategies;
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
            var random = new System.Random();
            IStrategyFactory strategyFactory = new StandardStrategyFactory();
            IConditionFactory conditionFactory = new StandardConditionFactory();
            ILogicFactory logicFactory = new StandardLogicFactory(strategyFactory, conditionFactory);
            IPlayerFactory playerFactory = new StandardPlayerFactory(logicFactory, random);
            IBallFactory ballFactory = new StandardBallFactory();
            
            _model = new StandardMatch(
                ballFactory.GetNewBall(), 
                new [] {playerFactory.GetNewTeam(), playerFactory.GetNewTeam()},
                random
                );
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
            _controller.Dispose();
            _model = null;
            Application.Quit();
        }
    }
}
