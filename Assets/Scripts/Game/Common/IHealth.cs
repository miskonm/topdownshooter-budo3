using System;

namespace TDS.Game.Common
{
    public interface IHealth
    {
        event Action OnChanged;
        
        int CurrentHp { get; }
        int MaxHp { get; }

        void ApplyDamage(int damage);
        void Heal(int healPoints);
    }
}