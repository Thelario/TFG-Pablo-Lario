/*using _Project.DOTS.Scripts.Components___Tags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace _Project.DOTS.Scripts.Systems
{
    [BurstCompile]
    public partial struct SpeedersGeneratorSystemWithoutLog : ISystem
    {
        private int _speedersAmount;
        private bool _initialSet;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<SpeedersGeneratorComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!Input.GetKeyDown(KeyCode.Q))
                return;
            
            // Destroying speeders
            
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            
            var query = SystemAPI.QueryBuilder().WithAll<SpeederComponent>().Build();

            foreach (var speederEntity in query.ToEntityArray(Allocator.Temp))
            {
                ecb.DestroyEntity(speederEntity);
            }
            
            // Creating buildings
            
            SpeedersGeneratorComponent spawnerComponent = SystemAPI.GetSingleton<SpeedersGeneratorComponent>();

            if (!_initialSet)
            {
                _speedersAmount = spawnerComponent.initialSpeedersAmount;
                _initialSet = true;
            }
            
            float xPositionOffset = spawnerComponent.xOffset;
            float yPositionOffset = spawnerComponent.yOffset;
            
            float z = _speedersAmount / 2f;

            for (float x = -z; x < z; x++)
            {
                for (float y = -z; y < z; y++)
                {
                    Entity building = state.EntityManager.Instantiate(spawnerComponent.speederEntity);
                
                    state.EntityManager.SetComponentData(building, new LocalTransform
                    {
                        Position = new float3(x * xPositionOffset + 1, y * yPositionOffset, -z * xPositionOffset),
                        Scale = 1f,
                        Rotation = quaternion.identity
                    });
                }
            }
            
            _speedersAmount += 5;
        }
    }
}*/