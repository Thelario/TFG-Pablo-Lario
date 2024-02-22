using Dots.Scripts.Mono___Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Dots.Scripts.Systems
{
    [BurstCompile]
    public partial struct DCC_MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DCC>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var job = new MovementJobWithOverhead
            {
                deltaTime = SystemAPI.Time.DeltaTime
            };
            job.Schedule();
        }
    }
    
    [BurstCompile]
    public partial struct MovementJobWithOverhead : IJobEntity
    {
        public float deltaTime;

        private void Execute(ref LocalTransform transform, in DCC_CubeComponent cube)
        {
            transform.Position += cube.direction * deltaTime * cube.moveSpeed;
                
            // Overhead
                
            int x = 0;
            for (int i = 0; i < 100000; i++)
                x++;
        }
    }
}