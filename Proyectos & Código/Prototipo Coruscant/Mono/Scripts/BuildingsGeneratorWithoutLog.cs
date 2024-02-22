using _Project.COMMON.Scripts.Manager_Helpers;
using UnityEngine;

namespace _Project.MONO.Scripts
{
	public class BuildingsGeneratorWithoutLog : Singleton<BuildingsGeneratorWithoutLog>
	{
		[Header("Amount of buildings")]
		[SerializeField] private int initialBuildingsAmount;
		[SerializeField] private float positionOffset;

		[Header("References")]
		[SerializeField] private GameObject buildingPrefab;
		
		private Transform _buildingsParent;

		private int _buildingsAmount;

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
		}

		private void DestroyBuildings()
		{
			foreach (Transform building in _buildingsParent)
				Destroy(building.gameObject);
		}
	}
}
