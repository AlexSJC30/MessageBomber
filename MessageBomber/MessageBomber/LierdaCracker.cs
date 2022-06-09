using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageBomber
{
    public class LierdaCracker
    {
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }

        public static void Cracker(int sleepSpan = 1)
        {
            _ = Task.Factory.StartNew(delegate
            {
                while (true)
                {
                    try
                    {
                        FlushMemory();
                        Thread.Sleep(TimeSpan.FromSeconds((double)sleepSpan));
                    }
                    catch { }
                }
            });
        }

    }
}
