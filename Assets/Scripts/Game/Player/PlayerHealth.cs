using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHp;

        public int CurrentHp;

        private void Start()
        {
            CurrentHp = _maxHp;
        }
    }
}