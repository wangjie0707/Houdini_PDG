using System;

namespace DBD.Editor
{

    [Flags]
    public enum PathType
    {
        /// <summary>
        /// 读取路径
        /// </summary>
        LoadPath = 1 << 0,
        /// <summary>
        /// 保存路径
        /// </summary>
        SavePath = 1 << 1,
        /// <summary>
        /// 远程路径
        /// </summary>
        RemotePath = 1 << 2,
        /// <summary>
        /// 外部文件路径
        /// </summary>
        FilePath = 1 << 3,
        /// <summary>
        /// 服务端热更文件路径
        /// </summary>
        Server = 1 << 4,
        /// <summary>
        /// AssetBundle
        /// </summary>
        AssetBundle = 1 << 5,
        /// <summary>
        /// 实体层本地路径
        /// </summary>
        Runtime = 1 << 6,
        /// <summary>
        /// 热更层本地路径
        /// </summary>
        Hotfix = 1 << 7,
        /// <summary>
        /// 数据表模板路径
        /// </summary>
        TempLate = 1 << 8,
        /// <summary>
        /// Resources 文件路径
        /// </summary>
        Resources = 1 << 9,
        /// <summary>
        /// 读写区域
        /// </summary>
        Persistent = 1 << 10,
        /// <summary>
        /// AB Packed路径
        /// </summary>
        ABPacked = 1 << 11,
        /// <summary>
        /// 多语言
        /// </summary>
        Language = 1 << 12
    }
}
