using System;
using System.Collections.Generic;
using TDS.Game.Factory;
using TDS.Infrastructure.Assets;
using TDS.Infrastructure.SceneLoading;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility;

namespace TDS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;

        private IExitableState _activeState;

        public GameStateMachine(Services.Services services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                {typeof(BootstrapState), new BootstrapState(this, services, coroutineRunner)},
                {typeof(MenuState), new MenuState(this)},
                {typeof(GameState), new GameState(this)},
                {
                    typeof(LoadingState),
                    new LoadingState(this, services.Get<ISceneLoader>(), services.Get<IEnemyFactory>(),
                        services.Get<IAssetsService>())
                },
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}