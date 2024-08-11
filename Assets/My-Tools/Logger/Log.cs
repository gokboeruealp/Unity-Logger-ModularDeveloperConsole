using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gokboerue.Tools
{
    public class Log
    {
        private static string _logFilePath = $"{Application.persistentDataPath}/roller_rogue_log.txt";
        private static string _logString;

        // Log message with white color
        internal static void L(object message)
        {
            _logString += $"{DateTime.Now} - <color=white>{message}</color>\n";
            Debug.Log(_logString);
            System.IO.File.AppendAllText(_logFilePath, _logString);

            _logString = "";
            
            DeveloperConsole.I.ClearCurrentConsole();
            DeveloperConsole.I.SetConsoleTexts();
        }

        // Log message with yellow color
        internal static void W(object message)
        {
            _logString += $"{DateTime.Now} - <color=yellow>{message}</color>\n";
            Debug.LogWarning(_logString);
            System.IO.File.AppendAllText(_logFilePath, _logString);

            _logString = "";
            
            DeveloperConsole.I.ClearCurrentConsole();
            DeveloperConsole.I.SetConsoleTexts();
        }

        // Log message with red color
        internal static void E(object message)
        {
            _logString += $"{DateTime.Now} - <color=red>{message}</color>\n";
            Debug.LogError(_logString);
            System.IO.File.AppendAllText(_logFilePath, _logString);

            _logString = "";
            
            DeveloperConsole.I.ClearCurrentConsole();
            DeveloperConsole.I.SetConsoleTexts();
        }

        // Log message with specified color
        internal static void C(object message, Color color)
        {
            _logString += $"{DateTime.Now} - <color=#{ColorUtility.ToHtmlStringRGB(color)}>{message}</color>\n";
            Debug.Log(_logString);
            System.IO.File.AppendAllText(_logFilePath, _logString);

            _logString = "";
            
            DeveloperConsole.I.ClearCurrentConsole();
            DeveloperConsole.I.SetConsoleTexts();
        }

        // Clear log file
        internal static void ClearLog()
        {
            _logString = "";
            System.IO.File.WriteAllText(_logFilePath, _logString);
        }

        // Read log file
        internal static List<string> ReadLog()
        {
            if (System.IO.File.Exists(_logFilePath))
            {
                return new List<string>(System.IO.File.ReadAllLines(_logFilePath));
            }
            else
            {
                throw new DeveloperFriendlyException("Log file not found.", LogType.ERROR);
            }
        }
    }
}
