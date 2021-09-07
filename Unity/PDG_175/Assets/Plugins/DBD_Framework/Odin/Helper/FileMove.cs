#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 项目名称 ：Assets.Scripts.Editor.ToolKit.AssetBundle.AssetBundleFile
* 项目描述 ：
* 类 名 称 ：AssetBundleFileMove
* 类 描 述 ：
* 所在的域 ：DESKTOP-MCIGEP7
* 命名空间 ：Assets.Scripts.Editor.ToolKit.AssetBundle.AssetBundleFile
* CLR 版本 ：4.0.30319.42000
* 作    者 ：WangJie0707
* 创建时间 ：2020/11/15 21:10:54
* 更新时间 ：2020/11/15 21:10:54
* 版 本 号 ：v1.0.0.0
*******************************************************************
* Copyright @ 13644 2020. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion

using System;
using System.IO;

namespace DBD
{
    public static class FileMove
    {

        public static void copyFiles(string path, string aimPath)
        {
            String[] files = Directory.GetFileSystemEntries(path);

            foreach (string element in files)
            {
                try
                {
                    //如果是文件夹，循环
                    if (Directory.Exists(element))
                    {
                        string aimdir = System.IO.Path.Combine(aimPath, Path.GetFileName(element));

                        if (!System.IO.Directory.Exists(aimdir))
                        {
                            System.IO.Directory.CreateDirectory(aimdir);
                        }
                        copyFiles(element, aimdir);
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(aimPath))
                        {
                            System.IO.Directory.CreateDirectory(aimPath);
                        }
                        string srcdir = System.IO.Path.Combine(aimPath, Path.GetFileName(element));
                        File.Copy(element, srcdir, true);
                    }
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.Log("无法复制" + e.ToString());
                }
            }
        }


        public static void copyDir(string srcPath, string aimPath)
        {
            try
            {
                //如果不存在目标路径，则创建之

                if (!System.IO.Directory.Exists(aimPath))
                {
                    System.IO.Directory.CreateDirectory(aimPath);
                }
                //令目标路径为aimPath\srcPath
                string srcdir = System.IO.Path.Combine(aimPath, System.IO.Path.GetFileName(srcPath));
                //如果源路径是文件夹，则令目标目录为aimPath\srcPath\
                if (Directory.Exists(srcPath))
                    srcdir += Path.DirectorySeparatorChar;
                // 如果目标路径不存在,则创建目标路径
                if (!System.IO.Directory.Exists(srcdir))
                {
                    System.IO.Directory.CreateDirectory(srcdir);
                }
                //获取源文件下所有的文件
                String[] files = Directory.GetFileSystemEntries(srcPath);
                foreach (string element in files)
                {
                    //如果是文件夹，循环
                    if (Directory.Exists(element))
                        copyDir(element, srcdir);
                    else
                    {
                        if (element.Contains("asmdef"))
                        {

                        }
                        else
                        {
                            File.Copy(element, srcdir + Path.GetFileName(element), true);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log("无法复制" + e.ToString());
            }
        }

        public static void DeleteDir(string file)
        {
            try
            {
                //去除文件夹和子文件的只读属性
                //去除文件夹的只读属性
                System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
                fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;

                //去除文件的只读属性
                System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);

                bool outer = false;

                //判断文件夹是否还存在
                if (Directory.Exists(file))
                {
                    foreach (string f in Directory.GetFileSystemEntries(file))
                    {
                        if (File.Exists(f))
                        {
                            //web.config 在最外面一层,所以不会被删除
                            if (!f.Contains("web.config"))
                            {
                                //如果有子文件删除文件
                                File.Delete(f);
                                Console.WriteLine(f);
                            }
                            else
                            {
                                outer = true;
                            }
                        }
                        else
                        {
                            //循环递归删除子文件夹
                            DeleteDir(f);
                        }
                    }

                    //最外层的文件夹不删除
                    if (!outer)
                    {
                        //删除空文件夹
                        Directory.Delete(file);
                        Console.WriteLine(file);
                    }
                }

            }
            catch (Exception ex) // 异常处理
            {
                Console.WriteLine(ex.Message.ToString());// 异常信息
            }
        }


    }
}
