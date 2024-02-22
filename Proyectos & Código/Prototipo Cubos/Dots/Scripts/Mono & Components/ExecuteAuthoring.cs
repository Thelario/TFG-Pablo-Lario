using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dots.Scripts.Mono___Components
{
    public class ExecuteAuthoring : MonoBehaviour
    {
        public bool DSS;
        public bool DSC;
        public bool DCS;
        public bool DCC;
    }

    public class ExecuteBaker : Baker<ExecuteAuthoring>
    {
        public override void Bake(ExecuteAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);

            if (authoring.DSS) AddComponent<DSS>(entity);
            if (authoring.DSC) AddComponent<DSC>(entity);
            if (authoring.DCS) AddComponent<DCS>(entity);
            if (authoring.DCC) AddComponent<DCC>(entity);
        }
    }
    
    public struct DSS : IComponentData
    {
    }

    public struct DSC : IComponentData
    {
    }

    public struct DCS : IComponentData
    {
    }

    public struct DCC : IComponentData
    {
    }
}