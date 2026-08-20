using Game.Simulation;
using Game.Simulation.Match;
using Shared;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game
{
    public class HUDController : MonoBehaviour
    {
        private ISimulationContext _model;
        private Label[] _scoreLabels;

        public void SetMatch(ISimulationContext simulationContext)
        {
            _model = simulationContext;
        }

        private void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            var rootElement = uiDocument.rootVisualElement;
            rootElement.styleSheets.Add(Resources.Load<StyleSheet>("Styles/HUD"));
                
            _scoreLabels = new []
            {
                rootElement.AddNew(new Label("Team 1")),
                rootElement.AddNew(new Label("Team 2"))
            };
        }

        private void Update()
        {
            if (_model == null) return;
            var points = _model.Points;
            for (var i = 0; i < _scoreLabels.Length; i++)
            {
                _scoreLabels[i].text = $"Team {i + 1}: {points[i]}";
            }
        }
    }
}
