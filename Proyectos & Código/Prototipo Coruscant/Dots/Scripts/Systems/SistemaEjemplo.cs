/*using _Project.DOTS.Scripts.Components___Tags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace _Project.DOTS.Scripts.Systems
{
    [BurstCompile]
    public partial struct SistemaEjemplo : ISystem
    {
        private int _buildingsAmount;

        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BuildingsGeneratorComponent>();
        }
        
        [BurstCompile]
        public void OnDestroy(ref SystemState state) { }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if (!Input.GetKeyDown(KeyCode.Q))
                return;
            
            BuildingsGeneratorComponent spawnerComponent = SystemAPI.GetSingleton<BuildingsGeneratorComponent>();

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
}
*/