using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Mono.Scripts
{
    public class CubeMCC : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform thisTransform;

        private Vector3 _direction;
        private NativeArray<Vector3> _positionResult;
        private JobHandle _handle;

        private void Awake()
        {
            _positionResult = new NativeArray<Vector3>(1, Allocator.Persistent);
        }

        private void Start()
        {
            _direction = thisTransform.position.normalized;
        }

        private void Update()
        {
            CubeJobOverhead cubeJob = new CubeJobOverhead(
                _positionResult, _direction, thisTransform.position, Time.deltaTime, moveSpeed);

            _handle = cubeJob.Schedule();
        }

        private void LateUpdate()
        {
            _handle.Complete();

            thisTransform.position = _positionResult[0];
        }
        
        private void OnDestroy()
        {
            _positionResult.Dispose();
        }
    }
}