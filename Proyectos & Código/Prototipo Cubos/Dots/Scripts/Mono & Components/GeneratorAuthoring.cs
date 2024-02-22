using Unity.Entities;
using UnityEngine;

namespace Dots.Scripts.Mono___Components
{
	public class GeneratorAuthoring : MonoBehaviour
	{
		public int initialAmountOfCubes;
		public CubeType type;
		public GameObject[] cubePrefabs;
	}
	
	public class GeneratorBaker : Baker<GeneratorAuthoring>
	{
		public override void Bake(GeneratorAuthoring authoring)
		{
			var entity = GetEntity(TransformUsageFlags.None);
			
			AddComponent(entity, new GeneratorComponent
			{
				initialAmountOfCubes = authoring.initialAmountOfCubes,
				cubePrefab = GetEntity(authoring.cubePrefabs[(int)authoring.type], TransformUsageFlags.Dynamic)
			});
		}
	}
	
	public struct GeneratorComponent : IComponentData
	{
		public int initialAmountOfCubes;
		public Entity cubePrefab;
	}
}
