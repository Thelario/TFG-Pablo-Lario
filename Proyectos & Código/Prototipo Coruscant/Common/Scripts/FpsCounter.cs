using System.Collections.Generic;
using System.IO;
using _Project.COMMON.Scripts.Manager_Helpers;
using TMPro;
using UnityEngine;

namespace _Project.COMMON.Scripts
{
    public class FpsCounter : Singleton<FpsCounter>
    {
        [SerializeField] private TMP_Text fpsText;
        [SerializeField] private bool consoleLog;
        [SerializeField] private bool mono;
 
        private int _avgFrameRate;
        private int _lastFrameIndex;
        private int _objectsSpawned;
        private float[] _frameDeltaTimeArray;

        private string monoUrl =
            "C:\\Users\\49427234\\Desktop\\TFG\\Proyectos Unity\\DOTS Futuristic City\\Assets\\_Project\\MONO\\Scripts\\CSV\\";
        
        private string dotsUrl =
            "C:\\Users\\49427234\\Desktop\\TFG\\Proyectos Unity\\DOTS Futuristic City\\Assets\\_Project\\DOTS\\Scripts\\CSV\\";
        
        private List<int> meanFps = new List<int>();
        private List<string> fpsLogData = new List<string>();
        
        protected override void Awake()
        {
            base.Awake();
            
            _frameDeltaTimeArray = new float[50];
            _lastFrameIndex = 0;
            _objectsSpawned = 10;
        }

        private void Start()
        {
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

            mean = mean / meanFps.Count;
            
            fpsLogData.Add($"{_objectsSpawned * _objectsSpawned};{mean}");
            
            meanFps.Clear();

            _objectsSpawned += 5;
        }
        
        private void OnApplicationQuit()
        {
            if (mono)
            {
                if (fpsLogData.Count > 0)
                    File.WriteAllLines(monoUrl + "monoFps.csv", fpsLogData);
            }
            else
            {
                if (fpsLogData.Count > 0)
                    File.WriteAllLines(dotsUrl + "dotsFps.csv", fpsLogData);
            }
        }
    }
}
