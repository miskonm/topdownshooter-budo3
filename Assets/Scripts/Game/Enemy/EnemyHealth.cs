using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        
        [SerializeField] private int _maxHp;

        private int _currentHp;

        private void Start()
        {
            _currentHp = _maxHp;
        }

        public void ApplyDamage(int damage)
        {
            _currentHp -= damage;

            if (_currentHp < 0)
                _enemy.Die();
        }
    }
}