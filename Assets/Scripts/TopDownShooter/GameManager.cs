using TopDownShooter.Controllers;
using TopDownShooter.Data;
using UnityEngine;
using UnityEngine.UIElements;

namespace TopDownShooter
{
	public class GameManager : MonoBehaviour
	{
		private static State _state;
		private Cam _cam;
		private VisualElement _rootElement;
		private Label _score;

		private void Awake()
		{
			_state = new State();
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
			_score.text = $"Score: {_state.Score}";
		}

		/// <summary>
		/// This method lets you add an amount to the Score.
		/// </summary>
		public static void AddScore(long score)
		{
			_state.Score += score;
		}

		/// <summary>
		/// This method lets you reset the score to 0.
		/// </summary>
		public static void ResetScore()
		{
			_state.Score = 0;
		}
	}
}