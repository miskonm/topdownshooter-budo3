using TDS.UI;
using TDS.Utility.Constants;

namespace TDS.Infrastructure.StateMachine.State
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public MenuState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            UnityEngine.Debug.Log($"Enter MenuState Frame <{UnityEngine.Time.frameCount}>");

            MenuScreen.OnStartButtonClicked += StartButtonClicked;
        }

        public void Exit()
        {
            UnityEngine.Debug.Log($"Enter MenuState Frame <{UnityEngine.Time.frameCount}>");

            MenuScreen.OnStartButtonClicked -= StartButtonClicked;
        }

        private void StartButtonClicked() =>
            _gameStateMachine.Enter<LoadingState, string>(SceneName.Game);
    }
}