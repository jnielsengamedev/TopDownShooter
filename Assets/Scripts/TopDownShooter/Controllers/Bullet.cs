using System.Collections;
using UnityEngine;

namespace TopDownShooter.Controllers
{
    public class Bullet : MonoBehaviour
    {
        public float moveSpeed;
        public long enemyScore;

        private Spawn _spawner;

        private void Awake()
        {
            _spawner = Spawn.Get();
            StartCoroutine(BulletExpiry());
        }

        private void Update()
        {
            transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            EnemyCheck(col);
        }

        private void EnemyCheck(Component col)
        {
            if (!col.gameObject.CompareTag("Enemy")) return;
            Destroy(col.gameObject);
            GameManager.AddScore(enemyScore);
            _spawner.CalculateEnemyCount();
            Destroy(gameObject);
        }

        private IEnumerator BulletExpiry()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
