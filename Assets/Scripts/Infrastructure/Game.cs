using TDS.Infrastructure.StateMachine;

namespace TDS.Infrastructure
{
    public class Game
    {
        public IGameStateMachine StateMachine;
        
        public Game(IGameStateMachine gameStateMachine)
        {
            StateMachine = gameStateMachine;
        }
    }
}