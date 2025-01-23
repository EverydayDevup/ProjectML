using System.Diagnostics;

namespace EDD
{
    public static class Logger
    {
        [Conditional("EDD_DEBUG")]
        public static void Log(string message, string tag = "")
        {
            UnityEngine.Debug.Log(!string.IsNullOrEmpty(tag) ? $"[{tag}] {message}" : message);
        }
        
        [Conditional("EDD_DEBUG")]
        public static void LogWarning(string message, string tag = "")
        {
            UnityEngine.Debug.LogWarning(!string.IsNullOrEmpty(tag) ? $"[{tag}] {message}" : message);
        }
        
        [Conditional("EDD_DEBUG")]
        public static void LogError(string message, string tag = "")
        {
            UnityEngine.Debug.LogError(!string.IsNullOrEmpty(tag) ? $"[{tag}] {message}" : message);
        }
    }
}