using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Dots.Scripts.Mono___Components
{
    public class DSC_CubeAuthoring : MonoBehaviour
    {
        public float moveSpeed;
    }

    public class MSC_CubeBaker : Baker<DSC_CubeAuthoring>
    {
        public override void Bake(DSC_CubeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new DSC_CubeComponent
            {
                moveSpeed = authoring.moveSpeed
            });
        }
    }

    public struct DSC_CubeComponent : IComponentData
    {
        public float moveSpeed;
        public float3 direction;
    }
}