using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;

namespace AgentOS
{
    public class WinOSInformation
    {
        public static WinOSInfo GetOSInfo()
        {
            var winos = new WinOSInfo();

            winos = GetInfoProcessor(winos);
            winos = GetInfoMemory(winos);
            winos = GetInfoDisk(winos);
            winos = GetInfoEthernet(winos);
            winos = GetInfoGPU(winos);
            winos = GetInfoOS(winos);
            winos = GetInfoProcesses(winos);
            winos = GetInfoServices(winos);

            return winos;
        }

        public static WinOSInfo GetInfoProcessor(WinOSInfo winos)
        {
            winos.ProcessorArchitecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE",
                EnvironmentVariableTarget.Machine);
            winos.ProcessorIden = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            winos.ProcessorLevel = Environment.GetEnvironmentVariable("PROCESSOR_LEVEL");
            winos.ProcessorNumber = Environment.ProcessorCount.ToString();
            return winos;
        }



        public static WinOSInfo GetInfoMemory(WinOSInfo winos)
        {
            var memoryInfo = new GlobalKernelEx();
            winos.MemorySize = Convert.ToDecimal((memoryInfo.TotalPhysicalMemory / (1024 * 1024)) * 0.001);
            winos.MemoryAvailable = Convert.ToDecimal((memoryInfo.AvailablePhysicalMemory / (1024 * 1024)) * 0.001);
            winos.MemoryAvailableVertual = Convert.ToDecimal((memoryInfo.AvailableVirtualMemory / (1024 * 1024)) * 0.001);
            winos.MemoryVirtualSize = Convert.ToDecimal((memoryInfo.TotalVirtualMemory / (1024 * 1024)) * 0.001);
            return winos;
        }

        public static WinOSInfo GetInfoDisk(WinOSInfo winos)
        {
            winos.LogicalDisksCount = Directory.GetLogicalDrives().Length;

            var winDisks = new List<OSDisk>();

            foreach (var disk in DriveInfo.GetDrives())
            {
                if (disk.IsReady)
                {
                    var disks = new OSDisk
                    {
                        Name = disk.Name,
                        TotalSize = Math.Ceiling(disk.TotalSize / 1073741824M),
                        FreeSize = Math.Ceiling(disk.TotalFreeSpace / 1073741824M),
                        Format = disk.DriveFormat,
                        RootDirectory = disk.RootDirectory.FullName
                    };

                    winDisks.Add(disks);
                }
            }

            winos.Disks = winDisks;

            return winos;
        }

        public static WinOSInfo GetInfoEthernet(WinOSInfo winos)
        {

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                winos.ExistsConnection = false;
                return winos;
            }

            winos.ExistsConnection = true;

            var netws = new List<OSNetwork>();

            foreach(var eth in NetworkInterface.GetAllNetworkInterfaces())
            {
                var net = new OSNetwork
                {
                    Name = eth.Name,
                    NetworkType = eth.NetworkInterfaceType.ToString(),
                    Status = eth.OperationalStatus.ToString(),
                    Description = eth.Description
                };

                net.Speed = eth.Speed.ToString();

                netws.Add(net);
            }

            winos.Networks = netws;

            return winos;
        }

        public static WinOSInfo GetInfoGPU(WinOSInfo winos)
        {
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            var gpus = new List<OSGPU>();

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                var gpu = new OSGPU
                {
                    Name = obj["Name"].ToString(),
                    Status = obj["Status"].ToString(),
                    Caption = obj["Caption"].ToString(),
                    DeviceID = obj["DeviceID"].ToString(),
                    AdapterRAM = Convert.ToDecimal(obj["AdapterRAM"]),
                    AdapterDACType = obj["AdapterDACType"].ToString(),
                    Monochrome = Convert.ToBoolean(obj["Monochrome"]),
                    InstalledDisplayDrivers = obj["InstalledDisplayDrivers"].ToString(),
                    DriverVersion = obj["DriverVersion"].ToString(),
                    VideoProcessor = obj["VideoProcessor"].ToString(),
                    VideoArchitecture = Convert.ToInt64(obj["VideoArchitecture"]),
                    VideoMemoryType = Convert.ToInt64(obj["VideoMemoryType"])
                };
                gpus.Add(gpu);
            }

            winos.GPUs = gpus;

            return winos;
        }

        public static WinOSInfo GetInfoOS(WinOSInfo winos)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            if (mos.Get().Count <= 0)
                return winos;

            var listOS = new List<OSInfo>();

            foreach (ManagementObject managementObject in mos.Get())
            {

                var osInfo = new OSInfo();

                if (managementObject["Caption"] != null)
                    osInfo.OperationName = managementObject["Caption"].ToString();

                if (managementObject["OSArchitecture"] != null)
                    osInfo.OperationArchitecture =  managementObject["OSArchitecture"].ToString();

                if (managementObject["CSDVersion"] != null)
                    osInfo.OperationVersion = managementObject["CSDVersion"].ToString();

                listOS.Add(osInfo);
            }

            winos.OSInfos = listOS;

            return winos;
        }

        public static WinOSInfo GetInfoProcesses(WinOSInfo winos)
        {
            var listPro = new List<OSInfoProcesses>();

            foreach (var process in Process.GetProcesses())
            {
                var pro = new OSInfoProcesses
                {
                    ProcessId = process.Id,
                    ProcessName = process.ProcessName,
                    Status = (process.Responding == true) ? "OK" : "Stopped"
                };

                listPro.Add(pro);
            }

            winos.OSInfoProcesses = listPro;
            return winos;
        }

        public static WinOSInfo GetInfoServices(WinOSInfo winos)
        {
            var services = ServiceController.GetServices();

            foreach (var item in services)
            {
                var name = item.DisplayName;
                var status = item.Status;
            }

            return winos;
        }


    }
}
