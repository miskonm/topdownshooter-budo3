using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            Vector3 direction = Direction();
            Move(direction);
            Rotate(direction);
        }

        public void Reset() =>
            _rb.velocity = Vector2.zero;

        private Vector3 Direction() =>
            _playerTransform.position - transform.position;

        private void Move(Vector3 direction) =>
            _rb.velocity = direction * _speed;

        private void Rotate(Vector3 direction) =>
            transform.up = direction;
    }
}