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

    }
}
