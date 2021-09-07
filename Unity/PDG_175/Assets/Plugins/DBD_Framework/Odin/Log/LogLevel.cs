using System;

namespace DBD
{
    /// <summary>
    /// 框架日志等级。
    /// </summary>
    [Flags]//表明选择值的集合，可做位运算
    public enum LogLevel
    {
        /// <summary>
        /// 调试。
        /// 用于调试时候的错误。
        /// </summary>
        Debug = 1 << 0,

        /// <summary>
        /// 信息。
        /// </summary>
        Info = 1 << 1,

        /// <summary>
        /// 警告。
        /// </summary>
        Warning = 1 << 2,

        /// <summary>
        /// 错误。
        /// 打印错误级别日志，建议在发生功能逻辑错误，但尚不会导致应用崩溃或异常时使用。
        /// </summary>
        Error = 1 << 3,

        /// <summary>
        /// 严重错误。
        /// 用于框架本身的错误。
        /// 打印严重错误级别日志，建议在发生严重错误，可能导致应用崩溃或异常时使用，此时应尝试重启进程或重建应用框架
        /// </summary>
        Fatal = 1 << 4,

        /// <summary>
        /// 普通日志
        /// </summary>
        Log = 1 << 5,

        /// <summary>
        /// 警告日志
        /// </summary>
        LogWarning = 1 << 6,

        /// <summary>
        /// 错误日志
        /// </summary>
        LogError = 1 << 7,

        /// <summary>
        /// 全部
        /// </summary>
        ALL = Debug | Info| Warning| Error| Fatal| Log| LogWarning| LogError
    }
}
