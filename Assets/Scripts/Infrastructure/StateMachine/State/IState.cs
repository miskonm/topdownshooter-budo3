namespace TDS.Infrastructure.StateMachine.State
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}