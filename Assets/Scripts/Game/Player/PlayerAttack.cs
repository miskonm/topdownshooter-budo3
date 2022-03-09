using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private float _shootDelay = 0.5f;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;

        private float _currentDelay;
        
        private void Update()
        {
            DecrementTimer(Time.deltaTime);

            if (Input.GetButtonDown("Fire1") && CanShoot())
                Attack();
        }

        private void DecrementTimer(float deltaTime) =>
            _currentDelay -= deltaTime;

        private bool CanShoot() =>
            _currentDelay <= 0f;

        private void Attack()
        {
            CreateBullet();
            _playerAnimation.PlayShoot();
            SetDelay();
        }

        private void SetDelay() =>
            _currentDelay = _shootDelay;

        private void CreateBullet() =>
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletSpawnPointTransform.rotation);
    }
}