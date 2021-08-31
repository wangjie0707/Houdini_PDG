using System;
using System.Diagnostics;
using System.Text;

namespace DBD
{
    /// <summary>
    /// 日志工具集。
    /// </summary>
    public static class Log
    {
        #region ENABLE_LOG

        [Conditional("ENABLE_LOG")]
        public static void Debug(string message)
        {
            Console(LogCategory.SysLog, LogLevel.Debug, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void Info(string message)
        {
            Console(LogCategory.SysLog, LogLevel.Info, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void Warning(string message)
        {
            Console(LogCategory.SysLog, LogLevel.Warning, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void Error(string message)
        {
            Console(LogCategory.SysLog, LogLevel.Error, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void Error(object message)
        {
            Console(LogCategory.SysLog, LogLevel.Error, message.ToString(), null);
        }

        [Conditional("ENABLE_LOG")]
        public static void Fatal(string message)
        {
            Console(LogCategory.SysLog, LogLevel.Fatal, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogInfo(string message)
        {
            Console(LogCategory.SysLog, LogLevel.Log, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogWarning(string message)
        {
            Console(LogCategory.SysLog, LogLevel.LogWarning, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogError(string message)
        {
            Console(LogCategory.SysLog, LogLevel.LogError, message, null);
        }

        [Conditional("ENABLE_LOG")]
        public static void Debug(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Debug, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Info(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Info, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Warning(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Warning, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Error(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Error, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Error(object message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Error, message.ToString(), args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Fatal(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Fatal, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogInfo(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.Log, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogWarning(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.LogWarning, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogError(string message, params object[] args)
        {
            Console(LogCategory.SysLog, LogLevel.LogError, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Debug(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.Debug, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Info(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.Info, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Warning(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.Warning, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Error(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.Error, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void Fatal(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.Fatal, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogInfo(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.Log, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogWarning(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.LogWarning, message, args);
        }

        [Conditional("ENABLE_LOG")]
        public static void LogError(LogCategory catetory, string message, params object[] args)
        {
            Console(catetory, LogLevel.LogError, message, args);
        }
        #endregion

        #region Console 日志输出

        static void Console(LogCategory catetory,LogLevel logLevel, string message, params object[] args)
        {
            if (!CheckLogLevel(logLevel))
            {
                return;
            }

            string msg;

            if (args != null)
            {
                msg = args.Length == 0 ? message : TextFormat.Format(message, args);
            }
            else
            {
                msg = message;
            }

            switch (catetory)
            {
                case LogCategory.Start:
                    msg = TextFormat.Format("<color=#ffa770>{0}</color>", msg);
                    break;
                case LogCategory.Proto:
                    msg = TextFormat.Format("<color=#ffa200>{0}</color>", msg);
                    break;
                case LogCategory.Event:
                    msg = TextFormat.Format("<color=#BA55D3>{0}</color>", msg);
                    break;
                case LogCategory.Resource:
                    msg = TextFormat.Format("<color=#xxc20e>{0}</color>", msg);
                    break;
                case LogCategory.Async:
                    msg = TextFormat.Format("<color=#ace44a>{0}</color>", msg);
                    break;
                case LogCategory.SysLog:
                    msg = TextFormat.Format("<color=#ffffff>{0}</color>", msg);
                    break;
                default:
                    break;
            }

            switch (logLevel)
            {
                case LogLevel.Debug:
                case LogLevel.Info:
                case LogLevel.Log:
                    UnityEngine.Debug.Log(msg);
                    break;
                case LogLevel.Warning:
                case LogLevel.LogWarning:
                    UnityEngine.Debug.LogWarning(msg);
                    break;
                case LogLevel.Error:
                case LogLevel.Fatal:
                case LogLevel.LogError:
                    UnityEngine.Debug.LogWarning(msg);
                    break;
                default:
                    UnityEngine.Debug.Log(msg);
                    break;
            }

        }

        #endregion

        #region CheckLogLevel 检查日志等级
        private static bool CheckLogLevel(LogLevel logLevel)
        {
            return true;
        }
        #endregion

        #region Write 输出日志

        /// <summary>
        /// 记录并显示日志
        /// </summary>
        /// <param name="format"></param>
        /// <param name="logCategory"></param>
        /// <param name="logLevel"></param>
        /// <param name="args"></param>
        public static void Write(LogLevel logLevel, string format, params object[] args)
        {
            Console(LogCategory.Normal, logLevel, format, args);
        }

        #endregion

    }
}
