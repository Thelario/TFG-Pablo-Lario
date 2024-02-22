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
    public partial struct BuildingsGeneratorSystemWithoutLog : ISystem
    {
        private int _buildingsAmount;
        private bool _initialSet;
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
            state.RequireForUpdate<BuildingsGeneratorComponent>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!Input.GetKeyDown(KeyCode.Q))
                return;
            
            // Destroying buildings
            
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            
            var query = SystemAPI.QueryBuilder().WithAll<BuildingComponent>().Build();

            foreach (var buildingEntity in query.ToEntityArray(Allocator.Temp))
            {
                ecb.DestroyEntity(buildingEntity);
            }
            
            // Creating buildings

            BuildingsGeneratorComponent spawnerComponent = SystemAPI.GetSingleton<BuildingsGeneratorComponent>();

            if (!_initialSet)
            {
                _buildingsAmount = spawnerComponent.initialBuildingsAmount;
                _initialSet = true;
            }
            
            float positionOffset = spawnerComponent.positionOffset;
            
            float x = _buildingsAmount / 2f;

            for (float i = -x; i < x; i++)
            {
                for (float j = -x; j < x; j++)
                {
                    Entity building = state.EntityManager.Instantiate(spawnerComponent.buildingEntity);
                
                    state.EntityManager.SetComponentData(building, new LocalTransform
                    {
                        Position = new float3(i, 0f, j) * positionOffset,
                        Scale = 1f,
                        Rotation = quaternion.identity
                    });
                }
            }
            
            _buildingsAmount += 5;
        }
    }
}*/