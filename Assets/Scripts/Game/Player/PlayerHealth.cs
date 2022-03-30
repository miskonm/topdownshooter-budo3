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

        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        private void Start()
        {
            CurrentHp = _maxHp;
            _currentHp = CurrentHp;
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp -= damage;
            _currentHp = CurrentHp;

            OnChanged?.Invoke();

            // if (_currentHp < 0)
            // TODO: _playerDeath.Die();
        }

        public void Heal(int healPoints)
        {
            CurrentHp += healPoints;
            CurrentHp = Mathf.Max(CurrentHp, MaxHp);
            _currentHp = CurrentHp;


            OnChanged?.Invoke();
        }
    }
}