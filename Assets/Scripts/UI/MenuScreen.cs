using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        
        public static event Action OnStartButtonClicked;

        private void Awake()
        {
            _startButton.onClick.AddListener(() => OnStartButtonClicked?.Invoke());
        }
    }
}