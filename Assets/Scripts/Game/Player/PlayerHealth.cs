using System;
using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int _maxHp;
        [SerializeField] private int _currentHp;
        
        public event Action OnChanged;
        
        public int CurrentHp
        {
            get => _currentHp;
            private set
            {
                int oldHp = _currentHp;
                _currentHp = value;

                _currentHp = Mathf.Max(_currentHp, MaxHp);

                if (oldHp != _currentHp)
                    OnChanged?.Invoke();
            }
        }

        public int MaxHp => _maxHp;

        private void Start()
        {
            CurrentHp = _maxHp;
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp -= damage;

            //if (CurrentHp < 0)
            //TODO: _playerDeath.Die();
        }

        public void Heal(int healPoints)
        {
            CurrentHp += healPoints;
        }
    }
}