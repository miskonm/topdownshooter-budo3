using TDS.Infrastructure.SceneLoading;
using TDS.Infrastructure.StateMachine;
using TDS.Infrastructure.StateMachine.State;
using TDS.UI;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(new GameStateMachine(new AsyncSceneLoader(this)));
            _game.StateMachine.Enter<BootstrapState>();
        
            DontDestroyOnLoad(this);
        }
    }
}