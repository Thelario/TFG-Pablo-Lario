using _Project.DOTS.Scripts.Components___Tags;
using Unity.Entities;
using UnityEngine;

namespace _Project.DOTS.Scripts.Authoring___Mono
{
	public class SpeedersGeneratorAuthoring : MonoBehaviour
	{
		public int initialSpeedersAmount;
		public float xOffset;
		public float yOffset;
		public float speedersMinSpeed;
		public float speedersMaxSpeed;
		public GameObject speederPrefab;
	}

	public class SpeedersGeneratorBaker : Baker<SpeedersGeneratorAuthoring>
	{
		public override void Bake(SpeedersGeneratorAuthoring authoring)
		{
			var entity = GetEntity(TransformUsageFlags.None);
			
			AddComponent(entity, new SpeedersGeneratorComponent
			{
				speederEntity = GetEntity(authoring.speederPrefab, TransformUsageFlags.Dynamic),
				initialSpeedersAmount = authoring.initialSpeedersAmount,
				xOffset = authoring.xOffset,
				yOffset = authoring.yOffset,
				speedersMinSpeed = authoring.speedersMinSpeed,
				speedersMaxSpeed = authoring.speedersMaxSpeed
			});
		}
	}
}
