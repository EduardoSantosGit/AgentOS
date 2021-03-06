﻿using System;
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
        public List<OSDisk> Disks { get; set; }
        public bool ExistsConnection { get; set; }
        public List<OSNetwork> Networks { get; set; }
        public List<OSGPU> GPUs { get; set; }
        public List<OSInfo> OSInfos { get; set; }
        public List<OSInfoProcesses> OSInfoProcesses { get; set; }
        public List<OSInfoServices> OSInfoServices { get; set; }

    }

    public class OSDisk
    {
        public string Name { get; set; }
        public decimal TotalSize { get; set; }
        public decimal FreeSize { get; set; }
        public string Format { get; set; }
        public string RootDirectory { get; set; }
    }

    public class OSNetwork
    {
        public string Name { get; set; }
        public string Speed { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string NetworkType { get; set; }
    }

    public class OSGPU
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Caption { get; set; }
        public string DeviceID { get; set; }
        public decimal AdapterRAM { get; set; }
        public string AdapterDACType { get; set; }
        public bool Monochrome { get; set; }
        public string InstalledDisplayDrivers { get; set; }
        public string DriverVersion { get; set; }
        public string VideoProcessor { get; set; }
        public long VideoArchitecture { get; set; }
        public long VideoMemoryType { get; set; }

    }

    public class OSInfo
    {
        public string OperationName { get; set; }
        public string OperationArchitecture { get; set; }
        public string OperationVersion { get; set; }
    }

    public class OSInfoProcesses
    {
        public int ProcessId { get; set; }
        public string ProcessName { get; set; }
        public string Status { get; set; }
    }

    public class OSInfoServices
    {
        public string Name { get; set; }
        public string StartType { get; set; }
        public string ServicesType { get; set; }
        public string ServiceName { get; set; }
        public string Status { get; set; }




    }
}
