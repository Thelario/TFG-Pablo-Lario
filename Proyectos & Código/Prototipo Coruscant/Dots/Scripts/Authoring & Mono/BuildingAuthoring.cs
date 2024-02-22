using _Project.DOTS.Scripts.Components___Tags;
using Unity.Entities;
using UnityEngine;

namespace _Project.DOTS.Scripts.Authoring___Mono
{
    public class BuildingAuthoring : MonoBehaviour { }

    public class BuildingBaker : Baker<BuildingAuthoring>
    {
        public override void Bake(BuildingAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
			
            AddComponent(entity, new BuildingComponent());
        }
    }
}