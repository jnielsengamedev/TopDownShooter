using System;
using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class Player : MonoBehaviour
	{
		public float moveSpeed;

		private float _horizontalMovement;
		private float _verticalMovement;
		private Camera _mainCamera;

		private void Awake()
		{
			_mainCamera = Camera.main;
		}

		private void Update()
		{
			Movement();
			FaceMouse();
		}

		private void Movement()
		{
			_horizontalMovement = Input.GetAxis("Horizontal");
			_verticalMovement = Input.GetAxis("Vertical");

			transform.Translate(Vector3.right * (_horizontalMovement * moveSpeed * Time.deltaTime), Space.World);
			transform.Translate(Vector3.up * (_verticalMovement * moveSpeed * Time.deltaTime), Space.World);
		}

		private void FaceMouse()
		{
			var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

			transform.rotation = rotation;
		}
	}
}