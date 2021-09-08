using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

namespace DBD.Editor
{
    //[CreateAssetMenu]
    public class ReopenProject_Setting : ScriptableObject

    {
        [PropertySpace(10)]
        [BoxGroup("ReopenProject Settings")]
        [LabelText("编辑控制"), LabelWidth(80)]
        public bool IsCanEditor;

        [EnableIf("IsCanEditor")]
        [PropertySpace(10)]
        //[HorizontalGroup]
        [Button(ButtonSizes.Gigantic, ButtonStyle.Box), GUIColor(0.6075472f, 1f, 0.976f)]
        [LabelText("重启项目")]
        public void ExcuteReopenProject()
        {
            EditorApplication.OpenProject(Application.dataPath.Replace("Assets", string.Empty));
        }

        [EnableIf("IsCanEditor")]
        [PropertySpace(10)]
        //[HorizontalGroup]
        [Button(ButtonSizes.Gigantic, ButtonStyle.Box), GUIColor(0.6075472f, 1f, 0.976f)]
        [LabelText("刷新调整文件")]
        public void AssetDatabaseRefresh()
        {
            AssetDatabase.Refresh();
        }

        [EnableIf("IsCanEditor")]
        [PropertySpace(10)]
        //[HorizontalGroup]
        [Button(ButtonSizes.Gigantic, ButtonStyle.Box), GUIColor(0.6075472f, 1f, 0.976f)]
        [LabelText("重新编译")]
        public void Recompire()
        {
            CompilationPipeline.RequestScriptCompilation();
            AssetDatabase.Refresh();
        }
    }
}
