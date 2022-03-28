using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAgro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyFollow _enemyFollow;

        private void Start()
        {
            _triggerObserver.OnEntered += Entered;
            _triggerObserver.OnExited += Exited;
        }

        private void Entered(Collider2D obj)
        {
            _enemyFollow.enabled = true;
        }

        private void Exited(Collider2D obj)
        {
            _enemyFollow.enabled = false;
        }
    }
}