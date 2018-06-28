using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentOS
{
    public class WinOSInfo
    {
        public string ProcessorArchitecture { get; set; }
        public string ProcessorNumber { get; set; }
        public string ProcessorIden { get; set; }
        public string ProcessorLevel { get; set; }
        public decimal MemorySize { get; set; }
        public decimal MemoryAvailable { get; set; }
        public decimal MemoryAvailableVertual { get; set; }
        public decimal MemoryVirtualSize { get; set; }
        public int LogicalDisksCount { get; set; }
        public List<WinOSDisk> Disks { get; set; }
        public string UserName { get; set; }
        public string WinDir { get; set; }
    }

    public class WinOSDisk
    {
        public string Name { get; set; }
        public decimal TotalSize { get; set; }
        public decimal FreeSize { get; set; }
        public string Format { get; set; }
    }

}
