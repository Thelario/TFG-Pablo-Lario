using System.Collections.Generic;
using System.IO;
using _Project.COMMON.Scripts.Manager_Helpers;

namespace _Project.COMMON.Scripts
{
    public enum LogType
    {
        MonoBuildingsCreation, MonoBuildingsDestruction, MonoSpeedersCreation, MonoSpeedersDestruction,
        DotsBuildingsCreation, DotsBuildingsDestruction, DotsSpeedersCreation, DotsSpeedersDestruction
    }
    
    public class CsvLoggerManager : Singleton<CsvLoggerManager>
    {
        private string monoUrl =
            "C:\\Users\\49427234\\Desktop\\TFG\\Proyectos Unity\\DOTS Futuristic City\\Assets\\_Project\\MONO\\Scripts\\CSV\\";
        
        private string dotsUrl =
            "C:\\Users\\49427234\\Desktop\\TFG\\Proyectos Unity\\DOTS Futuristic City\\Assets\\_Project\\DOTS\\Scripts\\CSV\\";
        
        private string monoBuildingsCreationCsvFilePath = "monoBuildingsCreationLog.csv";
        private string monoBuildingsDestructionCsvFilePath = "monoBuildingsDestructionLog.csv";
        private string monoSpeedersCreationCsvFilePath = "monoSpeedersCreationLog.csv";
        private string monoSpeedersDestructionCsvFilePath = "monoSpeedersDestructionLog.csv";
        
        private string dotsBuildingsCreationCsvFilePath = "dotsBuildingsCreationLog.csv";
        private string dotsBuildingsDestructionCsvFilePath = "dotsBuildingsDestructionLog.csv";
        private string dotsSpeedersCreationCsvFilePath = "dotsSpeedersCreationLog.csv";
        private string dotsSpeedersDestructionCsvFilePath = "dotsSpeedersDestructionLog.csv";

        private List<string> monoBuildingsCreationLogData = new List<string>();
        private List<string> monoBuildingsDestructionLogData = new List<string>();
        private List<string> monoSpeedersCreationLogData = new List<string>();
        private List<string> monoSpeedersDestructionLogData = new List<string>();
        
        private List<string> dotsBuildingsCreationLogData = new List<string>();
        private List<string> dotsBuildingsDestructionLogData = new List<string>();
        private List<string> dotsSpeedersCreationLogData = new List<string>();
        private List<string> dotsSpeedersDestructionLogData = new List<string>();

        public void LogData(string logEntry, LogType logType)
        {
            print("Logging: " + logEntry + ", type: " + logType);
            
            switch (logType)
            {
                case LogType.MonoBuildingsCreation:
                    monoBuildingsCreationLogData.Add(logEntry);
                    break;
                case LogType.MonoBuildingsDestruction:
                    monoBuildingsDestructionLogData.Add(logEntry);
                    break;
                case LogType.MonoSpeedersCreation:
                    monoSpeedersCreationLogData.Add(logEntry);
                    break;
                case LogType.MonoSpeedersDestruction:
                    monoSpeedersDestructionLogData.Add(logEntry);
                    break;
                case LogType.DotsBuildingsCreation:
                    dotsBuildingsCreationLogData.Add(logEntry);
                    break;
                case LogType.DotsBuildingsDestruction:
                    dotsBuildingsDestructionLogData.Add(logEntry);
                    break;
                case LogType.DotsSpeedersCreation:
                    dotsSpeedersCreationLogData.Add(logEntry);
                    break;
                case LogType.DotsSpeedersDestruction:
                    dotsSpeedersDestructionLogData.Add(logEntry);
                    break;
            }
        }
        
        private void OnApplicationQuit()
        {
            SaveData();
        }

        private void SaveData()
        {
            print("Saving data");
            
            // Saving MONO data
            
            if (monoBuildingsCreationLogData.Count > 0)
                File.WriteAllLines(monoUrl + monoBuildingsCreationCsvFilePath, monoBuildingsCreationLogData);
            
            if (monoBuildingsDestructionLogData.Count > 0)
                File.WriteAllLines(monoUrl + monoBuildingsDestructionCsvFilePath, monoBuildingsDestructionLogData);
            
            if (monoSpeedersCreationLogData.Count > 0)
                File.WriteAllLines(monoUrl + monoSpeedersCreationCsvFilePath, monoSpeedersCreationLogData);
            
            if (monoSpeedersDestructionLogData.Count > 0)
                File.WriteAllLines(monoUrl + monoSpeedersDestructionCsvFilePath, monoSpeedersDestructionLogData);
            
            // Saving DOTS data
            
            if (dotsBuildingsCreationLogData.Count > 0)
                File.WriteAllLines(dotsUrl + dotsBuildingsCreationCsvFilePath, dotsBuildingsCreationLogData);
            
            if (dotsBuildingsDestructionLogData.Count > 0)
                File.WriteAllLines(dotsUrl + dotsBuildingsDestructionCsvFilePath, dotsBuildingsDestructionLogData);
            
            if (dotsSpeedersCreationLogData.Count > 0)
                File.WriteAllLines(dotsUrl + dotsSpeedersCreationCsvFilePath, dotsSpeedersCreationLogData);
            
            if (dotsSpeedersDestructionLogData.Count > 0)
                File.WriteAllLines(dotsUrl + dotsSpeedersDestructionCsvFilePath, dotsSpeedersDestructionLogData);
        }
    }
}