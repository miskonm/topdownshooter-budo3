using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class MoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
            _enemyMovement.enabled = false;
            enabled = false;
        }
        
        private void OnEnable()
        {
            _enemyMovement.enabled = true;
            _enemyMovement.SetTarget(_playerTransform);
        }

        private void OnDisable()
        {
            _enemyMovement.enabled = false;
            _enemyMovement.Reset();
        }
    }
}