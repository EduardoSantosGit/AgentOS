using System;
using Xunit;

namespace AgentOS.Test
{
    public class OSInformationTest
    {
        [Fact]
        public void Test1()
        {
            var r = WinOSInformation.GetOSInfo();

            Assert.NotNull(r);
        }
    }
}
