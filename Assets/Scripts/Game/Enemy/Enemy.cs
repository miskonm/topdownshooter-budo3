using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private enum State
        {
            None = 0,
            Idle = 1,
            Move = 2,
            Attack = 3,
            Death = 4,
        }

        [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Collider2D _collider2D;

        [Header("Settings")]
        [SerializeField] private float _moveRadius = 1f;
        [SerializeField] private float _attackRadius = 0.5f;

        private Transform _playerTransform;
        [SerializeField] private State _currentState = State.None;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            if (_currentState == State.Death)
                return;

            float distance = Vector3.Distance(_playerTransform.position, transform.position);

            if (distance <= _attackRadius)
            {
                SetState(State.Attack);
            }
            else if (distance <= _moveRadius)
            {
                SetState(State.Move);
            }
            else
            {
                SetState(State.Idle);
            }

            UpdateState(_currentState);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _moveRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }

        public void Die()
        {
            SetState(State.Death);
        }

        private void SetState(State state)
        {
            if (_currentState == state)
                return;

            _currentState = state;

            switch (_currentState)
            {
                case State.Idle:
                    _enemyMovement.enabled = false;
                    _enemyMovement.Reset();
                    break;
                case State.Move:
                    _enemyMovement.enabled = true;
                    break;
                case State.Attack:
                    _enemyMovement.enabled = false;
                    _enemyMovement.Reset();
                    _enemyAnimation.PlayMove(_rb.velocity.magnitude);
                    break;
                case State.Death:
                    _enemyAnimation.PlayDeath();
                    _enemyMovement.enabled = false;
                    _enemyMovement.Reset();
                    _collider2D.enabled = false;
                    break;
            }
        }

        private void UpdateState(State state)
        {
            switch (state)
            {
                case State.Move:
                    _enemyAnimation.PlayMove(_rb.velocity.magnitude);
                    break;
                case State.Attack:
                    _enemyAttack.Attack();
                    break;
            }
        }
    }
}