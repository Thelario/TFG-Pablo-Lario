using System;
using _Project.COMMON.Scripts;
using _Project.COMMON.Scripts.Manager_Helpers;
using UnityEngine;
using UnityEngine.Serialization;
using LogType = _Project.COMMON.Scripts.LogType;
using Random = UnityEngine.Random;

namespace _Project.MONO.Scripts
{
	public class SpeedersGenerator : Singleton<SpeedersGenerator>
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
			if (!Input.GetKeyDown(KeyCode.Q))
				return;
			
			DestroySpeeders();

			DateTime before = DateTime.Now;
			
			float z = _speedersAmount / 2f;
			
			int speedersSpawned = SpeedersAmount;
			
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
			
			DateTime after = DateTime.Now;
			TimeSpan duration = after.Subtract(before);
			CsvLoggerManager.Instance.LogData($"{duration.TotalMilliseconds};{speedersSpawned}", LogType.MonoSpeedersCreation);
			Debug.Log($"It took {duration.TotalMilliseconds} ms to create {speedersSpawned} speeders.");
		}

		private void DestroySpeeders()
		{
			DateTime before = DateTime.Now;

			int childCount = _speedersParent.childCount;

			foreach (Transform speeder in _speedersParent)
				Destroy(speeder.gameObject);
			
			DateTime after = DateTime.Now;
			TimeSpan duration = after.Subtract(before);
			CsvLoggerManager.Instance.LogData($"{duration.TotalMilliseconds};{childCount}", LogType.MonoSpeedersDestruction);
			Debug.Log($"It took {duration.TotalMilliseconds} ms to destroy {childCount} speeders.");
		}
	}
}
