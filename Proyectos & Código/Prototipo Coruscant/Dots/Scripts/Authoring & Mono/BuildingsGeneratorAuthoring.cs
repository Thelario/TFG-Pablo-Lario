using _Project.DOTS.Scripts.Components___Tags;
using Unity.Entities;
using UnityEngine;

namespace _Project.DOTS.Scripts.Authoring___Mono
{
	public class BuildingsGeneratorAuthoring : MonoBehaviour
	{
		public GameObject buildingPrefab;
		public int initialBuildingsAmount;
		public float positionOffset;
	}

	public class BuildingsGeneratorBaker : Baker<BuildingsGeneratorAuthoring>
	{
		public override void Bake(BuildingsGeneratorAuthoring authoring)
		{
			var entity = GetEntity(TransformUsageFlags.None);
			
			AddComponent(entity, new BuildingsGeneratorComponent
			{
				buildingEntity = GetEntity(authoring.buildingPrefab, TransformUsageFlags.Dynamic),
				initialBuildingsAmount = authoring.initialBuildingsAmount,
				positionOffset = authoring.positionOffset
			});
		}
	}
}
