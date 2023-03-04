using System.Collections;
using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class Spawner : MonoBehaviour
	{
		public GameObject enemyPrefab;
		private int enemyCount;
		private int waveNumber = 1;

		public float timeBetweenEnemySpawn;
		public float timeBetweenWaves;

		public Transform[] spawnPoints;

		private bool spawningWave;


		// Start is called before the first frame update
		private void Start()
		{
			StartCoroutine(SpawnEnemyWave(waveNumber));
		}

		// Update is called once per frame
		private void Update()
		{
			if (enemyCount == 0 && !spawningWave)
			{
				waveNumber++;
				StartCoroutine(SpawnEnemyWave(waveNumber));
			}
		}

		IEnumerator SpawnEnemyWave(int enemiesToSpawn)
		{
			spawningWave = true;
			yield return new WaitForSeconds(timeBetweenWaves); //We wait here to pause between wave spawning
			for (int i = 0; i < enemiesToSpawn; i++)
			{
				Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position,
					enemyPrefab.transform.rotation);
				yield return
					new WaitForSeconds(
						timeBetweenEnemySpawn); //We wait here to give a bit of time between each enemy spawn
			}

			spawningWave = false;
		}
	}
}