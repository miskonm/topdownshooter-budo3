using System;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _maxHp;
        public event Action OnChanged;

        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        private void Start()
        {
            CurrentHp = _maxHp;
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp -= damage;
            OnChanged?.Invoke();

            // if (_currentHp < 0)
            // TODO: _enemyDeath.Die();
        }

        public void Heal(int healPoints)
        {
            CurrentHp += healPoints;
            CurrentHp = Mathf.Max(CurrentHp, MaxHp);

            OnChanged?.Invoke();
        }
    }
}