using System.Collections;
using Lean.Pool;
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
        private IEnumerator _killBulletRoutine;
        
        private void OnEnable()
        {
            _killBulletRoutine = KillBulletByLifeTime();
            StartCoroutine(_killBulletRoutine);
        }

        private void OnDisable()
        {
            if (_killBulletRoutine != null)
                StopCoroutine(_killBulletRoutine);
        }

        private void Start()
        {
            _velocity = Vector3.up * _speed;
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
            LeanPool.Despawn(gameObject);
    }
}