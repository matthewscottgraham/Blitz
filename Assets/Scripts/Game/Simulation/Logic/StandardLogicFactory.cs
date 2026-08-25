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
            return playerRole switch
            {
                PlayerRole.Center => CreateCenterPositionNodes(),
                PlayerRole.ForwardLeft => CreateForwardPositionNodes(),
                PlayerRole.ForwardRight => CreateForwardPositionNodes(),
                PlayerRole.DefenseLeft => CreateDefenseNodes(),
                PlayerRole.DefenseRight => CreateDefenseNodes(),
                PlayerRole.Keeper => CreateKeeperNodes(),
                _ => throw new ArgumentOutOfRangeException(nameof(playerRole), playerRole, null)
            };
        }

        private LogicNode[] CreateCenterPositionNodes()
        {
            return new LogicNode[]
            {
                new (
                    _conditionFactory.CreateCondition<IsOpponentCloseToPlayer>(), 
                    _strategyFactory.CreateStrategy<AvoidOpponent>()
                ),
                new (
                    _conditionFactory.CreateCondition<IsPlayerCloseToBall>(), 
                    _strategyFactory.CreateStrategy<KickBallTowardsGoal>()
                ),
                new (
                    _conditionFactory.CreateCondition<IsNearestTeammateToBall>(), 
                    _strategyFactory.CreateStrategy<ChaseBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<AlwaysTrue>(), 
                    _strategyFactory.CreateStrategy<StandGround>()
                )
            };
        }

        private LogicNode[] CreateForwardPositionNodes()
        {
            return new LogicNode[]
            {
                new(
                    _conditionFactory.CreateCondition<CanPlayerKickGoal>(),
                    _strategyFactory.CreateStrategy<KickBallTowardsGoal>()
                ),
                new(
                    _conditionFactory.CreateCondition<IsNearestTeammateToBall>(),
                    _strategyFactory.CreateStrategy<Dribble>()
                    ),
                new(
                    _conditionFactory.CreateCondition<IsPlayerCloseToBall>(),
                    _strategyFactory.CreateStrategy<ChaseBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<AlwaysTrue>(), 
                    _strategyFactory.CreateStrategy<StandGround>()
                )
            };
        }

        private LogicNode[] CreateDefenseNodes()
        {
            return new LogicNode[]
            {
                new (
                    _conditionFactory.CreateCondition<IsOpponentCloseToPlayer>(), 
                    _strategyFactory.CreateStrategy<AvoidOpponent>()
                    ),
                new (
                    _conditionFactory.CreateCondition<IsPlayerCloseToBall>(), 
                    _strategyFactory.CreateStrategy<PassBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<IsNearestTeammateToBall>(), 
                    _strategyFactory.CreateStrategy<ChaseBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<AlwaysTrue>(), 
                    _strategyFactory.CreateStrategy<MarkPlayer>()
                )
            };
        }

        private LogicNode[] CreateKeeperNodes()
        {
            return new LogicNode[]
            {
                new (
                    _conditionFactory.CreateCondition<IsPlayerCloseToBall>(), 
                    _strategyFactory.CreateStrategy<InterceptBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<IsPlayerAbleToReachBall>(), 
                    _strategyFactory.CreateStrategy<ChaseBall>()
                ),
                new (
                    _conditionFactory.CreateCondition<AlwaysTrue>(), 
                    _strategyFactory.CreateStrategy<StandGround>()
                )
            };
        }
    }
}