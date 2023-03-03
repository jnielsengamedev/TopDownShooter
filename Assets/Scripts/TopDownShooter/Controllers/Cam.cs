using TopDownShooter.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TopDownShooter.Controllers
{
	public class Cam : MonoBehaviour
	{
		public Transform followedObject;
		public TilemapCollider2D tilemap;

		private Camera _camera;
		private TilemapBounds _tilemapBounds;
		private float _horizontalSize;

		private void Awake()
		{
			_camera = GetComponent<Camera>();
			CalculateHorizontalSize();
		}

		private void Update()
		{
			if (!followedObject) return;
			transform.position = new Vector3(GetClampedHorizontalPosition(), GetClampedVerticalPosition(), -10);
		}

		private float GetClampedHorizontalPosition()
		{
			return Mathf.Clamp(followedObject.position.x, _tilemapBounds.Left,
				_tilemapBounds.Right < _horizontalSize ? _tilemapBounds.Left : _tilemapBounds.Right);
		}

		private float GetClampedVerticalPosition()
		{
			return Mathf.Clamp(followedObject.position.y,
				_tilemapBounds.Down < _camera.orthographicSize ? _tilemapBounds.Up : _tilemapBounds.Down,
				_tilemapBounds.Up);
		}

		private static float GetHorizontalSize(Camera camera)
		{
			return camera.orthographicSize * camera.aspect;
		}

		public void CalculateHorizontalSize()
		{
			_horizontalSize = GetHorizontalSize(_camera);
			_tilemapBounds = new TilemapBounds(tilemap.bounds, _horizontalSize, _camera.orthographicSize);
		}

		public static Cam Get()
		{
			return GameObject.Find("Main Camera").GetComponent<Cam>();
		}
	}
}