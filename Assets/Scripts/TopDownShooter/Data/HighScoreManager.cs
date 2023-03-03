using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace TopDownShooter.Data
{
	public class HighScoreManager
	{
		public static HighScore HighScore
		{
			get => ReadHighScore();
			set => SetHighScore(value);
		}

		private static readonly string Path = $"{Application.persistentDataPath}/HighScore.json";

		private static HighScore ReadHighScore()
		{
			string file;

			if (File.Exists(Path))
			{
				file = File.ReadAllText(Path);
			}
			else
			{
				return new HighScore();
			}

			return DeserializeHighScore(file);
		}

		private static void SetHighScore(HighScore highScore)
		{
			File.WriteAllText(Path, SerializeHighScore(highScore));
		}

		private static HighScore DeserializeHighScore(string highScore)
		{
			return JsonConvert.DeserializeObject<HighScore>(highScore);
		}

		private static string SerializeHighScore(HighScore highScore)
		{
			return JsonConvert.SerializeObject(highScore);
		}

		public static HighScore ScoreToHighScore(long score)
		{
			return new HighScore()
			{
				Score = score
			};
		}
	}
}