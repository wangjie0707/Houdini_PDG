//using System;
//using System.IO;
//using ProtoBuf;

//namespace DBD
//{
//    /// <summary>
//    /// ProtoBuf-Net扩展方法类
//    /// </summary>
//    public static class ProtoBufHelper
//    {
//        static ProtoBufHelper()
//        {
//            //TODO 预热在老版本的pb是不支持的


//        }

//        public static void Init()
//        {
//        }

//        public static object FromBytes(Type type, byte[] bytes, int index, int count)
//        {
//            using (MemoryStream stream = new MemoryStream(bytes, index, count))
//            {
//                return ProtoBuf.Serializer.Deserialize(type, stream);
//            }
//        }

//        public static byte[] ToBytes(object message)
//        {
//            using (MemoryStream stream = new MemoryStream())
//            {
//                ProtoBuf.Serializer.Serialize(stream, message);
//                return stream.ToArray();
//            }
//        }

//        public static void ToStream(object message, MemoryStream stream)
//        {
//            ProtoBuf.Serializer.Serialize(stream, message);
//        }

//        public static object FromStream(Type type, MemoryStream stream)
//        {
//            return ProtoBuf.Serializer.Deserialize(type, stream);
//        }

//        /// <summary>
//        /// 将对象实例序列化为字符串（Base64编码格式）——ProtoBuf
//        /// </summary>
//        /// <typeparam name="T">对象类型</typeparam>
//        /// <param name="obj">对象实例</param>
//        /// <returns>字符串（Base64编码格式）</returns>
//        public static string SerializeToString<T>(this T obj)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                ProtoBuf.Serializer.Serialize(ms, obj);
//                return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
//            }
//        }

//        /// <summary>
//        /// 将字符串（Base64编码格式）反序列化为对象实例——ProtoBuf
//        /// </summary>
//        /// <typeparam name="T">对象类型</typeparam>
//        /// <param name="txt">字符串（Base64编码格式）</param>
//        /// <returns>对象实例</returns>
//        public static T DeserializeFromString<T>(this string txt)
//        {
//            byte[] arr = Convert.FromBase64String(txt);
//            using (MemoryStream ms = new MemoryStream(arr))
//                return ProtoBuf.Serializer.Deserialize<T>(ms);
//        }

//        /// <summary>
//        /// 将对象实例序列化为字节数组——ProtoBuf
//        /// </summary>
//        /// <typeparam name="T">对象类型</typeparam>
//        /// <param name="obj">对象实例</param>
//        /// <returns>字节数组</returns>
//        public static byte[] SerializeToByteAry<T>(this T obj)
//        {
//            using (MemoryStream ms = new MemoryStream())
//            {
//                ProtoBuf.Serializer.Serialize(ms, obj);
//                return ms.ToArray();
//            }
//        }

//        /// <summary>
//        /// 将字节数组反序列化为对象实例——ProtoBuf
//        /// </summary>
//        /// <typeparam name="T">对象类型</typeparam>
//        /// <param name="arr">字节数组</param>
//        /// <returns></returns>
//        public static T DeserializeFromByteAry<T>(this byte[] arr)
//        {
//            using (MemoryStream ms = new MemoryStream(arr))
//                return ProtoBuf.Serializer.Deserialize<T>(ms);
//        }

//        /// <summary>
//        /// 将对象实例序列化为二进制文件——ProtoBuf
//        /// </summary>
//        /// <typeparam name="T">对象类型</typeparam>
//        /// <param name="obj">对象实例</param>
//        /// <param name="path">文件路径（目录+文件名）</param>
//        public static void SerializeToFile<T>(this T obj, string path)
//        {
//            using (var file = File.Create(path))
//            {
//                ProtoBuf.Serializer.Serialize(file, obj);
//            }
//        }

//        /// <summary>
//        /// 将二进制文件反序列化为对象实例——ProtoBuf
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static T DeserializeFromFile<T>(this string path)
//        {
//            using (var file = File.OpenRead(path))
//            {
//                return ProtoBuf.Serializer.Deserialize<T>(file);
//            }
//        }
//    }
//}