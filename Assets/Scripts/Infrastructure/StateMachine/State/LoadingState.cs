using TDS.Game.Enemy;
using TDS.Game.Factory;
using TDS.Game.Player;
using TDS.Game.Ui;
using TDS.Infrastructure.Assets;
using TDS.Infrastructure.SceneLoading;
using UnityEngine;

namespace TDS.Infrastructure.StateMachine.State
{
    public class LoadingState : IPayloadState<string>
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IAssetsService _assetsService;

        public LoadingState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IEnemyFactory enemyFactory,
            IAssetsService assetsService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _enemyFactory = enemyFactory;
            _assetsService = assetsService;
        }

        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoaded);
        }

        private void OnLoaded()
        {
            SetupHud();
            InitWorld();

            _stateMachine.Enter<GameState>();
        }

        private void SetupHud()
        {
            // GameObject hud = GameObject.Find("HUD");
            GameObject hudPrefab = _assetsService.GetAsset<GameObject>(AssetPath.HUD);
            GameObject hud = Object.Instantiate(hudPrefab);
            ActorUi actorUi = hud.GetComponentInChildren<ActorUi>();
            PlayerHealth playerHealth = Object.FindObjectOfType<PlayerHealth>();
            actorUi.Construct(playerHealth);
        }

        private void InitWorld()
        {
            InstantiateEnemies();
        }

        private void InstantiateEnemies()
        {
            EnemySpawnPoint[] spawnPoints = Object.FindObjectsOfType<EnemySpawnPoint>();

            foreach (EnemySpawnPoint spawnPoint in spawnPoints)
            {
                _enemyFactory.Create(spawnPoint);
            }
        }

        public void Exit()
        {
        }
    }
}