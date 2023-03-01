using System;
using UnityEngine;

namespace TopDownShooter.Controllers
{
	public class Player : MonoBehaviour
	{
		public float moveSpeed;
		
		private float _horizontalMovement;
		private float _verticalMovement;
		
		private void Update()
		{
			Movement();
		}

		private void Movement()
		{
			_horizontalMovement = Input.GetAxis("Horizontal");
			_verticalMovement = Input.GetAxis("Vertical");
			
			transform.Translate(Vector3.right * (_horizontalMovement * moveSpeed * Time.deltaTime));
			transform.Translate(Vector3.up * (_verticalMovement * moveSpeed * Time.deltaTime));
		}
	}
}