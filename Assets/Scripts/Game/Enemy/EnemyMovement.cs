using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        [Header(nameof(EnemyMovement))]
        [SerializeField] protected EnemyAnimation _enemyAnimation;
        [SerializeField] protected float _speed;

        public abstract void SetTarget(Transform targetTransform);
        public abstract void Refresh();
    }
}