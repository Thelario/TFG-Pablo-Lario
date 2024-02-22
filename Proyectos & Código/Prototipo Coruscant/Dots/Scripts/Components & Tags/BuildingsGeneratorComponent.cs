using Unity.Entities;

namespace _Project.DOTS.Scripts.Components___Tags
{
    public struct BuildingsGeneratorComponent : IComponentData
    {
        public Entity buildingEntity;
        public int initialBuildingsAmount;
        public float positionOffset;
    }
}