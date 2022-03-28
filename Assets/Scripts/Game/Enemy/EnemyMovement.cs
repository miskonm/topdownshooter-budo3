using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        private Transform _targetTransform;

        private void Update()
        {
            if (_targetTransform == null)
                return;

            Vector3 direction = Direction();
            Move(direction);
            Rotate(direction);
        }

        public void SetTarget(Transform targetTransform) =>
            _targetTransform = targetTransform;

        public void Reset()
        {
            _targetTransform = null;
            _rb.velocity = Vector2.zero;
        }

        private Vector3 Direction() =>
            (_targetTransform.position - transform.position).normalized;

        private void Move(Vector3 direction) =>
            _rb.velocity = direction * _speed;

        private void Rotate(Vector3 direction) =>
            transform.up = direction;
    }
}