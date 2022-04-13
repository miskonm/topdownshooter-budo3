using TDS.Game.Config;
using TDS.Game.Enemy;
using TDS.Infrastructure.Assets;
using UnityEngine;

namespace TDS.Game.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetsService _assetsService;
        
        private EnemyConfigContainer _enemyConfigContainer;

        public EnemyFactory(IAssetsService assetsService)
        {
            _assetsService = assetsService;
        }

        public void Bootstrap()
        {
            _enemyConfigContainer = _assetsService.GetAsset<EnemyConfigContainer>(AssetPath.EnemyConfigContainer);
        }

        public GameObject Create(EnemySpawnPoint enemySpawnPoint)
        {
            EnemyConfig enemyConfig = _enemyConfigContainer.Config(enemySpawnPoint.EnemyType);
            if (enemyConfig == null)
                return null;

            GameObject gameObject = Instantiate(enemyConfig.EnemyPrefab, enemySpawnPoint.transform.position);
            SetupEnemy(gameObject, enemySpawnPoint);
            return gameObject;
        }

        private GameObject Instantiate(GameObject prefab, Vector3 at, Transform under = null) =>
            UnityEngine.Object.Instantiate(prefab, at, Quaternion.identity, under);

        private void SetupEnemy(GameObject gameObject, EnemySpawnPoint enemySpawnPoint)
        {
            EnemyPatrol enemyPatrol = gameObject.GetComponentInChildren<EnemyPatrol>();
            if (enemyPatrol == null)
                return;

            enemyPatrol.Construct(enemySpawnPoint.PatrolPath);
        }
    }
}