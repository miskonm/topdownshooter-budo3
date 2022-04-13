using TDS.Game.Common;
using UnityEngine;

namespace TDS.Game.Ui
{
    public class ActorUi : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;

        private IHealth _health;

        private void Awake()
        {
            Construct(GetComponentInParent<IHealth>());
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.OnChanged -= HealthChanged;
        }

        public void Construct(IHealth health)
        {
            _health = health;

            if (_health != null)
            {
                HealthChanged();
                _health.OnChanged += HealthChanged;
            }
        }

        private void HealthChanged() =>
            _hpBar.SetValues(_health.CurrentHp, _health.MaxHp);
    }
}