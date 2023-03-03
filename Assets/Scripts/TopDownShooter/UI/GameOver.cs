using TopDownShooter.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace TopDownShooter.UI
{
	public class GameOver : MonoBehaviour
	{
		private VisualElement _rootElement;
		private Label _score;
		private Label _highScore;
		private Button _restart;
		private Button _mainMenu;

		private void Awake()
		{
			_rootElement = GetComponent<UIDocument>().rootVisualElement;
			_score = _rootElement.Q<Label>("Score");
			_highScore = _rootElement.Q<Label>("HighScore");
			_restart = _rootElement.Q<Button>("Restart");
			_mainMenu = _rootElement.Q<Button>("MainMenu");

			_score.text = $"Score: {GameManager.State.Score}";
			_highScore.text = $"High Score: {HighScoreManager.HighScore.Score}";
			_restart.clicked += Restart;
			_mainMenu.clicked += MainMenu;
		}

		private void OnDestroy()
		{
			_restart.clicked -= Restart;
			_mainMenu.clicked -= MainMenu;
		}

		private static void Restart()
		{
			GameManager.ResetScore();
			SceneManager.LoadScene("TopDownShooter");
		}

		private static void MainMenu()
		{
			GameManager.ResetScore();
			SceneManager.LoadScene("MainMenu");
		}
	}
}
