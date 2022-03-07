using TDS.Infrastructure.SceneLoading;
using TDS.Utility.Constants;

namespace TDS.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            UnityEngine.Debug.Log($"Enter BootstrapState Frame <{UnityEngine.Time.frameCount}>");
            LoadMenuScene();
        }

        public void Exit()
        {
            UnityEngine.Debug.Log($"Exit BootstrapState Frame <{UnityEngine.Time.frameCount}>");
        }

        private void LoadMenuScene()
        {
            _sceneLoader.Load(SceneName.Menu, EnterMenuState);
        }

        private void EnterMenuState()
        {
            _stateMachine.Enter<MenuState>();
        }
    }
}