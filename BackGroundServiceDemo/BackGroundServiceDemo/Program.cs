using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace BackGroundServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Process Current = Process.GetCurrentProcess();
            Process[] All = Process.GetProcesses();
            foreach (Process p in All)
            {
                if (p.ProcessName == Current.ProcessName && p.Id != Current.Id)
                {
                    MessageBox.Show("The Process is running", "Watch out");
                    return;
                }
            }
            //启动后台线程，无线循环执行CheckAmProduct方法，时间间隔5秒，线程名"CheckAmProduct"
            ThreadLauncher thread = new ThreadLauncher();
            thread.ThreadRun(Function.CheckAmProduct, 5000, "CheckAmProduct");
        }
    }
}
