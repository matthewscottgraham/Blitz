# Blitz

An underwater football(soccer) like game simulator built in unity 6. It is not 
meant to be played directly, and has 2 AI teams play autonomously. It is 
currently only using unity Gizmos to render the visualisations.

The simulation (`Blitz.Simulation`) has no Unity dependencies. It is
plain C# on `System.Numerics`, driven by a `Tick(deltaTime)` call. Unity only
supplies the clock, the debug rendering and the HUD. everything else is 
engine-agnostic and could be run headless or unit tested.

## Status

Early prototype. A match runs end to end — kickoff, AI play, goals, score,
reset.

## Requirements

- Unity **6000.4.5f1**
- Universal Render Pipeline 17.4, Input System 1.19, UI Toolkit

## Running it

1. Open the project in Unity.
2. Open `Assets/Scenes/Game.unity` and press Play.
3. Players, ball, goals and pitch boundary are drawn with `Gizmos` from 
   `SimulationView`, so they only appear in the Scene view, not the Game view. 
   The Game view shows the UI Toolkit scoreboard only.

`Assets/Scenes/App.unity` is the intended entry point (preferences, localisation,
launching the game) but `AppBootstrapper` is still a stub.

`GameBootstrapper.Play()` is the only place the object graph is wired up. Every
subsystem is constructed through an interface (`IStrategyFactory`,
`IConditionFactory`, `ILogicFactory`, `IPlayerFactory`, `IBallFactory`,
`IFormationFactory`, `IMatchFactory`), so the `Standard*` implementations can be
swapped without touching anything downstream.

## How a match works

`StandardMatch` implements both `ISimulationContext` (what the world looks like)
and `IMatchController` (how it advances). Each tick it:

1. Counts down the post-goal reset cooldown (0.5s) and returns if it's running.
2. Resets play if the ball has left the pitch.
3. Ticks the ball, then every player on both teams.
4. Checks whether the ball is inside either goal radius.

The pitch is a sphere of radius 5 centred on the origin. Goals are points at
`(0, 0, 5)` with a radius of 1 — put the ball inside one and the other team
scores. Play then resets to the `Standard` formation.

Each team has six players: `ForwardLeft`, `ForwardRight`, `Center`,
`DefenseLeft`, `DefenseRight`, `Keeper`. Stats (`Speed`, `KickPower`, `Accuracy`,
`Intercept`, `Mass`, `Drag`, `Range`, `Agility`) are currently rolled at random
in the range 1–10 by `StandardPlayerFactory`.

## How players decide what to do

Each player holds an **ordered array of `LogicNode`s**, where a node is one
`ICondition` paired with one `IStrategy`. On every tick the player walks the
array from the top and stops at the first node whose condition passes, executing
that node's strategy. Order is priority: the last node is always
`AlwaysTrue → <fallback>`, so a player always does something.

Strategies never set position directly — they call `ApplyForce` on the player
and/or the ball, and movement is integrated in `ApplyMove` with a speed clamp
and per-player drag.

### Adding a new behaviour

1. Add an `ICondition` in `Simulation/Conditions/` — a pure predicate over
   `(ISimulationContext, ISimulationTeamMember)`, no side effects.
2. Add an `IStrategy` in `Simulation/Strategies/` — apply forces, change nothing
   else.
3. Slot the pair into the relevant role list in `StandardLogicFactory`. Position
   in the list *is* the priority; putting a permissive condition high up will
   starve everything below it.

Both factories instantiate by generic type parameter (`CreateStrategy<T>()`), so
a new class needs a parameterless constructor and nothing more.

## Known gaps

- Rendering is Gizmo-only, so nothing is visible in the Game view or in a build.
- `PauseMatch`, `ResumeMatch` and `EndMatch` are empty.
- Tuning values are magic numbers scattered across strategies, entities and
  `StandardMatch`. `TuningConfig` exists to collect them but is not wired up yet.
- `Blitz.Management` and `Blitz.Story` are empty placeholder assemblies.
- No tests yet.
- `AppBootstrapper` does nothing; `Game.unity` has to be opened directly.