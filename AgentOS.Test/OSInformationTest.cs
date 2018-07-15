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

    }
}
