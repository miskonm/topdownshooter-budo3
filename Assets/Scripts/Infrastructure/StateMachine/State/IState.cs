namespace TDS.Infrastructure.StateMachine.State
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}