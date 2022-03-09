using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                Attack();
        }

        private void Attack()
        {
            CreateBullet();
            _playerAnimation.PlayShoot();
        }

        private void CreateBullet() =>
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _bulletSpawnPointTransform.rotation);
    }
}