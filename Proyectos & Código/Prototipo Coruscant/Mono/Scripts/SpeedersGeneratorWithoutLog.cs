using _Project.COMMON.Scripts.Manager_Helpers;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Project.MONO.Scripts
{
	public class SpeedersGeneratorWithoutLog : Singleton<SpeedersGeneratorWithoutLog>
	{
		[FormerlySerializedAs("amountOfSpeeders")]
		[Header("Amount of speeders")]
		[SerializeField] private int initialSpeedersAmount;
		[SerializeField] private float xOffset;
		[SerializeField] private float yOffset;
		[SerializeField] private float speedersMinSpeed;
		[SerializeField] private float speedersMaxSpeed;

		[Header("References")]
		[SerializeField] private GameObject[] speederPrefabs;

		private int _speedersAmount;

		private Transform _speedersParent;

		public int SpeedersAmount => _speedersAmount * _speedersAmount;

		protected override void Awake()
		{
			base.Awake();
			
			_speedersParent = transform;
			_speedersAmount = initialSpeedersAmount;
		}	
		
		private void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Q))
				return;

			GenerateSpeeders();
		}

		private void GenerateSpeeders()
		{
			DestroySpeeders();

			float z = _speedersAmount / 2f;
			
			for (float x = -z; x < z; x++)
			{
				for (float y = 0; y < _speedersAmount; y++)
				{
					GameObject speeder = Instantiate(speederPrefabs[Random.Range(0, speederPrefabs.Length)], 
						new Vector3(x * xOffset + 1, y * yOffset, -z * xOffset), 
						Quaternion.identity, 
						_speedersParent);
					
					speeder.GetComponent<SpeedersMovement>().ConfigureSpeeder(
						speedersMinSpeed, speedersMaxSpeed);
				}
			}
			
			_speedersAmount += 5;
		}

		private void DestroySpeeders()
		{
			foreach (Transform speeder in _speedersParent)
				Destroy(speeder.gameObject);
		}
	}
}
