using TDS.Infrastructure.StateMachine.State;

namespace TDS.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}