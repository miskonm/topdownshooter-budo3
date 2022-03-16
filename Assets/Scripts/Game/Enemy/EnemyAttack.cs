using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation _enemyAnimation;

        [SerializeField] private float _attackDelay = 0.5f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _attackRadius;
        [SerializeField] private LayerMask _attackMask;

        private float _currentDelay;

        // private void Update()
        // {
        //     DecrementTimer(Time.deltaTime);
        //
        //     if (_inputService.IsFireButtonClicked() && CanAttack())
        //         Attack();
        // }

        private void Update()
        {
            DecrementTimer(Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
        }

        public void Attack()
        {
            if (!CanAttack())
                return;

            _enemyAnimation.PlayAttack();
            SetDelay();
        }

        public void AppleDamage()
        {
            Collider2D circle = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, _attackMask);

            if (circle == null)
                return;

            PlayerHealth playerHealth = circle.GetComponent<PlayerHealth>();

            if (playerHealth == null)
                return;

            playerHealth.CurrentHp -= _damage;
        }

        private void DecrementTimer(float deltaTime) =>
            _currentDelay -= deltaTime;

        private bool CanAttack() =>
            _currentDelay <= 0f;

        private void SetDelay() =>
            _currentDelay = _attackDelay;
    }
}