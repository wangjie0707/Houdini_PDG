namespace DBD
{
    /// <summary>
    /// 日志分类
    /// </summary>
    public enum LogCategory : byte
    {
        /// <summary>
        /// 普通日志
        /// </summary>
        Normal,

        /// <summary>
        /// 启动
        /// </summary>
        Start,

        /// <summary>
        /// 流程日志
        /// </summary>
        Procedure,

        /// <summary>
        /// 通信日志
        /// </summary>
        Proto,

        /// <summary>
        /// 事件日志
        /// </summary>
        Event,

        /// <summary>
        /// 资源管理
        /// </summary>
        Resource,

        /// <summary>
        /// 异步调用
        /// </summary>
        Async,

        /// <summary>
        /// Core日志
        /// </summary>
        Core,

        /// <summary>
        /// 注解日志
        /// </summary>
        Annotation,

        /// <summary>
        /// 系统日志
        /// </summary>
        SysLog,

        /// <summary>
        /// 服务端日志
        /// </summary>
        Server,

        /// <summary>
        /// 边缘服务端 验证端 (Web)日志
        /// </summary>
        Realm,

        /// <summary>
        /// 网关服务端日志
        /// </summary>
        Gate,

        /// <summary>
        /// 数据库日志
        /// </summary>
        DB

    }
}
