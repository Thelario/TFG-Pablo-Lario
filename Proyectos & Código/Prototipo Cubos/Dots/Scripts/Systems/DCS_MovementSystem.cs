using Dots.Scripts.Mono___Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Dots.Scripts.Systems
{
    [BurstCompile]
    public partial struct DCS_MovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DCS>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var job = new MovementJob
            {
                deltaTime = SystemAPI.Time.DeltaTime
            };
            job.Schedule();
        }
    }
    
    [BurstCompile]
    public partial struct MovementJob : IJobEntity
    {
        public float deltaTime;

        private void Execute(ref LocalTransform transform, in DCS_CubeComponent cube)
        {
            transform.Position += cube.direction * deltaTime * cube.moveSpeed;
        }
    }
}