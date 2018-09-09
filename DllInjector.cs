using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Aka GijSoft.DllInjection
/// By: evolution536<
/// Thread: https://www.unknowncheats.me/forum/c/82629-basic-c-dll-injector.html
/// </summary>
/// 




namespace UnityLoader // Got the project from github it was a web based loader 
{
    //GIthub works?
    public enum DllInjectionResult
    {
        DllNotFound,
        GameProcessNotFound,
        InjectionFailed,
        Success
    }

 
    public sealed class DllInjector
    {
        static readonly IntPtr INTPTR_ZERO = (IntPtr)0;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, Int32 dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);



        static DllInjector _instance;

        public static DllInjector GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DllInjector();
                }
                return _instance;
            }
        }

        DllInjector() { }
        public delegate void dlgProgress(int value);
        public event dlgProgress Progress;
        public DllInjectionResult Inject(string sProcName, string sDllPath)
        {

            if (!File.Exists(sDllPath))
            {
                XHOOKACCESS.dllstatus = ("Error XL:1"); // just for debugging
                return DllInjectionResult.DllNotFound;
            }

            uint _procId = 0;

            Process[] _procs = Process.GetProcesses();
            for (int i = 0; i < _procs.Length; i++)
            {
                if (_procs[i].ProcessName == sProcName)
                {
                    _procId = (uint)_procs[i].Id;
                    XHOOKACCESS.dllstatus = ("we found process:" + sProcName + " at  " + _procId);
                    break;
                }
            }


            if (_procId == 0)
            {
                XHOOKACCESS.dllstatus = ("We cant find process: " + sProcName);
                return DllInjectionResult.GameProcessNotFound;
            }

            if (!bInject(_procId, sDllPath))
            {
                XHOOKACCESS.dllstatus = ("Injection Failed!");
                return DllInjectionResult.InjectionFailed;
            }
             
            return DllInjectionResult.Success;
        }

        bool bInject(uint pToBeInjected, string sDllPath)
        {
            IntPtr hndProc = OpenProcess((0x2 | 0x8 | 0x10 | 0x20 | 0x400), 1, pToBeInjected);

            if (hndProc == INTPTR_ZERO)
            {
                return false;
            }

            IntPtr lpLLAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            if (lpLLAddress == INTPTR_ZERO)
            {
                return false;
            }

            IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)sDllPath.Length, (0x1000 | 0x2000), 0X40);

            if (lpAddress == INTPTR_ZERO)
            {
                return false;
            }

            byte[] bytes = Encoding.ASCII.GetBytes(sDllPath);

            if (WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
            {
                return false;
            }

            if (CreateRemoteThread(hndProc, (IntPtr)null, INTPTR_ZERO, lpLLAddress, lpAddress, 0, (IntPtr)null) == INTPTR_ZERO)
            {
                return false;
            }
   
            CloseHandle(hndProc);

            return true;
        }

    }
}
