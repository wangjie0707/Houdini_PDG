using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBD.Editor
{

    [Serializable]
    /// <summary>
    /// 存储路径
    /// </summary>
    public class FileConfigClass
    {

        //[PropertySpace(10)]
        //[BoxGroup("参数信息")]
        //[LabelText("文件名称"), LabelWidth(120)]
        //public string SettingAssetName;

        [PropertySpace(15)]
        [BoxGroup("参数信息")]
        [LabelText("文件路径"), LabelWidth(120)]
        public PathClass[] PathList;

        public string LoadPath()
        {
            foreach (var item in PathList)
            {
                if (item.PathType == PathType.LoadPath)
                {
                    return item.Path;
                }
            }

            return null;
        }

        public string FilePath()
        {
            foreach (var item in PathList)
            {
                if (item.PathType == PathType.FilePath)
                {
                    return item.Path;
                }
            }

            return null;
        }

        public string[] SavePath()
        {
            int index = 0;

            foreach (var item in PathList)
            {
                if (item.PathType == PathType.SavePath)
                {
                    index += 1;
                }
            }

            string[] path = new string[index];

            index = 0;

            foreach (var item in PathList)
            {
                if (item.PathType == PathType.SavePath)
                {
                    path[index] = item.Path;
                    index += 1;
                }
            }

            return path;
        }

        public string GetPath(PathType pathType)
        {
            foreach (var item in PathList)
            {
                if (item.PathType == pathType)
                {
                    return item.Path;
                }
            }

            return null;
        }

        public string[] GetPaths(PathType pathType)
        {
            int index = 0;

            foreach (var item in PathList)
            {
                if (item.PathType == pathType)
                {
                    index += 1;
                }
            }

            string[] path = new string[index];

            index = 0;

            foreach (var item in PathList)
            {
                if (item.PathType == pathType)
                {
                    path[index] = item.Path;
                    index += 1;
                }
            }

            return path;
        }

        public int SavePathLength()
        {
            return SavePath().Length;
        }
    }

}
