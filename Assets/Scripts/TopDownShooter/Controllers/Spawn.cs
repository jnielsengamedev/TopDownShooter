using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class Spawn : MonoBehaviour
	{
		public GameObject enemyPrefab;
		public int enemyCount;
		public int waveNumber = 1;
		
		private float spawnRange = 7;

		// Start is called before the first frame update
		private void Start()
		{
			SpawnEnemyWave(waveNumber);
		}

		// Update is called once per frame
		private void Update()
		{
			if (enemyCount <= 3)
			{
				waveNumber++;
				SpawnEnemyWave(waveNumber);
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
			float spawnPosY = Random.Range(-spawnRange, spawnRange);
			Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
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