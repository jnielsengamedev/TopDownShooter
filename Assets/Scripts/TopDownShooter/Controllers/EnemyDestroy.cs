using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class EnemyDestroy : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.name == "Player")
			{
				Destroy(collision.gameObject);
				collision.gameObject.SetActive(false);
			}
		}
	}
}