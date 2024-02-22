using _Project.DOTS.Scripts.Components___Tags;
using Unity.Entities;
using UnityEngine;

namespace _Project.DOTS.Scripts.Authoring___Mono
{
	public class SpeederAuthoring : MonoBehaviour { }

	public class SpeederBaker : Baker<SpeederAuthoring>
	{
		public override void Bake(SpeederAuthoring authoring)
		{
			var entity = GetEntity(TransformUsageFlags.None);
			
			AddComponent(entity, new SpeederComponent());
		}
	}
}
