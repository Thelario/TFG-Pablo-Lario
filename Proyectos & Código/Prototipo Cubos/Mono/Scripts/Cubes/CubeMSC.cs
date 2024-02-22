﻿using UnityEngine;

namespace Mono.Scripts
{
    public class CubeMSC : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform thisTransform;

        private Vector3 _direction;
		
        private void Start()
        {
            _direction = thisTransform.position.normalized;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            thisTransform.position += moveSpeed * Time.deltaTime * _direction;

            Overhead();
        }

        private void Overhead()
        {
            int x = 0;
            for (int i = 0; i < 100000; i++)
                x++;
        }
    }
}