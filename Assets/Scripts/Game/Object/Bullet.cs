using System;
using System.Collections;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Object
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        [SerializeField] private int _damage;

        private Vector3 _velocity;

        private void Start()
        {
            _velocity = Vector3.up * _speed;

            StartCoroutine(KillBulletByLifeTime());
        }

        private void Update() =>
            Move();

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Enemy"))
            {
                col.GetComponent<EnemyHealth>().ApplyDamage(_damage);
                Kill();
            }
        }

        private void Move() =>
            transform.Translate(_velocity * Time.deltaTime);

        private IEnumerator KillBulletByLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);

            Kill();
        }

        private void Kill() =>
            Destroy(gameObject);
    }
}