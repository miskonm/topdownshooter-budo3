using System.Collections.Generic;
using TDS.Game.Enemy;
using TDS.Game.Utility;
using UnityEngine;

namespace TDS.Game.Config
{
    [CreateAssetMenu(fileName = Tag, menuName = "Config/EnemyContainer")]
    public class EnemyConfigContainer : ScriptableObject
    {
        private const string Tag = nameof(EnemyConfigContainer);

        [SerializeField] private List<EnemyConfig> _configs;

        private readonly Dictionary<EnemyType, EnemyConfig> _cachedConfigs = new Dictionary<EnemyType, EnemyConfig>();

        private void OnEnable()
        {
            _cachedConfigs.Fill(Tag, _configs, config => config.EnemyType);
        }

        public EnemyConfig Config(EnemyType enemyType)
        {
            if (_cachedConfigs.ContainsKey(enemyType))
                return _cachedConfigs[enemyType];
            
            Debug.LogError($"{Tag},{nameof(Config)}: There is no config for type '{enemyType}'");
            return null;
        }
    }
}