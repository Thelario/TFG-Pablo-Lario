using _Project.DOTS.Scripts.Components___Tags;
using Unity.Entities;
using UnityEngine;

namespace _Project.DOTS.Scripts.Authoring___Mono
{
    public class ConfigAuthoring : MonoBehaviour
    {
        public float speedersMinSpeed;
        public float speedersMaxSpeed;
    }
    
    public class ConfigBaker : Baker<ConfigAuthoring>
    {
        public override void Bake(ConfigAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
			
            AddComponent(entity, new ConfigComponent
            {
                speedersMaxSpeed = authoring.speedersMaxSpeed,
                speedersMinSpeed = authoring.speedersMinSpeed
            });
        }
    }
}