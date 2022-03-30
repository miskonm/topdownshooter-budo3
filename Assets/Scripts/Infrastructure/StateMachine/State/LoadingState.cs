using TDS.Game.Player;
using TDS.Game.Ui;
using TDS.Infrastructure.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class LoadingState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadingState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoaded);
        }

        private void OnLoaded()
        {
            SetupHud();

            _stateMachine.Enter<GameState>();
        }

        private static void SetupHud()
        {
            GameObject hud = GameObject.Find("HUD");
            ActorUi actorUi = hud.GetComponentInChildren<ActorUi>();
            PlayerHealth playerHealth = Object.FindObjectOfType<PlayerHealth>();
            actorUi.Construct(playerHealth);
        }

        public void Exit()
        {
        }
    }
}