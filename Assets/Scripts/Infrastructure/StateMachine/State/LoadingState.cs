using TDS.Infrastructure.SceneLoading;

namespace TDS.Infrastructure.StateMachine.State
{
    public class LoadingState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadingState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoaded);
        }

        private void OnLoaded()
        {
            // TODO: Some actions
            
            _stateMachine.Enter<GameState>();
        }

        public void Exit()
        {
        }
    }
}