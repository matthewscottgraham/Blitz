using Game.Simulation.Conditions;
using Game.Simulation.Strategies;

namespace Game.Simulation.Logic
{
    public class StandardLogicFactory : ILogicFactory
    {
        private readonly IStrategyFactory _strategyFactory = new StandardStrategyFactory();
        private readonly IConditionFactory _conditionFactory = new StandardConditionFactory();
        
        public LogicNode CreateLogicNode(ICondition condition, IStrategy strategy)
        {
            return new LogicNode(condition, strategy);
        }

        public LogicNode[] CreateLogicNodes()
        {
            var logicNodes = new LogicNode[]
            {
                new (
                    _conditionFactory.CreateCondition<IsOpponentCloseToPlayer>(), 
                    _strategyFactory.CreateStrategy<AvoidOpponent>()
                    ),
                new (
                    _conditionFactory.CreateCondition<IsPlayerAbleToReachBall>(), 
                    _strategyFactory.CreateStrategy<ChaseBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<IsPlayerCloseToBall>(), 
                    _strategyFactory.CreateStrategy<KickBallTowardsGoal>()
                ),
                new (
                    _conditionFactory.CreateCondition<AlwaysTrue>(), 
                    _strategyFactory.CreateStrategy<StandGround>()
                )
            };
            return logicNodes;
        }
    }
}