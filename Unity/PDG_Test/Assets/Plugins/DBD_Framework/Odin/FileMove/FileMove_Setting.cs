using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEditor;
using UnityEngine;

namespace DBD.Editor
{
    //[CreateAssetMenu]
    public class FileMove_Setting : ScriptableObject
    {
        [PropertySpace(10)]
        [BoxGroup("FileMove Settings")]
        [LabelText("编辑控制"), LabelWidth(80)]
        public bool IsCanEditor;

        [EnableIf("IsCanEditor")]
        [PropertySpace(10)]
        [LabelText("存取设置")]
        [BoxGroup("FileMove Settings")]
        public FileConfigClass FileConfig;

        [EnableIf("IsCanEditor")]
        [PropertySpace(10)]
        [HorizontalGroup]
        [EnableIf("@this.FileConfig != null && this.FileConfig.LoadPath() != string.Empty")]
        [Button(ButtonSizes.Medium, ButtonStyle.Box), GUIColor(0.6075472f, 1f, 0.976f)]
        [LabelText("加载配置文件信息")]
        public void LoadConfigSetting()
        {
            string loadPath = $"{Directory.GetCurrentDirectory()}/{FileConfig.LoadPath()}";
            string savePath = $"{Directory.GetCurrentDirectory()}/{FileConfig.GetPath(PathType.SavePath)}";

            Log.Info("loadPath" + loadPath);
            Log.Info("savePath" + savePath);

            FileMove.copyDir(loadPath, savePath);


            AssetDatabase.Refresh();
        }

    }
}
