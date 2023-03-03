using TopDownShooter.Controllers;
using TopDownShooter.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace TopDownShooter
{
	public class GameManager : MonoBehaviour
	{
		public static State State;
		private Cam _cam;
		private VisualElement _rootElement;
		private Label _score;

		private void Awake()
		{
			State = new State();
			_cam = Cam.Get();
			_rootElement = GetComponent<UIDocument>().rootVisualElement;
			_rootElement.RegisterCallback<GeometryChangedEvent>(_ => _cam.CalculateHorizontalSize());

			_score = _rootElement.Q<Label>("Score");
		}

		private void Update()
		{
			UpdateUI();
		}

		private void UpdateUI()
		{
			_score.text = $"Score: {State.Score}";
		}

		/// <summary>
		/// This method lets you add an amount to the Score.
		/// </summary>
		/// <param name="score">The score you want to add.</param>
		public static void AddScore(long score)
		{
			State.Score += score;
		}

		/// <summary>
		/// This method lets you subtract an amount to the Score.
		/// </summary>
		/// <param name="score">The score you want to subtract.</param>
		public static void SubtractScore(long score)
		{
			State.Score -= score;
		}

		/// <summary>
		/// This method lets you reset the score to 0.
		/// </summary>
		public static void ResetScore()
		{
			State.Score = 0;
		}

		/// <summary>
		/// Load the GameOver screen.
		/// </summary>
		public static void GameOver()
		{
			if (HighScoreManager.HighScore.Score < State.Score)
			{
				HighScoreManager.HighScore = HighScoreManager.ScoreToHighScore(State.Score);
			}

			SceneManager.LoadScene("GameOver");
		}
	}
}