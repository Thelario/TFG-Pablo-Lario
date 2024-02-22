using Dots.Scripts.Mono___Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Dots.Scripts.Systems
{
    [BurstCompile]
    public partial struct DSC_MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DSC>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (transform, cube) in
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<DSC_CubeComponent>>())
            {
                transform.ValueRW.Position +=
                    cube.ValueRO.direction * SystemAPI.Time.DeltaTime * cube.ValueRO.moveSpeed;
                
                // Overhead
                
                int x = 0;
                for (int i = 0; i < 100000; i++)
                    x++;
            }
        }
    }
}