using Unity.Burst;
using Unity.Jobs;
using UnityEngine;
using Unity.Collections;

namespace Mono.Scripts
{
    [BurstCompile]
    public struct CubeJob : IJob
    {
        private float _deltaTime;
        private float _moveSpeed;
        private Vector3 _direction;
        private Vector3 _position;

        private NativeArray<Vector3> _positionResult;

        public CubeJob(NativeArray<Vector3> positionResult,
            Vector3 direction, Vector3 position, float deltaTime, float moveSpeed)
        {
            _positionResult = positionResult;
            _direction = direction;
            _position = position;
            _deltaTime = deltaTime;
            _moveSpeed = moveSpeed;
        }
		
        public void Execute()
        {
            Move();
        }

        private void Move()
        {
            _position += _moveSpeed * _deltaTime * _direction;

            _positionResult[0] = _position;
        }
    }
}