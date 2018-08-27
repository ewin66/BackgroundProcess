using System;
using System.IO;

namespace BackGroundServiceDemo
{
    internal class Log
    {
        /// <summary>
        /// 写Log(重载)
        /// </summary>
        /// <param name="name">文件名</param>
        /// <param name="msg">异常信息</param>
        /// <param name="title">标题</param>
        public static void WriteLog(string name, string msg, string title)
        {
            DateTime date = DateTime.Now;
            string path = @"E:\Log\" + name + ".txt";
            msg = "[" + date.ToLongTimeString() + "]" + "[" + title + "]  " + msg + "\r\n";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            File.AppendAllText(path, msg);

        }

        /// <summary>
        /// 写Log(重载)
        /// </summary>
        /// <param name="msg">异常信息</param>
        /// <param name="title">标题</param>
        public static void WriteLog(string msg, string title)
        {
            DateTime date = DateTime.Now;
            string path = @"E:\Log\" + date.Year + "_" + date.Month.ToString().PadLeft(2, '0') + "_" + date.Day + ".txt";
            msg = "[" + date.ToLongTimeString() + "]" + "[" + title + "]  " + msg + "\r\n";
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            File.AppendAllText(path, msg);

        }
    }
}
