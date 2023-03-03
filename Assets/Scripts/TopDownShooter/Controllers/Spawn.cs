using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class Spawn : MonoBehaviour
	{
		public GameObject powerupPrefab;
		public GameObject enemyPrefab;
		private float spawnRange = 9;
		public int enemyCount;

		public int waveNumber = 1;

		// Start is called before the first frame update
		private void Start()
		{
			SpawnEnemyWave(waveNumber);
			Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
		}

		// Update is called once per frame
		private void Update()
		{
			if (enemyCount <= 4)
			{
				waveNumber++;
				SpawnEnemyWave(waveNumber);
				Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
			}
		}

		private void SpawnEnemyWave(int enemiesToSpawn)
		{
			for (int i = 0; i < enemiesToSpawn; i++)
			{
				Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
			}
		}

		private Vector3 GenerateSpawnPosition()
		{
			float spawnPosX = Random.Range(-spawnRange, spawnRange);
			float spawnPosZ = Random.Range(-spawnRange, spawnRange);
			Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
			return randomPos;
		}

		public void CalculateEnemyCount()
		{
			enemyCount = FindObjectsOfType<Enemy>().Length;
		}

		public static Spawn Get()
		{
			return GameObject.Find("Spawner").GetComponent<Spawn>();
		}
	}
}