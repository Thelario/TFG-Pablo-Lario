using UnityEngine;

namespace Mono.Scripts.Cubes
{
	public class CubeMSS : MonoBehaviour
	{
		[SerializeField] private float moveSpeed;
		[SerializeField] private Transform thisTransform;

		private Vector3 _direction;
		
		private void Start()
		{
			_direction = thisTransform.position.normalized;
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			thisTransform.position += moveSpeed * Time.deltaTime * _direction;
		}
	}
}

