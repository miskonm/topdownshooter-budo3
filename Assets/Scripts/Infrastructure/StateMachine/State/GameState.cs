namespace TDS.Infrastructure.StateMachine.State
{
    public class GameState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public GameState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}