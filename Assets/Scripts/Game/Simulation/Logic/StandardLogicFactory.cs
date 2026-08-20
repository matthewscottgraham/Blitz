using System;
using Game.Simulation.Conditions;
using Game.Simulation.Strategies;

namespace Game.Simulation.Logic
{
    public class StandardLogicFactory : ILogicFactory
    {
        private readonly IStrategyFactory _strategyFactory;
        private readonly IConditionFactory _conditionFactory;

        public StandardLogicFactory(IStrategyFactory strategyFactory, IConditionFactory conditionFactory)
        {
            _strategyFactory = strategyFactory;
            _conditionFactory = conditionFactory;
        }
        
        public LogicNode CreateLogicNode(ICondition condition, IStrategy strategy)
        {
            return new LogicNode(condition, strategy);
        }

        public LogicNode[] CreateLogicNodes(PlayerRole playerRole)
        {
            // TODO create different logic node profiles per PlayerRole
            return playerRole switch
            {
                PlayerRole.Center => CreateLogicNodes(),
                PlayerRole.Forward => CreateLogicNodes(),
                PlayerRole.Defense => CreateLogicNodes(),
                PlayerRole.Keeper => CreateLogicNodes(),
                _ => throw new ArgumentOutOfRangeException(nameof(playerRole), playerRole, null)
            };
            
        }

        private LogicNode[] CreateLogicNodes()
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