using System;
using _Project.COMMON.Scripts;
using _Project.COMMON.Scripts.Manager_Helpers;
using UnityEngine;
using LogType = _Project.COMMON.Scripts.LogType;

namespace _Project.MONO.Scripts
{

public class BuildingsGenerator : Singleton<BuildingsGenerator>
	{
		[Header("Amount of buildings")]
		[SerializeField] private int initialBuildingsAmount;
		[SerializeField] private float positionOffset;

		[Header("References")]
		[SerializeField] private GameObject buildingPrefab;
		
		private Transform _buildingsParent;

		private int _buildingsAmount;
		
		public int BuildingsAmount => _buildingsAmount * _buildingsAmount;
		public float PositionOffset => positionOffset;

		protected override void Awake()
		{
			base.Awake();
			
			_buildingsParent = transform;
			_buildingsAmount = initialBuildingsAmount;
		}

		private void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Q))
				return;

			GenerateBuildings();
		}

		private void GenerateBuildings()
		{
			DestroyBuildings();

			DateTime before = DateTime.Now;
			
			int buildingsSpawned = BuildingsAmount;
			
			float x = _buildingsAmount / 2f;
			
			for (float i = -x; i < x; i++)
			{
				for (float j = -x; j < x; j++)
				{
					Instantiate(buildingPrefab, 
						new Vector3(i, 0f, j) * positionOffset, 
						Quaternion.identity, 
						_buildingsParent);
				}
			}
			
			_buildingsAmount += 5;
			
			DateTime after = DateTime.Now;
			TimeSpan duration = after.Subtract(before);
			CsvLoggerManager.Instance.LogData($"{duration.TotalMilliseconds};{buildingsSpawned}", LogType.MonoBuildingsCreation);
			Debug.Log($"It took {duration.TotalMilliseconds} ms to create {buildingsSpawned} buildings.");
		}

		private void DestroyBuildings()
		{
			DateTime before = DateTime.Now;
			
			int childCount = _buildingsParent.childCount;
			
			foreach (Transform building in _buildingsParent)
				Destroy(building.gameObject);
			
			DateTime after = DateTime.Now;
			TimeSpan duration = after.Subtract(before);
			CsvLoggerManager.Instance.LogData($"{duration.TotalMilliseconds};{childCount}", LogType.MonoBuildingsDestruction);
			Debug.Log($"It took {duration.TotalMilliseconds} ms to destroy {childCount} buildings.");
		}
	}
}
