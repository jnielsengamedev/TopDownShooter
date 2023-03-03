using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace TopDownShooter.UI
{
	public class MainMenu: MonoBehaviour
	{
		private VisualElement _rootElement;
		private Button _play;

		private void Awake()
		{
			_rootElement = GetComponent<UIDocument>().rootVisualElement;
			_play = _rootElement.Q<Button>("Play");
			
			_play.clicked += Play;
		}

		private void OnDestroy()
		{
			_play.clicked -= Play;
		}

		private static void Play()
		{
			SceneManager.LoadScene("TopDownShooter");
		}
	}
}