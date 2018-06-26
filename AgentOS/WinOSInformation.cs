﻿using System;
using System.Collections.Generic;
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

            return winos;
        }

        private static WinOSInfo GetInfoProcessor(WinOSInfo winos)
        {
            winos.ProcessorArchitecture = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE",
                EnvironmentVariableTarget.Machine);
            winos.ProcessorIden = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
            winos.ProcessorLevel = Environment.GetEnvironmentVariable("PROCESSOR_LEVEL");
            winos.ProcessorNumber = Environment.ProcessorCount.ToString();
            return winos;
        }

        

        private static WinOSInfo GetInfoMemory(WinOSInfo winos)
        {
            var memoryInfo = new GlobalKernelEx();
            winos.MemorySize = Convert.ToDecimal((memoryInfo.TotalPhysicalMemory / (1024 * 1024)) * 0.001);
            winos.MemoryAvailable = Convert.ToDecimal((memoryInfo.AvailablePhysicalMemory / (1024 * 1024)) * 0.001);
            winos.MemoryAvailableVertual = Convert.ToDecimal((memoryInfo.AvailableVirtualMemory / (1024 * 1024)) * 0.001);
            winos.MemoryVirtualSize = Convert.ToDecimal((memoryInfo.TotalVirtualMemory / (1024 * 1024)) * 0.001);
            return winos;
        }



    }
}
