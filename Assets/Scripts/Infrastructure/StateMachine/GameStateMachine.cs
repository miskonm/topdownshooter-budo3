using System;
using System.Collections.Generic;
using TDS.Infrastructure.SceneLoading;
using TDS.Infrastructure.Services;
using TDS.Infrastructure.StateMachine.State;
using TDS.Utility;

namespace TDS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _activeState;

        public GameStateMachine(Services.Services services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IState>()
            {
                {typeof(BootstrapState), new BootstrapState(this, services, coroutineRunner)},
                {typeof(MenuState), new MenuState(this, services.Get<ISceneLoader>())},
                {typeof(GameState), new GameState(this)},
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            _activeState = _states[typeof(TState)];
            _activeState.Enter();
        }
    }
}