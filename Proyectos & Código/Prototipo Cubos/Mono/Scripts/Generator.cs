using UnityEngine;
using Random = UnityEngine.Random;

public enum CubeType { MSS, MCS, MSC, MCC }

namespace Mono.Scripts
{
    public class Generator : MonoBehaviour
    {
        [SerializeField] private int initialAmountOfCubes;
        [SerializeField] private CubeType type;
        [SerializeField] private Transform cubesParent;
        [SerializeField] private GameObject[] cubePrefabs;

        private int _amountOfCubes;
        private GameObject _cubePrefab;
        
        private void Awake()
        {
            _cubePrefab = cubePrefabs[(int)type];
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Q))
                return;
            
            DestroyCubes();

            CreateCubes();
        }

        private void DestroyCubes()
        {
            foreach (Transform cube in cubesParent)
            {
                Destroy(cube.gameObject);
            }
        }

        private void CreateCubes()
        {
            _amountOfCubes += initialAmountOfCubes;
            
            for (int i = 0; i < _amountOfCubes; i++)
            {
                Vector3 cubePosition;
                do {
                    cubePosition = new Vector3(
                        Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
                }
                while (cubePosition == Vector3.zero);

                Instantiate(_cubePrefab, cubePosition, Quaternion.identity, cubesParent);
            }
        }
    }
}