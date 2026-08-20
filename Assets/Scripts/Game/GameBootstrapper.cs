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
        private ISimulationContext _context;
        private IMatchController _controller;
        private SimulationView _view;
        private HUDController _hudController;
        
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
            IMatchFactory matchFactory = new StandardMatchFactory();
            
            var match = matchFactory.CreateMatch(
                ballFactory.GetNewBall(), 
                new [] {playerFactory.GetNewTeam(), playerFactory.GetNewTeam()},
                random
                );
            _context = match.context;
            _controller = match.controller;
            
            _view = gameObject.AddChild<SimulationView>();
            _view.Initialise(_context);

            _hudController = gameObject.AddChild<HUDController>();
            _hudController.Initialize(_context);
            
            _controller.StartMatch();
        }

        private void Update()
        {
            _controller?.Tick(Time.deltaTime);
        }

        private void Quit()
        {
            _controller.Dispose();
            _context = null;
            Application.Quit();
        }
    }
}
