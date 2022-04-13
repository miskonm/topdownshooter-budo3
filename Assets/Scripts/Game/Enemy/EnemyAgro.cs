using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAgro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyFollow _enemyFollow;
        [SerializeField] private EnemyIdleBehaviour _idleBehaviour;

        [Header("Raycast")]
        [SerializeField] private LayerMask _raycastMask;

        private void Start()
        {
            _triggerObserver.OnExited += Exited;
            _triggerObserver.OnStayed += Stay;
        }

        private void Exited(Collider2D obj) =>
            Follow(false);

        private void Stay(Collider2D other)
        {
            if (_enemyFollow.enabled)
                return;

            Vector3 direction = other.transform.position - transform.position;
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, direction.magnitude, _raycastMask);

            if (hit2D.collider != null)
                return;

            Follow(true);
        }

        private void Follow(bool isFallow)
        {
            _enemyFollow.enabled = isFallow;
            EnableIdle(!isFallow);
        }

        private void EnableIdle(bool isEnabled)
        {
            if (_idleBehaviour != null)
                _idleBehaviour.enabled = isEnabled;
        }
    }
}