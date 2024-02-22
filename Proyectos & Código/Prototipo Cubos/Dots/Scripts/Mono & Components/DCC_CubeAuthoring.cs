using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Dots.Scripts.Mono___Components
{
    public class DCC_CubeAuthoring : MonoBehaviour
    {
        public float moveSpeed;
    }

    public class MCC_CubeBaker : Baker<DCC_CubeAuthoring>
    {
        public override void Bake(DCC_CubeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new DCC_CubeComponent
            {
                moveSpeed = authoring.moveSpeed
            });
        }
    }

    public struct DCC_CubeComponent : IComponentData
    {
        public float moveSpeed;
        public float3 direction;
    }
}