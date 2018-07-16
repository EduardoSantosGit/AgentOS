using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using Xunit;

namespace AgentOS.Test
{
    public class OSInformationTest
    {
        [Fact]
        public void GetInfoProcessor_ReturnsDataProcessorNotNull()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoProcessor(winos);

            Assert.NotNull(result.ProcessorArchitecture);
            Assert.NotNull(result.ProcessorIden);
            Assert.NotNull(result.ProcessorLevel);
            Assert.NotNull(result.ProcessorNumber);
        }

        [Fact]
        public void GetInfoProcessor_ReturnsDataFormatString()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoProcessor(winos);

            Assert.NotEmpty(result.ProcessorArchitecture);
            Assert.NotEmpty(result.ProcessorIden);
            Assert.NotEmpty(result.ProcessorLevel);
            Assert.NotEmpty(result.ProcessorNumber);
        }

        [Fact]
        public void GetInfoMemory_ReturnDecimalLargerZero()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoMemory(winos);

            Assert.True(result.MemorySize > 0);
            Assert.True(result.MemoryAvailable > 0);
            Assert.True(result.MemoryAvailableVertual > 0);
            Assert.True(result.MemoryVirtualSize > 0);
        }

        [Fact]
        public void GetInfoDisk_ReturnDataCorrectInfoDisks()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoDisk(winos);

            var first = result.Disks.FirstOrDefault();

            var di = DriveInfo.GetDrives().Where(x => x.IsReady).ToList();

            Assert.NotNull(result.Disks);
            Assert.Equal(result.LogicalDisksCount, Directory.GetLogicalDrives().Length);
            Assert.Equal(di.Count, result.Disks.Count);
            Assert.NotNull(first.Name);
            Assert.True(first.TotalSize > 0);
            Assert.True(first.FreeSize > 0);
            Assert.NotNull(first.Format);
            Assert.NotNull(first.RootDirectory);
        }

        [Fact]
        public void GetInfoEthernet_ReturnDataCorrectInfoEthernet()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoEthernet(winos);

            var first = result.Networks.FirstOrDefault();

            Assert.True(result.ExistsConnection);
            Assert.NotNull(result.Networks);
            Assert.Equal(NetworkInterface.GetAllNetworkInterfaces().Count(), result.Networks.Count);
            Assert.NotNull(first.Name);
            Assert.NotNull(first.NetworkType);
            Assert.NotNull(first.Status);
            Assert.NotNull(first.Description);
            Assert.NotNull(first.Speed);
        }

        [Fact]
        public void GetInfoGPU_ReturnDataCorrectGetInfoGPU()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoGPU(winos);

            var first = result.GPUs.FirstOrDefault();

            Assert.NotNull(result.GPUs);
            Assert.NotNull(first.Name);
            Assert.NotNull(first.Status);
            Assert.NotNull(first.Caption);
            Assert.NotNull(first.DeviceID);
            Assert.True(first.AdapterRAM > 0);
            Assert.NotNull(first.AdapterDACType);
            Assert.NotNull(first.InstalledDisplayDrivers);
            Assert.NotNull(first.DriverVersion);
            Assert.NotNull(first.VideoProcessor);
            Assert.True(first.VideoArchitecture > 0);
            Assert.True(first.VideoMemoryType > 0);
        }

        [Fact]
        public void GetInfoOS_ReturnDataCorrectGetInfoOS()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoOS(winos);

            var first = result.OSInfos.FirstOrDefault();

            Assert.NotNull(result.OSInfos);
            Assert.NotNull(first.OperationName);
            Assert.NotNull(first.OperationArchitecture);
        }

        [Fact]
        public void GetInfoProcesses_ReturnDataCorrectGetInfoProcesses()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoProcesses(winos);

            Assert.NotNull(result.OSInfoProcesses);
            Assert.NotEmpty(result.OSInfoProcesses);

            foreach(var item in winos.OSInfoProcesses)
            {
                Assert.True(item.ProcessId > -1);
                Assert.NotNull(item.ProcessName);
                Assert.NotNull(item.Status);
            }

        }

        [Fact]
        public void GetInfoServices_ReturnDataCorrectGetInfoServices()
        {
            var winos = new WinOSInfo();
            var result = WinOSInformation.GetInfoServices(winos);

            Assert.NotNull(result);

        }

    }
}
