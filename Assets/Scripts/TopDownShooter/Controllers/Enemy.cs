using System;
using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class Enemy : MonoBehaviour
	{
		public static event Action<Enemy> OnEnemyKilled;
		[SerializeField] float health, maxHealth = 3f;

		[SerializeField] private float moveSpeed = 5f;
		Rigidbody2D rb;
		Transform target;
		Vector2 moveDirection;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			health = maxHealth;
			target = Player.Instance.transform;
		}

		private void Update()
		{
			if (target)
			{
				Vector3 direction = (target.position - transform.position).normalized;
				float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
				rb.rotation = angle;
				moveDirection = direction;
			}
		}

		private void FixedUpdate()
		{
			if (target)
			{
				rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
			}
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			DestroyCheck(collision);
		}

		private static void DestroyCheck(Collision2D collision)
		{
			if (collision.gameObject.name == "Player")
			{
				Destroy(collision.gameObject);
			}
		}

		public void TakeDamage(float damageAmount)
		{
		}
	}
}