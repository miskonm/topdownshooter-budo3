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
            UnityEngine.Debug.Log($"Enter MenuState");
        }

        public void Exit()
        {
            UnityEngine.Debug.Log($"Enter MenuState");

        }
    }
}