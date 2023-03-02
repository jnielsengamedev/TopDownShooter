using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TopDownShooter.Controllers
{
    public class Bullet : MonoBehaviour
    {
        public float moveSpeed;

        private void Awake()
        {
            StartCoroutine(BulletExpiry());
        }

        private void Update()
        {
            transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            EnemyCheck(col, gameObject);
        }

        private static void EnemyCheck(Component col, Object self)
        {
            if (!col.gameObject.CompareTag("Enemy")) return;
            Destroy(col.gameObject);
            GameManager.AddScore(500);
            Destroy(self);
        }

        private IEnumerator BulletExpiry()
        {
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }
}
