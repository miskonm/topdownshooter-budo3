using TDS.Game.Enemy;
using TDS.Infrastructure.Services;
using UnityEngine;

namespace TDS.Game.Factory
{
    public interface IEnemyFactory : IService
    {
        void Bootstrap();
        GameObject Create(EnemySpawnPoint enemySpawnPoint);
    }
}