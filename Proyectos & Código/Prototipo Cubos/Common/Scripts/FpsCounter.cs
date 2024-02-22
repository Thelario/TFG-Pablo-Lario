using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace Common.Scripts
{
    public class FpsCounter : MonoBehaviour
    {
        [SerializeField] private int initialAmountOfCubes;
        [SerializeField] private TMP_Text fpsText;
        [SerializeField] private TMP_Text cubesText;
        [SerializeField] private bool consoleLog;
        [SerializeField] private bool mono;
 
        private int _avgFrameRate;
        private int _lastFrameIndex;
        private int _objectsSpawned;
        private float[] _frameDeltaTimeArray;

        private string url =
            "C:\\Users\\49427234\\Desktop\\TFG\\Proyectos Unity\\DOTS Prototype One\\Assets\\Common\\Scripts\\CSV\\";

        private List<int> meanFps = new();
        private List<string> fpsLogData = new();
        
        private void Awake()
        {
            _frameDeltaTimeArray = new float[50];
            _lastFrameIndex = 0;
            _objectsSpawned = 0;
        }

        private void Start()
        {
            cubesText.text = "Cubes: " + _objectsSpawned;
            
            InvokeRepeating(nameof(DisplayFps), 0.25f, 0.25f);
        }

        private void Update()
        {
            CalculateFps();

            if (Input.GetKeyDown(KeyCode.Q))
                SaveFpsData();
        }
        
        private void DisplayFps()
        {
            float total = 0f;
            foreach (float deltaTime in _frameDeltaTimeArray)
                total += deltaTime;

            total = _frameDeltaTimeArray.Length / total;

            int mean = Mathf.RoundToInt(total);
            
            fpsText.text = "Fps: " + mean;
            
            meanFps.Add(mean);
            
            if (consoleLog)
                print("Fps: " + mean);
        }

        private void CalculateFps()
        {
            _frameDeltaTimeArray[_lastFrameIndex] = Time.unscaledDeltaTime;
            _lastFrameIndex = (_lastFrameIndex + 1) % _frameDeltaTimeArray.Length;
        }

        private void SaveFpsData()
        {
            int mean = 0;
            foreach (int fps in meanFps)
                mean += fps;

            mean /= meanFps.Count;
            
            fpsLogData.Add($"{_objectsSpawned};{mean}");
            
            meanFps.Clear();

            _objectsSpawned += initialAmountOfCubes;
            
            cubesText.text = "Cubes: " + _objectsSpawned;
        }
        
        private void OnApplicationQuit()
        {
            if (mono)
            {
                if (fpsLogData.Count > 0)
                    File.WriteAllLines(url + "monoFps.csv", fpsLogData);
            }
            else
            {
                if (fpsLogData.Count > 0)
                    File.WriteAllLines(url + "dotsFps.csv", fpsLogData);
            }
        }
    }
}
