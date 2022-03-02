namespace TDS.Infrastructure.StateMachine.State
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public BootstrapState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            UnityEngine.Debug.Log($"Enter BootstrapState");
            EnterMenuState();
        }

        public void Exit()
        {
            UnityEngine.Debug.Log($"Exit BootstrapState");
        }

        private void EnterMenuState()
        {
            _stateMachine.Enter<MenuState>();
        }
    }
}