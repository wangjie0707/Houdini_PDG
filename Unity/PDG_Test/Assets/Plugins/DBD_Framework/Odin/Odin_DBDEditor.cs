using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Sirenix.Utilities;
using UnityEngine;


namespace DBD.Editor
{
    public class Odin_DBDEditor : OdinMenuEditorWindow
    {
        [MenuItem("Tools/DBDEditor")]
        private static void OpenYouYouEditor()
        {
            var window = GetWindow<Odin_DBDEditor>();
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(1000, 700);
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree(true);

            //客户端应用文件
            tree.AddAssetAtPath("File Move", "Plugins/DBD_Framework/Odin/AssetMenu/FileMove_Setting.asset").AddIcon(EditorIcons.AlertCircle);

            tree.AddAssetAtPath("ReopenProject", "Plugins/DBD_Framework/Odin/AssetMenu/ReopenProject_Setting.asset").AddIcon(EditorIcons.Refresh);

            return tree;
        }
    }
}

