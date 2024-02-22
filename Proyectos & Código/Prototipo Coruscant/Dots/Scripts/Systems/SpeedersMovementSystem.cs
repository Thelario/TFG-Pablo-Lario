using _Project.DOTS.Scripts.Components___Tags;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace _Project.DOTS.Scripts.Systems
{
	[BurstCompile]
	public partial struct SpeedersMovementSystem : ISystem
	{
		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<ConfigComponent>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			ConfigComponent configComponent = SystemAPI.GetSingleton<ConfigComponent>();
            
			var rand = new Random(123);

			foreach (var playerTransform in
			         SystemAPI.Query<RefRW<LocalTransform>>()
				         .WithAll<SpeederComponent>())
			{
				var speed = rand.NextFloat(configComponent.speedersMinSpeed, configComponent.speedersMaxSpeed);
			
				var input = new float3(0f, 0f, 1f) * SystemAPI.Time.DeltaTime * speed;
				
				var newPos = playerTransform.ValueRO.Position + input;

				playerTransform.ValueRW.Position = newPos;
			}
		}
	}
}
