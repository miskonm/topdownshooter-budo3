namespace TDS.Infrastructure.StateMachine.State
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}