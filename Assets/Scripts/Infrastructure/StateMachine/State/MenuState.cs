using TDS.Infrastructure.SceneLoading;
using TDS.UI;
using TDS.Utility.Constants;

namespace TDS.Infrastructure.StateMachine.State
{
    public class MenuState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public MenuState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
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
            _sceneLoader.Load(SceneName.Game, EnterGameState);

        private void EnterGameState() =>
            _gameStateMachine.Enter<GameState>();
    }
}