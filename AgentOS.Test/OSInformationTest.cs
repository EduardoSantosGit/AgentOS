using System;
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





    }
}
