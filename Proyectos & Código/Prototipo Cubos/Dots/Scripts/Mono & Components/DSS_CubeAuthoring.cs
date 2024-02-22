using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Dots.Scripts.Mono___Components
{
    public class DSS_CubeAuthoring : MonoBehaviour
    {
        public float moveSpeed;
    }

    public class MSS_CubeBaker : Baker<DSS_CubeAuthoring>
    {
        public override void Bake(DSS_CubeAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new DSS_CubeComponent
            {
                moveSpeed = authoring.moveSpeed
            });
        }
    }

    public struct DSS_CubeComponent : IComponentData
    {
        public float moveSpeed;
        public float3 direction;
    }
}