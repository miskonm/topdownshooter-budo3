using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Config
{
    [CreateAssetMenu(fileName = Tag, menuName = "Config/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        private const string Tag = nameof(EnemyConfig);

        public EnemyType EnemyType;
        public GameObject EnemyPrefab;
        
        public int StartAttack;
    }
}