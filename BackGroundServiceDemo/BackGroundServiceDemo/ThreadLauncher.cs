using System;
using System.Threading;

namespace BackGroundServiceDemo
{
    public delegate void DelFunc();
    internal class RunHandle
    {
        public DelFunc del_func { get; set; }
        public int sleep_time { get; set; }
        public string thread_name { get; set; }
        internal RunHandle(DelFunc del, int time, string name)
        {
            del_func = del;
            sleep_time = time;
            thread_name = name;
        }
        public void Start()
        {
            del_func.Invoke();
        }

    }
    internal class ThreadLauncher
    {
        internal void ThreadRun(DelFunc method, int time, string name)
        {
            DelFunc del = method;
            RunHandle handle = new RunHandle(del, time, name);
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Run);
            Thread thread = new Thread(pts);
            thread.Name = name;
            thread.Start(handle);
        }

        private void Run(object obj)
        {
            RunHandle handle = (RunHandle)obj;
            while (true)
            {
                handle.Start();
                Thread.Sleep(handle.sleep_time);
            }
        }
    }
}
