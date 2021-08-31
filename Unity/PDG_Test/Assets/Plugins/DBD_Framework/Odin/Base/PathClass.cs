using DBD;
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
    public class PathClass
    {
        [LabelWidth(1)]
        [HorizontalGroup("Split", 0.2f)]
        public PathType PathType;

        [LabelWidth(1)]
        [FolderPath]
        [HorizontalGroup("Split", 0.79f)]
        //[FolderPath(ParentFolder = "Assets")]
        public string Path;

        public bool CheckPath()
        {
            if (string.IsNullOrEmpty(Path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
