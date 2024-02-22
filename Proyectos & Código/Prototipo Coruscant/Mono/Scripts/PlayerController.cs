using UnityEngine;

namespace _Project.MONO.Scripts
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private bool pressingThrottle;
		[SerializeField] private float pitchPower;
		[SerializeField] private float rollPower;
		[SerializeField] private float yawPower;
		[SerializeField] private float enginePower;
		[SerializeField] private Vector3 initialPosition;

		private float _activeRoll;
		private float _activePitch;
		private float _activeYaw;
		private float _dirRotation;
		private bool _pressingThrottle;

		private Transform _thisTransform;
		
		private void Awake()
		{
			_thisTransform = transform;
			_pressingThrottle = pressingThrottle;
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q))
				transform.position = initialPosition;
			
			GetThrottleInput();

			RotatePlayer();
		}

		private void GetThrottleInput()
		{
			if (!Input.GetKeyDown(KeyCode.Space))
				return;

			_pressingThrottle = !_pressingThrottle;
		}

		private void RotatePlayer()
		{
			if (_pressingThrottle)
			{
				_thisTransform.position += _thisTransform.forward * (enginePower * Time.deltaTime);

				_activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
				_activeRoll = Input.GetAxisRaw("Horizontal") * rollPower * Time.deltaTime;
				
				if (Input.GetMouseButton(0))
					_dirRotation = -1f;
				else if (Input.GetMouseButton(1))
					_dirRotation = 1f;
				else
					_dirRotation = 0f;
				
				_activeYaw = _dirRotation * yawPower * Time.deltaTime;

				_thisTransform.Rotate(_activePitch * pitchPower * Time.deltaTime,
					_activeYaw * yawPower * Time.deltaTime,
					-_activeRoll * rollPower * Time.deltaTime,
					Space.Self);
			}
			else
			{
				_activePitch = Input.GetAxisRaw("Vertical") * (pitchPower/2) * Time.deltaTime;
				_activeRoll = Input.GetAxisRaw("Horizontal") * (rollPower/2) * Time.deltaTime;

				if (Input.GetMouseButton(0))
					_dirRotation = -1f;
				else if (Input.GetMouseButton(1))
					_dirRotation = 1f;
				else
					_dirRotation = 0f;
				
				_activeYaw = _dirRotation * (yawPower/2) * Time.deltaTime;

				_thisTransform.Rotate(_activePitch * pitchPower * Time.deltaTime,
					_activeYaw * yawPower * Time.deltaTime,
					-_activeRoll * rollPower * Time.deltaTime,
					Space.Self);
			}
		}
	}
}
