using Dots.Scripts.Mono___Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Dots.Scripts.Systems
{
	[BurstCompile]
	public partial struct DCC_GeneratorSystem : ISystem
	{
		private uint _updateCounter;
		private int _amountOfCubes;
		
		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<GeneratorComponent>();
			state.RequireForUpdate<DCC>();
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			if (!Input.GetKeyDown(KeyCode.Q))
				return;
			
			// Destroy the cubes

			var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
			var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
			
			foreach (var (cube, entity) in
			         SystemAPI.Query<RefRO<DCC_CubeComponent>>()
				         .WithEntityAccess())
			{
				ecb.DestroyEntity(entity);
			}
			
			// Create the cubes

			var generator = SystemAPI.GetSingleton<GeneratorComponent>();
			
			_amountOfCubes += generator.initialAmountOfCubes;
			
			var cubes = state.EntityManager.Instantiate(
				generator.cubePrefab, _amountOfCubes, Allocator.Temp);

			var random = Random.CreateFromIndex(_updateCounter++);
			
			foreach (var cube in cubes)
			{
				float3 cubePosition;
				do {
					cubePosition = random.NextFloat3(
						new float3(-0.1f, -0.1f, -0.1f), new float3(0.1f, 0.1f, 0.1f));
				}
				while (cubePosition.Equals(float3.zero));

				cubePosition = math.normalize(cubePosition);
				
				var transform = SystemAPI.GetComponentRW<LocalTransform>(cube);
				transform.ValueRW.Position = cubePosition;

				var cubeComponent = SystemAPI.GetComponentRW<DCC_CubeComponent>(cube);
				cubeComponent.ValueRW.direction = cubePosition;
			}
		}
	}
}
