using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.Ui
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        public void SetValues(float currentValue, float maxValue)
        {
            if (maxValue == 0)
                return;

            float amount = currentValue / maxValue;
            _fillImage.fillAmount = amount;
        }
    }
}