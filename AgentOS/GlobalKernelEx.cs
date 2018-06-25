using System;
using System.Globalization;

namespace AgentOS
{
    public class GlobalKernelEx
    {
        static GlobalKernelEx()
        {
                GetTotalPhysicalMemory = WindowsMemoryEx.GetTotalPhysicalMemory;
                GetAvailablePhysicalMemory = WindowsMemoryEx.GetAvailablePhysicalMemory;
                GetTotalVirtualMemory = WindowsMemoryEx.GetTotalVirtualMemory;
                GetAvailableVirtualMemory = WindowsMemoryEx.GetAvailableVirtualMemory;
        }

        private static readonly Func<UInt64> GetTotalPhysicalMemory;
        private static readonly Func<UInt64> GetAvailablePhysicalMemory;
        private static readonly Func<UInt64> GetTotalVirtualMemory;
        private static readonly Func<UInt64> GetAvailableVirtualMemory;

        public UInt64 TotalPhysicalMemory => GetTotalPhysicalMemory.Invoke();
        public UInt64 AvailablePhysicalMemory => GetAvailablePhysicalMemory.Invoke();
        public UInt64 TotalVirtualMemory => GetTotalVirtualMemory.Invoke();
        public UInt64 AvailableVirtualMemory => GetAvailableVirtualMemory.Invoke();

        public CultureInfo InstalledUICulture => CultureInfo.InstalledUICulture;
        public String OSFullName => WindowsMemoryEx.OSFullName;
        public String OSPlatform => Environment.OSVersion.Platform.ToString();
        public String OSVersion => Environment.OSVersion.Version.ToString();

    }
}
