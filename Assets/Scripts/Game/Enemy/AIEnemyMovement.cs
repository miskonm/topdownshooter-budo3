using System;
using Pathfinding;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class AIEnemyMovement : EnemyMovement
    {
        [Header(nameof(AIEnemyMovement))]
        [SerializeField] private AIDestinationSetter _destinationSetter;
        [SerializeField] private AIBase _aiBase;

        private void Awake()
        {
            _aiBase.maxSpeed = _speed;
        }

        private void OnEnable()
        {
            _aiBase.enabled = true;
            _enemyAnimation.PlayMove(1f);
        }

        private void OnDisable()
        {
            _aiBase.enabled = false;
            _enemyAnimation.PlayMove(0f);
        }

        public override void SetTarget(Transform targetTransform) =>
            _destinationSetter.target = targetTransform;

        public override void Refresh() =>
            _destinationSetter.target = null;
    }
}