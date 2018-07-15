using AgentOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgentOS.Test
{
    public class WindowsServiceTests
    {
        [Fact]
        public void GetDataServer_ReturnsDataComputerStatus()
        {
            var service = new WindowsService(null, null);
            var data = service.GetDataServer();

            Assert.NotNull(data);
        }

    }
}
