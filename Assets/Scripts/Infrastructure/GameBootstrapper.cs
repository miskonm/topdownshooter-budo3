using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.StateMachine.State;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(new GameStateMachine());
            _game.StateMachine.Enter<BootstrapState>();
        
            DontDestroyOnLoad(this);
        }
    }
}