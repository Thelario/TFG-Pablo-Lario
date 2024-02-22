using Dots.Scripts.Mono___Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Dots.Scripts.Systems
{
    [BurstCompile]
    public partial struct DSS_MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DSS>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, cube) in
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<DSS_CubeComponent>>())
            {
                transform.ValueRW.Position +=
                    cube.ValueRO.direction * SystemAPI.Time.DeltaTime * cube.ValueRO.moveSpeed;
            }
        }
    }
}