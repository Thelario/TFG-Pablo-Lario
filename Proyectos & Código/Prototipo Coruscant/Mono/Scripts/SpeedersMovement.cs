using UnityEngine;

namespace _Project.MONO.Scripts
{
	public class SpeedersMovement : MonoBehaviour
	{
		private float _speed;

		private Transform _thisTransform;
		
		private void Awake()
		{
			_thisTransform = transform;
		}

		public void ConfigureSpeeder(float minSpeedLimit, float maxSpeedLimit)
		{
			_speed = Random.Range(minSpeedLimit, maxSpeedLimit);
		}

		private void Update()
		{
			_thisTransform.position += _speed * Time.deltaTime * Vector3.forward;
		}
	}
}
