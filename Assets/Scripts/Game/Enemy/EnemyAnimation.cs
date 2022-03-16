using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private string _attackName;
        [SerializeField] private string _speedName;
        [SerializeField] private string _deathName;

        // private void Update() =>
        //     PlayMove();

        public void PlayAttack() =>
            _animator.SetTrigger(_attackName);

        public void PlayMove(float speed) =>
            _animator.SetFloat(_speedName, speed);

        private void PlayMove() =>
            _animator.SetFloat(_speedName, _rb.velocity.magnitude);

        public void PlayDeath() =>
            _animator.SetTrigger(_deathName);
    }
}