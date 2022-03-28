using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttackRange : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMovement _enemyMovement;
        
        private bool _isInRange;

        private void Start()
        {
            _triggerObserver.OnEntered += Entered;
            _triggerObserver.OnExited += Exited;
        }

        private void Update()
        {
            if (!_isInRange)
                return;
            
            _enemyAttack.Attack();
        }

        private void Entered(Collider2D obj)
        {
            _isInRange = true;
            _enemyMovement.enabled = false;
        }

        private void Exited(Collider2D obj)
        {
            _isInRange = false;
            _enemyMovement.enabled = true;
        }
    }
}