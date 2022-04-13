using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class MoveToPlayer : EnemyFollow
    {
        [SerializeField] private EnemyMovement _enemyMovement;

        private Transform _playerTransform;

        private void Awake()
        {
            _enemyMovement.enabled = false;
            enabled = false;
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }
        
        private void OnEnable()
        {
            _enemyMovement.enabled = true;
            _enemyMovement.SetTarget(_playerTransform);
        }

        private void OnDisable()
        {
            _enemyMovement.enabled = false;
            _enemyMovement.Refresh();
        }
    }
}