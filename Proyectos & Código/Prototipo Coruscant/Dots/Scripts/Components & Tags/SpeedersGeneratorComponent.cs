using Unity.Entities;

namespace _Project.DOTS.Scripts.Components___Tags
{
    public struct SpeedersGeneratorComponent : IComponentData
    {
        public int initialSpeedersAmount;
        public float xOffset;
        public float yOffset;
        public float speedersMinSpeed;
        public float speedersMaxSpeed;
        public Entity speederEntity;
    }
}