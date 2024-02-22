using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Dots.Scripts.Mono___Components
{
    public class DCS_CubeAuthoring : MonoBehaviour
    {
        public float moveSpeed;
    }

    public class MCS_CubeBaker : Baker<DCS_CubeAuthoring>
    {
        public override void Bake(DCS_CubeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new DCS_CubeComponent
            {
                moveSpeed = authoring.moveSpeed
            });
        }
    }

    public struct DCS_CubeComponent : IComponentData
    {
        public float moveSpeed;
        public float3 direction;
    }
}